using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MESProject.기준정보
{
    public partial class USER_ADMIN : Form
    {

        //private string sqlCon = string.Format("Data Source={0}{1}; Initial Catalog={2}; User ID={3}; Password={4}", "127.0.0.1", 1433, "testdb", "sa", "1111");
        SqlConnection con = new SqlConnection("server = DESKTOP-E7U1E8O;" + "Database=MES;" + "Uid=sa;" + "Pwd=1;");

        public USER_ADMIN()
        {
            InitializeComponent();
            //Grid Setting
            DGVLoad();
        }

        private void DGVLoad()
        {
            //string[] DataPropertyName = new string[] { "WORKERID", "WORKERNAME", "PASSWORD", "BANCODE", "PLANTCODE", "PHONENO", "INDATE", "OUTDATE", "USEFLAG", "CREATE_DT", "CREATE_USERID", "MODIFY_DT", "MODIFY_USERID" };
            //string[] HeaderText = new string[] { "아이디", "이름", "비밀번호", "작업그룹", "공장코드", "전화번호", "입사일", "퇴사일", "사용여부", "등록일시", "등록자", "수정일시", "수정자" };
            //string[] HiddenColumn = null;
            //float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            //Font StyleFont = new Font("맑은고딕", 10, FontStyle.Bold);
            //Font BodyStyleFont = new Font("맑은고딕", 10, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            //Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 16);
            //dataGridView1.ReadOnly = false;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //데이터베이스 오픈
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM TB_USER_INFO", con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            Do_Search();
        }

        private void Do_Search()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM TB_USER_INFO";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Do_Add();
        }
        private void Do_Add()
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "insert into TB_USER_INFO(PLANTCODE, ITEMCODE, ITEMNAME, ITEMTYPE) values('" + cboPlantCode.SelectedItem.ToString() + "','" + txtItemName.Text + "','" + cboItemCode.SelectedItem.ToString() + "','" + cboItemType.SelectedItem.ToString() + "')";

            //cmd.ExecuteNonQuery();

            //cboPlantCode.SelectedItem = "";
            //txtItemName.Text = "";
            //cboItemCode.SelectedItem = "";
            //cboItemType.SelectedItem = "";
            //MessageBox.Show("품목이 추가되었습니다.");

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO TB_USER_INFO(WORKERID, WORKERNAME, PASSWORD, BANCODE, PLANTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, CREATE_DT, CREATE_USERID, MODIFY_DT, MODIFY_USERID) " +
                              "values ( '" + textBox1.Text + "',"
                                    + " '" + textBox2.Text + "',"
                                    + " '" + textBox3.Text + "',"
                                    + " '" + textBox4.Text + "',"
                                    + " '" + textBox5.Text + "',"
                                    + " '" + textBox6.Text + "',"
                                    + " '" + textBox7.Text + "',"
                                    + " '" + textBox8.Text + "',"
                                    + " '" + textBox9.Text + "',"
                                    + " '" + textBox10.Text + "',"
                                    + " '" + textBox11.Text + "',"
                                    + " '" + textBox12.Text + "',"
                                    + " '" + textBox13.Text + "')";

            cmd.ExecuteNonQuery();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            
            Do_Search();
            MessageBox.Show("추가되었습니다");
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            Do_Delete();
        }

        private void Do_Delete()
        {
            string workerID;
            workerID = dataGridView1.SelectedCells[0].Value.ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM TB_USER_INFO WHERE WORKERID = " + "'" + workerID + "'" + "";
            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("삭제되었습니다");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Do_Save();
        }

        private void Do_Save()
        {
            string WORKERID;
            string WORKERNAME;
            string PASSWORD;
            string BANCODE;
            string PLANTCODE;
            string PHONENO;
            string INDATE;
            string OUTDATE;
            string USEFLAG;
            string CREATE_DT;
            string CREATE_USERID;
            string MODIFY_DT;
            string MODIFY_USERID;

            int i = dataGridView1.SelectedCells[0].RowIndex; //현재 선택된 행 번호

            WORKERID = dataGridView1.SelectedCells[0].Value.ToString();
            WORKERNAME = dataGridView1.Rows[i].Cells[1].Value.ToString();
            PASSWORD = dataGridView1.Rows[i].Cells[2].Value.ToString();
            BANCODE = dataGridView1.Rows[i].Cells[3].Value.ToString();
            PLANTCODE = dataGridView1.Rows[i].Cells[4].Value.ToString();
            PHONENO = dataGridView1.Rows[i].Cells[5].Value.ToString();
            INDATE = dataGridView1.Rows[i].Cells[6].Value.ToString();
            OUTDATE = dataGridView1.Rows[i].Cells[7].Value.ToString();
            USEFLAG = dataGridView1.Rows[i].Cells[8].Value.ToString();
            CREATE_DT = dataGridView1.Rows[i].Cells[9].Value.ToString();
            CREATE_USERID = dataGridView1.Rows[i].Cells[10].Value.ToString();
            MODIFY_DT = dataGridView1.Rows[i].Cells[11].Value.ToString();
            MODIFY_USERID = dataGridView1.Rows[i].Cells[12].Value.ToString();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE TB_USER_INFO SET WORKERID = " + "'" + WORKERID + "'" + "," +
                               "WORKERNAME = " + "'" + WORKERNAME + "'" + "," +
                               "PASSWORD = " + "'" + PASSWORD + "'" + "," +
                               "BANCODE = " + "'" + BANCODE + "'" + "," +
                               "PLANTCODE = " + "'" + PLANTCODE + "'" + "," +
                               "PHONENO = " + "'" + PHONENO + "'" + "," +
                               "INDATE = " + "'" + INDATE + "'" + "," +
                               "OUTDATE = " + "'" + OUTDATE + "'" + "," +
                               "USEFLAG = " + "'" + USEFLAG + "'" + "," +
                               "CREATE_DT = " + "'" + CREATE_DT + "'" + "," +
                               "CREATE_USERID = " + "'" + CREATE_USERID + "'" + "," +
                               "MODIFY_DT = " + "'" + MODIFY_DT + "'" + "," +
                               "MODIFY_USERID = " + "'" + MODIFY_USERID + "'" +
                               "WHERE WORKERID = " + "'" + WORKERID + "'" + "";

            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("수정되었습니다");
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
