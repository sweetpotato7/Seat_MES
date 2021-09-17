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

namespace MESProject.기준정보
{
    public partial class ITEM_MST : Form
    {
        SQL sql = new SQL();

        public ITEM_MST()
        {
            InitializeComponent();
            DGVLoad();
        }

        private void DGVLoad()
        {
            /*string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "ITEMNAME", "ITEMTYPE", "USEFLAG", "CREATE_DT", "CREATE_USERID", "MODIFY_DT", "MODIFY_DT" };
            string[] HeaderText = new string[] { "공장", "품목코드", "품목명", "품목타입", "사용여부", "등록일시", "등록자", "수정일시", "수정자" };
            string[] HiddenColumn = null;
            float[] FillWeight = new float[] { 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("HY견고딕", 10, FontStyle.Bold);
            Font BodyStyleFont = new Font("HY견고딕", 9F, FontStyle.Regular);

            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, HiddenColumn, FillWeight, StyleFont, BodyStyleFont, 16);*/
            dataGridView1.ReadOnly = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }




        // 조회버튼
        public void Do_Search()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TB_ITEM_MST";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // ITEMCODE와 대조해서 DELETE
        private void Do_Delete()
        {
            string itemcode;
            itemcode = dataGridView1.SelectedCells[1].Value.ToString();
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from TB_ITEM_MST where ITEMCODE=" + "'" + itemcode + "'" + "";
            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("삭제되었습니다.");
        }

        // 추가버튼
        private void Do_Add()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into TB_ITEM_MST (PLANTCODE, ITEMCODE, ITEMNAME, ITEMTYPE) values('" + cboPlantCode.SelectedItem.ToString() + "','" + txtItemName.Text + "','" + cboItemCode.SelectedItem.ToString() + "','" + cboItemType.SelectedItem.ToString() + "')";
            cmd.ExecuteNonQuery();

            cboPlantCode.SelectedItem = "";
            txtItemName.Text = "";
            cboItemCode.SelectedItem = "";
            cboItemType.SelectedItem = "";
            Do_Search();
            MessageBox.Show("품목이 추가되었습니다.");
        }

        // 닫기버튼
        // 탭닫기 수정필요
        private void Do_Exit()
        {
            this.Close();
        }

      
        private void ITEM_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Do_Search();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Do_Add();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Do_Delete();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Do_Exit();
        }
    }
}
