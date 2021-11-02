using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace MESProject.기준정보
{
    public partial class ITEM_MST : Form
    {
        SQL sql = new SQL();
        string imageUrl = null;
        Function func = new Function();
        //public byte[] Image { get; set; }

        public ITEM_MST()
        {
            InitializeComponent();
        }

        

        private void ITEM_MST_Load(object sender, EventArgs e)
        {
            if (sql.con.State == ConnectionState.Open)
            {
                sql.con.Close();
            }
            sql.con.Open();
            DGVLoad();
            CboSet();
            Do_Search();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        #region 그리드세팅
        private void DGVLoad()
        {
            string[] DataPropertyName = new string[] { "PLANTCODE", "ITEMCODE", "ITEMNAME", "ITEMTYPE", "UNITCODE", "USEFLAG", "IMAGE", "CREATE_DT", "CREATE_USERID", "MODIFY_DT", "MODIFY_USERID"};
            string[] HeaderText = new string[] { "공장", "품목코드", "품목명", "품목타입", "단위", "사용여부", "이미지", "등록일시", "등록자", "수정일시", "수정자"};
            float[] FillWeight = new float[] { 50, 100, 100, 50, 50, 50, 100, 100, 100, 100, 100, 100, 100 };
            Font StyleFont = new Font("맑은고딕", 11, FontStyle.Bold);
            Font BodyStyleFont = new Font("맑은고딕", 11, FontStyle.Regular);


            //스타일 지정 밎 그리드에 데이터 바인드
            Main.DGVSetting(this.dataGridView1, DataPropertyName, 30, HeaderText, null, FillWeight, StyleFont, BodyStyleFont, 16);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Columns[6].Visible = false;

            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(95, 184, 255);

        }
        #endregion

        #region CRUD
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
        public void Do_Delete()
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
        public void Do_Add()
        {
            string check = "해당 칸을 입력해주세요";
            if (cboPlantCode.Text == "")
            {
                check += "\n공장";
            }
            if (cboItemCode.Text == "")
            {
                check += "\n품목코드 ";
            }
            if (txtItemName.Text == "")
            {
                check += "\n품목명 ";
            }
            if (cboItemType.Text == "")
            {
                check += "\n품목타입 ";
            }
            if (cboUnit.Text == "")
            {
                check += "\n단위 ";
            }
            if (check.Length != 12)
            {
                MessageBox.Show(check, "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "insert into TB_ITEM_MST (PLANTCODE, ITEMCODE, ITEMNAME, ITEMTYPE, UNITCODE) values('" + cboPlantCode.SelectedItem.ToString() + "','" + txtItemName.Text + "','" + cboItemCode.Text.ToString() + "','" + cboItemType.Text.ToString() + "','" + cboUnit.Text.ToString() + "')";
            cmd.CommandText = "insert into TB_ITEM_MST (PLANTCODE, ITEMCODE, ITEMNAME, ITEMTYPE, UNITCODE) values('" + cboPlantCode.SelectedItem.ToString() + "','" + cboItemCode.Text + "','" + txtItemName.Text + "','" + cboItemType.Text.ToString() + "','" + cboUnit.Text.ToString() + "')";
            cmd.ExecuteNonQuery();

            cboPlantCode.SelectedItem = "";
            txtItemName.Text = "";
            cboItemCode.SelectedItem = "";
            cboItemType.SelectedItem = "";
            Do_Search();
            MessageBox.Show("품목이 추가되었습니다.");
        }

        public void Do_Save()
        {
            string itemcode;
            int i;

            i = dataGridView1.SelectedCells[0].RowIndex; // 현재 선택된 행 번호
            itemcode = dataGridView1.Rows[i].Cells[1].Value.ToString(); // itemcode

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update TB_ITEM_MST SET " +
                              "ITEMNAME = '" + txtItemName.Text + "', " +
                              "ITEMTYPE = '" + cboItemType.Text + "', " +
                              "UNITCODE = '" + cboUnit.Text     + "'" +
                              "where ITEMCODE = '" + itemcode + "'";
            cmd.ExecuteNonQuery();

            Do_Search();
            MessageBox.Show("수정되었습니다.");

        }
        #endregion

        #region 이미지처리
        // 바이트 단위로 저장된 이미지를 다시 이미지로 만드는 함수
        private Image ConvertByteToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        // 이미지를 바이트 단위로 저장하는 함수

        private byte[] ConvertImageToByte(Image img)
        {
            Image temp = new Bitmap(img); // 중요
            using (MemoryStream ms = new MemoryStream())
            {
                temp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;
            string picture = dataGridView1.Rows[i].Cells[5].Value.ToString();

            if (picture != string.Empty)
            {
                MessageBox.Show("기존 이미지를 삭제 후 Browse 해주세요.");
            }
            if (picture == string.Empty)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        imageUrl = ofd.FileName;
                        txtURL.Text = imageUrl;
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                    }
                }
            }
        }

        // 이미지 업로드
        public void Image_Upload()
        {
            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update TB_ITEM_MST set IMAGE = @image";
            cmd.ExecuteNonQuery();
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;

                cboPlantCode.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                cboItemCode.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtItemName.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                cboItemType.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

                var picture = dataGridView1.Rows[i].Cells[5].Value.ToString();

                DataTable dt = dataGridView1.DataSource as DataTable;
                if (picture != string.Empty)
                {
                    DataRow row = dt.Rows[e.RowIndex];
                    pictureBox1.Image = ConvertByteToImage((byte[])row["IMAGE"]);
                }
                if (picture == string.Empty)
                {
                    pictureBox1.Image = null;
                }
            }

            catch
            {

            }
        }

        #endregion

        #region ========== 콤보박스
        private void CboSet()
        {
            func.CboLoad(cboPlantCode, "TB_CODE_MST", "MINORCODE", false, "MAJORCODE", "PLANT");
            func.CboLoad(cboItemCode,  "TB_ITEM_MST", "ITEMCODE",  false);
            func.CboLoad(cboItemType,  "TB_CODE_MST", "MINORCODE", false, "MAJORCODE", "PART_TYPE");
            func.CboLoad(cboUnit,      "TB_ITEM_MST", "UNITCODE",  false);
            cboPlantCode.SelectedItem = cboPlantCode.Items[0];
        }
        
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            string itemcode;
            
            i = dataGridView1.SelectedCells[0].RowIndex;
            itemcode = dataGridView1.Rows[i].Cells[1].Value.ToString();

            SqlCommand cmd = sql.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "insert into TB_ITEM_MST (PLANTCODE, ITEMCODE, ITEMNAME, ITEMTYPE, UNITCODE) values('" + cboPlantCode.SelectedItem.ToString() + "','" + txtItemName.Text + "','" + cboItemCode.Text.ToString() + "','" + cboItemType.Text.ToString() + "','" + cboUnit.Text.ToString() + "')";
            cmd.CommandText = "update TB_ITEM_MST set IMAGE = NULL where ITEMCODE =" + "'" + itemcode + "'" + "";
            cmd.ExecuteNonQuery();
            MessageBox.Show("이미지가 삭제되었습니다.");
            Do_Search();
        }

    }
}

// 검색조건 코드 어떻게?
// 셀클릭시 선택셀 표시
// 이미지셀 표시방법
