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
using System.IO;


namespace MESProject.공정관리
{
    public partial class PROC_MST_공정관리_ : Form
    {
        SQL sql = new SQL();
        string strqry = string.Empty;
        string strqry2 = string.Empty;
        Function func = new Function();

        public PROC_MST_공정관리_()
        {
            InitializeComponent();
        }

        public void Do_Search()
        {
            Plan_dv();
            ProcSeq_dv();
        }

        public void ProcSeq_dv()
        {
            DGVLoad_ProcSeq();
            string proc_cd = "010";
            strqry = "select PROC_SEQ, STEP_CD, STEP_NAME from TB_PROC_SEQ WHERE PROC_CD =" + "'" + proc_cd + "'" + "";
            dataGridView3.DataSource = func.GetDataTable(strqry);
        }

        public void Plan_dv() // 오늘날짜만 조회
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            DGVLoad_Plan();
            strqry = "select * from TB_PLAN_DET where PROC_TRACK is null and CREATE_DT >= " + "'" + today + "'" + "ORDER BY ORDERNO, SUBSEQ, SIDE";
            dataGridView4.DataSource = func.GetDataTable(strqry);

            for (int i = 1; i < dataGridView4.Rows.Count + 1; i++)
            {
                if (i == 1)
                {
                    dataGridView4.Rows[0].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dataGridView4.Rows[i - 1].DefaultCellStyle.BackColor = Color.Gray;
                }
            }

        }

