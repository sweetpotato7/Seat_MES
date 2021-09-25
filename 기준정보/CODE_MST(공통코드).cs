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
    public partial class CODE_MST : Form
    {
        SQL sql = new SQL();

        public CODE_MST()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 추가 수정 삭제 기능 넣기
        /// </summary>
        private void CODE_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            DGVLoad();
            disp();   // 전체조회
            CboSet(); // 콤보박스 세팅
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "MAJORCODE", "MINORCODE", "CODENAME", "RELCODE1", "RELCODE2", "RELCODE3", "RELCODE4", "RELCODE5", "DISPLAYNO", "USEFLAG", "CREATE_USERID", "CREATE_DT",  "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "주코드", "부코드", "코드명", "참조1", "참조2", "참조3", "참조4", "코드명", "순서", "사용", "등록자", "등록일시", "수정자", "수정일시" };
            string[] HiddenColumn     = null;
            float[] FillWeight = new float[] { 40, 100, 40, 100, 100, 100, 100, 100, 100, 40, 40, 100, 130, 100, 130 };
            Font StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            HiddenColumn = new string[] { "PLANTCODE", "MINORCODE", "CODENAME", "RELCODE1", "RELCODE2", "RELCODE3", "RELCODE4", "DISPLAYNO", "USEFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 15);
            HiddenColumn = new string[] { "MAJORCODE", "RELCODE5"};
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 15);

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CboSet()
        {
            cboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearch.Items.Add("주코드");
            cboSearch.Items.Add("부코드");
            cboSearch.Items.Add("코드명");
            cboSearch.SelectedIndex = 0;
        }

        public void DO_Search()
        {
            string strqry = string.Empty;
            if (txtSearch.Text != "")
            {
                switch(cboSearch.Text) // cboSearch에 맞는 쿼리문 생성
                {
                    case "주코드":
                        strqry = "SELECT DISTINCT MAJORCODE , RELCODE5 FROM TB_CODE_MST "
                               + "WHERE MAJORCODE LIKE '%" + txtSearch.Text + "%'";
                        break;
                    case "부코드":
                        strqry = "SELECT PLANTCODE, MINORCODE, CODENAME, RELCODE1, RELCODE2, RELCODE3, RELCODE4, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST "
                               + "WHERE MINORCODE LIKE '%" + txtSearch.Text + "%'"
                               + "ORDER BY DISPLAYNO";
                        break;
                    case "코드명": // 코드명은 부코드 이름?
                        strqry = "SELECT PLANTCODE, MAJORCODE, RELCODE1, MINORCODE, CODENAME, RELCODE1, RELCODE2, RELCODE3, RELCODE4, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST "
                               + "WHERE CODENAME LIKE '%"  + txtSearch.Text + "%'"
                               + "ORDER BY DISPLAYNO";
                        break;
                }

                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strqry;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                switch (cboSearch.Text) // 받은 dt 그리드에 바인딩
                {
                    case "주코드":
                        dataGridView1.DataSource = dt;
                        break;
                    case "부코드":
                        dataGridView2.DataSource = dt;
                        break;
                    case "코드명":
                        dataGridView2.DataSource = dt;
                        break;
                }
                txtSearch.Text = "";
            }
            else
            {
                disp();
            }
        }

        public void disp() // 전체조회
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DISTINCT MAJORCODE, RELCODE5 from TB_CODE_MST";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd2 = sql.con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            //cmd2.CommandText = "select MINORCODE, CODENAME from TB_CODE_MST";
            cmd2.CommandText = "SELECT PLANTCODE, MINORCODE, CODENAME, RELCODE1, RELCODE2, RELCODE3, RELCODE4, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        // MAJORCODE 클릭 시 MINORCODE, CODENAME 조회
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string majorcode;
                majorcode = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();

                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select MINORCODE, CODENAME from TB_CODE_MST " +
                cmd.CommandText = "SELECT PLANTCODE, MINORCODE, CODENAME, RELCODE1, RELCODE2, RELCODE3, RELCODE4, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST " +
                                  "where MAJORCODE = '" + majorcode + "' "
                                + "ORDER BY DISPLAYNO";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            
                cboPlantCode.SelectedItem = "D001";
            }
            catch
            {

            }
        }
    }
}