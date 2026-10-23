namespace NT106.R14._1_Lab03_Nhom4.Bai04
{
    partial class Bai04Client
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
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblCong = new Label();
            txtCong = new TextBox();
            btnKetNoi = new Button();
            btnNgatKetNoi = new Button();
            grpDatVe = new GroupBox();
            lblPhim = new Label();
            cmbPhim = new ComboBox();
            lblPhong = new Label();
            cmbPhong = new ComboBox();
            lblThongTinPhong = new Label();
            tableGhe = new TableLayoutPanel();
            lblKhachHang = new Label();
            txtKhachHang = new TextBox();
            lblTongTien = new Label();
            btnDatVe = new Button();
            lblChuThich = new Label();
            grpNhatKy = new GroupBox();
            rtbNhatKy = new RichTextBox();
            lblTrangThai = new Label();
            grpDatVe.SuspendLayout();
            grpNhatKy.SuspendLayout();
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
            lblTieuDe.Text = "TCP CLIENT - ĐẶT VÉ";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(600, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Chọn phim, phòng, ghế rồi gửi yêu cầu đặt vé tới Server.";
            //
            // lblDiaChi
            //
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(24, 93);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(26, 23);
            lblDiaChi.TabIndex = 2;
            lblDiaChi.Text = "IP:";
            //
            // txtDiaChi
            //
            txtDiaChi.Font = new Font("Segoe UI", 10.5F);
            txtDiaChi.Location = new Point(56, 88);
            txtDiaChi.MaxLength = 45;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(150, 31);
            txtDiaChi.TabIndex = 3;
            txtDiaChi.Text = "127.0.0.1";
            //
            // lblCong
            //
            lblCong.AutoSize = true;
            lblCong.Font = new Font("Segoe UI", 10F);
            lblCong.Location = new Point(226, 93);
            lblCong.Name = "lblCong";
            lblCong.Size = new Size(42, 23);
            lblCong.TabIndex = 4;
            lblCong.Text = "Port:";
            //
            // txtCong
            //
            txtCong.Font = new Font("Segoe UI", 10.5F);
            txtCong.Location = new Point(278, 88);
            txtCong.MaxLength = 5;
            txtCong.Name = "txtCong";
            txtCong.Size = new Size(70, 31);
            txtCong.TabIndex = 5;
            txtCong.Text = "8081";
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
            btnKetNoi.Location = new Point(372, 86);
            btnKetNoi.Name = "btnKetNoi";
            btnKetNoi.Size = new Size(130, 38);
            btnKetNoi.TabIndex = 6;
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
            btnNgatKetNoi.Location = new Point(516, 86);
            btnNgatKetNoi.Name = "btnNgatKetNoi";
            btnNgatKetNoi.Size = new Size(150, 38);
            btnNgatKetNoi.TabIndex = 7;
            btnNgatKetNoi.Text = "Ngắt kết nối";
            btnNgatKetNoi.UseVisualStyleBackColor = false;
            btnNgatKetNoi.Click += btnNgatKetNoi_Click;
            //
            // grpDatVe
            //
            grpDatVe.Controls.Add(lblPhim);
            grpDatVe.Controls.Add(cmbPhim);
            grpDatVe.Controls.Add(lblPhong);
            grpDatVe.Controls.Add(cmbPhong);
            grpDatVe.Controls.Add(lblThongTinPhong);
            grpDatVe.Controls.Add(tableGhe);
            grpDatVe.Controls.Add(lblKhachHang);
            grpDatVe.Controls.Add(txtKhachHang);
            grpDatVe.Controls.Add(lblTongTien);
            grpDatVe.Controls.Add(btnDatVe);
            grpDatVe.Controls.Add(lblChuThich);
            grpDatVe.Font = new Font("Segoe UI", 10F);
            grpDatVe.Location = new Point(24, 136);
            grpDatVe.Name = "grpDatVe";
            grpDatVe.Size = new Size(540, 520);
            grpDatVe.TabIndex = 8;
            grpDatVe.TabStop = false;
            grpDatVe.Text = "Đặt vé";
            //
            // lblPhim
            //
            lblPhim.AutoSize = true;
            lblPhim.Location = new Point(20, 30);
            lblPhim.Name = "lblPhim";
            lblPhim.Size = new Size(48, 23);
            lblPhim.TabIndex = 0;
            lblPhim.Text = "Phim:";
            //
            // cmbPhim
            //
            cmbPhim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhim.Font = new Font("Segoe UI", 10F);
            cmbPhim.FormattingEnabled = true;
            cmbPhim.Location = new Point(90, 26);
            cmbPhim.Name = "cmbPhim";
            cmbPhim.Size = new Size(200, 31);
            cmbPhim.TabIndex = 1;
            cmbPhim.SelectedIndexChanged += cmbPhim_SelectedIndexChanged;
            //
            // lblPhong
            //
            lblPhong.AutoSize = true;
            lblPhong.Location = new Point(310, 30);
            lblPhong.Name = "lblPhong";
            lblPhong.Size = new Size(54, 23);
            lblPhong.TabIndex = 2;
            lblPhong.Text = "Phòng:";
            //
            // cmbPhong
            //
            cmbPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhong.Font = new Font("Segoe UI", 10F);
            cmbPhong.FormattingEnabled = true;
            cmbPhong.Location = new Point(380, 26);
            cmbPhong.Name = "cmbPhong";
            cmbPhong.Size = new Size(80, 31);
            cmbPhong.TabIndex = 3;
            cmbPhong.SelectedIndexChanged += cmbPhong_SelectedIndexChanged;
            //
            // lblThongTinPhong
            //
            lblThongTinPhong.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblThongTinPhong.ForeColor = Color.FromArgb(100, 100, 100);
            lblThongTinPhong.Location = new Point(20, 66);
            lblThongTinPhong.Name = "lblThongTinPhong";
            lblThongTinPhong.Size = new Size(500, 24);
            lblThongTinPhong.TabIndex = 4;
            lblThongTinPhong.Text = "Chưa có dữ liệu phòng vé.";
            //
            // tableGhe
            //
            tableGhe.ColumnCount = 5;
            tableGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableGhe.Location = new Point(20, 100);
            tableGhe.Name = "tableGhe";
            tableGhe.RowCount = 3;
            tableGhe.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableGhe.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableGhe.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableGhe.Size = new Size(500, 240);
            tableGhe.TabIndex = 5;
            //
            // lblKhachHang
            //
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(20, 356);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(91, 23);
            lblKhachHang.TabIndex = 6;
            lblKhachHang.Text = "Khách hàng:";
            //
            // txtKhachHang
            //
            txtKhachHang.Font = new Font("Segoe UI", 10F);
            txtKhachHang.Location = new Point(126, 352);
            txtKhachHang.Name = "txtKhachHang";
            txtKhachHang.Size = new Size(200, 30);
            txtKhachHang.TabIndex = 7;
            //
            // lblTongTien
            //
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(35, 78, 120);
            lblTongTien.Location = new Point(20, 398);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(500, 28);
            lblTongTien.TabIndex = 8;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            //
            // btnDatVe
            //
            btnDatVe.BackColor = Color.FromArgb(51, 122, 183);
            btnDatVe.Cursor = Cursors.Hand;
            btnDatVe.FlatAppearance.BorderSize = 0;
            btnDatVe.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnDatVe.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnDatVe.FlatStyle = FlatStyle.Flat;
            btnDatVe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDatVe.ForeColor = Color.White;
            btnDatVe.Location = new Point(20, 438);
            btnDatVe.Name = "btnDatVe";
            btnDatVe.Size = new Size(200, 44);
            btnDatVe.TabIndex = 9;
            btnDatVe.Text = "Đặt vé";
            btnDatVe.UseVisualStyleBackColor = false;
            btnDatVe.Click += btnDatVe_Click;
            //
            // lblChuThich
            //
            lblChuThich.Font = new Font("Segoe UI", 9F);
            lblChuThich.ForeColor = Color.FromArgb(120, 120, 120);
            lblChuThich.Location = new Point(240, 438);
            lblChuThich.Name = "lblChuThich";
            lblChuThich.Size = new Size(280, 60);
            lblChuThich.TabIndex = 10;
            lblChuThich.Text = "Trắng: còn trống\r\nXanh: đang chọn\r\nXám: đã bán";
            //
            // grpNhatKy
            //
            grpNhatKy.Controls.Add(rtbNhatKy);
            grpNhatKy.Font = new Font("Segoe UI", 10F);
            grpNhatKy.Location = new Point(584, 136);
            grpNhatKy.Name = "grpNhatKy";
            grpNhatKy.Size = new Size(430, 520);
            grpNhatKy.TabIndex = 9;
            grpNhatKy.TabStop = false;
            grpNhatKy.Text = "Nhật ký Client";
            //
            // rtbNhatKy
            //
            rtbNhatKy.BackColor = Color.White;
            rtbNhatKy.BorderStyle = BorderStyle.FixedSingle;
            rtbNhatKy.DetectUrls = false;
            rtbNhatKy.Font = new Font("Segoe UI", 9.5F);
            rtbNhatKy.Location = new Point(14, 26);
            rtbNhatKy.Name = "rtbNhatKy";
            rtbNhatKy.ReadOnly = true;
            rtbNhatKy.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbNhatKy.Size = new Size(402, 480);
            rtbNhatKy.TabIndex = 0;
            rtbNhatKy.Text = "";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 666);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(990, 24);
            lblTrangThai.TabIndex = 10;
            lblTrangThai.Text = "Chưa kết nối.";
            //
            // Bai04Client
            //
            AcceptButton = btnDatVe;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1040, 700);
            Controls.Add(lblTrangThai);
            Controls.Add(grpNhatKy);
            Controls.Add(grpDatVe);
            Controls.Add(btnNgatKetNoi);
            Controls.Add(btnKetNoi);
            Controls.Add(txtCong);
            Controls.Add(lblCong);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiaChi);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai04Client";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Client - Bài 04";
            FormClosing += Bai04Client_FormClosing;
            grpDatVe.ResumeLayout(false);
            grpDatVe.PerformLayout();
            grpNhatKy.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblCong;
        private TextBox txtCong;
        private Button btnKetNoi;
        private Button btnNgatKetNoi;
        private GroupBox grpDatVe;
        private Label lblPhim;
        private ComboBox cmbPhim;
        private Label lblPhong;
        private ComboBox cmbPhong;
        private Label lblThongTinPhong;
        private TableLayoutPanel tableGhe;
        private Label lblKhachHang;
        private TextBox txtKhachHang;
        private Label lblTongTien;
        private Button btnDatVe;
        private Label lblChuThich;
        private GroupBox grpNhatKy;
        private RichTextBox rtbNhatKy;
        private Label lblTrangThai;
    }
}
