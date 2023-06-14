using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sosil_Server
{
    class Client
    {
        public string Password { get; set; }
        public string Nickname { get; set; }
        public bool IsConnected { get; set; } = false;

        //통신 관련
        public TcpClient client;
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;
        public Task ReceiveTask;                         //해당 클라이언트 메시지 수신역할 스레드

        //친구목록, 참여중인 채팅방목록, 설정정보            //채팅방은 나중에 구현. 일단은 채팅방 없이 간다.
        public List<string> friends;
        public List<string> schedule;


        public Client(string password, string nickname)
        {
            this.Password = password;
            this.Nickname = nickname;

            friends = new List<string>();
            schedule = new List<string>();
            IsConnected = false;
        }

        public override string ToString()    // 아이디 = Key, Value =  비밀번호, 닉네임, 친구목록 저장용
        {
            string f = "";
            foreach (string s in friends)
                f += s + "$";
            //친구목록이 0이라면
            if(f == "")
            {
                return Password + "$" + Nickname;
            }
            else
            {
                return Password + "$" + Nickname + "$" + f.Substring(0, f.Length - 1);
            }
            
        }

        // 회원정보 변경시에 사용할 메소드
        

        //클라이언트 연결 설정
        public void Set(TcpClient client, NetworkStream stream, StreamReader reader, StreamWriter writer)
        {
            this.client = client;
            this.stream = stream;

            this.reader = reader;
            this.writer = writer;

            IsConnected = true;
        }

        //연결 종료
        public void Dispose()
        {
            IsConnected = false;
            reader.Close();
            writer.Close();
            stream.Close();
            client.Close();
            
        }
    }

}
