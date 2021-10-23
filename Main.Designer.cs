
namespace MESProject
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.기준정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공통코드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.품번ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사양관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용자관리ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.생산계획ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.생산계획ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.공정관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공정실적ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공정순서관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공정관리ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.조립공정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtVersion = new System.Windows.Forms.ToolStripTextBox();
            this.txtDT = new System.Windows.Forms.ToolStripTextBox();
            this.pnlCRUD = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimeUse = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatemsg = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.pnlCRUD.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.기준정보ToolStripMenuItem,
            this.생산계획ToolStripMenuItem,
            this.공정관리ToolStripMenuItem,
            this.종료ToolStripMenuItem,
            this.txtVersion,
            this.txtDT});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 기준정보ToolStripMenuItem
            // 
            this.기준정보ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.공통코드ToolStripMenuItem,
            this.품번ToolStripMenuItem,
            this.bOMToolStripMenuItem,
            this.사양관리ToolStripMenuItem,
            this.사용자관리ToolStripMenuItem1});
            this.기준정보ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.기준정보ToolStripMenuItem.Name = "기준정보ToolStripMenuItem";
            this.기준정보ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.기준정보ToolStripMenuItem.Text = "기준정보";
            // 
            // 공통코드ToolStripMenuItem
            // 
            this.공통코드ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.공통코드ToolStripMenuItem.Image = global::MESProject.Properties.Resources._111_removebg_preview;
            this.공통코드ToolStripMenuItem.Name = "공통코드ToolStripMenuItem";
            this.공통코드ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.공통코드ToolStripMenuItem.Text = "공통코드";
            this.공통코드ToolStripMenuItem.Click += new System.EventHandler(this.공통코드ToolStripMenuItem_Click);
            // 
            // 품번ToolStripMenuItem
            // 
            this.품번ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.품번ToolStripMenuItem.Image = global::MESProject.Properties.Resources._222_removebg_preview;
            this.품번ToolStripMenuItem.Name = "품번ToolStripMenuItem";
            this.품번ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.품번ToolStripMenuItem.Text = "품목관리";
            this.품번ToolStripMenuItem.Click += new System.EventHandler(this.품번ToolStripMenuItem_Click);
            // 
            // bOMToolStripMenuItem
            // 
            this.bOMToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.bOMToolStripMenuItem.Image = global::MESProject.Properties.Resources._333_removebg_preview;
            this.bOMToolStripMenuItem.Name = "bOMToolStripMenuItem";
            this.bOMToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.bOMToolStripMenuItem.Text = "BOM";
            this.bOMToolStripMenuItem.Click += new System.EventHandler(this.bOMToolStripMenuItem_Click);
            // 
            // 사양관리ToolStripMenuItem
            // 
            this.사양관리ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.사양관리ToolStripMenuItem.Image = global::MESProject.Properties.Resources._444_removebg_preview;
            this.사양관리ToolStripMenuItem.Name = "사양관리ToolStripMenuItem";
            this.사양관리ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.사양관리ToolStripMenuItem.Text = "사양관리";
            this.사양관리ToolStripMenuItem.Click += new System.EventHandler(this.사양관리ToolStripMenuItem_Click);
            // 
            // 사용자관리ToolStripMenuItem1
            // 
            this.사용자관리ToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.사용자관리ToolStripMenuItem1.Image = global::MESProject.Properties.Resources._555_removebg_preview;
            this.사용자관리ToolStripMenuItem1.Name = "사용자관리ToolStripMenuItem1";
            this.사용자관리ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.사용자관리ToolStripMenuItem1.Text = "사용자관리";
            this.사용자관리ToolStripMenuItem1.Click += new System.EventHandler(this.사용자관리ToolStripMenuItem_Click);
            // 
            // 생산계획ToolStripMenuItem
            // 
            this.생산계획ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.생산계획ToolStripMenuItem1});
            this.생산계획ToolStripMenuItem.Name = "생산계획ToolStripMenuItem";
            this.생산계획ToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.생산계획ToolStripMenuItem.Text = "생산계획";
            // 
            // 생산계획ToolStripMenuItem1
            // 
            this.생산계획ToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.생산계획ToolStripMenuItem1.Image = global::MESProject.Properties.Resources._666_removebg_preview;
            this.생산계획ToolStripMenuItem1.Name = "생산계획ToolStripMenuItem1";
            this.생산계획ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.생산계획ToolStripMenuItem1.Text = "작업지시";
            this.생산계획ToolStripMenuItem1.Click += new System.EventHandler(this.생산계획ToolStripMenuItem1_Click);
            // 
            // 공정관리ToolStripMenuItem
            // 
            this.공정관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.공정실적ToolStripMenuItem,
            this.공정순서관리ToolStripMenuItem,
            this.공정관리ToolStripMenuItem1,
            this.조립공정ToolStripMenuItem});
            this.공정관리ToolStripMenuItem.Name = "공정관리ToolStripMenuItem";
            this.공정관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.공정관리ToolStripMenuItem.Text = "공정관리";
            // 
            // 공정실적ToolStripMenuItem
            // 
            this.공정실적ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.공정실적ToolStripMenuItem.Image = global::MESProject.Properties.Resources._777_removebg_preview;
            this.공정실적ToolStripMenuItem.Name = "공정실적ToolStripMenuItem";
            this.공정실적ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.공정실적ToolStripMenuItem.Text = "공정실적";
            this.공정실적ToolStripMenuItem.Click += new System.EventHandler(this.공정실적ToolStripMenuItem_Click);
            // 
            // 공정순서관리ToolStripMenuItem
            // 
            this.공정순서관리ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.공정순서관리ToolStripMenuItem.Image = global::MESProject.Properties.Resources._888_removebg_preview;
            this.공정순서관리ToolStripMenuItem.Name = "공정순서관리ToolStripMenuItem";
            this.공정순서관리ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.공정순서관리ToolStripMenuItem.Text = "공정순서관리";
            this.공정순서관리ToolStripMenuItem.Click += new System.EventHandler(this.공정순서관리ToolStripMenuItem_Click);
            // 
            // 공정관리ToolStripMenuItem1
            // 
            this.공정관리ToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.공정관리ToolStripMenuItem1.Image = global::MESProject.Properties.Resources._999_removebg_preview;
            this.공정관리ToolStripMenuItem1.Name = "공정관리ToolStripMenuItem1";
            this.공정관리ToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.공정관리ToolStripMenuItem1.Text = "트랙적재공정";
            this.공정관리ToolStripMenuItem1.Click += new System.EventHandler(this.공정관리ToolStripMenuItem1_Click);
            // 
            // 조립공정ToolStripMenuItem
            // 
            this.조립공정ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.조립공정ToolStripMenuItem.Image = global::MESProject.Properties.Resources._1010_removebg_preview;
            this.조립공정ToolStripMenuItem.Name = "조립공정ToolStripMenuItem";
            this.조립공정ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.조립공정ToolStripMenuItem.Text = "조립공정";
            this.조립공정ToolStripMenuItem.Click += new System.EventHandler(this.조립공정ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtVersion.BackColor = System.Drawing.SystemColors.Window;
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVersion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVersion.ShortcutsEnabled = false;
            this.txtVersion.Size = new System.Drawing.Size(75, 22);
            this.txtVersion.Text = "ver 00.0000";
            // 
            // txtDT
            // 
            this.txtDT.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtDT.BackColor = System.Drawing.SystemColors.Window;
            this.txtDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDT.Name = "txtDT";
            this.txtDT.ReadOnly = true;
            this.txtDT.ShortcutsEnabled = false;
            this.txtDT.Size = new System.Drawing.Size(125, 22);
            this.txtDT.Text = "0000-00-00 00:00:00";
            // 
            // pnlCRUD
            // 
            this.pnlCRUD.ColumnCount = 6;
            this.pnlCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlCRUD.Controls.Add(this.btnClose, 5, 0);
            this.pnlCRUD.Controls.Add(this.btnSave, 4, 0);
            this.pnlCRUD.Controls.Add(this.btnDelete, 3, 0);
            this.pnlCRUD.Controls.Add(this.btnInsert, 2, 0);
            this.pnlCRUD.Controls.Add(this.btnSearch, 1, 0);
            this.pnlCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCRUD.Location = new System.Drawing.Point(3, 27);
            this.pnlCRUD.Name = "pnlCRUD";
            this.pnlCRUD.RowCount = 1;
            this.pnlCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCRUD.Size = new System.Drawing.Size(963, 44);
            this.pnlCRUD.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Window;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(913, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 44);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Window;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(863, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(813, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 44);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.SystemColors.Window;
            this.btnInsert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnInsert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Location = new System.Drawing.Point(763, 0);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(0);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(50, 44);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Window;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(713, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 44);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.ColumnCount = 6;
            this.pnlStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.pnlStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.pnlStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.pnlStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.pnlStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.pnlStatus.Controls.Add(this.lblTimeUse, 5, 0);
            this.pnlStatus.Controls.Add(this.lblId, 3, 0);
            this.pnlStatus.Controls.Add(this.label4, 2, 0);
            this.pnlStatus.Controls.Add(this.label3, 1, 0);
            this.pnlStatus.Controls.Add(this.lblName, 4, 0);
            this.pnlStatus.Controls.Add(this.lblStatemsg, 0, 0);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Location = new System.Drawing.Point(3, 587);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.RowCount = 1;
            this.pnlStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlStatus.Size = new System.Drawing.Size(963, 17);
            this.pnlStatus.TabIndex = 2;
            // 
            // lblTimeUse
            // 
            this.lblTimeUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeUse.AutoSize = true;
            this.lblTimeUse.Location = new System.Drawing.Point(766, 2);
            this.lblTimeUse.Name = "lblTimeUse";
            this.lblTimeUse.Size = new System.Drawing.Size(194, 12);
            this.lblTimeUse.TabIndex = 5;
            this.lblTimeUse.Text = "label7";
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(606, 2);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(38, 12);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "label5";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(536, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(676, 2);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "가나다";
            // 
            // lblStatemsg
            // 
            this.lblStatemsg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatemsg.AutoSize = true;
            this.lblStatemsg.Location = new System.Drawing.Point(3, 2);
            this.lblStatemsg.Name = "lblStatemsg";
            this.lblStatemsg.Size = new System.Drawing.Size(93, 12);
            this.lblStatemsg.TabIndex = 1;
            this.lblStatemsg.Text = "StatusMessage";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlStatus, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pnlCRUD, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(969, 607);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(963, 504);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(955, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 607);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlCRUD.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 기준정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공통코드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 품번ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사양관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용자관리ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 생산계획ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 생산계획ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 공정관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공정실적ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel pnlCRUD;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel pnlStatus;
        private System.Windows.Forms.Label lblTimeUse;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatemsg;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripTextBox txtVersion;
        private System.Windows.Forms.ToolStripTextBox txtDT;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 공정순서관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공정관리ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 조립공정ToolStripMenuItem;
    }
}