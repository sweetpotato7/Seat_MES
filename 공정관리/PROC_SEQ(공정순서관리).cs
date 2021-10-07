using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void PRODSEQ_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            DGVLoad();
            Do_Search();
        }

        private void DGVLoad() // 작업지시
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "ITEMNAME", "ITEMTYPE", "UNITCODE", "USEFLAG", "IMAGE", "CREATE_DT", "CREATE_USERID", "MODIFY_DT", "MODIFY_USERID" };
            string[] HeaderText = new string[] { "공장", "품목코드", "품목명", "품목타입", "단위", "사용여부", "이미지", "등록일시", "등록자", "수정일시", "수정자" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
        }

        public void Do_Search()
        {
            string Proc = cmbProc.Text;

            if (cmbProc.Text == "")
            {
                strqry = "select * from TB_PROC_SEQ";
                dataGridView1.DataSource = func.GetDataTable(strqry);
            }

            else
            {
                strqry = "select * from TB_PROC_SEQ where PROC_CD =" + "'" + cmbProc.Text + "'";
                dataGridView1.DataSource = func.GetDataTable(strqry);
            }

            // 공정 번호가 아닌 공정 이름으로 출력
            // 작업 번호가 아닌 작업 이름으로 출력
            // 공정번호, 작업번호 콤보박스에서 이름으로 받고 번호로 변환해서 SQL저장
            
            // 공정추가
            // 추가 시 순서중복 방지
            // 공정번호 중복방지
            // 작업번호 중복방지
            // 기타 중복방지 
        }
    }
}
