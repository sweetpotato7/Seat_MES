using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

/// <summary>
/// 
/// 
/// </summary>

namespace MESProject.기준정보
{
    public partial class BOM : Form
    {
        Function func = new Function();
        SQL sql = new SQL();
        SqlDataAdapter da;
        DataTable dt;
        string strqry = string.Empty;
        // BOM 전체 리스트 조회문
        //string strqry = "SELECT a.PLANTCODE, a.ITEMCODE, b.ITEMNAME AS PNAME, a.BASEQTY, a.UNITCODE, a.COMPONENT, c.ITEMNAME AS CNAME, a.COMPONENTQTY, a.COMPONENTUNIT, a.USEFLAG, a.CREATE_USERID, a.CREATE_DT, a.MODIFY_USERID, a.MODIFY_DT"
        //               + " FROM TB_BOM a LEFT JOIN TB_ITEM_MST b"
        //                             + " ON a.ITEMCODE = b.ITEMCODE"
        //                             + " LEFT JOIN TB_ITEM_MST c"
        //                             + " ON a.COMPONENT = c.ITEMCODE";

        public BOM()
        {
            InitializeComponent();
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            DGVLoad();
            //DGV1Set(strqry); 사용안함
            TreeViewLoad();
            CboSet();
            CboClear();
            Do_Search();
            lblItemCode.Text = "";
            lblItemName.Text = "";
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "PITEMNAME", "BASEQTY", "UNITCODE", "COMPONENT", "CITEMNAME", "COMPONENTQTY", "COMPONENTUNIT", "USEFLAG", "CREATE_USERID", "CREATE_DT",  "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "품목", "품명", "수량", "단위", "하위품목", "품명", "수량", "단위", "사용", "등록자", "등록일시", "수정자", "수정일시" };
            string[] HiddenColumn     = null;
            float[] FillWeight = new float[] { 40, 100, 100, 40, 40, 100, 100, 40, 40, 40, 100, 130, 100, 130 };
            Font StyleFont     = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 14);
            //dataGridView2.ReadOnly = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #region ========== 사용안함 DGV1Set(string sQuery)
        //private void DGV1Set(string sQuery)
        //{
        //    try
        //    {
        //        sql.con.Open();

        //        da = new SqlDataAdapter(sQuery, sql.con);
        //        dt = new DataTable();
        //        da.Fill(dt); // da값 => dt에 데이터 입력
        //        //dataGridView1.DataSource = dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        sql.con.Close();
        //    }
        //}
        #endregion

