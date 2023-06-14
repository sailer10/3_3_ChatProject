using Org.BouncyCastle.Utilities.Net;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Sosil_Project
{
    public partial class SignUp : Form
    {
        private const int PORT = 8000;
        private string signUpMessage;   //메세지 서식 : SignUp$아이디$비밀번호$닉네임

        private TcpClient client;
        private NetworkStream stream;
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtPw.Text != txtPwCheck.Text)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }
            else if(txtId.Text == "SignUp" || txtId.Text.Contains("$") || txtName.Text.Contains("$")
                || txtPw.Text.Contains("$"))
            {
                MessageBox.Show("잘못된 텍스트 서식입니다. ($)");
                return;
            }

            try
            {
                client = new TcpClient("127.0.0.1", PORT);
                stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream);
                StreamReader reader = new StreamReader(stream);
                
                signUpMessage = "SignUp$" + txtId.Text + "$" + txtPw.Text + "$" + txtName.Text;
                writer.WriteLine(signUpMessage);
                writer.Flush();
                
                string returnState = reader.ReadLine();

                if(returnState == "Success")
                {
                    MessageBox.Show("회원가입 성공!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(returnState);
                }
                writer.Close(); reader.Close();
            }
            catch
            {
                MessageBox.Show("서버 접속 오류!");
            }
            finally
            {
                stream.Close();
                client.Close();
            }

        }
    }
}
