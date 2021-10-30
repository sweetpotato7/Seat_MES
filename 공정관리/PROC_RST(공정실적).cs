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
using System.Collections.ObjectModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace MESProject.공정관리
{
    public partial class PROC_RST : Form
    {
        /// PROC_SEQ LOTNO 키 잡아야됨
        /// 

        Function func = new Function();
        string strqry = string.Empty;
        SQL sql = new SQL();
        DataTable dt;
        string sPercent = string.Empty;
        int iYear  = 0;
        int iMonth = 0;

        public PROC_RST()
        {
            InitializeComponent();
        }

        private void PROC_RST_Load(object sender, EventArgs e)
        {
            func.CboLoad(cboPlantCode, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            cboPlantCode.SelectedIndex = 0;
            DGVLoad();
            ChartLoad();
            Do_Search();
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "LINE_CD", "LOTNO", "PROC_CD", "PROC_SEQ", "BARCODENO", "PROC_RST", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "라인", "LOTNO", "공정", "작업순서", "바코드번호", "작업일자", "등록자", "등록일시", "수정자", "수정일시" };
            string[] HiddenColumn     = null;
            float[] FillWeight        = new float[]  { 40, 40, 130, 100, 40, 130, 100, 100, 130, 100, 130 };
            Font StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 14);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #region ========== CRUD
        public void Do_Search()
        {
            strqry = "SELECT * FROM TB_PROC_RST"
                   + " WHERE PLANTCODE = '" + cboPlantCode.Text + "'"
                   + " AND PROC_RST  between '" + dtDate.Value.ToString("yy-MM-dd") + "'"
                                      + "and '" + dtDate.Value.ToString("yy-MM-dd") + " 23:59:59'";
            dt = func.GetDataTable2(strqry);
            dataGridView1.DataSource = dt;
            Chart1Set();
            Chart2Set();
        }
        #endregion

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            Do_Search();
        }

        #region ========== Chart
        private void ChartLoad()
        {
            // 차트 기본 로드
            chart1.Legends.Clear();          // 범례 초기화
            chart1.Titles.Clear();           // 제목 초기화
            chart1.Titles.Add("진행도");     // 제목 추가
            chart1.Titles[0].Font = new Font("굴림", 17, FontStyle.Bold);
            chart2.Titles.Clear();
            chart2.Titles.Add("월간 공정실적");
            chart2.Titles[0].Font = new Font("굴림", 17, FontStyle.Bold);

            // 차트 끝부분 설정
            chart2.ChartAreas[0].AxisX.Interval = 5;
        }

        private void Chart1Set()
        {
            try
            {
                // 값 초기화
                chart1.Series[0].Points.Clear(); 

                // 전체 계획 수
                strqry = "SELECT COUNT(*) FROM TB_PLAN_MST"
                       + " WHERE PLANTCODE = '" + cboPlantCode.Text + "'"
                         + " AND PLANDATE  = '" + dtDate.Value.ToString("yyMMdd") + "'";
                dt = func.GetDataTable2(strqry);
                float all = int.Parse(dt.Rows[0].ItemArray[0].ToString());

                // 완료 계획 수
                strqry += " AND PLANFLAG  = 'C'";
                dt = func.GetDataTable2(strqry);
                float rst = int.Parse(dt.Rows[0].ItemArray[0].ToString());

                // 값 추가
                chart1.Series[0].Points.Add(rst);       // 완료수
                chart1.Series[0].Points.Add(all - rst); // 빈공간

                sPercent = Math.Truncate(rst / all * 100).ToString(); // 퍼센트 값 입력
                
                chart1.Invalidate(); // 그리기
            }
            catch
            {

            }
        }

        private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
        {
            // 퍼센트 글자 추가
            if (e.ChartElement is ChartArea)
            {
                chart1.Annotations.Clear();
                if (sPercent == "NaN") return;
                var ta = new TextAnnotation();
                
                ta.Text = sPercent + "%";
                ta.Width  = e.Position.Width;
                ta.Height = e.Position.Height;
                ta.X = e.Position.X;
                ta.Y = e.Position.Y + 1;
                ta.Font = new Font("굴림", 15, FontStyle.Bold);

                chart1.Annotations.Add(ta);
            }
        }

        private void Chart2Set()
        {
            
            if (iYear == dtDate.Value.Year && iMonth == dtDate.Value.Month) return;

            //월별 일수 가져옴
            iYear    = dtDate.Value.Year;
            iMonth   = dtDate.Value.Month;
            int iDay = DateTime.DaysInMonth((int)iYear, (int)iMonth);
            chart2.Series[0].Points.Clear();

            // 데이터 가져와서 날짜별 순서대로 list에 집어넣기
            strqry = "SELECT PLANDATE, SUM(PRODQTY) AS PRODQTY FROM TB_PLAN_MST "
                    + "WHERE PLANTCODE = '" + cboPlantCode.Text + "' "
                      + "AND PLANDATE LIKE '" + dtDate.Value.ToString("yyMM") + "__' "
                      + "AND PLANFLAG = 'C'"
                    + "GROUP BY PLANDATE";
            dt = func.GetDataTable2(strqry);

            foreach (DataRow dr in dt.Rows)
            {
                bool chk = false;
                for (int i = 1; i < iDay + 1; i++)
                {
                    if ( int.Parse(dr.ItemArray[0].ToString().Substring(4)) == i)
                    {
                        chart2.Series[0].Points.AddXY(int.Parse(dr.ItemArray[0].ToString().Substring(4)), dr.ItemArray[1]);
                        chk = true;
                        break;
                    }
                }
                if (chk == false)
                {
                    chart2.Series[0].Points.AddXY(int.Parse(dr.ItemArray[0].ToString().Substring(4)), 0);
                }
            }
            try
            {
                for (int i = 0; i < iDay; i++)
                {
                    if (chart2.Series[0].Points[i].YValues[0].ToString() == "0")
                    {
                        continue;
                    }
                    chart2.Series[0].Points[i].Label = chart2.Series[0].Points[i].YValues[0].ToString();
                }
            }
            catch
            {
            }
        }
        #endregion
    }
}
