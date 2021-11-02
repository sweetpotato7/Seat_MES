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

        SQL sql = new SQL();
        Function func = new Function();
        string strqry = string.Empty;

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

            DGVLoad();
            CboSet();
            Do_Search();
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "WORKERID", "WORKERNAME", "PASSWORD", "BANCODE", "PLANTCODE", "PHONENO", "INDATE", "OUTDATE", "USEFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "아이디", "이름", "비밀번호", "작업그룹", "공장코드", "전화번호", "입사일", "퇴사일", "사용여부", "등록자", "등록일시", "수정자", "수정일시" };
            float[] FillWeight        = new float[]  { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont     = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView1.Columns[2].Visible = false;

            //데이터그리드뷰 스타일 지정
            dataGridView1.BorderStyle     = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false; //ColumnHeader 부분
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Row선택 방식
        }

        //콤보박스 세팅
        private void CboSet()
        {  
            func.CboLoad(comboBox1, "TB_CODE_MST", "CODENAME",  true, "MAJORCODE", "BANCODE");
            func.CboLoad(comboBox2, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            func.CboLoad(comboBox3, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "USEFLAG");
            cboInout.Items.Clear();
            cboInout.DropDownStyle = ComboBoxStyle.DropDownList;
            cboInout.Items.Add("입사일");
            cboInout.Items.Add("퇴사일"); //추가
        }

        public void Do_Search()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM TB_USER_INFO WHERE WORKERID LIKE " + "'%" + txtSearch.Text + "%'" + 
                              " AND WORKERNAME LIKE " + "'%" + textBox4.Text + "%'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            textBox1.Text  = "";
            textBox2.Text  = "";
            textBox3.Text  = "";
            maskedTextBox1.Text  = "";
            dateTimePicker1.Value   = DateTime.Today;
        }

        public void Do_Add()
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("아이디를 입력하세요");
                    return;
                }
                
                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO TB_USER_INFO(WORKERID, WORKERNAME, PASSWORD, BANCODE, PLANTCODE, PHONENO, INDATE, USEFLAG, CREATE_USERID, CREATE_DT) " +
                                  "values ( '" + textBox1.Text        + "',"
                                        + " '" + textBox2.Text        + "',"
                                        + " '" + textBox3.Text        + "',"
                                        + " '" + comboBox1.Text       + "',"
                                        + " '" + comboBox2.Text       + "',"
                                        + " '" + maskedTextBox1.Text  + "',"
                                        + " '" + dateTimePicker1.Text + "',"
                                        + " '" + comboBox3.Text       + "',"
                                        + " '" + Main.ID + "', "
                                        + " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')";
                //if (dateTimePicker1.Value.ToString() != dateTimePicker2.Value.ToString())
                //{
                //    cmd.CommandText = "INSERT INTO TB_USER_INFO(WORKERID, WORKERNAME, PASSWORD, BANCODE, PLANTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, CREATE_USERID, CREATE_DT) " +
                //                  "values ( '" + textBox1.Text + "',"
                //                        + " '" + textBox2.Text + "',"
                //                        + " '" + textBox3.Text + "',"
                //                        + " '" + comboBox1.Text + "',"
                //                        + " '" + comboBox2.Text + "',"
                //                        + " '" + maskedTextBox1.Text + "',"
                //                        + " '" + dateTimePicker1.Text + "',"
                //                        + " '" + dateTimePicker2.Text + "',"
                //                        + " '" + comboBox3.Text + "',"
                //                        + " '" + Main.ID + "', "
                //                        + " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')";
                //}
                cmd.ExecuteNonQuery();
                Do_Search();
                MessageBox.Show("추가되었습니다");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
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
                DialogResult result = MessageBox.Show("삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    SqlCommand cmd = sql.con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM TB_USER_INFO WHERE WORKERID = " + "'" + textBox1.Text + "'" + "";
                    cmd.ExecuteNonQuery();

                    Do_Search();

                    MessageBox.Show("삭제되었습니다");
                }
                else if(result == DialogResult.No)
                {
                    return;
                }
            }
        }

        public void Do_Save()
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE TB_USER_INFO SET " +
                               "WORKERID = '"       + textBox1.Text        + "', " +
                               "WORKERNAME = '"     + textBox2.Text        + "', " +
                               "PASSWORD = '"       + textBox3.Text        + "', " +
                               "BANCODE = '"        + comboBox1.Text       + "', " +
                               "PLANTCODE = '"      + comboBox2.Text       + "', " +
                               "PHONENO = '"        + maskedTextBox1.Text  + "', " +
                               "INDATE = '"         + dateTimePicker1.Text + "', " +
                               "USEFLAG = '"        + comboBox3.Text       + "', " +
                               "MODIFY_USERID = '"  + Main.ID + "', " +
                               "MODIFY_DT = '"      + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'" +
                               "WHERE WORKERID = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";
            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("수정되었습니다");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;

                textBox1.Text        = dataGridView1.Rows[i].Cells[0].Value.ToString();    //아이디
                textBox2.Text        = dataGridView1.Rows[i].Cells[1].Value.ToString();    //이름
                textBox3.Text        = dataGridView1.Rows[i].Cells[2].Value.ToString();    //비밀번호
                comboBox1.Text       = dataGridView1.Rows[i].Cells[3].Value.ToString();    //작업반
                comboBox2.Text       = dataGridView1.Rows[i].Cells[4].Value.ToString();    //공장코드
                maskedTextBox1.Text  = dataGridView1.Rows[i].Cells[5].Value.ToString();    //전화번호
                
                dateTimePicker1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();    //입사일
                comboBox3.Text       = dataGridView1.Rows[i].Cells[8].Value.ToString();    //사용유무
            }
            catch
            {

            }
        }
    }
}
