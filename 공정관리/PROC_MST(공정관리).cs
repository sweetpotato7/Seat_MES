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

        public void Spec_dv()
        {
            DGVLoad_Spec();
            strqry = "select * from TB_SPEC";
            dataGridView2.DataSource = func.GetDataTable(strqry);
        }

        public void ProcSeq_dv()
        {
            DGVLoad_ProcSeq();
            strqry = "select * from TB_PROC_SEQ";
            dataGridView3.DataSource = func.GetDataTable(strqry);
        }

        private void DGVLoad_Spec()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "CARCODE", "SEATTYPE", "SPEC1", "SPEC2", "SPEC3", "SPEC4", "SPEC5", "SPEC6", "LOTNO", "USEFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText = new string[] { "공장코드", "품번", "차종", "시트타입", "지역", "트랙", "시트", "헤드레스트", "색상", "SAB", "사용여부", "고유번호", "등록자", "등록일시", "수정자", "수정일시" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.RowHeadersVisible = false;
        }

        private void DGVLoad_ProcSeq()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "LINE_CD", "PROC_CD", "PROC_NAME", "STEP_CD", "STEP_NAME", "PROC_SEQ", "INCOMDE", "WORK_START", "LOTNO", "WORK_END", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText = new string[] { "공장", "라인번호", "공정코드", "공정", "작업코드", "작업", "작업순서", "INCOMDE", "WORK_START", "LOTNO", "WORK_END", "등록자", "등록일시", "수정자", "수정일시" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
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
            Spec_dv();
            ProcSeq_dv();
        }
    }
}
