using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace MESProject
{
    public partial class Login : Form
    {
        SQL sql = new SQL();
        Function func = new Function();

        public Login()
        {
            InitializeComponent();
            ActiveControl = txtUserid;
        }

        public void LoginTry()
        {
            bool login = false; // 로그인 여부 확인
            string login_id = txtUserid.Text; // 로그인 ID
            string login_pw = txtPassword.Text; // 로그인 PW

            //SQL 로그인 연결문
            SQL sql = new SQL();
            sql.ConnectDb(login_id, login_pw, ref login);

            if (login)
            {
                Main.ID = login_id;
                Main main = new Main();
                this.Hide();
                main.ShowDialog();
                this.Close();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginTry();
        }

        private void txtUserid_Enter(object sender, EventArgs e)
        {
            if(txtUserid.Text == "USER ID")
            {
                txtUserid.Text = "";
                txtUserid.ForeColor = System.Drawing.Color.LightGray;
            }
        }

        private void txtUserid_Leave(object sender, EventArgs e)
        {
            if(txtUserid.Text == "")
            {
                txtUserid.Text = "USER ID";
                txtUserid.ForeColor = System.Drawing.Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "PASSWORD")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = System.Drawing.Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text == "")
            {
                txtPassword.Text = "PASSWORD";
                txtPassword.ForeColor = System.Drawing.Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUserid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginTry();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginTry();
            if (e.KeyCode == Keys.Tab)
                this.ActiveControl = txtUserid;
        }
    }
}
