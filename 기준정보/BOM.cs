using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;


namespace MESProject.기준정보
{
    public partial class BOM : Form
    {
        SQL sql = new SQL();
        DataTable dt;
        SqlDataAdapter da;
        string strqry = "SELECT a.PLANTCODE, a.ITEMCODE, b.ITEMNAME AS PNAME, a.BASEQTY, a.UNITCODE, a.COMPONENT, c.ITEMNAME AS CNAME, a.COMPONENTQTY, a.COMPONENTUNIT, a.USEFLAG, a.CREATE_USERID, a.CREATE_DT, a.MODIFY_USERID, a.MODIFY_DT"
                       + " FROM TB_BOM a LEFT JOIN TB_ITEM_MST b"
                                     + " ON a.ITEMCODE = b.ITEMCODE"
                                     + " LEFT JOIN TB_ITEM_MST c"
                                     + " ON a.COMPONENT = c.ITEMCODE";

        public BOM()
        {
            InitializeComponent();
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            DGVLoad();
            DGV1Set(strqry);
            TreeViewLoad();
            CboLoad(cboPlantCode, "TB_ITEM_MST", "PLANTCODE");
            CboLoad(cboItemCode,  "TB_ITEM_MST", "ITEMCODE");
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "PNAME", "BASEQTY", "UNITCODE", "COMPONENT", "CNAME", "COMPONENTQTY", "COMPONENTUNIT", "USEFLAG", "CREATE_USERID", "CREATE_DT",  "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "품목", "품명", "수량", "단위", "하위품목", "품명", "수량", "단위", "사용", "등록자", "등록일시", "수정자", "수정일시" };
            string[] HiddenColumn = null;
            float[] FillWeight = new float[] { 40, 100, 100, 40, 40, 100, 100, 40, 40, 40, 100, 130, 100, 130 };
            Font StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 14);
            dataGridView2.ReadOnly = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DGV1Set(string sQuery)
        {
            try
            {
                sql.con.Open();
                
                da = new SqlDataAdapter(sQuery, sql.con);
                dt = new DataTable();
                da.Fill(dt); // da값 => dt에 데이터 입력
                //dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.con.Close();
            }
        }

        #region ========== CRUD
        public void Do_Search() // 인자 넣어서 검색되게 바꾸기
        {
            try
            {
                if (cboPlantCode.Text == "" && txtItemName.Text.Trim(' ').Length == 0 && cboItemCode.Text == "")
                {
                    DGV1Set(strqry);
                }
                else
                {
                    string sOption = " Where";
                    if (cboPlantCode.Text != "")
                        sOption += " a.PLANTCODE LIKE '%" + cboPlantCode.Text + "%'";
                    if (txtItemName.Text.Trim(' ').Length != 0)
                        sOption += " b.ITEMNAME LIKE '%" + txtItemName.Text + "%'";
                    if (cboItemCode.Text != "")
                        sOption += " a.ITEMCODE LIKE '%" + cboItemCode.Text + "%'";
                    sOption = strqry + sOption;
                    DGV1Set(sOption);
                }
                cboPlantCode.Text = "";
                txtItemName.Text  = "";
                cboItemCode.Text  = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.con.Close();
            }
        }

