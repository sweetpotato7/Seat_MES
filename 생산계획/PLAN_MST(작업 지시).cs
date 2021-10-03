using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject.생산계획
{
    /// <summary>
    /// DB에 추가해야될 것
    /// INSERT INTO TB_CODE_MST ( PLANTCODE, MAJORCODE, MINORCODE, CODENAME, RELCODE5, DISPLAYNO, USEFLAG) VALUES ( 'D100', 'PLANFLAG', 'C', '생산완료', '계획상태', '3', 'Y')
    /// INSERT INTO TB_CODE_MST ( PLANTCODE, MAJORCODE, MINORCODE, CODENAME, RELCODE5, DISPLAYNO, USEFLAG) VALUES ( 'D100', 'PLANFLAG', 'I', '투입중', '계획상태', '2', 'Y')
    /// INSERT INTO TB_CODE_MST ( PLANTCODE, MAJORCODE, MINORCODE, CODENAME, RELCODE5, DISPLAYNO, USEFLAG) VALUES ( 'D100', 'PLANFLAG', 'R', '계획수립', '계획상태', '1', 'Y')
    
    /// PLANDATE 형식 6자리 변경 (211002)
    /// ALTER TABLE TB_PLAN_MST ALTER COLUMN PLANDATE VARCHAR(6) NOT NULL;
    /// ALTER TABLE TB_PLAN_DET ALTER COLUMN PLANDATE VARCHAR(6) NOT NULL;
    /// </summary>




    public partial class PLAN_MST : Form
    {
        Function func = new Function();
        SQL sql = new SQL();
        SqlDataAdapter da;
        DataTable dt;
        string strqry = string.Empty;

        public PLAN_MST()
        {
            InitializeComponent();
        }

        private void PROC_SEQ_Load(object sender, EventArgs e)
        {
            DGVLoad();
            func.CboLoad(cboALC, "TB_ITEM_MST", "ITEMCODE", false, "ITEMTYPE", "ALC");
            Do_Search();
        }

        private void DGVLoad()
        {
            // DGV1
            string[] DataPropertyName = new string[] { "PLANTCODE", "PLANDATE", "PLANSEQ", "ALC_CD", "PLANQTY", "ORDERNO", "PRODQTY", "PLANFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "날짜", "순서", "ALC", "수량", "작업지시번호", "생산수량", "계획상태", "등록자", "등록일자", "수정자", "수정일자" };
            string[] HiddenColumn     = new string[] { "공장" };
            float[] FillWeight        = new float[] { 40, 100, 40, 100, 40, 130, 40, 40, 100, 130, 100, 130 };
            Font StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 12);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // DGV2 수정!
            DataPropertyName = new string[] { "PLANTCODE", "PLANDATE", "PLANSEQ", "ALC_CD", "PLANQTY", "ORDERNO", "PRODQTY", "PLANFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            HeaderText       = new string[] { "공장", "날짜", "순서", "ALC", "수량", "작업지시번호", "생산수량", "계획상태", "등록자", "등록일자", "수정자", "수정일자" };
            HiddenColumn     = new string[] { "공장" };
            FillWeight       = new float[]  { 40, 100, 40, 100, 40, 130, 40, 40, 100, 130, 100, 130 };
            StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 12);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #region ========== CRUD
        public void Do_Search() // 검색
        {
            strqry = "SELECT * FROM TB_PLAN_MST";
            if (dtDate.Value.ToString("yyMMdd") != DateTime.Now.ToString("yyMMdd"))
            {
                strqry += " WHERE PLANDATE = '" + dtDate.Value.ToString("yyMMdd") + "'";
            }
            strqry += " ORDER BY PLANDATE, PLANSEQ";

            try
            {
                sql.con.Open();
                dt = func.GetDataTable2(strqry);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.con.Close();
            }
        }
        public void Do_Insert()
        {
            string sDate = dtDate.Value.ToString("yyMMdd");
            string sALC  = cboALC.Text;
            int iQty     = int.Parse(txtQty.Text);

            SqlCommand cmd = new SqlCommand("저장프로시저이름", sql.con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PLANDATE", SqlDbType.VarChar, 6).Value  = dtDate.Value.ToString("yyMMdd");
            cmd.Parameters.Add("@ALC_CD",   SqlDbType.VarChar, 20).Value = cboALC.Text;
            cmd.Parameters.Add("@PLANQTY",  SqlDbType.Int).Value         = txtQty.Text;

            //SqlCommand cmd = new SqlCommand("EXEC 프로시저명 값1, 값2", conn);

            cmd.ExecuteNonQuery();

        }
        #endregion

    }
}
