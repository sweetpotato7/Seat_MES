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
    public partial class PROC_ASSEM_조립공정_ : Form
    {
        SQL sql = new SQL();
        string strqry = string.Empty;
        Function func = new Function();

        public PROC_ASSEM_조립공정_()
        {
            InitializeComponent();
        }

        public void ProcSeq_dv()
        {
            //DGVLoad_ProcSeq();
            string proc_cd = "020";
            strqry = "select PROC_SEQ, STEP_CD, STEP_NAME from TB_PROC_SEQ WHERE PROC_CD =" + "'" + proc_cd + "'" + "";
            dataGridView3.DataSource = func.GetDataTable(strqry);
        }
        public void Plan_dv()
        {
            string Date = DateTime.Now.ToString("M/d/yyyy");
            DGVLoad_Plan();
            strqry = "select * from TB_PLAN_DET WHERE ORDERNO =" + "'" + /*Date*/ "20211005004" + "'" + "";
            dataGridView4.DataSource = func.GetDataTable(strqry);
        }

        private void DGVLoad_Plan()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "PLANSEQ", "ORDERNO", "SUBSEQ", "SIDE", "LOTNO", "ITEMCODE", "INDATE", "PRODDATE", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText = new string[] { "공장", "계획수량", "주문번호", "순서", "타입", "LOTNO", "품번", "INDATE", "PRODDATE", "생성자", "생성일시", "수정자", "수정일시" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView4, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView4.ReadOnly = true;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.RowHeadersVisible = true;
        }

        private void DGVLoad_ProcSeq()
        {
            string[] DataPropertyName = new string[] { "PROC_SEQ", "STEP_CD", "STEP_NAME" };
            string[] HeaderText = new string[] { "순서", "작업코드", "작업" };
            float[] FillWeight = new float[] { 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView3, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView3.ReadOnly = true;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.RowHeadersVisible = true;
        }

        private void PROC_ASSEM_조립공정__Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.Name = "작업완료";
            dataGridView3.Columns.Add(check);
            sql.con.Open();
            ProcSeq_dv();
            Plan_dv();
            timer1_Tick(sender, e);
            timer1.Interval = 5000; // 5초간격
            timer1.Start();
        }

        // 작업지시 타이머(자동새로고침)
        private void timer1_Tick(object sender, EventArgs e)
        {
            DGVLoad_Plan();
            strqry = "select * from TB_PLAN_MST";
            dataGridView4.DataSource = func.GetDataTable(strqry);
        }

        // 체크박스 체크시 셀 색변환
        private void dataGridView3_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(row.Cells["작업완료"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Blue;
                }

                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        // 셀 색변환 바로 적용
        private void dataGridView3_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dataGridView3.IsCurrentCellDirty)
                dataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
