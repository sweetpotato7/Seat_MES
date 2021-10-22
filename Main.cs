using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MESProject
{
    public partial class Main : Form
    {
        #region ========== 폼 객체
        기준정보.CODE_MST Code_Mst;
        기준정보.ITEM_MST Item_Mst;
        기준정보.BOM Bom;
        기준정보.SPEC_MST Spec_Mst;
        기준정보.USER_ADMIN User_Admin;
        생산계획.PLAN_MST Plan_Mst;
        공정관리.PROC_SEQ_공정순서관리_ Proc_Seq;
        공정관리.PROC_MST_공정관리_ Proc_Mst; // 트랙공정
        공정관리.PROC_ASSEM_조립공정_ Proc_Assem;
        공정관리.PROC_RST Proc_Rst;
        #endregion

        public static string ID; // 로그인 아이디
        
        public Main()
        {
            InitializeComponent();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            ID = "USERID"; // 로그인폼 사용시 삭제

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState     = FormWindowState.Maximized;

            txtVersion.Text = SQL.VerCheck(); // 실행 시 SQL로 버전 받아서 업데이트(SQLSetting에서 받아오기)
            btnImageLoad();
            timer();
            lblStatemsg.Text = $"{ID}님 접속 중";
            TimeUse(); // C# 소코반 코드 참고 사용시간 체크 추가하기 label7?
        }

        #region ========== 탭컨트롤
        private void tabCtrlAdd(Form form, object sender)
        {
            // 중복탭 방지 및 선택 탭으로 이동
            int index = 0;
            foreach (TabPage item in tabControl1.TabPages)
            {
                if (item.Text == sender.ToString())
                {
                    tabControl1.SelectedIndex = index;
                    return;
                }
                index++;
            }

            form.TopLevel = false;
            tabControl1.TabPages.Add(sender.ToString());
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;

            int leng = (form.ToString().Length - 24) / 2;
            int word = leng + 24;
            tabControl1.SelectedTab.Name = form.ToString().Substring(word, leng);

            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        private void 공통코드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Code_Mst = new 기준정보.CODE_MST();
            tabCtrlAdd(Code_Mst, sender);
        }
        private void 품번ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item_Mst = new 기준정보.ITEM_MST();
            tabCtrlAdd(Item_Mst, sender);
        }
        private void bOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bom = new 기준정보.BOM();
            tabCtrlAdd(Bom, sender);
        }
        private void 사양관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spec_Mst = new 기준정보.SPEC_MST();
            tabCtrlAdd(Spec_Mst, sender);
        }
        private void 사용자관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Admin = new 기준정보.USER_ADMIN();
            tabCtrlAdd(User_Admin, sender);
        }
        private void 생산계획ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Plan_Mst = new 생산계획.PLAN_MST();
            tabCtrlAdd(Plan_Mst, sender);
        }
        private void 작업지시ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plan_Mst = new 생산계획.PLAN_MST();
            tabCtrlAdd(Plan_Mst, sender);
        }
        private void 공정순서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proc_Seq = new 공정관리.PROC_SEQ_공정순서관리_();
            tabCtrlAdd(Proc_Seq, sender);
        }
        private void 공정관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Proc_Mst = new 공정관리.PROC_MST_공정관리_();
            tabCtrlAdd(Proc_Mst, sender);
        }
        private void 조립공정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proc_Assem = new 공정관리.PROC_ASSEM_조립공정_();
            tabCtrlAdd(Proc_Assem, sender);
        }
        private void 공정실적ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proc_Rst = new 공정관리.PROC_RST();
            tabCtrlAdd(Proc_Rst, sender);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
                tabControl1.Controls.Remove(tabControl1.SelectedTab);
            else
                return;
        }
        #endregion

        #region ========== CRUD버튼
        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null) return;
            try
            {
                switch (tabControl1.SelectedTab.Name)
                {
                    case "CODE_MST":
                        Code_Mst.Do_Search();
                        break;
                    case "ITEM_MST":
                        Item_Mst.Do_Search();
                        break;
                    case "BOM":
                        Bom.Do_Search();
                        break;
                    case "SPEC_MST":
                        Spec_Mst.Do_Search();
                        break;
                    case "USER_ADMIN":
                        User_Admin.Do_Search();
                        break;
                    case "PROC_SEQ_공정순서관리_":
                        Proc_Seq.Do_Search();
                        break;
                    case "PLAN_MST":
                        Plan_Mst.Do_Search();
                        break;
                    case "PROC_TRACK":
                        Proc_Mst.Do_Search();
                        break;
                    case "PROC_ASSEM":
                        Proc_Assem.Do_Search();
                        break;
                    case "PROC_RST":
                        Proc_Rst.Do_Search();
                        break;
                    default:
                        break;
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null) return;
            try
            {
                switch (tabControl1.SelectedTab.Name)
                {
                    case "CODE_MST":
                        Code_Mst.Do_Insert();
                        break;
                    case "ITEM_MST":
                        Item_Mst.Do_Add();
                        break;
                    case "BOM":
                        Bom.Do_INSERT();
                        break;
                    case "SPEC_MST":
                        Spec_Mst.Do_Add();
                        break;
                    case "USER_ADMIN":
                        User_Admin.Do_Add();
                        break;
                    case "PLAN_MST":
                        Plan_Mst.Do_Insert();
                        break;
                    case "PROC_SEQ_공정순서관리_":
                        Proc_Seq.Do_Insert();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null) return;
            try
            {
                switch (tabControl1.SelectedTab.Name)
                {
                    case "CODE_MST":
                        Code_Mst.Do_Delete();
                        break;
                    case "ITEM_MST":
                        Item_Mst.Do_Delete();
                        break;
                    case "BOM":
                        Bom.Do_Delete();
                        break;
                    case "SPEC_MST":
                        Spec_Mst.Do_Delete();
                        break;
                    case "USER_ADMIN":
                        User_Admin.Do_Delete();
                        break;
                    case "PLAN_MST":
                        Plan_Mst.Do_Delete();
                        break;
                    case "PROC_SEQ_공정순서관리_":
                        Proc_Seq.Do_Delete();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null) return;
            try
            {
                switch (tabControl1.SelectedTab.Name)
                {
                    case "CODE_MST":
                        Code_Mst.Do_Save();
                        break;
                    case "ITEM_MST":
                        Item_Mst.Do_Save();
                        break;
                    case "BOM":
                        Bom.Do_SAVE();
                        break;
                    case "SPEC_MST":
                        Spec_Mst.Do_Save();
                        break;
                    case "USER_ADMIN":
                        User_Admin.Do_Save();
                        break;
                    case "PLAN_MST":
                        Plan_Mst.Do_Save();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImageLoad() // 버튼 이미지
        {
            tabControl1.Controls.Clear();
            btnSearch.Image = Properties.Resources.Search;
            btnInsert.Image    = Properties.Resources.Add;
            btnDelete.Image = Properties.Resources.Delete;
            btnSave.Image   = Properties.Resources.Save;
            btnClose.Image  = Properties.Resources.Close;
            tabPage1.BackgroundImage = Properties.Resources.RYAN;
        }
        #endregion

        #region ========== DGV 셋팅
        public static void DGVSetting(DataGridView Dgv, string[] DataPropertyName, int HeaderHeight, string[] HeaderText, string[] HiddenColumn, float[] FillWeight, Font HeaderStyleFont, Font CellStyleFont, int MaxRow)
        {
            Dgv.DataSource = null;
            Dgv.Rows.Clear();
            Dgv.Columns.Clear();

            Font HeaderCellFont = null;
            Font CellFont = null;

            if (HeaderStyleFont == null) { HeaderCellFont = new Font("HY견고딕", 14F, FontStyle.Bold); }
            else { HeaderCellFont = HeaderStyleFont; }

            if (CellStyleFont == null) { CellFont = new Font("HY견고딕", 12F, FontStyle.Bold); }
            else { CellFont = CellStyleFont; }

            // DataGridView
            Dgv.ReadOnly = false;
            Dgv.EnableHeadersVisualStyles = false;

            Dgv.BorderStyle = BorderStyle.FixedSingle;

            Dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.ScrollBars = ScrollBars.Both;

            Dgv.AllowUserToAddRows       = false;
            Dgv.AllowUserToDeleteRows    = false;
            Dgv.AllowUserToOrderColumns  = false;
            Dgv.AllowUserToResizeColumns = false;
            Dgv.AllowUserToResizeRows    = false;
            Dgv.MultiSelect              = false;

            Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv.AutoSizeRowsMode    = DataGridViewAutoSizeRowsMode.None;

            // Column Header
            Dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Dgv.ColumnHeadersHeight         = HeaderHeight;
            Dgv.ColumnHeadersBorderStyle    = DataGridViewHeaderBorderStyle.Single;
            Dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Empty; // FromArgb(27, 85, 159);
            Dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Empty; //White;
            Dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.ColumnHeadersDefaultCellStyle.Font      = HeaderCellFont;

            // Column
            for (int i = 0; i < DataPropertyName.Length; i++)
            {
                if (DataPropertyName[i] == "CHK" || DataPropertyName[i] == "PROC_TRACK" || DataPropertyName[i] == "PROC_ASSEM")
                {
                    DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn();
                    chkcol.Name             = DataPropertyName[i];
                    chkcol.HeaderText       = HeaderText[i];
                    chkcol.DataPropertyName = DataPropertyName[i];
                    chkcol.FillWeight       = FillWeight[i];
                    chkcol.TrueValue  = 1;
                    chkcol.FalseValue = 0;
                    if (HiddenColumn != null)
                    {
                        for (int j = 0; j < HiddenColumn.Length; j++)
                        {
                            if (chkcol.Name == HiddenColumn[j])
                            {
                                chkcol.Visible = false;
                            }
                        }
                    }
                    Dgv.Columns.Add(chkcol);
                }

                else
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name             = DataPropertyName[i];
                    column.HeaderText       = HeaderText[i];
                    column.DataPropertyName = DataPropertyName[i];
                    column.SortMode         = DataGridViewColumnSortMode.NotSortable;
                    column.FillWeight       = FillWeight[i];
                    column.DefaultCellStyle.SelectionBackColor = Dgv.DefaultCellStyle.BackColor;
                    column.DefaultCellStyle.SelectionForeColor = Dgv.DefaultCellStyle.ForeColor;
                    column.DefaultCellStyle.ForeColor          = Color.Black;
                    column.DefaultCellStyle.Font               = CellFont;
                    column.ReadOnly = true;
                    if (HiddenColumn != null)
                    {
                        for (int j = 0; j < HiddenColumn.Length; j++)
                        {
                            if (column.Name == HiddenColumn[j])
                            {
                                column.Visible = false;
                            }
                        }
                    }
                    Dgv.Columns.Add(column);
                }
            }

            // Row Header
            Dgv.RowHeadersVisible = false;

            // Row 행 높이 이상해서 주석처리
            DataGridViewRow row = Dgv.RowTemplate;
            //decimal calRowHeight = (Dgv.Height - Dgv.ColumnHeadersHeight) / MaxRow;
            //int rowHeight = (int)Math.Truncate(calRowHeight);
            //row.Height = rowHeight; 
            row.MinimumHeight = 20;
        }
        #endregion

        #region ========== 시간
        private void timer()
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            txtDT.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDT.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
        private void TimeUse()
        {
            lblTimeUse.Text = "사용시간";
        }
        #endregion

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        
    }
}
