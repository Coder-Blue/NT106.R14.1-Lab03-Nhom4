namespace NT106.R14._1_Lab03_Nhom4.Bai05
{
    partial class Bai05Client
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
            lblTenNguoiDung = new Label();
            txtTenNguoiDung = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblCong = new Label();
            txtCong = new TextBox();
            btnKetNoi = new Button();
            btnNgatKetNoi = new Button();
            grpMonAn = new GroupBox();
            lvMonAn = new ListView();
            colMa = new ColumnHeader();
            colTenMon = new ColumnHeader();
            colNguoiDongGop = new ColumnHeader();
            lblTenMonMoi = new Label();
            txtTenMonAn = new TextBox();
            lblHinhAnh = new Label();
            cmbHinhAnh = new ComboBox();
            btnThemMon = new Button();
            btnXoaMon = new Button();
            btnAnGiCaNhan = new Button();
            btnAnGiCongDong = new Button();
            lblGoiY = new Label();
            grpKetQua = new GroupBox();
            lblKetQua = new Label();
            picMonAn = new PictureBox();
            lblNguoiDongGop = new Label();
            rtbNhatKy = new RichTextBox();
            lblTrangThai = new Label();
            grpMonAn.SuspendLayout();
            grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMonAn).BeginInit();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(35, 78, 120);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(500, 38);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "TCP CLIENT - HÔM NAY ĂN GÌ?";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(700, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Thêm món ăn, xem danh sách cộng đồng và chọn ngẫu nhiên món hôm nay.";
            //
            // lblTenNguoiDung
            //
            lblTenNguoiDung.AutoSize = true;
            lblTenNguoiDung.Font = new Font("Segoe UI", 10F);
            lblTenNguoiDung.Location = new Point(24, 93);
            lblTenNguoiDung.Name = "lblTenNguoiDung";
            lblTenNguoiDung.Size = new Size(40, 23);
            lblTenNguoiDung.TabIndex = 2;
            lblTenNguoiDung.Text = "Tên:";
            //
            // txtTenNguoiDung
            //
            txtTenNguoiDung.Font = new Font("Segoe UI", 10.5F);
            txtTenNguoiDung.Location = new Point(70, 88);
            txtTenNguoiDung.MaxLength = 50;
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.Size = new Size(160, 31);
            txtTenNguoiDung.TabIndex = 3;
            //
            // lblDiaChi
            //
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(246, 93);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(26, 23);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "IP:";
            //
            // txtDiaChi
            //
            txtDiaChi.Font = new Font("Segoe UI", 10.5F);
            txtDiaChi.Location = new Point(278, 88);
            txtDiaChi.MaxLength = 45;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(120, 31);
            txtDiaChi.TabIndex = 5;
            txtDiaChi.Text = "127.0.0.1";
            //
            // lblCong
            //
            lblCong.AutoSize = true;
            lblCong.Font = new Font("Segoe UI", 10F);
            lblCong.Location = new Point(410, 93);
            lblCong.Name = "lblCong";
            lblCong.Size = new Size(42, 23);
            lblCong.TabIndex = 6;
            lblCong.Text = "Port:";
            //
            // txtCong
            //
            txtCong.Font = new Font("Segoe UI", 10.5F);
            txtCong.Location = new Point(456, 88);
            txtCong.MaxLength = 5;
            txtCong.Name = "txtCong";
            txtCong.Size = new Size(60, 31);
            txtCong.TabIndex = 7;
            txtCong.Text = "8082";
            //
            // btnKetNoi
            //
            btnKetNoi.BackColor = Color.FromArgb(51, 122, 183);
            btnKetNoi.Cursor = Cursors.Hand;
            btnKetNoi.FlatAppearance.BorderSize = 0;
            btnKetNoi.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnKetNoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnKetNoi.FlatStyle = FlatStyle.Flat;
            btnKetNoi.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnKetNoi.ForeColor = Color.White;
            btnKetNoi.Location = new Point(530, 86);
            btnKetNoi.Name = "btnKetNoi";
            btnKetNoi.Size = new Size(120, 38);
            btnKetNoi.TabIndex = 8;
            btnKetNoi.Text = "Kết nối";
            btnKetNoi.UseVisualStyleBackColor = false;
            btnKetNoi.Click += btnKetNoi_Click;
            //
            // btnNgatKetNoi
            //
            btnNgatKetNoi.BackColor = Color.FromArgb(220, 80, 80);
            btnNgatKetNoi.Cursor = Cursors.Hand;
            btnNgatKetNoi.Enabled = false;
            btnNgatKetNoi.FlatAppearance.BorderSize = 0;
            btnNgatKetNoi.FlatAppearance.MouseDownBackColor = Color.FromArgb(175, 60, 60);
            btnNgatKetNoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 100, 100);
            btnNgatKetNoi.FlatStyle = FlatStyle.Flat;
            btnNgatKetNoi.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnNgatKetNoi.ForeColor = Color.White;
            btnNgatKetNoi.Location = new Point(662, 86);
            btnNgatKetNoi.Name = "btnNgatKetNoi";
            btnNgatKetNoi.Size = new Size(140, 38);
            btnNgatKetNoi.TabIndex = 9;
            btnNgatKetNoi.Text = "Ngắt kết nối";
            btnNgatKetNoi.UseVisualStyleBackColor = false;
            btnNgatKetNoi.Click += btnNgatKetNoi_Click;
            //
            // grpMonAn
            //
            grpMonAn.Controls.Add(lvMonAn);
            grpMonAn.Controls.Add(lblTenMonMoi);
            grpMonAn.Controls.Add(txtTenMonAn);
            grpMonAn.Controls.Add(lblHinhAnh);
            grpMonAn.Controls.Add(cmbHinhAnh);
            grpMonAn.Controls.Add(btnThemMon);
            grpMonAn.Controls.Add(btnXoaMon);
            grpMonAn.Controls.Add(btnAnGiCaNhan);
            grpMonAn.Controls.Add(btnAnGiCongDong);
            grpMonAn.Controls.Add(lblGoiY);
            grpMonAn.Font = new Font("Segoe UI", 10F);
            grpMonAn.Location = new Point(24, 136);
            grpMonAn.Name = "grpMonAn";
            grpMonAn.Size = new Size(620, 520);
            grpMonAn.TabIndex = 10;
            grpMonAn.TabStop = false;
            grpMonAn.Text = "Món ăn cộng đồng";
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
            lvMonAn.Size = new Size(592, 300);
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
            // lblTenMonMoi
            //
            lblTenMonMoi.AutoSize = true;
            lblTenMonMoi.Location = new Point(14, 342);
            lblTenMonMoi.Name = "lblTenMonMoi";
            lblTenMonMoi.Size = new Size(86, 23);
            lblTenMonMoi.TabIndex = 1;
            lblTenMonMoi.Text = "Tên món:";
            //
            // txtTenMonAn
            //
            txtTenMonAn.Font = new Font("Segoe UI", 10F);
            txtTenMonAn.Location = new Point(108, 338);
            txtTenMonAn.MaxLength = 100;
            txtTenMonAn.Name = "txtTenMonAn";
            txtTenMonAn.Size = new Size(220, 30);
            txtTenMonAn.TabIndex = 2;
            //
            // lblHinhAnh
            //
            lblHinhAnh.AutoSize = true;
            lblHinhAnh.Location = new Point(342, 342);
            lblHinhAnh.Name = "lblHinhAnh";
            lblHinhAnh.Size = new Size(49, 23);
            lblHinhAnh.TabIndex = 3;
            lblHinhAnh.Text = "Hình:";
            //
            // cmbHinhAnh
            //
            cmbHinhAnh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHinhAnh.Font = new Font("Segoe UI", 10F);
            cmbHinhAnh.FormattingEnabled = true;
            cmbHinhAnh.Location = new Point(396, 338);
            cmbHinhAnh.Name = "cmbHinhAnh";
            cmbHinhAnh.Size = new Size(180, 31);
            cmbHinhAnh.TabIndex = 4;
            //
            // btnThemMon
            //
            btnThemMon.BackColor = Color.FromArgb(51, 122, 183);
            btnThemMon.Cursor = Cursors.Hand;
            btnThemMon.FlatAppearance.BorderSize = 0;
            btnThemMon.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnThemMon.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnThemMon.FlatStyle = FlatStyle.Flat;
            btnThemMon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThemMon.ForeColor = Color.White;
            btnThemMon.Location = new Point(14, 382);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.Size = new Size(160, 38);
            btnThemMon.TabIndex = 5;
            btnThemMon.Text = "Thêm món";
            btnThemMon.UseVisualStyleBackColor = false;
            btnThemMon.Click += btnThemMon_Click;
            //
            // btnXoaMon
            //
            btnXoaMon.Font = new Font("Segoe UI", 9.5F);
            btnXoaMon.Location = new Point(184, 382);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.Size = new Size(180, 38);
            btnXoaMon.TabIndex = 6;
            btnXoaMon.Text = "Xóa món của tôi";
            btnXoaMon.UseVisualStyleBackColor = true;
            btnXoaMon.Click += btnXoaMon_Click;
            //
            // btnAnGiCaNhan
            //
            btnAnGiCaNhan.BackColor = Color.FromArgb(46, 160, 100);
            btnAnGiCaNhan.Cursor = Cursors.Hand;
            btnAnGiCaNhan.FlatAppearance.BorderSize = 0;
            btnAnGiCaNhan.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 125, 75);
            btnAnGiCaNhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 180, 115);
            btnAnGiCaNhan.FlatStyle = FlatStyle.Flat;
            btnAnGiCaNhan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAnGiCaNhan.ForeColor = Color.White;
            btnAnGiCaNhan.Location = new Point(14, 432);
            btnAnGiCaNhan.Name = "btnAnGiCaNhan";
            btnAnGiCaNhan.Size = new Size(280, 42);
            btnAnGiCaNhan.TabIndex = 7;
            btnAnGiCaNhan.Text = "Chọn từ món của tôi";
            btnAnGiCaNhan.UseVisualStyleBackColor = false;
            btnAnGiCaNhan.Click += btnAnGiCaNhan_Click;
            //
            // btnAnGiCongDong
            //
            btnAnGiCongDong.BackColor = Color.FromArgb(51, 122, 183);
            btnAnGiCongDong.Cursor = Cursors.Hand;
            btnAnGiCongDong.FlatAppearance.BorderSize = 0;
            btnAnGiCongDong.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnAnGiCongDong.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnAnGiCongDong.FlatStyle = FlatStyle.Flat;
            btnAnGiCongDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAnGiCongDong.ForeColor = Color.White;
            btnAnGiCongDong.Location = new Point(306, 432);
            btnAnGiCongDong.Name = "btnAnGiCongDong";
            btnAnGiCongDong.Size = new Size(300, 42);
            btnAnGiCongDong.TabIndex = 8;
            btnAnGiCongDong.Text = "Chọn từ cộng đồng";
            btnAnGiCongDong.UseVisualStyleBackColor = false;
            btnAnGiCongDong.Click += btnAnGiCongDong_Click;
            //
            // lblGoiY
            //
            lblGoiY.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblGoiY.ForeColor = Color.FromArgb(120, 120, 120);
            lblGoiY.Location = new Point(14, 484);
            lblGoiY.Name = "lblGoiY";
            lblGoiY.Size = new Size(592, 24);
            lblGoiY.TabIndex = 9;
            lblGoiY.Text = "Món mới sẽ được lưu vào SQLite của Server và đồng bộ tới mọi Client.";
            //
            // grpKetQua
            //
            grpKetQua.Controls.Add(lblKetQua);
            grpKetQua.Controls.Add(picMonAn);
            grpKetQua.Controls.Add(lblNguoiDongGop);
            grpKetQua.Controls.Add(rtbNhatKy);
            grpKetQua.Font = new Font("Segoe UI", 10F);
            grpKetQua.Location = new Point(664, 136);
            grpKetQua.Name = "grpKetQua";
            grpKetQua.Size = new Size(392, 520);
            grpKetQua.TabIndex = 11;
            grpKetQua.TabStop = false;
            grpKetQua.Text = "Kết quả";
            //
            // lblKetQua
            //
            lblKetQua.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblKetQua.ForeColor = Color.FromArgb(35, 78, 120);
            lblKetQua.Location = new Point(14, 20);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(364, 70);
            lblKetQua.TabIndex = 0;
            lblKetQua.Text = "Chưa chọn món.";
            //
            // picMonAn
            //
            picMonAn.BackColor = Color.White;
            picMonAn.BorderStyle = BorderStyle.FixedSingle;
            picMonAn.Location = new Point(14, 100);
            picMonAn.Name = "picMonAn";
            picMonAn.Size = new Size(364, 240);
            picMonAn.SizeMode = PictureBoxSizeMode.Zoom;
            picMonAn.TabIndex = 1;
            picMonAn.TabStop = false;
            //
            // lblNguoiDongGop
            //
            lblNguoiDongGop.Font = new Font("Segoe UI", 9.5F);
            lblNguoiDongGop.ForeColor = Color.FromArgb(100, 100, 100);
            lblNguoiDongGop.Location = new Point(14, 350);
            lblNguoiDongGop.Name = "lblNguoiDongGop";
            lblNguoiDongGop.Size = new Size(364, 24);
            lblNguoiDongGop.TabIndex = 2;
            //
            // rtbNhatKy
            //
            rtbNhatKy.BackColor = Color.White;
            rtbNhatKy.BorderStyle = BorderStyle.FixedSingle;
            rtbNhatKy.DetectUrls = false;
            rtbNhatKy.Font = new Font("Segoe UI", 9F);
            rtbNhatKy.Location = new Point(14, 384);
            rtbNhatKy.Name = "rtbNhatKy";
            rtbNhatKy.ReadOnly = true;
            rtbNhatKy.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbNhatKy.Size = new Size(364, 122);
            rtbNhatKy.TabIndex = 3;
            rtbNhatKy.Text = "";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 666);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(1032, 24);
            lblTrangThai.TabIndex = 12;
            lblTrangThai.Text = "Chưa kết nối.";
            //
            // Bai05Client
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1080, 700);
            Controls.Add(lblTrangThai);
            Controls.Add(grpKetQua);
            Controls.Add(grpMonAn);
            Controls.Add(btnNgatKetNoi);
            Controls.Add(btnKetNoi);
            Controls.Add(txtCong);
            Controls.Add(lblCong);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiaChi);
            Controls.Add(txtTenNguoiDung);
            Controls.Add(lblTenNguoiDung);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai05Client";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Client - Bài 05";
            FormClosing += Bai05Client_FormClosing;
            grpMonAn.ResumeLayout(false);
            grpMonAn.PerformLayout();
            grpKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMonAn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblTenNguoiDung;
        private TextBox txtTenNguoiDung;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblCong;
        private TextBox txtCong;
        private Button btnKetNoi;
        private Button btnNgatKetNoi;
        private GroupBox grpMonAn;
        private ListView lvMonAn;
        private ColumnHeader colMa;
        private ColumnHeader colTenMon;
        private ColumnHeader colNguoiDongGop;
        private Label lblTenMonMoi;
        private TextBox txtTenMonAn;
        private Label lblHinhAnh;
        private ComboBox cmbHinhAnh;
        private Button btnThemMon;
        private Button btnXoaMon;
        private Button btnAnGiCaNhan;
        private Button btnAnGiCongDong;
        private Label lblGoiY;
        private GroupBox grpKetQua;
        private Label lblKetQua;
        private PictureBox picMonAn;
        private Label lblNguoiDongGop;
        private RichTextBox rtbNhatKy;
        private Label lblTrangThai;
    }
}