        #region ========== CRUD
        public void Do_Search() // 검색
        {
            try
            {
                sql.con.Open();
                strqry = "SELECT * FROM TB_BOM";
                dt = func.GetDataTable(strqry);
                dataGridView2.DataSource = dt;
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

        public void DO_INSERT() // 추가
        {
            strqry = "INSERT INTO TB_BOM ( PLANTCODE, ITEMCODE, BASEQTY, UNITCODE, COMPONENT, COMPONENTQTY, COMPONENTUNIT, USEFLAG)"
                               + "VALUES ( '" + cboPlantCode2.Text
                                     + "', '" + cboPItemCode.Text
                                     + "', '" + txtPQty.Text
                                     + "', '" + cboPUnitCode.Text
                                     + "', '" + cboCItemCode.Text
                                     + "', '" + txtCQty.Text
                                     + "', '" + cboCUnitCode.Text
                                     + "', '" + cboUseFlag.SelectedItem.ToString() + "')";
            try
            {
                sql.con.Open();
                da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand(strqry, sql.con);
                da.InsertCommand.ExecuteNonQuery();

                // 입력 후 재조회
                strqry = "SELECT * FROM TB_BOM";
                dt = func.GetDataTable(strqry);
                dataGridView2.DataSource = dt;

                MessageBox.Show("입력되었습니다!");

                CboClear();

            }
            catch ( SqlException ex )
            {
                MessageBox.Show(ex.Message);
            }
            catch ( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sql.con.Close();
            }
        }

        public void DO_DELETE() // 삭제
        {
            strqry = "DELETE FROM TB_BOM "
                    + "WHERE PLANTCODE = '" + dataGridView2.SelectedCells[2].Value.ToString() + "'"
                      + "AND ITEMCODE  = '" + dataGridView2.SelectedCells[3].Value.ToString() + "'"
                      + "AND COMPONENT = '" + dataGridView2.SelectedCells[6].Value.ToString() + "'";
            
            try
            {
                sql.con.Open();
                da = new SqlDataAdapter();
                da.DeleteCommand = new SqlCommand(strqry, sql.con);
                da.DeleteCommand.ExecuteNonQuery();

                // 삭제 후 재조회
                strqry = "SELECT * FROM TB_BOM";
                dt = func.GetDataTable(strqry);
                dataGridView2.DataSource = dt;

                MessageBox.Show("삭제되었습니다!");

                CboClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

        public void DO_SAVE() // 수정
        {
            strqry = "UPDATE TB_BOM SET "
                   + "PLANTCODE = '"     + cboPlantCode2.Text + "', "
                   + "ITEMCODE = '"      + cboPItemCode.Text  + "', "
                   + "BASEQTY = '"       + txtPQty.Text       + "', "
                   + "UNITCODE = '"      + cboPUnitCode.Text  + "', "
                   + "COMPONENT = '"     + cboCItemCode.Text  + "', "
                   + "COMPONENTQTY = '"  + txtCQty.Text       + "', "
                   + "COMPONENTUNIT = '" + cboPUnitCode.Text  + "', "
                   + "USEFLAG = '"       + cboUseFlag.Text    + "' "
                   + "WHERE PLANTCODE = '" + dataGridView2.SelectedCells[2].Value.ToString() + "'"
                     + "AND ITEMCODE  = '" + dataGridView2.SelectedCells[3].Value.ToString() + "'"
                     + "AND COMPONENT = '" + dataGridView2.SelectedCells[6].Value.ToString() + "'";

            try
            {
                sql.con.Open();
                da = new SqlDataAdapter();
                da.UpdateCommand = new SqlCommand(strqry, sql.con);
                da.UpdateCommand.ExecuteNonQuery();

                // 수정 후 재조회
                strqry = "SELECT * FROM TB_BOM";
                dt = func.GetDataTable(strqry);
                dataGridView2.DataSource = dt;

                MessageBox.Show("수정되었습니다!");

                CboClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

        #region ========== 트리뷰
        public void TreeViewLoad() // 트리뷰 로드
        {
            TreeNode parentNode;
            string strqry = "SELECT * FROM TB_BOM WHERE ITEMCODE NOT IN "
                         + "(SELECT COMPONENT FROM TB_BOM GROUP BY COMPONENT)";
            try
            {
                sql.con.Open();
                dt = func.GetDataTable(strqry);

                treeView1.Refresh();

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

        private void TreeViewSet(string parentID, TreeNode parentNode) // 트리뷰 세팅
        {
            string strqry = "SELECT * FROM TB_BOM WHERE ITEMCODE = '" + parentID + "'";
            DataTable dtChild = func.GetDataTable(strqry);

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
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) // 트리뷰 선택 시 dgv2 바인딩, 이미지 출력
        {
            string SelectItem = e.Node.Text;
            try
            {
                sql.con.Open();
                LblItemName_Load(SelectItem);
                string strqry = "SELECT * FROM FN_TopDown('" + SelectItem + "')";
                dt = func.GetDataTable(strqry);
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
            func.CboLoad(cboPlantCode,  "TB_ITEM_MST", "PLANTCODE", true);
            func.CboLoad(cboItemCode,   "TB_ITEM_MST", "ITEMCODE",  false);
            func.CboLoad(cboPlantCode2, "TB_ITEM_MST", "PLANTCODE", true);
            func.CboLoad(cboUseFlag,    "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "USEFLAG");
            func.CboLoad(cboPItemCode,  "TB_ITEM_MST", "ITEMCODE",  false);
            func.CboLoad(cboCItemCode,  "TB_ITEM_MST", "ITEMCODE",  false);
            func.CboLoad(cboPUnitCode,  "TB_ITEM_MST", "UNITCODE",  true);
            func.CboLoad(cboCUnitCode,  "TB_ITEM_MST", "UNITCODE",  true);
        }

        private void cboPItemCode_SelectedValueChanged(object sender, EventArgs e) // 품목 선택 시 품명 출력
        {
            try
            {
                sql.con.Open();
                LblItemName_Load(cboPItemCode, lblPItemName);
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

        private void cboCItemCode_SelectedIndexChanged(object sender, EventArgs e) // 품목 선택 시 품명 출력
        {
            try
            {
                sql.con.Open();
                LblItemName_Load(cboCItemCode, lblCItemName);
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

        private void LblItemName_Load(string NodeText) // 이미지 위 라벨 이름
        {
            string strqry = "SELECT ITEMCODE, ITEMNAME FROM TB_ITEM_MST WHERE ITEMCODE = '" + NodeText + "'";
            dt = func.GetDataTable(strqry);
            lblItemCode.Text = dt.Rows[0].ItemArray[0].ToString();
            lblItemName.Text = dt.Rows[0].ItemArray[1].ToString();
        }

        private void LblItemName_Load(ComboBox CboName, Label LabelName) // 입력창 라벨 설정
        {
            if ( CboName.Text == "" )
            {
                LabelName.Text = "";
                return;
            }
            string strqry = "SELECT DISTINCT ITEMNAME FROM TB_ITEM_MST WHERE ITEMCODE = '" + CboName.Text + "'";
            dt = func.GetDataTable(strqry);
            LabelName.Text = dt.Rows[0].ItemArray[0].ToString();
        }

        private void CboClear() // 입력칸 초기화
        {
            cboPlantCode2.SelectedItem = cboPlantCode2.Items[0];
            cboUseFlag.SelectedItem    = cboUseFlag.Items[0];
            cboPUnitCode.SelectedItem  = cboPUnitCode.Items[0];
            cboCUnitCode.SelectedItem  = cboCUnitCode.Items[0];
            cboPItemCode.Text = "";
            cboCItemCode.Text = "";
            txtPQty.Text = "";
            txtCQty.Text = "";
            lblPItemName.Text = "";
            lblCItemName.Text = "";
        }
        #endregion

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) // 선택셀 입력칸 입력
        {
            try
            {
                cboPlantCode2.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboPItemCode.Text  = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPQty.Text       = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                cboPUnitCode.Text  = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                cboCItemCode.Text  = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCQty.Text       = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                cboCUnitCode.Text  = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                cboUseFlag.Text    = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            catch
            {

            }
        }
    }
}