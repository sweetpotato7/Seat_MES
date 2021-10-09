
namespace MESProject.공정관리
{
    partial class PROC_SEQ_공정순서관리_
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboProc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPlant = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboStepCode = new System.Windows.Forms.ComboBox();
            this.cboProcCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLineNum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPlantCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtProcSeq = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboProcName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboStepName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cboProc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboLine);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboPlant);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 48);
            this.panel1.TabIndex = 0;
            // 
            // cboProc
            // 
            this.cboProc.FormattingEnabled = true;
            this.cboProc.Location = new System.Drawing.Point(479, 9);
            this.cboProc.Name = "cboProc";
            this.cboProc.Size = new System.Drawing.Size(121, 23);
            this.cboProc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "공정코드";
            // 
            // cboLine
            // 
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(268, 11);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(121, 23);
            this.cboLine.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "라인넘버";
            // 
            // cboPlant
            // 
            this.cboPlant.FormattingEnabled = true;
            this.cboPlant.Location = new System.Drawing.Point(56, 10);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.Size = new System.Drawing.Size(121, 23);
            this.cboPlant.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "공장";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.txtProcSeq);
            this.panel2.Controls.Add(this.cboStepName);
            this.panel2.Controls.Add(this.cboStepCode);
            this.panel2.Controls.Add(this.cboProcName);
            this.panel2.Controls.Add(this.cboProcCode);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboLineNum);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboPlantCode);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(600, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 402);
            this.panel2.TabIndex = 1;
            // 
            // cboStepCode
            // 
            this.cboStepCode.FormattingEnabled = true;
            this.cboStepCode.Location = new System.Drawing.Point(79, 210);
            this.cboStepCode.Name = "cboStepCode";
            this.cboStepCode.Size = new System.Drawing.Size(99, 23);
            this.cboStepCode.TabIndex = 9;
            // 
            // cboProcCode
            // 
            this.cboProcCode.FormattingEnabled = true;
            this.cboProcCode.Location = new System.Drawing.Point(80, 127);
            this.cboProcCode.Name = "cboProcCode";
            this.cboProcCode.Size = new System.Drawing.Size(99, 23);
            this.cboProcCode.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "작업코드";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "공정순서";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "공정코드";
            // 
            // cboLineNum
            // 
            this.cboLineNum.FormattingEnabled = true;
            this.cboLineNum.Location = new System.Drawing.Point(80, 90);
            this.cboLineNum.Name = "cboLineNum";
            this.cboLineNum.Size = new System.Drawing.Size(99, 23);
            this.cboLineNum.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "라인넘버";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.FormattingEnabled = true;
            this.cboPlantCode.Location = new System.Drawing.Point(80, 51);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(99, 23);
            this.cboPlantCode.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "공장";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "공정추가";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(600, 402);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtProcSeq
            // 
            this.txtProcSeq.Location = new System.Drawing.Point(79, 277);
            this.txtProcSeq.Name = "txtProcSeq";
            this.txtProcSeq.Size = new System.Drawing.Size(99, 25);
            this.txtProcSeq.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "공정";
            // 
            // cboProcName
            // 
            this.cboProcName.FormattingEnabled = true;
            this.cboProcName.Location = new System.Drawing.Point(80, 166);
            this.cboProcName.Name = "cboProcName";
            this.cboProcName.Size = new System.Drawing.Size(99, 23);
            this.cboProcName.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "작업";
            // 
            // cboStepName
            // 
            this.cboStepName.FormattingEnabled = true;
            this.cboStepName.Location = new System.Drawing.Point(79, 241);
            this.cboStepName.Name = "cboStepName";
            this.cboStepName.Size = new System.Drawing.Size(99, 23);
            this.cboStepName.TabIndex = 9;
            // 
            // PROC_SEQ_공정순서관리_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PROC_SEQ_공정순서관리_";
            this.Text = "PROC_SEQ_공정순서관리_";
            this.Load += new System.EventHandler(this.PROC_SEQ_공정순서관리__Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboProc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPlant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboStepCode;
        private System.Windows.Forms.ComboBox cboProcCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboLineNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPlantCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtProcSeq;
        private System.Windows.Forms.ComboBox cboStepName;
        private System.Windows.Forms.ComboBox cboProcName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}