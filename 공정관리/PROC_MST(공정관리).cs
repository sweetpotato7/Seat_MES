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
    public partial class PROC_MST_공정관리_ : Form
    {
        SQL sql = new SQL();
        string strqry = string.Empty;
        Function func = new Function();

        public PROC_MST_공정관리_()
        {
            InitializeComponent();
        }

        public void ProcSeq_dv()
        {
            DGVLoad_ProcSeq();
            string proc_cd = "010";
            strqry = "select PROC_SEQ, STEP_CD, STEP_NAME from TB_PROC_SEQ WHERE PROC_CD =" + "'" + proc_cd + "'" + "";
            dataGridView3.DataSource = func.GetDataTable(strqry);
        }

        private void DGVLoad_ProcSeq()
        {
            string[] DataPropertyName = new string[] { "PROC_SEQ", "STEP_CD", "STEP_NAME", "RESULT"};
            string[] HeaderText = new string[] { "순서", "작업코드", "작업", "결과"};
            float[] FillWeight = new float[] { 100, 100, 100, 100};
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView3, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView3.ReadOnly = true;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.RowHeadersVisible = true;
        }

        private void PROC_MST_공정관리__Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            ProcSeq_dv();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView3.SelectedCells[0].RowIndex;
            dataGridView3.Rows[i].Cells[3].Value.ToString();
            // 셀 더블 클릭 시 결과 셀에 "완료" 입력

        }
    }
}
