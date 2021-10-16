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
        Function func = new Function();
        string strqry = string.Empty;
        SQL sql = new SQL();
        DataTable dt;
        SqlDataAdapter da;
        SqlTransaction transaction;

        public PROC_RST()
        {
            InitializeComponent();
        }

        private void PROC_RST_Load(object sender, EventArgs e)
        {
            func.CboLoad(cboPlantCode, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            cboPlantCode.SelectedIndex = 0;
            DGVLoad();
            Do_Search();
            SetChart();
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

        public void Do_Search()
        {
            strqry = "SELECT * FROM TB_PROC_RST"
                   + " WHERE PLANTCODE = '" + cboPlantCode.Text + "'"
                   + " AND PROC_RST  between '" + dtDate.Value.ToString("yy-MM-dd") + "'"
                                      + "and '" + dtDate.Value.ToString("yy-MM-dd") + " 23:59:59'";
            dt = func.GetDataTable2(strqry);
            dataGridView1.DataSource = dt;
            
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            Do_Search();
        }

        // 차트 만들기
        // 당일 생산 비율( 계획량 / 완료량) 도넛형식, 퍼센트
        // 주간 생산 숫자
        public void SetChart()
        {
            chart1.Series[0].ChartType = SeriesChartType.Doughnut;
            chart1.Legends.Clear();
            chart1.Titles.Add("진행도");
            chart1.Titles[0].Font = new Font("굴림", 17, FontStyle.Bold);
            // 하나는 전체 계획수 하나는 완료수
            // 전체계획수 - 완료수 = 빈공간
            // 완료수 / 전체계획수 = 중간 퍼센트
            chart1.Series[0].Points.Add(60); // 완료수
            chart1.Series[0].Points.Add(40); // 빈공간
            chart1.Invalidate();


        }

        private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is ChartArea)
            {
                var ta = new TextAnnotation();
                string stxt = "50";
                ta.Text = stxt + "%";
                ta.Width  = e.Position.Width;
                ta.Height = e.Position.Height;
                ta.X = e.Position.X;
                ta.Y = e.Position.Y + 1;
                ta.Font = new Font("굴림", 15, FontStyle.Bold);

                chart1.Annotations.Add(ta);
            }
        }
    }
}
