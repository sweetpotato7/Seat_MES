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

        private void CODE_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            //DGVLoad();
            disp(); // 전체조회
            CboSet(); // 콤보박스 세팅
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "MAJORCODE", "MINORCODE", "CODENAME", "RELCODE1", "RELCODE2", "RELCODE3", "RELCODE4", "RELCODE5", "DISPLAYNO", "USEFLAG", "CREATE_USERID", "CREATE_DT",  "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "주코드", "부코드", "코드명", "코드명", "참조2", "참조3", "참조4", "참조5", "순서", "사용", "등록자", "등록일시", "수정자", "수정일시" };
            string[] HiddenColumn     = null;
            float[] FillWeight = new float[] { 40, 100, 40, 100, 100, 100, 100, 100, 100, 40, 40, 100, 130, 100, 130 };
            Font StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            HiddenColumn = new string[] { "PLANTCODE", "MINORCODE", "CODENAME", "RELCODE2", "RELCODE3", "RELCODE4", "RELCODE5", "DISPLAYNO", "USEFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 15);
            HiddenColumn = new string[] { "MAJORCODE", "RELCODE1"};
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 15);

            //dataGridView2.ReadOnly = false;
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
            // 조건별 검색 기능 고민
            string strqry = string.Empty;
            if (txtSearch.Text != "")
            {
                switch(cboSearch.Text) // 쿼리문 생성
                {
                    case "주코드":
                        strqry = "SELECT DISTINCT MAJORCODE , RELCODE1 FROM TB_CODE_MST "
                               + "WHERE MAJORCODE LIKE '%" + txtSearch.Text + "%'";
                        break;
                    case "부코드":
                        strqry = "SELECT PLANTCODE, MINORCODE, CODENAME, RELCODE2, RELCODE3, RELCODE4, RELCODE5, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST "
                               + "WHERE MINORCODE LIKE '%" + txtSearch.Text + "%'";
                        break;
                    case "코드명": // 코드명은 부코드 이름?
                        strqry = "SELECT PLANTCODE, MAJORCODE, RELCODE1, MINORCODE, CODENAME, RELCODE2, RELCODE3, RELCODE4, RELCODE5, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST "
                               + "WHERE CODENAME LIKE '%"  + txtSearch.Text + "%'";
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
            cmd.CommandText = "SELECT DISTINCT MAJORCODE, RELCODE1 from TB_CODE_MST";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd2 = sql.con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            //cmd2.CommandText = "select MINORCODE, CODENAME from TB_CODE_MST";
            cmd2.CommandText = "SELECT PLANTCODE, MINORCODE, CODENAME, RELCODE2, RELCODE3, RELCODE4, RELCODE5, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        // MAJORCODE 클릭 시 MINORCODE, CODENAME 조회
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string majorcode;
            majorcode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select MINORCODE, CODENAME from TB_CODE_MST " +
            cmd.CommandText = "SELECT PLANTCODE, MINORCODE, CODENAME, RELCODE2, RELCODE3, RELCODE4, RELCODE5, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST " +
                              "where MAJORCODE =" + "'" + majorcode + "'" + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            
            cboPlantCode.SelectedItem = "D001";
        }
    }
}