        private void DGVLoad_Plan()
        {
            string[] DataPropertyName = new string[] { "PROC_TRACK", "PLANTCODE", "PLANSEQ", "ORDERNO", "SUBSEQ", "SIDE", "LOTNO", "ITEMCODE", "INDATE", "PRODDATE", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT", "CHK", "PROC_ASSEM", "PRODDATE" };
            string[] HeaderText = new string[] { "완료", "공장", "순서", "주문번호", "작업순서", "타입", "LOTNO", "품번", "INDATE", "PRODDATE", "생성자", "생성일시", "수정자", "수정일시", "CHK", "PROC_ASSEM", "PRODDATE" };
            float[] FillWeight = new float[] { 65, 80, 65, 190, 100, 65, 240, 90, 100, 100, 100, 100, 100, 100, 10, 10, 10 };
            string[] HiddenColumn = new string[] { "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT", "CHK", "PROC_ASSEM", "PRODDATE", "INDATE" };
            Font StyleFont = new Font("맑은고딕", 22, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 20, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Function.DGVSetting(this.dataGridView4, DataPropertyName, 40, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 19);
            dataGridView4.ReadOnly = true;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.RowHeadersVisible = true;
            dataGridView4.RowTemplate.Height = 40;
        }

        private void DGVLoad_ProcSeq()
        {
            string[] DataPropertyName = new string[] { "CHK","PROC_SEQ", "STEP_CD", "STEP_NAME"};
            string[] HeaderText = new string[] { "작업완료","순서", "작업코드", "작업"};
            float[] FillWeight = new float[] { 40, 100, 100, 100};
            Font StyleFont = new Font("맑은고딕", 22, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 20, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Function.DGVSetting(this.dataGridView3, DataPropertyName, 40, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 17);
            //dataGridView3.ReadOnly = true;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.RowHeadersVisible = true;
        }

        private void PROC_MST_공정관리__Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            //DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            //check.Name = "작업완료";
            //dataGridView3.Columns.Add(check);
            DGVLoad_ProcSeq();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            sql.con.Open();
            ProcSeq_dv();
            Plan_dv();
            //dv_item_mst();
            
            // 초기 라벨 초기화
            label5.Text = "--";
            label8.Text = "--";
            label18.Text = "--";
            label10.Text = "--";
            label14.Text = "--";
            label16.Text = "--";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            timer1_Tick(sender, e);
            timer1.Interval = 5000; // 5초간격
            timer1.Start();
        }

        // 작업지시 타이머(자동새로고침)
        private void timer1_Tick(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            DGVLoad_Plan();
            strqry = "select * from TB_PLAN_DET where PROC_TRACK is null and CREATE_DT >= " + "'" + today + "'" + "ORDER BY ORDERNO, SUBSEQ, SIDE";
            dataGridView4.DataSource = func.GetDataTable(strqry);
            Cell_Lock();
        }

        // 체크박스 체크시 셀 색변환
        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool check = Convert.ToBoolean(dataGridView3.Rows[0].Cells[0].Value);
                bool check2 = Convert.ToBoolean(dataGridView3.Rows[1].Cells[0].Value);
                int i;
                i = dataGridView3.SelectedCells[0].RowIndex;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["CHK"].Value) == true)
                    {
                        row.DefaultCellStyle.BackColor = Color.Blue;
                    }

                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }

                if (check == true && check2 == true)
                {
                    string lotno;
                    string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    lotno = dataGridView4.Rows[0].Cells[8].Value.ToString();
                    strqry = "update TB_PLAN_DET set PROC_TRACK = 1, INDATE =" + "'" + today + "'" + ", MODIFY_DT = " + "'" + today + "'" + ", MODIFY_USERID =" + "'" + Main.ID + "'"
                            + "where ORDERNO =" + "'" + label10.Text + "'" + "and SIDE =" + "'" + label14.Text + "'" + "and LOTNO =" + "'" + label16.Text + "'" + "";
                    dataGridView3.DataSource = func.GetDataTable(strqry);
                    MessageBox.Show(label16.Text + " " + label14.Text + "의 작업이 완료되었습니다.");
                    ProcSeq_dv();
                    Plan_dv();
                }

                if (check == true)
                {
                    string orderno = dataGridView4.Rows[0].Cells[5].Value.ToString();
                    strqry2 = "update TB_PLAN_MST set PLANFLAG = 'I' where ORDERNO =" + "'" + orderno + "'" + "";
                    func.GetDataTable(strqry2);
                }
            }
            catch
            {
                
            }
        }

        // 셀 색변환 바로 적용
        private void dataGridView3_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView3.IsCurrentCellDirty)
                dataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dv_item_mst();
                int i;
                i = dataGridView4.SelectedCells[0].RowIndex;

                label10.Text = dataGridView4.Rows[0].Cells[5].Value.ToString(); // ORDERNO
                label14.Text = dataGridView4.Rows[0].Cells[7].Value.ToString(); // TYPE
                label16.Text = dataGridView4.Rows[0].Cells[8].Value.ToString(); // LOTNO
                label7.Text  = dataGridView1.Rows[0].Cells[0].Value.ToString(); // 차종

                strqry = "select ALC_CD from TB_PLAN_MST where ORDERNO =" + "'" + label10.Text + "'" + "";
                dataGridView1.DataSource = func.GetDataTable(strqry);

                if (e.RowIndex >= 1)
                {
                    MessageBox.Show("이전 작업을 완료해주세요.");
                    dataGridView4.Rows[0].Selected = true;
                }

                if (dataGridView4.Rows[0].Cells[0].Selected == true)
                {
                    MessageBox.Show("공정작업을 완료해주세요.");
                }

                string side   = dataGridView4.Rows[0].Cells[7].Value.ToString();
                string cutalc = dataGridView4.Rows[0].Cells[9].Value.ToString().Substring(0, 2);

                strqry = "select * from TB_SPEC where ITEMCODE =" + "'" + cutalc + side + "'" + "";
                dataGridView2.DataSource = func.GetDataTable(strqry);

                label8.Text  = dataGridView2.Rows[0].Cells[4].Value.ToString(); // 지역
                label5.Text  = dataGridView2.Rows[0].Cells[5].Value.ToString(); // 트랙
                label18.Text = dataGridView2.Rows[0].Cells[6].Value.ToString(); // 커버
                label7.Text  = dataGridView2.Rows[0].Cells[2].Value.ToString(); // 차종

                string head = dataGridView2.Rows[0].Cells[7].Value.ToString();
                string sab  = dataGridView2.Rows[0].Cells[9].Value.ToString();

                if (head == "O") label4.BackColor = Color.Blue;
                if (head == "X") label4.BackColor = Color.White;
                if (sab  == "O") label6.BackColor = Color.Blue;
                if (sab  == "X") label6.BackColor = Color.White;
            }
            catch
            {
            }
        }

        
        private void Cell_Lock() // 셀잠금
        {
            for (int i = 1 ; i < dataGridView4.Rows.Count + 1; i++)
            {
                if(i==1)
                {
                    dataGridView4.Rows[0].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dataGridView4.Rows[i-1].DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        public void Plan_Mst()
        {
            strqry = "select ALC_CD from TB_PLAN_MST where ORDERNO =" + "'" + label10.Text + "'" + "";
            dataGridView1.DataSource = func.GetDataTable(strqry);
        }

        private void dataGridView4_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Cell_Lock();
        }

        public void Spec()
        {
            string side   = dataGridView4.Rows[0].Cells[7].Value.ToString();
            string cutalc = dataGridView4.Rows[0].Cells[9].Value.ToString().Substring(0, 2);

            strqry = "select * from TB_SPEC where ITEMCODE =" + "'" + cutalc + side + "'" + "";
            dataGridView2.DataSource = func.GetDataTable(strqry);
        }

        private void dv_item_mst()
        {
            try
            {
                string itemtype = dataGridView4.Rows[0].Cells[7].Value.ToString();
                strqry = "select TOP 1 IMAGE from TB_ITEM_MST where ITEMNAME =" + "'" + itemtype + "'" + "";
                dataGridView5.DataSource = func.GetDataTable(strqry);

                var picture = dataGridView5.Rows[0].Cells[0].Value.ToString();

                DataTable dt = dataGridView5.DataSource as DataTable;
                if (picture != string.Empty)
                {
                    DataRow row = dt.Rows[0];
                    pictureBox1.Image = ConvertByteToImage((byte[])row[0]);
                }
                if (picture == string.Empty)
                {
                    pictureBox1.Image = null;
                }
            }
            catch
            {

            }
        }

        private Image ConvertByteToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void update_flag()
        {
            string orderno = dataGridView2.Rows[0].Cells[5].Value.ToString();
            string indate = dataGridView2.Rows[0].Cells[10].Value.ToString();
            if (indate != null)
            {
                strqry = "update TB_PLAN_MST set PLANFLAG = 'I' where  ";
                dataGridView1.DataSource = func.GetDataTable(strqry);
            }
        }
    }
}

// 작업지시 데이터 타이머설정(자동새로고침) // 완료
// 
