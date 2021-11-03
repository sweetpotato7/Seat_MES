using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    class Function
    {
        SQL sql = new SQL();
        SqlDataAdapter da;
        DataTable dt;

        public static void DGVSetting(DataGridView Dgv, string[] DataPropertyName, int HeaderHeight, string[] HeaderText, string[] HiddenColumn, float[] FillWeight, Font HeaderStyleFont, Font CellStyleFont, int MaxRow)
        {
            Dgv.DataSource = null;
            Dgv.Rows.Clear();
            Dgv.Columns.Clear();

            Font HeaderCellFont = null;
            Font CellFont = null;

            if (HeaderStyleFont == null) { HeaderCellFont = new Font("맑은 고딕", 14F, FontStyle.Bold); }
            else { HeaderCellFont = HeaderStyleFont; }

            if (CellStyleFont == null) { CellFont = new Font("맑은 고딕", 12F, FontStyle.Bold); }
            else { CellFont = CellStyleFont; }

            // DataGridView
            Dgv.ReadOnly = false;
            Dgv.EnableHeadersVisualStyles = false;
            
            Dgv.BorderStyle = BorderStyle.FixedSingle;
            Dgv.ScrollBars  = ScrollBars.Both;
            
            Dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.RowsDefaultCellStyle.BackColor = Color.White;
            Dgv.RowsDefaultCellStyle.SelectionBackColor   = Color.FromArgb(95, 184, 255);
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            Dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Dgv.SelectionMode   = DataGridViewSelectionMode.CellSelect;

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
            Dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 70);
            Dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
                    chkcol.ReadOnly = false;
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
            row.MinimumHeight = 28;
        }

        /// <summary>
        /// 테이블의 열 리스트를 가져온다
        /// <para>ex) TB_ITEM_MST의 ITEMCODE</para>
        /// </summary>
        /// <param name="Cbobox">설정할 콤보박스</param>
        /// <param name="Table">찾을 테이블 - From</param>
        /// <param name="Column">가져올 열이름 - Select</param>
        /// <param name="DropDownList">수정불가 여부</param>
        public void CboLoad(ComboBox Cbobox, string Table, string Column, bool DropDownList)
        {
            Cbobox.Items.Clear();
            if (DropDownList)
            {
                Cbobox.DropDownStyle = ComboBoxStyle.DropDownList; // 콤보박스 직접입력 불가능하게
            }
            else
            {
                Cbobox.AutoCompleteMode  = AutoCompleteMode.SuggestAppend; // 콤보박스 입력 시 자동 완성기능
                Cbobox.AutoCompleteSource = AutoCompleteSource.ListItems;  // 콤보박스 입력 시 자동 완성기능
            }

            string strqry = "SELECT DISTINCT " + Column + " FROM " + Table;
            try
            {
                sql.con.Open();
                dt = GetDataTable(strqry);
                foreach (DataRow dr in dt.Rows)
                    Cbobox.Items.Add(dr[Column]);
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

        /// <summary>
        /// 공통코드의 특정 부코드를 가져온다 
        /// <para>ex) SELECT 'Column' FROM 'Table' WHERE 'Option1' = 'Option2'</para>
        /// </summary>
        /// <param name="Cbobox">설정할 콤보박스</param>
        /// <param name="Table">찾을 테이블 - From</param>
        /// <param name="Column">가져올 열이름 - Select</param>
        /// <param name="Option1">WHERE Option1 = 'Option2'</param>
        /// <param name="Option2">찾을 조건 이름</param>
        /// <param name="DropDownList">수정불가 여부</param>
        public void CboLoad(ComboBox Cbobox, string Table, string Column, bool DropDownList, string Option1, string Option2)// 공통코드 로드
        {
            Cbobox.Items.Clear();
            if (DropDownList)
            {
                Cbobox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                Cbobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Cbobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

            string strqry = "SELECT " + Column + " FROM " + Table
                         + " WHERE " + Option1 + " = '" + Option2 + "'";
            if (Table.ToUpper() == "TB_CODE_MST")
            {
                strqry += " ORDER BY DISPLAYNO";
            }
            try
            {
                sql.con.Open();
                dt = GetDataTable(strqry);
                foreach (DataRow dr in dt.Rows)
                    Cbobox.Items.Add(dr[Column]);
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

        /// <summary>
        /// 해당 쿼리문 DataTable로 반환
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string Query)
        {
            da = new SqlDataAdapter(Query, sql.con);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// CreateCommand 이용한 해당 쿼리문 DT 반환
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable GetDataTable2(string Query)
        {
            dt = new DataTable();
            try
            {
                sql.con.Open();
                SqlCommand cmd = sql.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Query;
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
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
            return dt;
        }

        public DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {
            try
            {
                if (_DataGridView.ColumnCount == 0)
                    return null;
                DataTable dt = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null)
                        dt.Columns.Add(col.Name, typeof(string));
                    else
                        dt.Columns.Add(col.Name, col.ValueType);
                    dt.Columns[col.Name].Caption = col.HeaderText;
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dt.NewRow();
                    foreach (DataColumn col in dt.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dt.Rows.Add(drNewRow);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        internal void CboLoad(ComboBox cmb_ALC, string v1, string v2, bool v3, string v4)
        {
            throw new NotImplementedException();
        }
    }
}
