using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sosil_Project
{
    public partial class Login : Form
    {
        string id;
        string name;
        TcpClient client;
        NetworkStream stream;

        private const int PORT = 8000;

        public Login()
        {
            InitializeComponent();

            txtId.Text = "아이디";
            txtId.ForeColor = Color.Gray;
            txtPassword.Text = "비밀번호";
            txtPassword.ForeColor = Color.Gray;
        }


        private void btnLogin_Click (object sender, EventArgs e)    //로그인 체크를 위한 함수
        {
            client = new TcpClient("127.0.0.1", PORT);
            stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            string query = "Login$" + txtId.Text + "$" + txtPassword.Text;
            writer.WriteLine(query);
            writer.Flush();

            string receive = reader.ReadLine();

            if(receive == "로그인 성공")
            {
                MessageBox.Show("로그인 성공");

                Main main = new Main();
                main.Tag = this;
                main.ID = txtId.Text;
                main.client = client;
                main.stream = stream;
                main.reader = reader;
                main.writer = writer;

                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(receive);
            }

        }

        #region 아이디, 비밀번호 힌트 나타내기
        private void txtId_Enter(object sender, EventArgs e)
        {
            if (txtId.Text == "아이디")
            {
                txtId.Text = "";
                txtId.ForeColor = Color.Black;
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {

            
            if (txtId.Text == "")
            {
                txtId.Text = "아이디";
                txtId.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "비밀번호")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '*';         //비밀번호가 *로 표시되도록 변경
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "비밀번호";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';    //passwordChar 의 DefaultValue 로 다시 설정
            }
        }
        #endregion

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            DialogResult dResult = signUp.ShowDialog();
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

    }
}
