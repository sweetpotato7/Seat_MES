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
    public partial class USER_ADMIN : Form
    {
        //SqlConnection 개체를 사용해 DB에 접속
        //private string sqlCon = string.Format("Data Source={0}{1}; Initial Catalog={2}; User ID={3}; Password={4}", "127.0.0.1", 1433, "testdb", "sa", "1111");

        SqlConnection sqlCon = new SqlConnection("server = 222.235.141.8;" + "Database=KFQB_MES_2021;" + "Uid=kfqb;" + "Pwd=2211;");

        public USER_ADMIN()
        {
            InitializeComponent();
            sqlCon.Open();
            DGVLoad();
        }



        private void DGVLoad()
        {

            SqlCommand command = new SqlCommand("SELECT * FROM TB_USER_INFO", sqlCon);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dt.Rows.Add();
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //조회개요
            //SqlCommand를 이용하여 CRUD 쿼리를 실행할 수 있음
            //SqlCommand는 쿼리를 실행하기 위해 대표적으로 3개의 메서드(ExecuteNonQuerys, ExecuteScalar, ExecuteReader)를 제공함


            //조회방법 1
            //SqlCommand cmd = sqlCon.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from TB_USER_INFO";
            //cmd.ExecuteNonQuery();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //추가(수정필요)
            SqlCommand cmd = new SqlCommand("INSERT INTO TB_USER_INFO(WORKERID, WORKERNAME, PASSWORD, BANCODE, PLANTCODE, PHONENO, INDATE, OUTDATE, USEFLAG, CREATE_DT, CREATE_USERID, MODIFY_DT, MODIFY_USERID)", sqlCon);
        }

        private void Do_Add()
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "insert into TB_USER_INFO(PLANTCODE, ITEMCODE, ITEMNAME, ITEMTYPE) values('" + cboPlantCode.SelectedItem.ToString() + "','" + txtItemName.Text + "','" + cboItemCode.SelectedItem.ToString() + "','" + cboItemType.SelectedItem.ToString() + "')";

            //cmd.ExecuteNonQuery();

            //cboPlantCode.SelectedItem = "";
            //txtItemName.Text = "";
            //cboItemCode.SelectedItem = "";
            //cboItemType.SelectedItem = "";
            //MessageBox.Show("품목이 추가되었습니다.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //삭제
            string itemcode;
            itemcode = dataGridView1.SelectedCells[1].Value.ToString();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE * FROM TB_USER_INFO WHERE WORKERID=" + "'" + itemcode + "'" + "";
            cmd.ExecuteNonQuery();
            MessageBox.Show("삭제되었습니다.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //닫기
            Close();
        }

    }
}
