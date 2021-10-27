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

namespace MESProject.생산계획
{
    public partial class PLAN_MST : Form
    {
        /// <summary>
        /// 수정 부분 확인후 삭제
        /// </summary>

        Function func = new Function();
        SQL sql = new SQL();
        SqlDataAdapter da;
        DataTable dt;
        string strqry = string.Empty;
        SqlTransaction transaction;

        public PLAN_MST()
        {
            InitializeComponent();
        }

        private void PLAN_MST_Load(object sender, EventArgs e)
        {
            func.CboLoad(cboALC, "TB_ITEM_MST", "ITEMCODE", true, "ITEMTYPE", "ALC");
            DGV1Load();
            Do_Search();
        }

        #region ========== DGV Setting
        private void DGV1Load()
        {
            // DGV1
            string[] DataPropertyName = new string[] { "PLANTCODE", "PLANDATE", "PLANSEQ", "ALC_CD", "PLANQTY", "ORDERNO", "PRODQTY", "PLANFLAG", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT" };
            string[] HeaderText = new string[] { "공장", "날짜", "순서", "ALC", "수량", "작업지시번호", "생산수량", "계획상태", "등록자", "등록일자", "수정자", "수정일자" };
            string[] HiddenColumn = new string[] { "PLANTCODE" };
            float[] FillWeight = new float[] { 40, 100, 40, 100, 40, 130, 40, 40, 100, 130, 100, 130 };
            Font StyleFont = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 12);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DGV2Load()
        {
            // DGV2 수정!
            string[] DataPropertyName = new string[] { "CHK", "PLANTCODE", "PLANSEQ", "ORDERNO", "SUBSEQ", "SIDE", "LOTNO", "ITEMCODE", "INDATE", "PRODDATE", "CREATE_USERID", "CREATE_DT", "MODIFY_USERID", "MODIFY_DT", "PROC_TRACK", "PROC_ASSEM" };
            string[] HeaderText = new string[] { "완료", "공장", "작업순서", "작업번호", "순서", "위치", "LOTNO", "ALC", "투입일자", "완료일자", "등록자", "등록일자", "수정자", "수정일자", "1", "1" };
            string[] HiddenColumn = new string[] { "CHK", "PLANTCODE", "PROC_TRACK", "PROC_ASSEM" };
            float[] FillWeight = new float[] { 40, 40, 40, 80, 40, 40, 130, 100, 100, 100, 100, 130, 100, 130, 10, 10 };
            Font StyleFont = new Font("굴림", 9, FontStyle.Bold);
            Font BodyStyleFont = new Font("굴림", 9, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView2, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        #region ========== CRUD
        public void Do_Search() // 검색
        {
            strqry = "SELECT * FROM TB_PLAN_MST"
                   + " WHERE PLANDATE = '" + dtDate.Value.ToString("yyMMdd") + "'"
                   + " ORDER BY PLANDATE, PLANSEQ";
            dt = func.GetDataTable2(strqry);
            dataGridView1.DataSource = dt;
            DGV2Load();

        }

        public void Do_Insert()
        {
            string check = "해당 칸을 입력해주세요";
            if (cboALC.Text == "")
            {
                check += "\n          ALC";
            }
            if (txtQty.Text == "")
            {
                check += "\n          수량 ";
            }
            if (check.Length != 12)
            {
                MessageBox.Show(check, "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlCommand cmd = new SqlCommand("PLAN_MST_I1", sql.con))
            {
                try
                {
                    string sDate = dtDate.Value.ToString("yyyyMMdd");
                    string sALC = cboALC.Text;
                    int iQty = int.Parse(txtQty.Text);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PLANTCODE", SqlDbType.VarChar).Value = "D100";
                    cmd.Parameters.Add("@PLANDATE", SqlDbType.VarChar).Value = sDate;
                    cmd.Parameters.Add("@ALC_CD", SqlDbType.VarChar).Value = sALC;
                    cmd.Parameters.Add("@PLANQTY", SqlDbType.Int).Value = iQty;
                    cmd.Parameters.Add("@USERID", SqlDbType.VarChar).Value = Main.ID; // ID아닌 이름?

                    var rscode = new SqlParameter("@RS_CODE", SqlDbType.VarChar);
                    var rsmsg = new SqlParameter("@RS_MSG", SqlDbType.VarChar);
                    rscode.Direction = ParameterDirection.Output;
                    rsmsg.Direction = ParameterDirection.Output;
                    rscode.Size = 2;
                    rsmsg.Size = 200;
                    cmd.Parameters.Add(rscode);
                    cmd.Parameters.Add(rsmsg);

                    sql.con.Open();
                    transaction = sql.con.BeginTransaction();
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@RS_CODE"].Value.ToString() == "E")
                    {
                        transaction.Rollback();
                        MessageBox.Show(cmd.Parameters["@RS_MSG"].Value.ToString());
                        return;
                    }

                    transaction.Commit();
                    MessageBox.Show("입력되었습니다!");
                    txtQty.Text = "";
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.con.Close();
                }
                Do_Search();
            }
        }

        public void Do_Delete()
        {
            using (SqlCommand cmd = new SqlCommand("PLAN_MST_D1", sql.con))
            {
                try
                {
                    int i = dataGridView1.SelectedCells[0].RowIndex; // 현재 선택된 행 번호
                    string sOrderno = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    if (dataGridView1.Rows[i].Cells[7].Value.ToString() != "R")
                    {
                        MessageBox.Show("투입중인 작업은 삭제할 수 없습니다!");
                        return;
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PLANTCODE", SqlDbType.VarChar).Value = "D100";
                    cmd.Parameters.Add("@ORDERNO", SqlDbType.VarChar).Value = sOrderno;
                    cmd.Parameters.Add("@USERID", SqlDbType.VarChar).Value = Main.ID; // ID아닌 이름?

                    var rscode = new SqlParameter("@RS_CODE", SqlDbType.VarChar);
                    var rsmsg = new SqlParameter("@RS_MSG", SqlDbType.VarChar);
                    rscode.Direction = ParameterDirection.Output;
                    rsmsg.Direction = ParameterDirection.Output;
                    rscode.Size = 2;
                    rsmsg.Size = 200;
                    cmd.Parameters.Add(rscode);
                    cmd.Parameters.Add(rsmsg);

                    sql.con.Open();
                    transaction = sql.con.BeginTransaction();
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters["@RS_CODE"].Value.ToString() == "E")
                    {
                        transaction.Rollback();
                        MessageBox.Show(cmd.Parameters["@RS_MSG"].Value.ToString());
                        return;
                    }
                    transaction.Commit();
                    MessageBox.Show("삭제되었습니다!");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.con.Close();
                }
                Do_Search();
            }
        }

        //조립공정 추가로 사용 안함
        public void Do_Save()
        {
            using (SqlCommand cmd = new SqlCommand("PLAN_MST_U1", sql.con))
            {
                try
                {
                    string sLotno;
                    DataTable dtchange = dt.Clone();
                    dt = new DataTable();
                    dt = func.GetDataGridViewAsDataTable(dataGridView2);

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.ItemArray[0].ToString() == "0") continue;
                        dtchange.ImportRow(dr);
                    }

                    sql.con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PLANTCODE", SqlDbType.VarChar);
                    cmd.Parameters.Add("@LOTNO", SqlDbType.VarChar);
                    cmd.Parameters.Add("@USERID", SqlDbType.VarChar); // ID아닌 이름?

                    var rscode = new SqlParameter("@RS_CODE", SqlDbType.VarChar);
                    var rsmsg = new SqlParameter("@RS_MSG", SqlDbType.VarChar);
                    rscode.Direction = ParameterDirection.Output;
                    rsmsg.Direction = ParameterDirection.Output;
                    rscode.Size = 2;
                    rsmsg.Size = 200;
                    cmd.Parameters.Add(rscode);
                    cmd.Parameters.Add(rsmsg);

                    cmd.Parameters["@PLANTCODE"].Value = "D100";
                    cmd.Parameters["@USERID"].Value = Main.ID;

                    for (int i = 0; i < dtchange.Rows.Count; i++)
                    {
                        sLotno = dtchange.Rows[i].ItemArray[8].ToString();
                        cmd.Parameters["@LOTNO"].Value = sLotno;

                        transaction = sql.con.BeginTransaction();
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@RS_CODE"].Value.ToString() == "E")
                        {
                            transaction.Rollback();
                            MessageBox.Show(cmd.Parameters["@RS_MSG"].Value.ToString());
                            return;
                        }
                        transaction.Commit();
                    }

                    MessageBox.Show("저장되었습니다!");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
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
            string sOrderNo = dataGridView1.SelectedCells[3].Value.ToString();
            Do_Search();
            strqry = "SELECT * FROM TB_PLAN_DET "
                    + "WHERE ORDERNO = '" + sOrderNo + "' "
                    + "ORDER BY ORDERNO, SUBSEQ, SIDE";
            try
            {
                dt = new DataTable();
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
        #endregion

        #region ========== DGV 이벤트
        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            Do_Search();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string Orderno = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            strqry = "SELECT * FROM TB_PLAN_DET "
                    + "WHERE ORDERNO = '" + Orderno + "' "
                    + "ORDER BY ORDERNO, SUBSEQ, SIDE";
            try
            {
                dt = new DataTable();
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
        #endregion

       
    }
}
