namespace Quanlybangiay
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLNhanSu = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàiKhoảnNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKinhDoanh = new System.Windows.Forms.ToolStripMenuItem();
            this.bánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từSQLXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từXMLSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýPhiếuNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlWorkspace = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(169)))), ((int)(((byte)(141)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 53);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.lblTen);
            this.groupBox1.Controls.Add(this.lblHoTen);
            this.groupBox1.Controls.Add(this.lblQuyen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(985, 53);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(19, 73);
            this.lblTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(0, 19);
            this.lblTen.TabIndex = 2;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(586, 22);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(56, 19);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ Tên";
            // 
            // lblQuyen
            // 
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Location = new System.Drawing.Point(402, 22);
            this.lblQuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(52, 19);
            this.lblQuyen.TabIndex = 1;
            this.lblQuyen.Text = "Quyền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(516, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ Tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(343, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quyền:";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhậpToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.mnuHeThong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(96, 27);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            this.đăngNhậpToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            this.đăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
            this.đăngNhậpToolStripMenuItem.Text = "đăng nhập";
            this.đăngNhậpToolStripMenuItem.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
            this.đăngXuấtToolStripMenuItem.Text = "đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
            this.thoátToolStripMenuItem.Text = "thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // mnuQLNhanSu
            // 
            this.mnuQLNhanSu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhânViênToolStripMenuItem,
            this.quảnLýTàiKhoảnNhânViênToolStripMenuItem});
            this.mnuQLNhanSu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuQLNhanSu.Name = "mnuQLNhanSu";
            this.mnuQLNhanSu.Size = new System.Drawing.Size(149, 27);
            this.mnuQLNhanSu.Text = "Quản lý nhân sự";
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(309, 28);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýTàiKhoảnNhânViênToolStripMenuItem
            // 
            this.quảnLýTàiKhoảnNhânViênToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.quảnLýTàiKhoảnNhânViênToolStripMenuItem.Name = "quảnLýTàiKhoảnNhânViênToolStripMenuItem";
            this.quảnLýTàiKhoảnNhânViênToolStripMenuItem.Size = new System.Drawing.Size(309, 28);
            this.quảnLýTàiKhoảnNhânViênToolStripMenuItem.Text = "Quản lý tài khoản nhân viên";
            this.quảnLýTàiKhoảnNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTàiKhoảnNhânViênToolStripMenuItem_Click);
            // 
            // mnuKinhDoanh
            // 
            this.mnuKinhDoanh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bánHàngToolStripMenuItem,
            this.quảnLýHàngToolStripMenuItem,
            this.quảnLýNhàCungCấpToolStripMenuItem});
            this.mnuKinhDoanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuKinhDoanh.Name = "mnuKinhDoanh";
            this.mnuKinhDoanh.Size = new System.Drawing.Size(174, 27);
            this.mnuKinhDoanh.Text = "Quản lý kinh doanh";
            this.mnuKinhDoanh.Click += new System.EventHandler(this.mnuKinhDoanh_Click);
            // 
            // bánHàngToolStripMenuItem
            // 
            this.bánHàngToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            this.bánHàngToolStripMenuItem.Size = new System.Drawing.Size(262, 28);
            this.bánHàngToolStripMenuItem.Text = "Quản lý hóa Đơn";
            this.bánHàngToolStripMenuItem.Click += new System.EventHandler(this.bánHàngToolStripMenuItem_Click);
            // 
            // quảnLýHàngToolStripMenuItem
            // 
            this.quảnLýHàngToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.quảnLýHàngToolStripMenuItem.Name = "quảnLýHàngToolStripMenuItem";
            this.quảnLýHàngToolStripMenuItem.Size = new System.Drawing.Size(262, 28);
            this.quảnLýHàngToolStripMenuItem.Text = "Quản lý hàng";
            this.quảnLýHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHàngToolStripMenuItem_Click);
            // 
            // quảnLýNhàCungCấpToolStripMenuItem
            // 
            this.quảnLýNhàCungCấpToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.quảnLýNhàCungCấpToolStripMenuItem.Name = "quảnLýNhàCungCấpToolStripMenuItem";
            this.quảnLýNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(262, 28);
            this.quảnLýNhàCungCấpToolStripMenuItem.Text = "Quản lý nhà cung cấp";
            this.quảnLýNhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhàCungCấpToolStripMenuItem_Click);
            // 
            // chuyểnĐổiDữLiệuToolStripMenuItem
            // 
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Checked = true;
            this.chuyểnĐổiDữLiệuToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chuyểnĐổiDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.từSQLXMLToolStripMenuItem,
            this.từXMLSQLToolStripMenuItem});
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Name = "chuyểnĐổiDữLiệuToolStripMenuItem";
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(168, 27);
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Text = "Chuyển đổi dữ liệu";
            // 
            // từSQLXMLToolStripMenuItem
            // 
            this.từSQLXMLToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.từSQLXMLToolStripMenuItem.Name = "từSQLXMLToolStripMenuItem";
            this.từSQLXMLToolStripMenuItem.Size = new System.Drawing.Size(227, 28);
            this.từSQLXMLToolStripMenuItem.Text = "Từ SQL sang XML";
            this.từSQLXMLToolStripMenuItem.Click += new System.EventHandler(this.từSQLXMLToolStripMenuItem_Click);
            // 
            // từXMLSQLToolStripMenuItem
            // 
            this.từXMLSQLToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.từXMLSQLToolStripMenuItem.Name = "từXMLSQLToolStripMenuItem";
            this.từXMLSQLToolStripMenuItem.Size = new System.Drawing.Size(227, 28);
            this.từXMLSQLToolStripMenuItem.Text = "Từ XML sang SQL";
            this.từXMLSQLToolStripMenuItem.Click += new System.EventHandler(this.từXMLSQLToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQLNhanSu,
            this.mnuKinhDoanh,
            this.quảnLýPhiếuNhậpToolStripMenuItem,
            this.chuyểnĐổiDữLiệuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(985, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýPhiếuNhậpToolStripMenuItem
            // 
            this.quảnLýPhiếuNhậpToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.quảnLýPhiếuNhậpToolStripMenuItem.Checked = true;
            this.quảnLýPhiếuNhậpToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.quảnLýPhiếuNhậpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.quảnLýPhiếuNhậpToolStripMenuItem.Name = "quảnLýPhiếuNhậpToolStripMenuItem";
            this.quảnLýPhiếuNhậpToolStripMenuItem.Size = new System.Drawing.Size(175, 27);
            this.quảnLýPhiếuNhậpToolStripMenuItem.Text = "Quản lý phiếu nhập";
            this.quảnLýPhiếuNhậpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýPhiếuNhậpToolStripMenuItem_Click);
            // 
            // pnlWorkspace
            // 
            this.pnlWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlWorkspace.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlWorkspace.BackgroundImage")));
            this.pnlWorkspace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkspace.Location = new System.Drawing.Point(0, 84);
            this.pnlWorkspace.Margin = new System.Windows.Forms.Padding(4);
            this.pnlWorkspace.Name = "pnlWorkspace";
            this.pnlWorkspace.Size = new System.Drawing.Size(985, 606);
            this.pnlWorkspace.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(985, 690);
            this.Controls.Add(this.pnlWorkspace);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán giày";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuQLNhanSu;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýTàiKhoảnNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuKinhDoanh;
        private System.Windows.Forms.ToolStripMenuItem bánHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chuyểnĐổiDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem từSQLXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem từXMLSQLToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhiếuNhậpToolStripMenuItem;
        private System.Windows.Forms.Panel pnlWorkspace;
    }
}

