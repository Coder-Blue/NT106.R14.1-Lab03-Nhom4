namespace NT106.R14._1_Lab03_Nhom4.Bai05
{
    partial class Bai05Server
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblSoClient = new Label();
            btnListen = new Button();
            grpMonAn = new GroupBox();
            lvMonAn = new ListView();
            colMa = new ColumnHeader();
            colTenMon = new ColumnHeader();
            colNguoiDongGop = new ColumnHeader();
            btnXoaMon = new Button();
            btnLamMoi = new Button();
            lblTongMon = new Label();
            grpChiTiet = new GroupBox();
            picMonAn = new PictureBox();
            lblTenMon = new Label();
            lblNguoiDongGop = new Label();
            grpNhatKy = new GroupBox();
            rtbNhatKy = new RichTextBox();
            lblTrangThai = new Label();
            grpMonAn.SuspendLayout();
            grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMonAn).BeginInit();
            grpNhatKy.SuspendLayout();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(35, 78, 120);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(700, 38);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "TCP SERVER - HÔM NAY ĂN GÌ?";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(800, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Dữ liệu món ăn được lưu trong SQLite tại Server và đồng bộ tới tất cả Client.";
            //
            // lblSoClient
            //
            lblSoClient.Font = new Font("Segoe UI", 9.5F);
            lblSoClient.ForeColor = Color.FromArgb(100, 100, 100);
            lblSoClient.Location = new Point(760, 24);
            lblSoClient.Name = "lblSoClient";
            lblSoClient.Size = new Size(170, 24);
            lblSoClient.TabIndex = 2;
            lblSoClient.Text = "0 client đang kết nối";
            lblSoClient.TextAlign = ContentAlignment.MiddleRight;
            //
            // btnListen
            //
            btnListen.BackColor = Color.FromArgb(51, 122, 183);
            btnListen.Cursor = Cursors.Hand;
            btnListen.FlatAppearance.BorderSize = 0;
            btnListen.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnListen.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnListen.FlatStyle = FlatStyle.Flat;
            btnListen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnListen.ForeColor = Color.White;
            btnListen.Location = new Point(950, 16);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(146, 44);
            btnListen.TabIndex = 3;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            //
            // grpMonAn
            //
            grpMonAn.Controls.Add(lvMonAn);
            grpMonAn.Controls.Add(btnXoaMon);
            grpMonAn.Controls.Add(btnLamMoi);
            grpMonAn.Controls.Add(lblTongMon);
            grpMonAn.Font = new Font("Segoe UI", 10F);
            grpMonAn.Location = new Point(24, 90);
            grpMonAn.Name = "grpMonAn";
            grpMonAn.Size = new Size(650, 520);
            grpMonAn.TabIndex = 4;
            grpMonAn.TabStop = false;
            grpMonAn.Text = "Danh sách món ăn (SQLite)";
            //
            // lvMonAn
            //
            lvMonAn.Columns.AddRange(new ColumnHeader[] { colMa, colTenMon, colNguoiDongGop });
            lvMonAn.Font = new Font("Segoe UI", 9.5F);
            lvMonAn.FullRowSelect = true;
            lvMonAn.GridLines = true;
            lvMonAn.Location = new Point(14, 26);
            lvMonAn.MultiSelect = false;
            lvMonAn.Name = "lvMonAn";
            lvMonAn.Size = new Size(622, 420);
            lvMonAn.TabIndex = 0;
            lvMonAn.UseCompatibleStateImageBehavior = false;
            lvMonAn.View = View.Details;
            lvMonAn.SelectedIndexChanged += lvMonAn_SelectedIndexChanged;
            //
            // colMa
            //
            colMa.Text = "Mã";
            colMa.Width = 60;
            //
            // colTenMon
            //
            colTenMon.Text = "Tên món";
            colTenMon.Width = 300;
            //
            // colNguoiDongGop
            //
            colNguoiDongGop.Text = "Người góp";
            colNguoiDongGop.Width = 200;
            //
            // btnXoaMon
            //
            btnXoaMon.Font = new Font("Segoe UI", 9.5F);
            btnXoaMon.Location = new Point(14, 456);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.Size = new Size(200, 36);
            btnXoaMon.TabIndex = 1;
            btnXoaMon.Text = "Xóa món đang chọn";
            btnXoaMon.UseVisualStyleBackColor = true;
            btnXoaMon.Click += btnXoaMon_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Font = new Font("Segoe UI", 9.5F);
            btnLamMoi.Location = new Point(224, 456);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(160, 36);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // lblTongMon
            //
            lblTongMon.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTongMon.ForeColor = Color.FromArgb(100, 100, 100);
            lblTongMon.Location = new Point(394, 462);
            lblTongMon.Name = "lblTongMon";
            lblTongMon.Size = new Size(242, 24);
            lblTongMon.TabIndex = 3;
            lblTongMon.Text = "0 món ăn";
            lblTongMon.TextAlign = ContentAlignment.MiddleRight;
            //
            // grpChiTiet
            //
            grpChiTiet.Controls.Add(picMonAn);
            grpChiTiet.Controls.Add(lblTenMon);
            grpChiTiet.Controls.Add(lblNguoiDongGop);
            grpChiTiet.Font = new Font("Segoe UI", 10F);
            grpChiTiet.Location = new Point(694, 90);
            grpChiTiet.Name = "grpChiTiet";
            grpChiTiet.Size = new Size(402, 260);
            grpChiTiet.TabIndex = 5;
            grpChiTiet.TabStop = false;
            grpChiTiet.Text = "Chi tiết món ăn";
            //
            // picMonAn
            //
            picMonAn.BackColor = Color.White;
            picMonAn.BorderStyle = BorderStyle.FixedSingle;
            picMonAn.Location = new Point(14, 26);
            picMonAn.Name = "picMonAn";
            picMonAn.Size = new Size(374, 160);
            picMonAn.SizeMode = PictureBoxSizeMode.Zoom;
            picMonAn.TabIndex = 0;
            picMonAn.TabStop = false;
            //
            // lblTenMon
            //
            lblTenMon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTenMon.ForeColor = Color.FromArgb(35, 78, 120);
            lblTenMon.Location = new Point(14, 196);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(374, 28);
            lblTenMon.TabIndex = 1;
            lblTenMon.Text = "Chưa chọn món ăn.";
            //
            // lblNguoiDongGop
            //
            lblNguoiDongGop.Font = new Font("Segoe UI", 9.5F);
            lblNguoiDongGop.ForeColor = Color.FromArgb(100, 100, 100);
            lblNguoiDongGop.Location = new Point(14, 228);
            lblNguoiDongGop.Name = "lblNguoiDongGop";
            lblNguoiDongGop.Size = new Size(374, 24);
            lblNguoiDongGop.TabIndex = 2;
            //
            // grpNhatKy
            //
            grpNhatKy.Controls.Add(rtbNhatKy);
            grpNhatKy.Font = new Font("Segoe UI", 10F);
            grpNhatKy.Location = new Point(694, 360);
            grpNhatKy.Name = "grpNhatKy";
            grpNhatKy.Size = new Size(402, 250);
            grpNhatKy.TabIndex = 6;
            grpNhatKy.TabStop = false;
            grpNhatKy.Text = "Nhật ký Server";
            //
            // rtbNhatKy
            //
            rtbNhatKy.BackColor = Color.White;
            rtbNhatKy.BorderStyle = BorderStyle.FixedSingle;
            rtbNhatKy.DetectUrls = false;
            rtbNhatKy.Font = new Font("Segoe UI", 9F);
            rtbNhatKy.Location = new Point(14, 26);
            rtbNhatKy.Name = "rtbNhatKy";
            rtbNhatKy.ReadOnly = true;
            rtbNhatKy.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbNhatKy.Size = new Size(374, 210);
            rtbNhatKy.TabIndex = 0;
            rtbNhatKy.Text = "";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 630);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(1072, 24);
            lblTrangThai.TabIndex = 7;
            lblTrangThai.Text = "Chưa lắng nghe.";
            //
            // Bai05Server
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1120, 670);
            Controls.Add(lblTrangThai);
            Controls.Add(grpNhatKy);
            Controls.Add(grpChiTiet);
            Controls.Add(grpMonAn);
            Controls.Add(btnListen);
            Controls.Add(lblSoClient);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai05Server";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Server - Bài 05";
            FormClosing += Bai05Server_FormClosing;
            grpMonAn.ResumeLayout(false);
            grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMonAn).EndInit();
            grpNhatKy.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblSoClient;
        private Button btnListen;
        private GroupBox grpMonAn;
        private ListView lvMonAn;
        private ColumnHeader colMa;
        private ColumnHeader colTenMon;
        private ColumnHeader colNguoiDongGop;
        private Button btnXoaMon;
        private Button btnLamMoi;
        private Label lblTongMon;
        private GroupBox grpChiTiet;
        private PictureBox picMonAn;
        private Label lblTenMon;
        private Label lblNguoiDongGop;
        private GroupBox grpNhatKy;
        private RichTextBox rtbNhatKy;
        private Label lblTrangThai;
    }
}
