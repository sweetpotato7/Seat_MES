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
    /// <summary>
    /// DGV2 셀 클릭 시 주코드 입력되게 해야됨
    /// </summary>
    public partial class CODE_MST : Form
    {
        SQL sql = new SQL();
        Function func = new Function();
        DataTable dt;
        SqlDataAdapter da;
        string strqry = string.Empty;
        

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
            Do_Search(); // 전체조회
            CboSet(); // 콤보박스 세팅
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "MAJORCODE", "MINORCODE", "CODENAME", "RELCODE1", "RELCODE2", "RELCODE3", "RELCODE4", "RELCODE5", "DISPLAYNO", "USEFLAG", "CREATE_USERID", "CREATE_DT",  "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "주코드", "부코드", "코드명", "참조1", "참조2", "참조3", "참조4", "코드명", "순서", "사용", "등록자", "등록일시", "수정자", "수정일시" };
            string[] HiddenColumn     = null;
            float[] FillWeight = new float[] { 40, 100, 50, 100, 100, 100, 100, 100, 100, 40, 40, 100, 130, 100, 130 };
            Font StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            HiddenColumn = new string[] { "PLANTCODE", "MINORCODE", "CODENAME", "RELCODE1", "RELCODE2", "RELCODE3", "RELCODE4", "DISPLAYNO", "USEFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 15);
            HiddenColumn = new string[] { "MAJORCODE", "RELCODE5"};
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 15);

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #region ========== CRUD
        public void Do_Search()
        {
            try
            {
                dt = new DataTable();
                if (txtSearch.Text != "")
                {
                    switch (cboSearch.Text) // cboSearch에 맞는 쿼리문 생성
                    {
                        case "주코드":
                            strqry = "SELECT DISTINCT MAJORCODE , RELCODE5 FROM TB_CODE_MST "
                                   + "WHERE MAJORCODE LIKE '%" + txtSearch.Text + "%'";
                            dt = func.GetDataTable2(strqry);
                            dataGridView1.DataSource = dt;
                            break;
                        case "부코드":
                            strqry = "SELECT * FROM TB_CODE_MST "
                                   + "WHERE MINORCODE LIKE '%" + txtSearch.Text + "%'"
                                   + "ORDER BY DISPLAYNO";
                            dt = func.GetDataTable2(strqry);
                            dataGridView2.DataSource = dt;
                            break;
                        case "코드명": // 코드명은 부코드 이름?
                            strqry = "SELECT * FROM TB_CODE_MST "
                                   + "WHERE CODENAME LIKE '%"  + txtSearch.Text + "%'"
                                   + "ORDER BY DISPLAYNO";
                            dt = func.GetDataTable2(strqry);
                            dataGridView2.DataSource = dt;
                            break;
                    }
                    txtSearch.Text = "";
                }
                else
                {
                    // 주코드 로드
                    strqry = "SELECT DISTINCT MAJORCODE, RELCODE5 from TB_CODE_MST";
                    dt = func.GetDataTable2(strqry);
                    dataGridView1.DataSource = dt;
                    // 부코드 로드
                    strqry = "SELECT * FROM TB_CODE_MST";
                    dt = func.GetDataTable2(strqry);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Do_Insert()
        {
            try
            {
                string message = "다음 항목을 입력해 주세요";
                if (cboIPlantcode.Text == "") message += "\n공장";
                if (cboIMajorCode.Text == "") message += "\n주코드";
                if (txtIMajorName.Text == "") message += "\n주코드명";
                if (cboIMinorCode.Text == "") message += "\n부코드";
                if (txtIMinorName.Text == "") message += "\n부코드명";
                if (txtIDisplayNo.Text == "") message += "\n순서";
                if (message.Length > 14)
                {
                    MessageBox.Show(message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                dt = new DataTable();
                strqry = "INSERT INTO TB_CODE_MST (PLANTCODE, MAJORCODE, MINORCODE, CODENAME, RELCODE1, RELCODE2, RELCODE3, RELCODE4, RELCODE5, DISPLAYNO, USEFLAG) "
                                        + "VALUES ('" + cboIPlantcode.Text + "',"
                                               + " '" + cboIMajorCode.Text + "',"
                                               + " '" + cboIMinorCode.Text + "',"
                                               + " '" + txtIMinorName.Text + "',"
                                               + " '" + txtIRelCode1.Text  + "',"
                                               + " '" + txtIRelCode2.Text  + "',"
                                               + " '" + txtIRelCode3.Text  + "',"
                                               + " '" + txtIRelCode4.Text  + "',"
                                               + " '" + txtIMajorName.Text + "',"
                                               + " '" + txtIDisplayNo.Text + "',"
                                               + " '" + cboIUseFlag.Text   + "')";
                da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand(strqry, sql.con);
                da.InsertCommand.ExecuteNonQuery();

                // 입력 후 재조회
                // 주코드 로드
                strqry = "SELECT DISTINCT MAJORCODE, RELCODE5 from TB_CODE_MST";
                dt = func.GetDataTable2(strqry);
                dataGridView1.DataSource = dt;
                // 부코드 로드
                strqry = "SELECT * FROM TB_CODE_MST "
                       + "WHERE PLANTCODE = '" + cboIPlantcode.Text + "'"
                        + " AND MAJORCODE = '" + cboIMajorCode.Text + "'";
                dt = func.GetDataTable2(strqry);
                dataGridView2.DataSource = dt;

                MessageBox.Show("입력되었습니다!");

                // 입력칸 초기화
                cboclear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Do_Delete()
        {
            try
            {
                strqry = "DELETE FROM TB_CODE_MST "
                        + "WHERE PLANTCODE = '" + dataGridView2.SelectedCells[0].Value.ToString() + "'"
                         + " AND MAJORCODE = '" + dataGridView2.SelectedCells[1].Value.ToString() + "'"
                         + " AND MINORCODE = '" + dataGridView2.SelectedCells[2].Value.ToString() + "'";
                da = new SqlDataAdapter();
                da.DeleteCommand = new SqlCommand(strqry, sql.con);
                da.DeleteCommand.ExecuteNonQuery();
                
                //재조회
                Do_Search();

                MessageBox.Show("삭제되었습니다!");

                // 입력칸 초기화
                cboclear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Do_Save()
        {
            string message = "다음 항목을 입력해 주세요";
            if (cboIPlantcode.Text == "") message += "\n공장";
            if (cboIMajorCode.Text == "") message += "\n주코드";
            if (txtIMajorName.Text == "") message += "\n주코드명";
            if (cboIMinorCode.Text == "") message += "\n부코드";
            if (txtIMinorName.Text == "") message += "\n부코드명";
            if (txtIDisplayNo.Text == "") message += "\n순서";
            if (message.Length > 14)
            {
                MessageBox.Show(message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            strqry = "UPDATE TB_CODE_MST SET "
                   + "PLANTCODE = '" + cboIPlantcode.Text + "', "
                   + "MAJORCODE = '" + cboIMajorCode.Text + "', "
                   + "RELCODE5  = '" + txtIMajorName.Text + "', "
                   + "MINORCODE = '" + cboIMinorCode.Text + "', "
                   + "CODENAME  = '" + txtIMinorName.Text + "', "
                   + "RELCODE1  = '" + txtIRelCode1.Text  + "', "
                   + "RELCODE2  = '" + txtIRelCode2.Text  + "', "
                   + "RELCODE3  = '" + txtIRelCode3.Text  + "', "
                   + "RELCODE4  = '" + txtIRelCode4.Text  + "', "
                   + "DISPLAYNO = '" + txtIDisplayNo.Text + "', "
                   + "USEFLAG   = '" + cboIUseFlag.Text   + "' "
                   + "WHERE PLANTCODE = '" + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].Value.ToString() + "'"
                     + "AND MAJORCODE = '" + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[1].Value.ToString() + "'"
                     + "AND MINORCODE = '" + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[2].Value.ToString() + "'";
            try
            {
                da = new SqlDataAdapter();
                da.UpdateCommand = new SqlCommand(strqry, sql.con);
                da.UpdateCommand.ExecuteNonQuery();
                
                Do_Search(); //재조회
                
                MessageBox.Show("수정되었습니다!");
                
                cboclear(); // 입력칸 초기화
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboclear()
        {
            cboIPlantcode.Text = "";
            cboIMajorCode.Text = "";
            txtIMajorName.Text = "";
            cboIMinorCode.Text = "";
            txtIMinorName.Text = "";
            txtIDisplayNo.Text = "";
            cboIUseFlag.SelectedIndex = 0;
            txtIRelCode1.Text = "";
            txtIRelCode2.Text = "";
            txtIRelCode3.Text = "";
            txtIRelCode4.Text = "";
        }
        #endregion

        // MAJORCODE 클릭 시 MINORCODE, CODENAME 조회
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dt = new DataTable();
                string majorcode;
                majorcode = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();

                strqry = "SELECT * FROM TB_CODE_MST "
                //strqry = "SELECT PLANTCODE, MINORCODE, CODENAME, RELCODE1, RELCODE2, RELCODE3, RELCODE4, DISPLAYNO, USEFLAG, CREATE_USERID, CREATE_DT, MODIFY_USERID, MODIFY_DT FROM TB_CODE_MST "
                        + "WHERE MAJORCODE = '" + majorcode + "' "
                        + "ORDER BY DISPLAYNO";

                dt = func.GetDataTable2(strqry);
                dataGridView2.DataSource = dt;

                cboPlantCode.SelectedItem = "D001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboIPlantcode.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            cboIMajorCode.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtIMajorName.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            cboIMinorCode.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtIMinorName.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtIDisplayNo.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            cboIUseFlag.Text   = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtIRelCode1.Text  = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtIRelCode2.Text  = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtIRelCode3.Text  = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtIRelCode4.Text  = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        #region ========== 콤보박스
        private void CboSet()
        {
            cboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearch.Items.Add("주코드");
            cboSearch.Items.Add("부코드");
            cboSearch.Items.Add("코드명");
            cboSearch.SelectedIndex = 0;
            func.CboLoad(cboIPlantcode, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            func.CboLoad(cboIMajorCode, "TB_CODE_MST", "MAJORCODE", false);
            func.CboLoad(cboIUseFlag,   "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "USEFLAG");
            cboIPlantcode.SelectedIndex = 0;
            cboIUseFlag.SelectedIndex = 0;
        }

        private void cboIMajorCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string SelectItem = cboIMajorCode.SelectedItem.ToString();
                dt = new DataTable();
                strqry = "SELECT DISTINCT RELCODE5 FROM TB_CODE_MST "
                       + "WHERE MAJORCODE = '" + SelectItem + "'";
                dt = func.GetDataTable(strqry);
                txtIMajorName.Text = dt.Rows[0].ItemArray[0].ToString();

                func.CboLoad(cboIMinorCode, "TB_CODE_MST", "MINORCODE", false, "MAJORCODE", SelectItem);
                cboIMinorCode.Text = "";
                txtIMinorName.Text = "";
                txtIDisplayNo.Text = "";
                cboIUseFlag.SelectedIndex = 0;
                txtIRelCode1.Text = "";
                txtIRelCode2.Text = "";
                txtIRelCode3.Text = "";
                txtIRelCode4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboIMinorCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                strqry = "SELECT CODENAME FROM TB_CODE_MST "
                       + "WHERE MINORCODE = '" + cboIMinorCode.SelectedItem.ToString() + "'";
                dt = func.GetDataTable(strqry);
                txtIMinorName.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Do_Search();
        }
    }
}