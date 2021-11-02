using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MESProject.기준정보
{
    public partial class SPEC_MST : Form
    {

        /// </summary>

        Function func = new Function();
        SQL sql = new SQL();
        DataTable dt;
        SqlDataAdapter da;

        public SPEC_MST()
        {
            InitializeComponent();
        }

        public void SPEC_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();

            DGVLoad();
            CboSet();
        }

        #region 그리드세팅
        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "CARCODE", "SEATTYPE", "SPEC1", "SPEC2", "SPEC3", "SPEC4",      "SPEC5", "SPEC6", "USEFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장코드",  "품번",     "차종",    "시트타입", "지역",  "트랙",  "시트",  "헤드레스트", "색상",  "SAB",   "사용여부", "등록자", "등록일시", "수정자", "수정일시" };
            float[] FillWeight        = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            //dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //상단 콤보박스 세팅
            SqlCommand cmd = new SqlCommand("SELECT ITEMCODE FROM TB_BOM WHERE ITEMCODE LIKE '%ALC';", sql.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();

            cmb_S_ALC.DataSource = ds.Tables[0];
            cmb_S_ALC.DisplayMember = "ITEMCODE";
            cmb_S_ALC.ValueMember = "ITEMCODE";

            //데이터그리드 뷰 전체 조회
            cmb_S_ALC.Text = "";
            Do_Search();
        }
        #endregion

        #region CRUD버튼
        public void Do_Search()
        {
            try
            {
                if (cmb_S_ALC.Text == "")
                {
                    SqlCommand cmd = sql.con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TB_SPEC";
                    cmd.ExecuteNonQuery();

                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    cmb_S_ALC.Text = "";
                }

                else
                {
                    string s = cmb_S_ALC.Text;

                    SqlCommand cmd = sql.con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TB_SPEC WHERE ITEMCODE = ANY(SELECT COMPONENT FROM TB_BOM WHERE ITEMCODE = ANY(SELECT COMPONENT FROM TB_BOM  WHERE ITEMCODE = '" + cmb_S_ALC.Text + "'))";

                    cmd.ExecuteNonQuery();

                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    cmb_S_ALC.Text = "";
                }
            }
            catch
            {

            }
        }

        public void Do_Add()
        {
            try
            {
                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO TB_SPEC (PLANTCODE, ITEMCODE, CARCODE, SEATTYPE, SPEC1, SPEC2, SPEC3, SPEC4, SPEC5, SPEC6, USEFLAG, CREATE_USERID, CREATE_DT) VALUES"
                    + "('" 
                    + cmb_PlantCode.Text   + "','"
                    + cmb_ItemCode.Text    + "','"
                    + cmb_CarCode.Text     + "','"
                    + cmb_SeatType.Text    + "','"
                    + cmbLocal.Text        + "','"
                    + cmbTrack.Text        + "','"
                    + cmbFormpad.Text      + "','"
                    + cmbHeadrestrian.Text + "','"
                    + cmbCovering.Text     + "','"
                    + cmbSAB.Text          + "','"
                    + cmbUseFlag.Text      + "','"
                    + Main.ID              + "','"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')";
                cmd.ExecuteNonQuery();

                cmb_PlantCode.Text   = "";
                cmb_ItemCode.Text    = "";
                cmb_CarCode.Text     = "";
                cmb_SeatType.Text    = "";
                cmbLocal.Text        = "";
                cmbTrack.Text        = "";
                cmbFormpad.Text      = "";
                cmbHeadrestrian.Text = "";
                cmbCovering.Text     = "";
                cmbSAB.Text          = "";
                cmbUseFlag.Text      = "";

                Do_Search();
                MessageBox.Show("추가되었습니다.");
            }
            catch
            {

            }
        }

        public void Do_Delete()
        {
            try
            {
                string itemcode;
                itemcode = dataGridView1.SelectedCells[1].Value.ToString();
                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM TB_SPEC WHERE " +
                                  "PLANTCODE = '" + cmb_PlantCode.Text + "' " +
                                  "AND ITEMCODE = '" + cmb_ItemCode.Text + "' " +
                                  "AND CARCODE = '" + cmb_CarCode.Text + "' " +
                                  "AND SEATTYPE = '" + cmb_SeatType.Text + "'";
                cmd.ExecuteNonQuery();
                Do_Search();
                MessageBox.Show("삭제되었습니다.");
            }
            catch
            {

            }
        }

        public void Do_Save()
        {
            try
            {
                string itemcode;
                int i;

                i = dataGridView1.SelectedCells[0].RowIndex; // 현재 선택된 행 번호
                itemcode = dataGridView1.Rows[i].Cells[1].Value.ToString(); // carcode선택

                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE TB_SPEC SET " +
                                  "PLANTCODE = '"     + cmb_PlantCode.Text   + "', " +
                                  "ITEMCODE  = '"     + cmb_ItemCode.Text    + "', " +
                                  "CARCODE   = '"     + cmb_CarCode.Text     + "', " +
                                  "SEATTYPE  = '"     + cmb_SeatType.Text    + "', " +
                                  "SPEC1 = '"         + cmbLocal.Text        + "', " +
                                  "SPEC2 = '"         + cmbTrack.Text        + "', " +
                                  "SPEC3 = '"         + cmbFormpad.Text      + "', " +
                                  "SPEC4 = '"         + cmbHeadrestrian.Text + "', " +
                                  "SPEC5 = '"         + cmbCovering.Text     + "', " +
                                  "SPEC6 = '"         + cmbSAB.Text          + "', " +
                                  "USEFLAG = '"       + cmbUseFlag.Text      + "', " +
                                  "MODIFY_USERID = '" + Main.ID              + "', " +
                                  "MODIFY_DT = '"     + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'" +

                                  "WHERE PLANTCODE = '" + cmb_PlantCode.Text + "' " +
                                    "AND ITEMCODE = '"  + cmb_ItemCode.Text  + "' " +
                                    "AND CARCODE = '"   + cmb_CarCode.Text   + "' " +
                                    "AND SEATTYPE = '"  + cmb_SeatType.Text  + "'";
                cmd.ExecuteNonQuery();

                Do_Search();
                MessageBox.Show("수정되었습니다.");
            }
            catch
            {

            }
        }
        #endregion

        #region 콤보박스
        private void CboSet()
        {
            func.CboLoad(cmb_PlantCode,   "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            func.CboLoad(cmb_ItemCode,    "TB_ITEM_MST", "ITEMCODE",  true, "ITEMTYPE",  "FERT");
            func.CboLoad(cmb_CarCode,     "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "CAR_CD");
            func.CboLoad(cmb_SeatType,    "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "SEAT_TYPE");
            func.CboLoad(cmbLocal,        "TB_CODE_MST", "CODENAME",  true, "MAJORCODE", "SPEC_01");
            func.CboLoad(cmbTrack,        "TB_CODE_MST", "CODENAME",  true, "MAJORCODE", "SPEC_02");
            func.CboLoad(cmbFormpad,      "TB_CODE_MST", "CODENAME",  true, "MAJORCODE", "SPEC_03");
            func.CboLoad(cmbHeadrestrian, "TB_CODE_MST", "CODENAME",  true, "MAJORCODE", "SPEC_04");
            func.CboLoad(cmbCovering,     "TB_CODE_MST", "CODENAME",  true, "MAJORCODE", "SPEC_05");
            func.CboLoad(cmbSAB,          "TB_CODE_MST", "CODENAME",  true, "MAJORCODE", "SPEC_06");
            func.CboLoad(cmbUseFlag,      "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "USEFLAG");
        }
        #endregion

        #region 자동완성
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;

            cmb_PlantCode.Text   = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cmb_ItemCode.Text    = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cmb_CarCode.Text     = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cmb_SeatType.Text    = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cmbLocal.Text        = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cmbTrack.Text        = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cmbFormpad.Text      = dataGridView1.Rows[i].Cells[6].Value.ToString();
            cmbHeadrestrian.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            cmbCovering.Text     = dataGridView1.Rows[i].Cells[8].Value.ToString();
            cmbSAB.Text          = dataGridView1.Rows[i].Cells[9].Value.ToString();
            cmbUseFlag.Text      = dataGridView1.Rows[i].Cells[10].Value.ToString();
        }
        #endregion

        private void cmb_S_ALC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Do_Search();
        }
    }
}

#region 사용 안함
//public void fill_cmb_ALC()
//{

//    cmb_S_ALC.Items.Clear();
//    SqlCommand cmd = sql.con.CreateCommand();
//    cmd.CommandType = CommandType.Text;
//    cmd.CommandText = "select * from TB_SPEC";
//    cmd.ExecuteNonQuery();
//    DataTable dt = new DataTable();
//    SqlDataAdapter da = new SqlDataAdapter(cmd);
//    da.Fill(dt);
//    foreach (DataRow dr in dt.Rows)
//    {
//        cmb_S_ALC.Items.Add(dr["ITEMCODE"].ToString());
//    }
//}

//public void fill_cmb_carcode()
//{

//    cmb_CarCode.Items.Clear();
//    SqlCommand cmd = sql.con.CreateCommand();
//    cmd.CommandType = CommandType.Text;
//    cmd.CommandText = "select * from TB_SPEC";
//    cmd.ExecuteNonQuery();
//    DataTable dt = new DataTable();
//    SqlDataAdapter da = new SqlDataAdapter(cmd);
//    da.Fill(dt);
//    foreach (DataRow dr in dt.Rows)
//    {
//        cmb_CarCode.Items.Add(dr["CARCODE"].ToString());
//    }
//}
#endregion

