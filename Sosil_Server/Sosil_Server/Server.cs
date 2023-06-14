using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sosil_Server
{
    public partial class Server : Form
    {
        private const int PORT = 8000;
        private bool serverstat;                        //서버 플래그
        private TcpListener listener;           
        private Task taskGetClient;                     //새로운 클라이언트 접속 스레드
        private Dictionary<string, Client> clientList;  //클라이언트 목록

        private int second = 0; //서버 실행 시간

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            clientList = new Dictionary<string, Client>();
            LoadClients();
            LoadSchedule();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "서버 시작")
            {
                btnStart.Text = "서버 종료";
                btnStart.ForeColor = Color.Red;

                timer1.Enabled = true;
                serverstat = true;
                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();

                //AcceptClient 시작
                taskGetClient = new Task(() => AcceptClient());
                taskGetClient.Start();

                AddLog("서버 시작...");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            lblStartTime.Text = second.ToString();
            lblTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        async private void AcceptClient()
        {
            while(serverstat)
            {
                TcpClient newClient = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                NetworkStream ns = newClient.GetStream();
                StreamReader reader = new StreamReader(ns);
                StreamWriter writer = new StreamWriter(ns);

                string buf = reader.ReadLine();

                if(buf != null) {
                    string[] query = StringTokenizer(buf);

                    if (query[0] == "SignUp")// 회원가입. SIgnUp$아이디$비밀번호$닉네임
                    {
                        AddLog("SignUp 시도>>>");
                        Task.Factory.StartNew(() => HandleSignUp(newClient, ns, query));
                    }
                    else if (query[0] == "Login")// 로그인. Login$아이디$비밀번호
                    {
                        AddLog("Login 시도>>>");

                        if (!clientList.ContainsKey(query[1]))
                        {
                            AddLog("존재하지 않는 아이디");
                            writer.WriteLine("존재하지 않는 아이디입니다.");
                        }
                        else if (!clientList[query[1]].Password.Equals(query[2]))
                        {
                            AddLog("비밀번호 틀림: " + query[2] + ", real: " + clientList[query[1]].Password);
                            writer.WriteLine("비밀번호가 틀렷습니다.");
                        }
                        else if (clientList[query[1]].IsConnected == true)
                        {
                            AddLog("이미 로그인");
                            writer.WriteLine("이미 로그인 되었습니다.");
                        }
                        else
                        {
                            clientList[query[1]].Set(newClient, ns, reader, writer);
                            AddLog(query[1] + " is Connected");

                            //callback 메세지
                            writer.WriteLine("로그인 성공");
                            writer.Flush();

                            //Receive Task 시작
                            clientList[query[1]].ReceiveTask = new Task(() => Receive(query[1]));
                            clientList[query[1]].ReceiveTask.Start();

                            // 친구 목록 & 일정 전송
                            SendFriendsList(query[1]);
                            SendSchedule(query[1]);
                            AddLog("친구 목록 전송...");
                        }
                        writer.Flush();
                    }
                    else
                    {
                        AddLog("잘못된 쿼리문...");
                    }
                }//if end
            }//while end
        }

        public void Receive(string id)  // 각 클라이언트별로 하나씩 Task 존재해야함
        {                               // 클라이언트로부터 받은 쿼리문 처리
            try
            {
                while(clientList[id].IsConnected == true)
                {
                    string str = clientList[id].reader.ReadLine();
                    AddLog(id + " -> " + str);
                    string[] query = StringTokenizer(str);

                    if(query[0] == "Logout")    // Logout$ ID
                    {
                        break;
                    }
                    else if(query[0] == "Send") // Send$ Sender$ Receiver$ msg
                    {
                        HandleMessage(query);
                    }
                    else if(query[0] == "Friends") // Friends$ ID
                    {
                        string state;
                        if (clientList.ContainsKey(query[1]))
                        {
                            clientList[id].friends.Add(query[1]);
                            AddLog(id + " 친구추가 : " + query[1]);
                            state = "true";
                        }
                        else
                            state = "false";
                        Send(id, "Friends$" + state + "$" + query[1]);
                    }
                    else if(query[0] == "Schedule") // Schedule$ mode$ ~
                    {
                        HandleSchedule(id, query);
                    }
                    else if(query[0] == "Request") // Request$ msg
                    {
                        string re = "Send$Server$" + id + "$[알람]" + query[1];
                        Send(id, re);
                    }
                }


            }
            catch (Exception ex)
            {
                AddLog(id + ">> Error!");
                AddLog(ex.ToString());
                clientList[id].IsConnected = false;
            }

            Disconnect(id);
        }

        public void Disconnect(string id)
        {

            clientList[id].IsConnected = false;
            clientList[id].Dispose();

            AddLog(id + " is Disconnected !!");
        }

        public void SendFriendsList(string id)
        {
            string query = "Friends";
            for(int i=0; i<clientList[id].friends.Count; i++)
            {
                query += "$" + clientList[id].friends[i];
            }

            Send(id, query);
        }

        public void SendSchedule(string id)
        {
            if (clientList[id].schedule.Count == 0)
                return;

            string query = "Schedule";
            foreach(string s in clientList[id].schedule)
            {
                query += "$" + s;
            }
            Send(id, query);
        }




        

        public void HandleSignUp(TcpClient tc, NetworkStream ns, string[] query)
        {
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            //query[0] = "SignUp"
            string id = query[1];
            string password = query[2];
            string name = query[3].Split('\n')[0];
            name = name.Substring(0, name.Length - 1);

            if(clientList.ContainsKey(id))  //중복되는 아이디일경우
            {
                AddLog("중복되는 아이디>>" + id);
                writer.WriteLine("중복되는 아이디!");
                writer.Flush();
            }
            else    // 회원가입 성공시
            {
                clientList.Add(id, new Client(password, name));
                lsbClients.Items.Add(id);
                writer.WriteLine("Success");
                writer.Flush();
                AddLog("신규회원가입 ID: " + id);
            }

            reader.Close();
            writer.Close();
            ns.Close();
            tc.Close();
        }



        public void HandleMessage(string[] query) // 메시지 전송 처리
        {   // 0. Send
            // 1. 보내는 아이디, 2. 수신자 아이디, 3. 메시지 내용 으로 분할
            string sender = query[1];
            string receiver = query[2];
            string message = query[3];

            // 1. 서버에 메시지 전송
            if (receiver == "Server")
            {
                AddLog("[" + sender + "]: " + message);
            }
            // 2. 등록되지 않은 사용자거나 접속중이지 않을경우
            else if (clientList.ContainsKey( receiver ) == false || clientList[ receiver ].IsConnected == false)
            {
                AddLog("Wrong Message! From : " + sender);
                //Sender의 Receiver채팅창에 에러메세지 출력하도록 메시지 전송
                string errorMessage = "Send$" + receiver + "$" + sender + "$[Server]Failed to send Message!";
                Send(sender, errorMessage);
            }
            // 3. 등록된 Receiver 가 Connected 일 경우. 메세지 전송
            else
            {
                //receiver 에게 메시지 원형 보냄
                string str = string.Join("$", query);
                AddLog(str);
                Send(receiver, str);
                //Log등록
                AddLog(sender + "->" + receiver + " : " + message);
            }
        }

        public void HandleSchedule(string id, string[] query)
        {   // Schedule$ mode$ time$ contents
            if (query[1] == "Add")
            {
                string str = query[3] + "$" + query[4];
                clientList[id].schedule.Add(str);
                AddLog(id + " schedule added");
            }
            else    // mode == "Delete"
            {   // Schedule$ mode$ index
                clientList[id].schedule.RemoveAt(Int32.Parse(query[2]));
                AddLog(id + " schedule deleted");
            }
        }

        #region 디버깅 아니면 기본메소드
        public void Send(string receiver, string query)
        {
            try
            {
                clientList[receiver].writer.WriteLine(query);
                clientList[receiver].writer.Flush();
            }
            catch
            {
                AddLog("메세지 전송 오류");
            }
        }
        public string[] StringTokenizer(string str)
        {
            return str.Split('$');
        }

        public void AddLog(string str)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                txtLog.AppendText(str + "\r\n");
                txtLog.Focus();
                txtLog.ScrollToCaret();
            }));
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            AddLog("등록된 ID>>");
            foreach(string s in clientList.Keys)
            {
                AddLog("ID : " + s + ", PW : " + clientList[s].Password + ", 친구수 : " + clientList[s].friends.Count + ", 연결상태: " +clientList[s].IsConnected);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            string client = lsbClients.SelectedItem.ToString();
            string query = "Send$Server$" + client + "$" + txtSend.Text;
            Send(client, query);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter file = new StreamWriter("clients.txt", false))
            {
                foreach (var entry in clientList)   // id, pw, name, friends[] 
                    file.Write("{0}${1}\n", entry.Key, entry.Value.ToString());
                
                AddLog("클라이언트 목록 저장 완료");
            }

            foreach (string id in clientList.Keys)
            {
                string filename = id + ".txt";
                using (StreamWriter file = new StreamWriter(filename, false))
                {
                    foreach (string schedule in clientList[id].schedule)
                        file.Write("{0}\n", schedule);
                    
                }
            }
        }
       

        public void LoadClients()
        {
            AddLog("클라이언트 목록 불러오는중...");
            try
            {
                StreamReader file = new StreamReader("clients.txt");
                string[] query = file.ReadToEnd().Split('\n');
                for (int i = 0; i < query.Length - 1; i++)
                {// id$ password$ name$ friends[]
                    string[] token = StringTokenizer(query[i]);
                    clientList.Add(token[0], new Client(token[1], token[2]));
                    lsbClients.Items.Add(token[0]);

                    for (int j = 3; j < token.Length; j++)
                        clientList[token[0]].friends.Add(token[j]);
                }

                file.Close();
            }
            catch (Exception ex) 
            {
                AddLog("Error!>>>\n" + ex.ToString());
            }
            AddLog("클라이언트 목록 불러옴");
        }

        public void LoadSchedule()
        {
            AddLog("일정 불러오는중...");
            foreach(string id in clientList.Keys)
            {
                try
                {
                    using (StreamReader file = new StreamReader(id + ".txt"))
                    {
                        string[] schedules = file.ReadToEnd().Split('\n');
                        for (int i = 0; i < schedules.Length - 1; i++)
                            clientList[id].schedule.Add(schedules[i]);
                    }
                }
                catch { continue; } // 저장된 일정이 없을경우
            }
            AddLog("일정 불러옴");
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            foreach(string id in clientList.Keys)
            {
                if (clientList[id].schedule.Count == 0)
                    continue;
                AddLog(id + "의 일정>>>\n");
                foreach (string schedule in clientList[id].schedule)
                    AddLog(schedule);
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnSave.PerformClick();
        }

        
    }
}
