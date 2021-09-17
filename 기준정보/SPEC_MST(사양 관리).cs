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

        private void SPEC_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
        }

        private void Do_Exit()
        {
            this.Close();
        }

        private void Do_Search()
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
        }

        private void Do_Add()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into TB_SPEC (PLANTCODE, ITEMCODE, CARCODE, SPEC1, SPEC2, SPEC3, SPEC4, SPEC5, SPEC6) values" +
                "('D100','" + txtFERT.Text + "','" + txtALC.Text + "','" + cmbLocal.SelectedItem.ToString() + "','"
                + cmbTrack.SelectedItem.ToString() + "','" + cmbFormpad.SelectedItem.ToString() + "','" + cmbHeadrestrian.SelectedItem.ToString()
                + "','" + cmbCovering.SelectedItem.ToString() + "','" + cmbSAB.SelectedItem.ToString() + "')";
            cmd.ExecuteNonQuery();

            txtALC.Text = "";
            txtFERT.Text = "";
            cmbLocal.SelectedIndex = 0;
            cmbTrack.SelectedIndex = 0;
            cmbFormpad.SelectedIndex = 0;
            cmbHeadrestrian.SelectedIndex = 0;
            cmbHeadrestrian.SelectedIndex = 0;
            cmbSAB.SelectedIndex = 0;
            Do_Search();
            MessageBox.Show("추가되었습니다.");
        }

        private void Do_Delete()
        {
            string itemcode;
            itemcode = dataGridView1.SelectedCells[1].Value.ToString();
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from TB_SPEC where ITEMCODE=" + "'" + itemcode + "'" + "";
            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("삭제되었습니다.");
        }

        private void Do_Save()
        {
            string itemcode;
            string carcode;
            string spec1;
            string spec2;
            string spec3;
            string spec4;
            string spec5;
            string spec6;

            int i;
            i = dataGridView1.SelectedCells[0].RowIndex; // 현재 선택된 행 번호

            itemcode = dataGridView1.SelectedCells[0].Value.ToString();
            carcode = dataGridView1.Rows[i].Cells[2].Value.ToString(); // carcode선택
            spec1 = dataGridView1.Rows[i].Cells[3].Value.ToString();
            spec2 = dataGridView1.Rows[i].Cells[4].Value.ToString();
            spec3 = dataGridView1.Rows[i].Cells[5].Value.ToString();
            spec4 = dataGridView1.Rows[i].Cells[6].Value.ToString();
            spec5 = dataGridView1.Rows[i].Cells[7].Value.ToString();
            spec6 = dataGridView1.Rows[i].Cells[8].Value.ToString();



            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update TB_SPEC SET ITEMCODE = " + "'" + itemcode + "'" + "," +
                              "SPEC1 = " + "'" + spec1 + "'" + "," +
                              "SPEC2 = " + "'" + spec2 + "'" + "," +
                              "SPEC3 = " + "'" + spec3 + "'" + "," +
                              "SPEC4 = " + "'" + spec4 + "'" + "," +
                              "SPEC5 = " + "'" + spec5 + "'" + "," +
                              "SPEC6 = " + "'" + spec6 + "'" +
                              "where CARCODE = " + "'" + carcode + "'" + "";
            cmd.ExecuteNonQuery();
            Do_Search();
            MessageBox.Show("수정되었습니다.");
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Do_Save();
        }
    }

    // 추가작업
    // 차종 공통코드에서 가져오기
}
