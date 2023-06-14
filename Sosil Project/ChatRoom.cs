using System;
using System.IO;
using System.Windows.Forms;

namespace Sosil_Project
{
    public partial class ChatRoom : Form
    {
        private string sender;
        private string receiver;

        public StreamReader reader;
        public StreamWriter writer;

        public ChatRoom(string sender, string receiver, StreamReader reader, StreamWriter writer)
        {
            InitializeComponent();
            this.receiver = receiver;
            this.reader = reader;
            this.writer = writer;


            this.sender = sender;
            this.Text = receiver + "의 채팅방";

        }

        public void Disable()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                txtSend.Enabled = false;
                btnSend.Enabled = false;
            }));
        }

        

        public void Message(string sender ,string msg)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                txtBox.AppendText(sender + ">>>" + DateTime.Now.ToString("t") + "\r\n");
                txtBox.AppendText(msg + "\r\n");
                txtBox.Focus();
                txtBox.ScrollToCaret();
                txtSend.Focus();
            }));
        }

        public void Send()  // 0. Send
        {                   // 1. 보내는 아이디, 2. 수신자 아이디, 3. 메시지 내용 으로 분할
            if (txtSend.Text.Equals(""))
                return;
            try
            {
                writer.WriteLine("Send$" + sender + "$" + receiver + "$" + txtSend.Text);
                writer.Flush();

                string curTime = DateTime.Now.ToString("t");
                Message("", txtSend.Text);

                txtSend.Text = "";
            }
            catch
            {

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
            }
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {   // main화면이 닫힐때 같이 닫힐수 있도록 일단 닫지 않는다.
            Main main = (Main)this.Tag;
            if(main.closeFlag == false)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
    }
}
