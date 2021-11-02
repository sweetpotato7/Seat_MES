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
    public partial class PROC_ASSEM_조립공정_ : Form
    {
        SQL sql = new SQL();
        string strqry = string.Empty;
        string strqry2 = string.Empty;
        string strqry3 = string.Empty;
        Function func = new Function();

        public PROC_ASSEM_조립공정_()
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
            string proc_cd = "020";
            strqry = "select PROC_SEQ, STEP_CD, STEP_NAME from TB_PROC_SEQ WHERE PROC_CD =" + "'" + proc_cd + "'" + "";
            dataGridView3.DataSource = func.GetDataTable(strqry);
        }

        public void Plan_dv()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            DGVLoad_Plan();
            strqry = "select * from TB_PLAN_DET where PROC_TRACK = 1 AND PROC_ASSEM is null and CREATE_DT >=" + "'" + today + "'" + "ORDER BY ORDERNO, SUBSEQ, SIDE";
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
            string[] DataPropertyName = new string[] { "PROC_ASSEM", "PLANTCODE", "PLANSEQ", "ORDERNO", "SUBSEQ", "SIDE", "LOTNO", "ITEMCODE", "INDATE", "PRODDATE", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT", "CHK", "PROC_TRACK" };
            string[] HeaderText = new string[] { "완료", "공장", "순서", "주문번호", "작업순서", "타입", "LOTNO", "품번", "INDATE", "PRODDATE", "생성자", "생성일시", "수정자", "수정일시", "1", "2" };
            string[] HiddenColumn = new string[] { "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT", "CHK", "PROC_TRACK", "PRODDATE", "INDATE" };
            float[] FillWeight = new float[] { 65, 80, 65, 190, 100, 65, 240, 90, 100, 200, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 22, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 20, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView4, DataPropertyName, 40, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 18);
            dataGridView4.ReadOnly = true;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.RowHeadersVisible = true;
            dataGridView4.RowTemplate.Height = 40;
        }

        private void DGVLoad_ProcSeq()
        {
            string[] DataPropertyName = new string[] { "CHK","PROC_SEQ", "STEP_CD", "STEP_NAME" };
            string[] HeaderText = new string[] { "작업완료", "순서", "작업코드", "작업" };
            float[] FillWeight = new float[] { 40, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 22, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 20, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView3, DataPropertyName, 40, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 17);
            //dataGridView3.ReadOnly = true;
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
            DGVLoad_ProcSeq(); 
            sql.con.Open();
            ProcSeq_dv();
            Plan_dv();
            //dv_item_mst();

            // 라벨 초기화
            label5.Text = "--";
            label7.Text = "--";
            label8.Text = "--";
            label10.Text = "--";
            label14.Text = "--";
            label16.Text = "--";
            label18.Text = "--";

            timer1_Tick_1(sender, e);
            timer1.Interval = 5000; // 5초간격
            timer1.Start();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


        }

        // 체크박스 체크시 셀 색변환
        private void dataGridView3_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            bool check  = Convert.ToBoolean(dataGridView3.Rows[0].Cells[0].Value);
            bool check2 = Convert.ToBoolean(dataGridView3.Rows[1].Cells[0].Value);
            bool check3 = Convert.ToBoolean(dataGridView3.Rows[2].Cells[0].Value);

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

            try
            {
                if (check == true && check2 == true && check3 == true)
                {
                    string today    = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string orderno  = dataGridView4.Rows[0].Cells[5].Value.ToString();
                    string lotno    = dataGridView4.Rows[0].Cells[8].Value.ToString();
                    string procseq  = dataGridView4.Rows[0].Cells[6].Value.ToString();

                    strqry = "update TB_PLAN_DET set PROC_ASSEM = 1, PRODDATE =" + "'" + today + "'" + ", MODIFY_DT =" + "'" + today + "'" + ", MODIFY_USERID =" + "'" + Main.ID + "'"
                            + "where LOTNO =" + "'" + label16.Text + "'" + "";
                    dataGridView3.DataSource = func.GetDataTable(strqry);
                
                    // RH일때 수량 +1
                    if (label14.Text == "RH")
                    {
                        strqry = "update TB_PLAN_MST " +
                                    "set PRODQTY = PRODQTY + 1 " +
                                  "where ORDERNO = '" + orderno + "'";
                        func.GetDataTable(strqry);
                    }

                    if (label14.Text == "LH")
                    {
                        func.GetDataTable(strqry);
                    }

                    strqry = "insert into TB_PROC_RST (PLANTCODE, LINE_CD, LOTNO, PROC_CD, PROC_SEQ, PROC_RST, CREATE_USERID) " +
                            "VALUES ('D100', '1', " + "'" + lotno + "'" + ", '010'," + "'" + procseq + "'" + "," + "'" + today + "'" + ", '" + Main.ID + "')";
                    func.GetDataTable(strqry);

                    strqry = "update TB_PLAN_DET set CHK = 1 where LOTNO =" + "'" + label16.Text + "'" + "";
                    dataGridView3.DataSource = func.GetDataTable(strqry);

                    MessageBox.Show(label16.Text + " " + label14.Text + "의 작업이 완료되었습니다.");
                    ProcSeq_dv();
                    Plan_dv();

                    strqry = "select * from TB_PLAN_MST where ORDERNO =" + "'" + label10.Text + "'" + "";
                    dataGridView6.DataSource = func.GetDataTable(strqry);

                    string planqty = dataGridView6.Rows[0].Cells[5].Value.ToString();
                    string prodqty = dataGridView6.Rows[0].Cells[6].Value.ToString();
                    if (planqty == prodqty)
                    {
                        strqry = "update TB_PLAN_MST set PLANFLAG = 'C' where ORDERNO =" + "'" + orderno + "'" + "";
                        func.GetDataTable(strqry);
                    }
                }
            }
            catch
            {
            }
        }

        // 셀 색변환 바로 적용
        private void dataGridView3_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dataGridView3.IsCurrentCellDirty)
                dataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    
                    using (MemoryStream ms = new MemoryStream((byte[])row[0]))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                if (picture == string.Empty)
                {
                    pictureBox1.Image = null;
                }
            }
            catch
            {
            }

            int i;
            i = dataGridView4.SelectedCells[0].RowIndex;

            label10.Text = dataGridView4.Rows[0].Cells[5].Value.ToString(); // ORDERNO
            label14.Text = dataGridView4.Rows[0].Cells[7].Value.ToString(); // TYPE
            label16.Text = dataGridView4.Rows[0].Cells[8].Value.ToString(); // LOTNO

            strqry = "select ALC_CD from TB_PLAN_MST where ORDERNO =" + "'" + label10.Text + "'" + "";
            dataGridView1.DataSource = func.GetDataTable(strqry);

            //label7.Text = dataGridView1.Rows[0].Cells[0].Value.ToString(); // 차종

            if (e.RowIndex >= 1)
            {
                MessageBox.Show("이전 작업을 완료해주세요.");
                dataGridView4.Rows[0].Selected = true;
            }

            if (dataGridView4.Rows[0].Cells[0].Selected == true)
            {
                MessageBox.Show("공정작업을 완료해주세요.");
            }

            string side;
            string cutalc;
            side   = dataGridView4.Rows[0].Cells[7].Value.ToString();
            cutalc = dataGridView4.Rows[0].Cells[9].Value.ToString().Substring(0, 2);

            strqry = "select * from TB_SPEC where ITEMCODE =" + "'" + cutalc + side + "'" + "";
            dataGridView2.DataSource = func.GetDataTable(strqry);

            label8.Text  = dataGridView2.Rows[0].Cells[4].Value.ToString();
            label5.Text  = dataGridView2.Rows[0].Cells[5].Value.ToString();
            label18.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
            label7.Text  = dataGridView2.Rows[0].Cells[2].Value.ToString();

            string head    = dataGridView2.Rows[0].Cells[7].Value.ToString();
            string sab     = dataGridView2.Rows[0].Cells[9].Value.ToString();


            if (head == "O") label4.BackColor = Color.Blue;
            if (head == "X") label4.BackColor = Color.White;
            if (sab  == "O") label6.BackColor = Color.Blue;
            if (sab  == "X") label6.BackColor = Color.White;
        }

        private void Cell_Lock() // 셀잠금
        {
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

        private void dataGridView4_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Cell_Lock();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            DGVLoad_Plan();
            strqry = "select * from TB_PLAN_DET where PROC_TRACK = 1 AND PROC_ASSEM is null and CREATE_DT >=" + "'" + today + "'" + "ORDER BY ORDERNO, SUBSEQ, SIDE";
            dataGridView4.DataSource = func.GetDataTable(strqry);
            Cell_Lock();
        }
    }
}

//private void view_image()
//{
//    Image img = pictureBox1.Image;
//    byte[] arr;
//    ImageConverter converter = new ImageConverter();
//    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

//    string itemname;

//    itemname = dataGridView4.Rows[0].Cells[0].Value.ToString();
//}