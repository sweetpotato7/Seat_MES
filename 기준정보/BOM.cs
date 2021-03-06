using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace MESProject.기준정보
{
    public partial class BOM : Form
    {
        Function func = new Function();
        SQL sql = new SQL();
        SqlDataAdapter da;
        DataTable dt;
        string strqry = string.Empty;

        public BOM()
        {
            InitializeComponent();
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            DGVLoad();
            TreeViewLoad();
            CboSet();
            CboClear();
            Do_Search();
        }

        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "PITEMNAME", "BASEQTY", "UNITCODE", "COMPONENT", "CITEMNAME", "COMPONENTQTY", "COMPONENTUNIT", "USEFLAG", "CREATE_USERID", "CREATE_DT",  "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText       = new string[] { "공장", "품목", "품명", "수량", "단위", "하위품목", "품명", "수량", "단위", "사용", "등록자", "등록일시", "수정자", "수정일시" };
            string[] HiddenColumn     = null;
            float[]  FillWeight       = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont      = new Font("맑은 고딕", 11, FontStyle.Bold);
            Font BodyStyleFont  = new Font("맑은 고딕", 11, FontStyle.Regular);

            Function.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 14);

            //스타일 지정 밎 그리드에 데이터 바인드
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(95, 184, 255);

        }

        #region ========== CRUD
        public void Do_Search() // 검색
        {
            try
            {
                strqry = "SELECT B.PLANTCODE, B.ITEMCODE, I1.ITEMNAME AS PITEMNAME, B.BASEQTY, B.UNITCODE, B.COMPONENT, I2.ITEMNAME AS CITEMNAME, B.COMPONENTQTY, B.COMPONENTUNIT, B.USEFLAG, B.CREATE_USERID, B.CREATE_DT, B.MODIFY_USERID, B.MODIFY_DT"
                        + " FROM TB_BOM B LEFT JOIN TB_ITEM_MST I1 "
				                              + "ON B.ITEMCODE  = I1.ITEMCODE "
			                           + "LEFT JOIN TB_ITEM_MST I2 "
				                              + "ON B.COMPONENT = I2.ITEMCODE";
                dt = func.GetDataTable2(strqry);
                dataGridView2.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Do_INSERT() // 추가
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
                Do_Search();

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
                TreeViewLoad();
            }
        }

        public void Do_Delete() // 삭제
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
                TreeViewLoad();
            }
        }

        public void Do_SAVE() // 수정
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
                TreeViewLoad();
            }
        }
        #endregion

        #region ========== 트리뷰
        public void TreeViewLoad() // 트리뷰 로드
        {
            treeView1.Nodes.Clear();
            TreeNode parentNode;
            // 최상위 품목 선택(하위 품목에 없는 것만)
            string strqry = "SELECT * FROM TB_BOM WHERE ITEMCODE NOT IN "
                         + "(SELECT COMPONENT FROM TB_BOM GROUP BY COMPONENT)";
            try
            {
                sql.con.Open();
                dt = func.GetDataTable(strqry);

                treeView1.Refresh(); // 트리뷰 재조회

                foreach (DataRow dr in dt.Rows) // 각 최상위품목 추가
                {
                    parentNode = treeView1.Nodes.Add(dr["ITEMCODE"].ToString()); // 노드에 추가
                    TreeViewSet(dr["ITEMCODE"].ToString(), parentNode);
                }
                treeView1.ExpandAll(); //트리뷰 가지 확장
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
                string strqry = "SELECT * FROM FN_TopDown('" + SelectItem + "')"; // 테이블 반환함수 FN_TopDown를 사용
                dt = func.GetDataTable(strqry);
                dataGridView2.DataSource = dt;

                if (e.Node.Parent != null)
                {
                    sql.con.Close();
                    cboPItemCode.Text = e.Node.Parent.Text;
                    cboCItemCode.Text = e.Node.Text;
                    txtPQty.Text = "1";
                    txtCQty.Text = "1";
                    sql.con.Open();
                }
                else
                    CboClear();

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
            func.CboLoad(cboPlantCode,  "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            func.CboLoad(cboItemCode,   "TB_ITEM_MST", "ITEMCODE",  false);
            func.CboLoad(cboPlantCode2, "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "PLANT");
            func.CboLoad(cboUseFlag,    "TB_CODE_MST", "MINORCODE", true, "MAJORCODE", "USEFLAG");
            func.CboLoad(cboPItemCode,  "TB_ITEM_MST", "ITEMCODE",  false);
            func.CboLoad(cboCItemCode,  "TB_ITEM_MST", "ITEMCODE",  false);
            func.CboLoad(cboPUnitCode,  "TB_ITEM_MST", "UNITCODE",  true);
            func.CboLoad(cboCUnitCode,  "TB_ITEM_MST", "UNITCODE",  true);
            cboPlantCode.SelectedItem = cboPlantCode.Items[0];
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
                //MessageBox.Show(ex.Message);
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
            lblPItemName.Text = "--";
            lblCItemName.Text = "--";
        }
        #endregion

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) // 선택셀 입력칸 입력
        {
            try
            {
                cboPlantCode2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboPItemCode.Text  = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPQty.Text       = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboPUnitCode.Text  = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                cboCItemCode.Text  = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
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