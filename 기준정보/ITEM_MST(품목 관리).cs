﻿using System;
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
        //string imageUrl = null;

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

        private void ITEM_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // 셀 클릭 시 자동완성
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;

            cboPlantCode.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cboItemCode.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtItemName.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cboItemType.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

            using (OpenFileDialog ofd = new OpenFileDialog())
                if (dataGridView1.Rows[i].Cells[6].Value != "")
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
        }

        #region 버튼기능
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

        // 셀 선택 후 자동완성 시키고 ITEMCODE와 대조해서 삭제
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
            cmd.CommandText = "insert into TB_ITEM_MST (PLANTCODE, ITEMCODE, ITEMNAME, ITEMTYPE, UNITCODE) values('" + cboPlantCode.SelectedItem.ToString() + "','" + txtItemName.Text + "','" + cboItemCode.Text.ToString() + "','" + cboItemType.Text.ToString() + "','" + cboUnit.Text.ToString() + "')";
            cmd.ExecuteNonQuery();

            cboPlantCode.SelectedItem = "";
            txtItemName.Text = "";
            cboItemCode.SelectedItem = "";
            cboItemType.SelectedItem = "";
            Do_Search();
            MessageBox.Show("품목이 추가되었습니다.");
        }

        // 이미지 업로드
        public void Image_Upload()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into TB_ITEM_MST (IMAGE) values(@image)";
            cmd.ExecuteNonQuery();
        }
        
        private void Do_Exit()
        {
            this.Close();
        }
        #endregion

        #region 버튼클릭
        private void btn_Add_Click(object sender, EventArgs e) 
        {
            Do_Add();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            Do_Delete();
        }
        #endregion

        private void btnUpload_Click(object sender, EventArgs e) //이미지 업로드
        {
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            
            string itemcode;
            int i;

            i = dataGridView1.SelectedCells[0].RowIndex; // 현재 선택된 행 번호
            itemcode = dataGridView1.Rows[i].Cells[1].Value.ToString(); 

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update TB_ITEM_MST set IMAGE = @IMAGE where ITEMCODE =" + "'" + itemcode + "'";
            cmd.Parameters.AddWithValue("@IMAGE", arr);
            //cmd.Parameters.AddWithValue("@IMAGE_URL", imageUrl);
            cmd.ExecuteNonQuery();
            MessageBox.Show("이미지가 업로드 되었습니다.");
            Do_Search();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    //imageUrl = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}

// 검색조건 코드 어떻게?
// 셀클릭시 이미지 출력되게 만들기
