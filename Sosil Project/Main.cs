using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sosil_Project //# = 아직 구현 안한부분. 구현 방법 설명
{
    public partial class Main : Form
    {
        private string id;
        private string name;
        private int time;

        public TcpClient client;
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;
        public bool closeFlag = false;

        public Dictionary<string, ChatRoom> Rooms;

        public string ID {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name {
            get { return name; }
            set { this.name = value; }
        }

        public Main()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Main_Load(object sender, EventArgs e)  // Main() 에서 lblID.Text = id 하면 변경 안되고 Load 에서 변경하면 됨
        {
            setupClient();

            lsvFriends.Dock = DockStyle.Fill;
            panelFriends.Dock = DockStyle.Fill;
            panelSetting.Dock = DockStyle.Fill;
            panelSchedule.Dock = DockStyle.Fill;

            // 친구목록 읽어옴. friends[0] = "Friends"
            string[] friends = StringTokenizer( reader.ReadLine() );
            for (int i = 0; i < friends.Length - 1; i++)
            {
                ListViewItem item = new ListViewItem(friends[i + 1], lsvFriends.Groups[1]);
                lsvFriends.Items.Add(item);
                Rooms.Add(friends[i + 1], new ChatRoom(id, friends[i + 1], reader, writer));
            }
            foreach(ChatRoom chatRoom in Rooms.Values)
            {
                chatRoom.Tag = this;
                // 에러 처리
                chatRoom.Show();
                chatRoom.Hide();
            }

            // 일정 읽어옴.

            //시작화면을 메인으로
            btnMain.PerformClick();
            Rooms[id].Disable();
            // 수신 Task 시작
            Task rTask = Task.Run(() => Receive());
        }

        public void setupClient()   //변수 할당
        {
            closeFlag = false;
            time = 0;
            Rooms = new Dictionary<string, ChatRoom>();
            lblID.Text = id;
            // 0번: 모르는 사람에게 메시지수신시, 1번: chatBot 사용시
            lsvFriends.Items[0].Text = id;
            Rooms.Add(id, new ChatRoom(id, id, reader, writer));

            lsvFriends.Items[1].Text = "Server";
            Rooms.Add("Server", new ChatRoom(id, "Server", reader, writer));
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        { // 서버에서 로그아웃
            Send("Logout$" + id);

            writer.Close();
            reader.Close();
            stream.Close();
            client.Close();

            //백그라운드 실행중인 채팅창 닫음
            closeFlag = true;
            foreach(ChatRoom chatRoom in Rooms.Values)
            {
                chatRoom.Close();
            }

            Login login = (Login)this.Tag;
            login.Show();
        }

        public void Receive()
        {
            try
            {
                while (!closeFlag)
                {
                    string str = reader.ReadLine();
                    string[] query = StringTokenizer(str);
                    if (query[0] == "Send") // Send$ Sender$ Receiver$ msg
                    {
                        if (Rooms.ContainsKey(query[1])) // 등록된 친구에게 메시지 수신
                        {
                            Rooms[query[1]].Visible = true;
                            Rooms[query[1]].Message(query[1], query[3]);
                        }
                        else // 미등록 친구에게 메시지 수신. 자기 아이디 채팅방에 메시지 수신
                        {
                            Rooms[id].Visible = true;
                            Rooms[id].Message("[미등록 친구]", query[3]);
                        }
                    }
                    else if (query[0] == "Friends") // Friends$ state$ ID
                    {
                        HandleFriends(query);
                    }
                    else if (query[0] == "Schedule")
                    {
                        HandleSchedule(query);
                    }
                }
            }
            catch { }
        }

        #region 버튼& 기본 메소드
        private void btnMain_Click(object sender, EventArgs e)  // 친구목록
        {
            panelFriends.Visible = true;
            panelSetting.Visible = false;
            panelSchedule.Visible = false;

            btnMain.BackColor = Color.OrangeRed;
            btnSetting.BackColor = Color.Orange;
            btnSchedule.BackColor = Color.Orange;
        }

        private void btnSetting_Click(object sender, EventArgs e)// 설정
        {
            panelFriends.Visible = false;
            panelSetting.Visible = true;
            panelSchedule.Visible = false;

            btnMain.BackColor = Color.Orange;
            btnSetting.BackColor = Color.OrangeRed;
            btnSchedule.BackColor = Color.Orange;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            panelFriends.Visible = false;
            panelSetting.Visible = false;
            panelSchedule.Visible = true;

            btnMain.BackColor = Color.Orange;
            btnSetting.BackColor = Color.Orange;
            btnSchedule.BackColor = Color.OrangeRed;
        }

        private void lsvFriends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lsvFriends.SelectedItems.Count == 1)
            {
                try
                {
                    ListView.SelectedListViewItemCollection items = lsvFriends.SelectedItems;
                    Rooms[items[0].Text].Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            

        }

        private string[] StringTokenizer(string query)
        {
            return query.Split('$');
        }

        public void Send(string query)
        {
            writer.WriteLine(query);
            writer.Flush();
        }
        #endregion

        

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            for(int i=0; i<lsvFriends.Items.Count; i++)
            {
                if (txtFriend.Text.Equals(lsvFriends.Items[i].Text))
                {
                    MessageBox.Show("이미 추가된 친구입니다");
                    txtFriend.Text = "";
                    return;
                }
            }

            Send("Friends$" + txtFriend.Text);
            txtFriend.Text = "";
        }

        private void HandleFriends(string[] query)
        {   // Friends$ state$ ID
            if (query[1] == "true")
            {
                ListViewItem item = new ListViewItem();
                item.Text = query[2];
                item.Group = lsvFriends.Items[1].Group;
                lsvFriends.Items.Add(item);

                ChatRoom chatRoom = new ChatRoom(id, query[2], reader, writer);
                chatRoom.Tag = this;
                Rooms.Add(query[2], chatRoom);

                MessageBox.Show("친구 추가되었습니다.");
            }
            else if (query[1] == "false")
            {
                MessageBox.Show("없는 아이디 입니다.");
            }
        }

        #region 스케쥴
        public void HandleSchedule(string[] query)
        {   // query = Sche|dule$ T$ S ...

            for(int i=0; i<query.Length/2; i++)
            {
                DateTime date = Convert.ToDateTime(query[2 * i + 1]);
                ListViewItem item = new ListViewItem(date.ToString("yyyy-MM-dd tt hh:mm"));
                item.SubItems.Add(query[2 * i + 2]);
                lsvSchedule.Items.Add(item);
            }
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            if (txtContents.Text == "")
            {
                MessageBox.Show("항목을 입력하세요");
                return;
            }

            DateTime date1 = dateTimePicker1.Value.Date
                .AddHours(dateTimePicker2.Value.Hour)
                .AddMinutes(dateTimePicker2.Value.Minute);

            //클라이언트에 저장
            string date = date1.ToString("yyyy-MM-dd tt hh:mm");
            ListViewItem item = new ListViewItem(date); 
            item.SubItems.Add(txtContents.Text);   
            lsvSchedule.Items.Add(item);

            //통신
            date = date1.ToString("yyyy-MM-dd HH:mm");

            string query = "Schedule$Add$" + "$" + date + "$" + txtContents.Text;
            Send(query);

            txtContents.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvSchedule.SelectedIndices.Count > 0)  //count이 0이면 아무것도 선택안됨
            {
                //통신
                string query = "Schedule$Delete$" + lsvSchedule.SelectedIndices[0].ToString();
                Send(query);

                lsvSchedule.SelectedItems[0].Remove();
            }
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {

            for(int i=0; i<lsvSchedule.Items.Count; i++)
            {
                DateTime time = Convert.ToDateTime(lsvSchedule.Items[i].Text);
                int result = DateTime.Compare(time, DateTime.Now);

                if(result <= 0) //시간이 됐거나 지난경우 알람호출
                {
                    string query = "Request$" + lsvSchedule.Items[i].SubItems[1].Text;
                    Send(query);

                    lsvSchedule.Items[i].Remove();

                    query = "Schedule$Delete$" + i;
                    Send(query);
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            foreach(ChatRoom room in Rooms.Values)
            {
                Font font = new Font(lstTextFamily.SelectedItem.ToString(),
                    Int32.Parse(lstTextSize.SelectedItem.ToString()));
                room.txtBox.Font = font;
                room.txtSend.Font = font;
            }

            MessageBox.Show("설정이 적용되었습니다.");
        }
    }
}
