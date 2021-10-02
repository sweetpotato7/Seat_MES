using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                Cbobox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                Cbobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Cbobox.AutoCompleteSource = AutoCompleteSource.ListItems;
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
    }
}
