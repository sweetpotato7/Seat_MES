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
    public partial class SPEC_MST : Form
    {
        SQL sql = new SQL();

        public SPEC_MST()
        {
            InitializeComponent();
        }

        public void SPEC_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            fill_cmb_ALC();
            fill_cmb_carcode();
        }

        public void Do_Search()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TB_SPEC where ITEMCODE = " + "'" + cmb_S_ALC.SelectedItem + "'" + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].ReadOnly = true; // carcode 수정방지
        }

        public void Do_Entire_Search()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TB_SPEC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].ReadOnly = true; // carcode 수정방지
            cmb_S_ALC.Text = "ALL";
        }

        public void Do_Add()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into TB_SPEC (PLANTCODE, ITEMCODE, CARCODE, SPEC1, SPEC2, SPEC3, SPEC4, SPEC5, SPEC6) values" 
                + "('D100','" 
                + cmb_ALC.Text + "','" 
                + cmb_CarCode.Text + "','" 
                + cmbLocal.SelectedItem.ToString() + "','"
                + cmbTrack.SelectedItem.ToString() + "','" 
                + cmbFormpad.SelectedItem.ToString() + "','" 
                + cmbHeadrestrian.SelectedItem.ToString() + "','" 
                + cmbCovering.SelectedItem.ToString() + "','" 
                + cmbSAB.SelectedItem.ToString() + "')";
            cmd.ExecuteNonQuery();

            cmb_ALC.Text = "";
            cmb_CarCode.Text = "";
            cmbLocal.SelectedIndex = 0;
            cmbTrack.SelectedIndex = 0;
            cmbFormpad.SelectedIndex = 0;
            cmbHeadrestrian.SelectedIndex = 0;
            cmbHeadrestrian.SelectedIndex = 0;
            cmbSAB.SelectedIndex = 0;
            Do_Entire_Search();
            MessageBox.Show("추가되었습니다.");
        }

        public void Do_Delete()
        {
            string itemcode;
            itemcode = dataGridView1.SelectedCells[1].Value.ToString();
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from TB_SPEC where ITEMCODE=" + "'" + itemcode + "'" + "";
            cmd.ExecuteNonQuery();
            Do_Entire_Search();
            MessageBox.Show("삭제되었습니다.");
        }

        public void Do_Save()
        {
            string carcode;
            int i;

            i = dataGridView1.SelectedCells[0].RowIndex; // 현재 선택된 행 번호
            carcode  = dataGridView1.Rows[i].Cells[2].Value.ToString(); // carcode선택

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update TB_SPEC SET " +
                              "SPEC1 = " + "'" + cmbLocal.Text + "'" + "," +
                              "SPEC2 = " + "'" + cmbTrack.Text + "'" + "," +
                              "SPEC3 = " + "'" + cmbFormpad.Text + "'" + "," +
                              "SPEC4 = " + "'" + cmbHeadrestrian.Text + "'" + "," +
                              "SPEC5 = " + "'" + cmbCovering.Text + "'" + "," +
                              "SPEC6 = " + "'" + cmbSAB.Text + "'" +
                              "where CARCODE = " + "'" + carcode + "'" + "";
            cmd.ExecuteNonQuery();

            cmb_ALC.Text = "";
            cmb_CarCode.Text = "";
            cmbLocal.Text = "";
            cmbTrack.Text = "";
            cmbFormpad.Text = "";
            cmbHeadrestrian.Text = "";
            cmbCovering.Text = "";
            cmbSAB.Text = "";

            Do_Entire_Search();
            MessageBox.Show("수정되었습니다.");
        }

        // 자동완성
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;

            cmb_ALC.Text         = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cmb_CarCode.Text     = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cmbLocal.Text        = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cmbTrack.Text        = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cmbFormpad.Text      = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cmbHeadrestrian.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            cmbCovering.Text     = dataGridView1.Rows[i].Cells[7].Value.ToString();
            cmbSAB.Text          = dataGridView1.Rows[i].Cells[8].Value.ToString();
        }

        public void fill_cmb_ALC()
        {
            cmb_S_ALC.Items.Clear();
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TB_SPEC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cmb_S_ALC.Items.Add(dr["ITEMCODE"].ToString());
            }
        }

        public void fill_cmb_carcode()
        {
            cmb_CarCode.Items.Clear();
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TB_SPEC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cmb_CarCode.Items.Add(dr["CARCODE"].ToString());
            }
        }

        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            Do_Search();
        }
        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            Do_Add();
        }
        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            Do_Delete();
        }
        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            Do_Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Do_Entire_Search();
        }
    }

    // 추가작업
    // - 품번마스터 만든후 ITEMCODE 불러오기
    // - SPEC: DB에는 코드로 표시, 그리드에는 O,X 또는 가죽 등으로 표시
}