        public void DO_INSERT()
        {
            //int MaxRow = dataGridView1.Rows.Count;
            //try
            //{
            //    if (MaxRow >= 0)
            //    {
            //        if (dataGridView1.Rows[MaxRow - 1].Cells[0].Value.ToString() != "")
            //        {
            //            dt = new DataTable();
            //            dt = dataGridView1.DataSource as DataTable;
            //            string[] row0 = { "", "", "", "", "", "", "", "", "", "", "", DateTime.Now.ToString(), "", DateTime.Now.ToString() };
            //            dt.Rows.Add(row0);
            //            dataGridView1.DataSource = null;
            //            dataGridView1.DataSource = dt;
            //        }
            //        else
            //        {
            //            MessageBox.Show("추가 등록은 한번에 하나씩만 가능합니다.");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public void DO_DELETE()
        {
            
        }

        public void DO_SAVE()
        {

        }
        #endregion

        #region ========== 트리뷰
        public void TreeViewLoad()
        {
            try
            {
                sql.con.Open();
                da = new SqlDataAdapter("SELECT * FROM TB_BOM WHERE ITEMCODE NOT IN "
                                     + "(SELECT COMPONENT FROM TB_BOM GROUP BY COMPONENT)", 
                                        sql.con);
                dt = new DataTable();
                da.Fill(dt);

                treeView1.Refresh();
                TreeNode parentNode;
                foreach (DataRow dr in dt.Rows)
                {
                    parentNode = treeView1.Nodes.Add(dr["ITEMCODE"].ToString());
                    TreeViewSet(dr["ITEMCODE"].ToString(), parentNode);
                }
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.con.Close();
            }
        }

        private void TreeViewSet(string parentID, TreeNode parentNode)
        {
            SqlDataAdapter daChild = new SqlDataAdapter("SELECT * FROM TB_BOM WHERE ITEMCODE = '" + parentID + "'", 
                                                        sql.con);
            DataTable dtChild = new DataTable();
            daChild.Fill(dtChild);

            foreach (DataRow dr in dtChild.Rows)
            {
                TreeNode childNode;
                if (parentNode == null)
                    childNode = treeView1.Nodes.Add(dr["COMPONENT"].ToString());
                else
                    childNode = parentNode.Nodes.Add(dr["COMPONENT"].ToString());
                TreeViewSet(dr["COMPONENT"].ToString(), childNode);
            }
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string SelectItem = e.Node.Text;

                sql.con.Open();
                string qry = "SELECT * FROM FN_TopDown('" + SelectItem + "')";
                da = new SqlDataAdapter(qry, sql.con);
                dt = new DataTable();
                da.Fill(dt); 
                dataGridView2.DataSource = dt;

                #region 이미지 출력
                int i = 0;

                if ( int.TryParse(SelectItem.Substring(0,1), out i))
                    SelectItem = SelectItem.Substring(0, 5);
                else
                    SelectItem = SelectItem.Substring(2);

                switch (SelectItem)
                {
                    case "ALC":
                        pictureBox1.Image = Properties.Resources.ALC;
                        break;
                    case "PLT":
                        pictureBox1.Image = Properties.Resources.PALLET;
                        break;
                    case "LH":
                        pictureBox1.Image = Properties.Resources.COVERING;
                        break;
                    case "RH":
                        pictureBox1.Image = Properties.Resources.COVERING;
                        break;
                    case "88001":
                        pictureBox1.Image = Properties.Resources.TRACK;
                        break;
                    case "88100":
                        pictureBox1.Image = Properties.Resources.FOAMPAD;
                        break;
                    case "89000":
                        pictureBox1.Image = Properties.Resources.HEADREST;
                        break;
                    case "90000":
                        pictureBox1.Image = Properties.Resources.COVERING;
                        break;
                    case "91000":
                        pictureBox1.Image = Properties.Resources.AIRBAG;
                        break;
                    default:
                        pictureBox1.Image = Properties.Resources.RYAN;
                        break;
                }
                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.con.Close();
            }
        }
        #endregion

        #region ========== 콤보박스 셋팅
        private void CboSet()
        {
            CboLoad(cboPlantCode,  "TB_ITEM_MST", "PLANTCODE");
            CboLoad(cboItemCode,   "TB_ITEM_MST", "ITEMCODE");
            CboLoad(cboPlantCode2, "TB_ITEM_MST", "PLANTCODE");
            CboLoad(cboUseFlag,    "TB_ITEM_MST", "USEFLAG");
            CboLoad(cboPItemCode,  "TB_ITEM_MST", "ITEMCODE");
            CboLoad(cboCItemCode,  "TB_ITEM_MST", "ITEMCODE");
            CboLoad(cboPUnitCode,  "TB_ITEM_MST", "UNITCODE");
            CboLoad(cboCUnitCode,  "TB_ITEM_MST", "UNITCODE");
        }

        private void CboLoad(ComboBox Cbobox, string TableName, string ListName)
        {
            string strqry = "SELECT DISTINCT " + ListName + " FROM " + TableName;
            DataSet ds;
            try
            {
                sql.con.Open();
                da = new SqlDataAdapter(strqry, sql.con);
                ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Cbobox.Items.Add(dr[ListName]);
                }
                Cbobox.Items.Clear();
                Cbobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Cbobox.AutoCompleteSource = AutoCompleteSource.ListItems;
                Cbobox.SelectedIndex = 0;
                Cbobox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.con.Close();
            }
        }
        #endregion

        private void DGVChild()
        {

        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //LoadTreeView(dataGridView1.SelectedCells[1].Value.ToString());
        }
    }
}