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


namespace MESProject.공정관리
{
    public partial class PROC_SEQ_공정순서관리_ : Form
    {
        SQL sql = new SQL();
        string strqry = string.Empty;
        Function func = new Function();

        public PROC_SEQ_공정순서관리_()
        {
            InitializeComponent();
        }

        private void PROC_SEQ_공정순서관리__Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            DGVLoad();
            Do_Search();
            CboSet();
        }

        private void DGVLoad() 
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "LINE_CD", "PROC_CD", "PROC_NAME", "STEP_CD", "STEP_NAME", "PROC_SEQ", "INCOMDE", "WORK_START", "LOTNO", "WORK_END", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText = new string[] { "공장", "라인번호", "공정코드", "공정", "작업코드", "작업", "작업순서", "INCOMDE", "WORK_START", "LOTNO", "WORK_END", "등록자", "등록일시", "수정자", "수정일시" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100};
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = true;
        }

        private void CboSet()
        {
            func.CboLoad(cboPlant, "TB_PROC_SEQ", "PLANTCODE", false);
            func.CboLoad(cboLine, "TB_PROC_SEQ", "LINE_CD", false);
            func.CboLoad(cboProc, "TB_PROC_SEQ", "PROC_CD", false);
            func.CboLoad(cboPlantCode, "TB_PROC_SEQ", "PLANTCODE", false);
            func.CboLoad(cboLineNum, "TB_PROC_SEQ", "LINE_CD", false);
            func.CboLoad(cboProcCode, "TB_PROC_SEQ", "PROC_CD", false);
            func.CboLoad(cboProcName, "TB_PROC_SEQ", "PROC_NAME", false);
            func.CboLoad(cboStepCode, "TB_PROC_SEQ", "STEP_CD", false);
            func.CboLoad(cboStepName, "TB_PROC_SEQ", "STEP_NAME", false);
            cboPlant.Text = "D100";
            cboLine.Text = "1";
        }
        
        public void Do_Search()
        {
            string Proc = cboProc.Text;

            if (cboProc.Text == "")
            {
                strqry = "select * from TB_PROC_SEQ";
                dataGridView1.DataSource = func.GetDataTable(strqry);
            }

            else
            {
                strqry = "select * from TB_PROC_SEQ where PROC_CD =" + "'" + cboProc.Text + "'";
                dataGridView1.DataSource = func.GetDataTable(strqry);
            }
            // 공정추가
            // 추가 시 순서중복 방지
            // 공정번호 중복방지
            // 작업번호 중복방지
            // 기타 중복방지 
        }

        public void Do_Insert()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO TB_PROC_SEQ (PLANTCODE, LINE_CD, PROC_CD, PROC_NAME, STEP_CD, STEP_NAME, PROC_SEQ) VALUES"
                + "('" + cboPlantCode.Text + "','"
                + cboLineNum.Text + "','"
                + cboProcCode.Text + "','"
                + cboProcName.Text + "','"
                + cboStepCode.Text + "','"
                + cboStepName.Text + "','"
                + txtProcSeq.Text + "')";
            cmd.ExecuteNonQuery();

            cboLineNum.Text  = "";
            cboProcCode.Text = "";
            cboProcName.Text = "";
            cboStepCode.Text = "";
            cboStepName.Text = "";
            txtProcSeq.Text  = "";
            Do_Search();

            MessageBox.Show("추가되었습니다.");
        }

        public void Do_Delete()
        {
            string proc_cd;
            string step_cd;

            proc_cd = dataGridView1.SelectedCells[2].Value.ToString();
            step_cd = dataGridView1.SelectedCells[4].Value.ToString();

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from TB_PROC_SEQ where PROC_CD = " + "'" + proc_cd + "'" + "AND STEP_CD = " + "'" + step_cd + "'" + "";
            cmd.ExecuteNonQuery();
            
            cboLineNum.Text = "";
            cboProcCode.Text = "";
            cboProcName.Text = "";
            cboStepCode.Text = "";
            cboStepName.Text = "";
            txtProcSeq.Text = "";
            Do_Search();
            MessageBox.Show("삭제되었습니다.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;

            cboPlantCode.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cboLineNum.Text   = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cboProcCode.Text  = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cboProcName.Text  = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cboStepCode.Text  = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cboStepName.Text  = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtProcSeq.Text   = dataGridView1.Rows[i].Cells[6].Value.ToString();

        }

    }
}
