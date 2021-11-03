using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
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
        Stopwatch sw = new Stopwatch();

        public Main()
        {
            InitializeComponent();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            lblStatemsg.Text = $"{ID}님 접속 중";
            lblTimeUse.Text = "사용시간 : 00:00:00";

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;

            txtVersion.Text = SQL.VerCheck(); // 실행 시 SQL로 버전 받아서 업데이트(SQLSetting에서 받아오기)
            btnImageLoad();
            timer();

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
                index++; // 해당 탭컨트롤을 찾기 위해서 하나씩 추가
            }

            form.TopLevel = false; // 최상위 컨트롤 추가 불가로 false 해줘야 됨
            
            // 탭 제목만 추가됨,(탭 이름 가져옴, 페이지 추가된게 아님)
            tabControl1.TabPages.Add(sender.ToString());
            // 탭 이름에 맞는 폼을 추가
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
            // 추가한 탭을 선택
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;

            //버튼 검색...에 쓸 Tab-Name 추가
            //form.ToString() = "MESProject.기준정보.CODE_MST, Text: CODE_MST"
            int leng = (form.ToString().Length - 24) / 2; //글자 개수
            int word = leng + 24;                         //글자 시작 위치
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
        private void btnSearch_Click(object sender, EventArgs e)
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
                        //Plan_Mst.Do_Save(); //조립공정 추가로 제거
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
            btnInsert.Image = Properties.Resources.Add;
            btnDelete.Image = Properties.Resources.Delete;
            btnSave.Image   = Properties.Resources.Save;
            btnClose.Image  = Properties.Resources.Close;
            tabPage1.BackgroundImage = Properties.Resources.RYAN;
        }
        #endregion

        #region ========== 시간
        private void timer()
        {
            sw.Start();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDT.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lblTimeUse.Text = $"사용시간 : {(sw.ElapsedMilliseconds / 1000 / 3600).ToString().PadLeft(2, '0')}" +
                                        $":{(sw.ElapsedMilliseconds / 1000 / 60 % 60).ToString().PadLeft(2, '0')}" +
                                        $":{(sw.ElapsedMilliseconds / 1000 % 60).ToString().PadLeft(2, '0')}";
        }
        #endregion

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
