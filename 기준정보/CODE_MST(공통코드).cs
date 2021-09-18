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
    public partial class CODE_MST : Form
    {
        SQL sql = new SQL();

        public CODE_MST()
        {
            InitializeComponent();
        }

        public void Search()
        {
            // 조건별 검색 기능 고민
        }

        public void disp() // 전체조회
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select MAJORCODE from TB_CODE_MST";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd2 = sql.con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select MINORCODE, CODENAME from TB_CODE_MST";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }
        
        private void CODE_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            disp();
        }

        // MAJORCODE 클릭 시 MINORCODE, CODENAME 조회
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string majorcode;
            majorcode = dataGridView1.SelectedCells[0].Value.ToString();

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select MINORCODE, CODENAME from TB_CODE_MST " +
                              "where MAJORCODE =" + "'" + majorcode + "'" + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            
            txtItemName.Text = dataGridView1.SelectedCells[0].Value.ToString();
            cboPlantCode.SelectedItem = "D001";
        }
    }
}
