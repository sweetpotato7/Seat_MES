﻿
namespace MESProject.기준정보
{
    partial class CODE_MST
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPlantCode = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIDisplayNo = new System.Windows.Forms.TextBox();
            this.txtIMinorName = new System.Windows.Forms.TextBox();
            this.txtIMajorName = new System.Windows.Forms.TextBox();
            this.txtIRelCode4 = new System.Windows.Forms.TextBox();
            this.txtIRelCode3 = new System.Windows.Forms.TextBox();
            this.txtIRelCode2 = new System.Windows.Forms.TextBox();
            this.txtIRelCode1 = new System.Windows.Forms.TextBox();
            this.cboIUseFlag = new System.Windows.Forms.ComboBox();
            this.cboIMinorCode = new System.Windows.Forms.ComboBox();
            this.cboIMajorCode = new System.Windows.Forms.ComboBox();
            this.cboIPlantcode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.cboSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboPlantCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1537, 55);
            this.panel2.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("굴림", 15F);
            this.txtSearch.Location = new System.Drawing.Point(293, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 30);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cboSearch
            // 
            this.cboSearch.Font = new System.Drawing.Font("굴림", 15F);
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(187, 12);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(100, 28);
            this.cboSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "공장";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Font = new System.Drawing.Font("굴림", 15F);
            this.cboPlantCode.FormattingEnabled = true;
            this.cboPlantCode.Items.AddRange(new object[] {
            "D001"});
            this.cboPlantCode.Location = new System.Drawing.Point(60, 12);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(121, 28);
            this.cboPlantCode.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(1231, 821);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(238, 821);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(989, 821);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1537, 825);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIDisplayNo);
            this.panel1.Controls.Add(this.txtIMinorName);
            this.panel1.Controls.Add(this.txtIMajorName);
            this.panel1.Controls.Add(this.txtIRelCode4);
            this.panel1.Controls.Add(this.txtIRelCode3);
            this.panel1.Controls.Add(this.txtIRelCode2);
            this.panel1.Controls.Add(this.txtIRelCode1);
            this.panel1.Controls.Add(this.cboIUseFlag);
            this.panel1.Controls.Add(this.cboIMinorCode);
            this.panel1.Controls.Add(this.cboIMajorCode);
            this.panel1.Controls.Add(this.cboIPlantcode);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1240, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 819);
            this.panel1.TabIndex = 3;
            // 
            // txtIDisplayNo
            // 
            this.txtIDisplayNo.Font = new System.Drawing.Font("굴림", 15F);
            this.txtIDisplayNo.Location = new System.Drawing.Point(95, 230);
            this.txtIDisplayNo.Name = "txtIDisplayNo";
            this.txtIDisplayNo.Size = new System.Drawing.Size(171, 30);
            this.txtIDisplayNo.TabIndex = 9;
            // 
            // txtIMinorName
            // 
            this.txtIMinorName.Font = new System.Drawing.Font("굴림", 15F);
            this.txtIMinorName.Location = new System.Drawing.Point(95, 191);
            this.txtIMinorName.Name = "txtIMinorName";
            this.txtIMinorName.Size = new System.Drawing.Size(171, 30);
            this.txtIMinorName.TabIndex = 8;
            // 
            // txtIMajorName
            // 
            this.txtIMajorName.Font = new System.Drawing.Font("굴림", 15F);
            this.txtIMajorName.Location = new System.Drawing.Point(95, 113);
            this.txtIMajorName.Name = "txtIMajorName";
            this.txtIMajorName.Size = new System.Drawing.Size(171, 30);
            this.txtIMajorName.TabIndex = 6;
            // 
            // txtIRelCode4
            // 
            this.txtIRelCode4.Font = new System.Drawing.Font("굴림", 15F);
            this.txtIRelCode4.Location = new System.Drawing.Point(95, 425);
            this.txtIRelCode4.Name = "txtIRelCode4";
            this.txtIRelCode4.Size = new System.Drawing.Size(171, 30);
            this.txtIRelCode4.TabIndex = 14;
            // 
            // txtIRelCode3
            // 
            this.txtIRelCode3.Font = new System.Drawing.Font("굴림", 15F);
            this.txtIRelCode3.Location = new System.Drawing.Point(95, 386);
            this.txtIRelCode3.Name = "txtIRelCode3";
            this.txtIRelCode3.Size = new System.Drawing.Size(171, 30);
            this.txtIRelCode3.TabIndex = 13;
            // 
            // txtIRelCode2
            // 
            this.txtIRelCode2.Font = new System.Drawing.Font("굴림", 15F);
            this.txtIRelCode2.Location = new System.Drawing.Point(95, 347);
            this.txtIRelCode2.Name = "txtIRelCode2";
            this.txtIRelCode2.Size = new System.Drawing.Size(171, 30);
            this.txtIRelCode2.TabIndex = 12;
            // 
            // txtIRelCode1
            // 
            this.txtIRelCode1.Font = new System.Drawing.Font("굴림", 15F);
            this.txtIRelCode1.Location = new System.Drawing.Point(95, 308);
            this.txtIRelCode1.Name = "txtIRelCode1";
            this.txtIRelCode1.Size = new System.Drawing.Size(171, 30);
            this.txtIRelCode1.TabIndex = 11;
            // 
            // cboIUseFlag
            // 
            this.cboIUseFlag.Font = new System.Drawing.Font("굴림", 15F);
            this.cboIUseFlag.FormattingEnabled = true;
            this.cboIUseFlag.Location = new System.Drawing.Point(95, 269);
            this.cboIUseFlag.Name = "cboIUseFlag";
            this.cboIUseFlag.Size = new System.Drawing.Size(171, 28);
            this.cboIUseFlag.TabIndex = 10;
            // 
            // cboIMinorCode
            // 
            this.cboIMinorCode.Font = new System.Drawing.Font("굴림", 15F);
            this.cboIMinorCode.FormattingEnabled = true;
            this.cboIMinorCode.Location = new System.Drawing.Point(95, 152);
            this.cboIMinorCode.Name = "cboIMinorCode";
            this.cboIMinorCode.Size = new System.Drawing.Size(171, 28);
            this.cboIMinorCode.TabIndex = 7;
            this.cboIMinorCode.SelectionChangeCommitted += new System.EventHandler(this.cboIMinorCode_SelectionChangeCommitted);
            // 
            // cboIMajorCode
            // 
            this.cboIMajorCode.Font = new System.Drawing.Font("굴림", 15F);
            this.cboIMajorCode.FormattingEnabled = true;
            this.cboIMajorCode.Location = new System.Drawing.Point(95, 77);
            this.cboIMajorCode.Name = "cboIMajorCode";
            this.cboIMajorCode.Size = new System.Drawing.Size(171, 28);
            this.cboIMajorCode.TabIndex = 5;
            this.cboIMajorCode.SelectionChangeCommitted += new System.EventHandler(this.cboIMajorCode_SelectionChangeCommitted);
            // 
            // cboIPlantcode
            // 
            this.cboIPlantcode.Font = new System.Drawing.Font("굴림", 15F);
            this.cboIPlantcode.FormattingEnabled = true;
            this.cboIPlantcode.Location = new System.Drawing.Point(95, 35);
            this.cboIPlantcode.Name = "cboIPlantcode";
            this.cboIPlantcode.Size = new System.Drawing.Size(171, 28);
            this.cboIPlantcode.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 15F);
            this.label12.Location = new System.Drawing.Point(10, 428);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "참조4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 15F);
            this.label11.Location = new System.Drawing.Point(10, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "참조3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 15F);
            this.label8.Location = new System.Drawing.Point(10, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "참조2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 15F);
            this.label9.Location = new System.Drawing.Point(10, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "사용";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 15F);
            this.label10.Location = new System.Drawing.Point(10, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "참조1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15F);
            this.label5.Location = new System.Drawing.Point(10, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "순서";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 15F);
            this.label6.Location = new System.Drawing.Point(10, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "부코드";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 15F);
            this.label7.Location = new System.Drawing.Point(10, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "코드명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 15F);
            this.label4.Location = new System.Drawing.Point(10, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "코드명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15F);
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "공장";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(10, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "주코드";
            // 
            // CODE_MST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 880);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CODE_MST";
            this.Text = "CODE_MST";
            this.Load += new System.EventHandler(this.CODE_MST_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPlantCode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIMinorName;
        private System.Windows.Forms.TextBox txtIMajorName;
        private System.Windows.Forms.TextBox txtIRelCode4;
        private System.Windows.Forms.TextBox txtIRelCode3;
        private System.Windows.Forms.TextBox txtIRelCode2;
        private System.Windows.Forms.TextBox txtIRelCode1;
        private System.Windows.Forms.ComboBox cboIUseFlag;
        private System.Windows.Forms.ComboBox cboIMinorCode;
        private System.Windows.Forms.ComboBox cboIMajorCode;
        private System.Windows.Forms.ComboBox cboIPlantcode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDisplayNo;
    }
}