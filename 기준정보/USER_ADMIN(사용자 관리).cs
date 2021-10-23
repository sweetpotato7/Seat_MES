﻿using System;
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
        }


        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "WORKERID", "WORKERNAME", "PASSWORD", "BANCODE", "PLANTCODE", "PHONENO", "INDATE", "OUTDATE", "USEFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText = new string[] { "아이디", "이름", "비밀번호", "작업그룹", "공장코드", "전화번호", "입사일", "퇴사일", "사용여부", "등록자", "등록일시", "수정자", "수정일시" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);

            //dataGridView1.ColumnCount = 13;
            //dataGridView1.Columns[0].Name = "아이디"; 
            //dataGridView1.Columns[1].Name = "이름";
            //dataGridView1.Columns[2].Name = "비밀번호";
            //dataGridView1.Columns[3].Name = "작업그룹";
            //dataGridView1.Columns[4].Name = "공장코드";
            //dataGridView1.Columns[5].Name = "전화번호";
            //dataGridView1.Columns[6].Name = "입사일";
            //dataGridView1.Columns[7].Name = "퇴사일";
            //dataGridView1.Columns[8].Name = "사용여부";
            //dataGridView1.Columns[9].Name = "등록자";
            //dataGridView1.Columns[10].Name = "등록일시";
            //dataGridView1.Columns[11].Name = "수정자";
            //dataGridView1.Columns[12].Name = "수정일시";

            //데이터베이스 오픈
            SqlCommand command = new SqlCommand("SELECT * FROM TB_USER_INFO", sql.con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            dataGridView1.DataSource = da;
            
            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);

            //데이터그리드뷰 스타일 지정
            StyleDatagridview();

            //dataGridView1.ReadOnly = true;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.Columns[2].Visible = false;

            //DataTable dt = new DataTable();
            //da.Fill(dt);

            //기본값 셋팅
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
            dateTimePicker4.Value = DateTime.Today;
        }

        private void StyleDatagridview()
        {

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //ColumnHeader 부분
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 70);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            //Row 부분
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(95, 184, 255);


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //콤보박스 세팅
        private void CboSet()
        {  
            func.CboLoad(comboBox1, "TB_CODE_MST", "CODENAME", true, "MAJORCODE", "BANCODE");
            func.CboLoad(comboBox2, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            func.CboLoad(comboBox3, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "USEFLAG");
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

            //txtWorkerName.Text = "";
            //txtName.Text   = "";

            textBox1.Text  = "";
            textBox2.Text  = "";
            textBox3.Text  = "";
            textBox11.Text = "";
            textBox13.Text = "";
            maskedTextBox1.Text  = "";
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
            dateTimePicker4.Value = DateTime.Today;

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
                cmd.CommandText = "INSERT INTO TB_USER_INFO(WORKERID, WORKERNAME, PASSWORD, BANCODE, PLANTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT) " +
                                  "values ( '" + textBox1.Text + "',"
                                        + " '" + textBox2.Text + "',"
                                        + " '" + textBox3.Text + "',"
                                        + " '" + comboBox1.Text + "',"
                                        + " '" + comboBox2.Text + "',"
                                        + " '" + maskedTextBox1.Text + "',"
                                        + " '" + dateTimePicker1.Text + "',"
                                        + " '" + dateTimePicker2.Text + "',"
                                        + " '" + comboBox3.Text + "',"
                                        + " '" + textBox11.Text + "',"
                                        + " '" + dateTimePicker3.Text + "',"
                                        + " '" + textBox13.Text + "',"
                                        + " '" + dateTimePicker4.Text + "')";

                cmd.ExecuteNonQuery();
                Do_Search();
                MessageBox.Show("추가되었습니다");
            }
            catch(Exception e)
            {

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
                               "OUTDATE = '"        + dateTimePicker2.Text + "', " +
                               "USEFLAG = '"        + comboBox3.Text       + "', " +
                               "CREATE_USERID = '"  + textBox11.Text       + "', " +
                               "CREATE_DT = '"      + dateTimePicker3.Text + "', " +
                               "MODIFY_USERID = '"  + textBox13.Text       + "', " +
                               "MODIFY_DT = '"      + dateTimePicker4.Text + "'" +
                               "WHERE WORKERID = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";

            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("수정되었습니다");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();    //아이디
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();    //이름
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();    //비밀번호
            comboBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();    //작업반
            comboBox2.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();    //공장코드
            maskedTextBox1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();    //전화번호
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();    //입사일
            dateTimePicker2.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();    //퇴사일
            comboBox3.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();    //사용유무
            textBox11.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();    //등록자
            dateTimePicker3.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();   //등록일시
            textBox13.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();   //수정자
            dateTimePicker4.Text = dataGridView1.Rows[i].Cells[12].Value.ToString();   //수정일시
            
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            Do_Search();
        }

        
    }
}
