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
        SqlDataAdapter da;
        DataTable dt;
        

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

        private void DGVLoad() // 작업지시
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "LINE_CD", "PROC_CD", "PROC_SEQ", "STEP_CD", "INCOMDE", "WORK_START", "LOTNO", "WORK_END", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText = new string[] { "공장", "라인번호", "공정", "공정순서", "작업", "INCOMDE", "WORK_START", "LOTNO", "WORK_END", "등록자", "등록일시", "수정자", "수정일시" };
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;

        }

        private void CboSet()
        {
            func.CboLoad(cboProc, "TB_PROC_SEQ", "PROC_CD", false);
        }

        private void ChangeValue()
        {
            dt = GetDataTable(strqry);
            foreach (DataRow dr in dt.Rows)
                if (dr["PROC_CD"].ToString() == "010")
                {
                    dr["PROC_CD"] = "트랙적재";
                }
                else if(dr["PROC_CD"].ToString() == "020")
                {
                    dr["PROC_CD"] = "부품조립";
                }
                else if(dr["PROC_CD"].ToString() == "020")
                {
                    dr["PROC_CD"] = "검사공정";
                }
        }

        public DataTable GetDataTable(string Query)
        {
            da = new SqlDataAdapter(Query, sql.con);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
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
            ChangeValue();

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
