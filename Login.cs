using System;
using System.Windows.Forms;

namespace MESProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ActiveControl = txtLoginid;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginTry();
        }
        private void LoginTry()
        {
            bool login = false; // 로그인 여부 확인
            string login_id = txtLoginid.Text; // 로그인 ID
            string login_pw = txtLoginpw.Text; // 로그인 PW
            //SQL 로그인 연결문
            SQL sql = new SQL();
            sql.ConnectDb(login_id, login_pw, ref login);
            
            if(login)
            {
                Main main = new Main();
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
        }

        private void txtLoginid_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode) { LoginTry(); }
        }
        
        private void txtLoginpw_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode) { LoginTry(); }
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) { Application.Exit(); }
        }
    }
}
