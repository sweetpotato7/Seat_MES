using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MESProject
{
    class SQL // 가져온 파일, 수정해야됨
    {
        //public SqlConnection con = new SqlConnection("server = " + SystemInformation.ComputerName + "; Database=MES; Uid=sa; Pwd=1;");
        public SqlConnection con = new SqlConnection("server = 61.83.51.99, 1433; Database=MES; Uid=sa; Pwd=password2021!@;"); //서버 외부 접속
        //public SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MES; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void ConnectDb(string login_id, string login_pw, ref bool login) // 
        {
            int i;
            SqlCommand cmd;
            DataTable dt;
            SqlDataAdapter da;

            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();

                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT WORKERID FROM TB_USER_INFO WHERE WORKERID='" + login_id + "' AND PASSWORD='" + login_pw + "'";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = 0;
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("아이디와 비밀번호가 일치하지 않습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    login = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static string VerCheck()
        {
            // ~~에서 버전 정보 받고 SQL에서 받아와 비교 후
            // 버전 다를 시 업데이트(메세지박스) 팝업
            string Version = "00.1234";
            string Value = "Ver " + Version;
            return Value;
        }
    }
}