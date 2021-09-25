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
        //SqlConnection con = new SqlConnection("server = DESKTOP-BI9FM3O;" + "Database=testdb;" + "Uid=sa;" + "Pwd=1;");
        SQL sql = new SQL();

        public USER_ADMIN()
        {
            InitializeComponent();

        }

        private void USER_ADMIN_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            //Grid Setting
            DGVLoad();
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "WORKERID", "WORKERNAME", "PASSWORD", "BANCODE", "PLANTCODE", "PHONENO", "INDATE", "OUTDATE", "USEFLAG", "CREATE_DT", "CREATE_USERID", "MODIFY_DT", "MODIFY_USERID" };
            string[] HeaderText = new string[] { "아이디", "이름", "비밀번호", "작업그룹", "공장코드", "전화번호", "입사일", "퇴사일", "사용여부", "등록일시", "등록자", "수정일시", "수정자" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 10, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 10, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView1.ReadOnly = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //데이터베이스 오픈
            SqlCommand command = new SqlCommand("SELECT * FROM TB_USER_INFO", sql.con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //콤보박스 기본값 셋팅
            cboPlantCode.SelectedIndex = cboPlantCode.Items.IndexOf("D100");
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("조립반");
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf("D100");
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf("Y");
        }



        public void Do_Search()
        {
            SqlCommand cmd = sql.con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM TB_USER_INFO WHERE WORKERID LIKE " + "'%" + txtWorkerName.Text + "%'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "조립반";
            comboBox2.Text = "D100";
            textBox6.Text = "";
            comboBox3.Text = "Y";
            textBox11.Text = "";
            textBox13.Text = "";
        }


        public void Do_Add()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO TB_USER_INFO(WORKERID, WORKERNAME, PASSWORD, BANCODE, PLANTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, CREATE_DT, CREATE_USERID, MODIFY_DT, MODIFY_USERID) " +
                              "values ( '" + textBox1.Text + "',"
                                    + " '" + textBox2.Text + "',"
                                    + " '" + textBox3.Text + "',"
                                    + " '" + comboBox1.Text + "',"
                                    + " '" + comboBox2.Text + "',"
                                    + " '" + textBox6.Text + "',"
                                    + " '" + dateTimePicker1.Text + "',"
                                    + " '" + dateTimePicker2.Text + "',"
                                    + " '" + comboBox3.Text + "',"
                                    + " '" + dateTimePicker3.Text + "',"
                                    + " '" + textBox11.Text + "',"
                                    + " '" + dateTimePicker4.Text + "',"
                                    + " '" + textBox13.Text + "')";

            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("추가되었습니다");
        }


        public void Do_Delete()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("데이터를 선택하세요");
                return;
            }
            else
            {
                string workerID;
                workerID = dataGridView1.SelectedCells[0].Value.ToString();

                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM TB_USER_INFO WHERE WORKERID = " + "'" + workerID + "'" + "";
                cmd.ExecuteNonQuery();

                Do_Search();

                MessageBox.Show("삭제되었습니다");
            }
        }


        public void Do_Save()
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex; // 현재 선택된 행 번호

            string workerid;
            workerid = dataGridView1.Rows[i].Cells[0].Value.ToString();

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE TB_USER_INFO SET " +
                               "WORKERID = " + "'" + textBox1.Text + "'" + "," +
                               "WORKERNAME = " + "'" + textBox2.Text + "'" + "," +
                               "PASSWORD = " + "'" + textBox3.Text + "'" + "," +
                               "BANCODE = " + "'" + comboBox1.Text + "'" + "," +
                               "PLANTCODE = " + "'" + comboBox2.Text + "'" + "," +
                               "PHONENO = " + "'" + textBox6.Text + "'" + "," +

                               "INDATE = " + "'" + dateTimePicker1.Text + "'" + "," +
                               "OUTDATE = " + "'" + dateTimePicker2.Text + "'" + "," +

                               "USEFLAG = " + "'" + comboBox3.Text + "'" + "," +

                               "CREATE_DT = " + "'" + dateTimePicker3.Text + "'" + "," +

                               "CREATE_USERID = " + "'" + textBox11.Text + "'" + "," +

                               "MODIFY_DT = " + "'" + dateTimePicker4.Text + "'" + "," +
                               "MODIFY_USERID = " + "'" + textBox13.Text + "'" +

                               "WHERE WORKERID = " + "'" + workerid + "'" + "";

            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("수정되었습니다");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            dateTimePicker3.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            dateTimePicker4.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
            textBox13.Text = dataGridView1.Rows[i].Cells[12].Value.ToString();
        }


    }
}
