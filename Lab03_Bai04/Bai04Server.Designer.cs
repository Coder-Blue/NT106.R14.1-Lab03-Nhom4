namespace NT106.R14._1_Lab03_Nhom4.Bai04
{
    partial class Bai04Server
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
            grpPhongVe = new GroupBox();
            lvPhongVe = new ListView();
            colPhim = new ColumnHeader();
            colGia = new ColumnHeader();
            colDaBan = new ColumnHeader();
            colDoanhThu = new ColumnHeader();
            btnDocFile = new Button();
            btnGhiFile = new Button();
            btnXoaPhong = new Button();
            grpThemPhong = new GroupBox();
            lblTenPhim = new Label();
            txtTenPhim = new TextBox();
            lblGiaVe = new Label();
            txtGiaVe = new TextBox();
            lblPhong = new Label();
            txtPhong = new TextBox();
            btnThemPhong = new Button();
            grpThongKe = new GroupBox();
            rtbThongKe = new RichTextBox();
            progressBar = new ProgressBar();
            btnXuatThongKe = new Button();
            grpVe = new GroupBox();
            lvVe = new ListView();
            colThoiGian = new ColumnHeader();
            colKhach = new ColumnHeader();
            colPhimVe = new ColumnHeader();
            colGhe = new ColumnHeader();
            colTien = new ColumnHeader();
            grpNhatKy = new GroupBox();
            rtbNhatKy = new RichTextBox();
            lblTrangThai = new Label();
            grpPhongVe.SuspendLayout();
            grpThemPhong.SuspendLayout();
            grpThongKe.SuspendLayout();
            grpVe.SuspendLayout();
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
            lblTieuDe.Text = "TCP SERVER - QUẢN LÝ PHÒNG VÉ";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(800, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Dữ liệu phòng vé được lưu tại Server và đồng bộ tới tất cả Client.";
            //
            // lblSoClient
            //
            lblSoClient.Font = new Font("Segoe UI", 9.5F);
            lblSoClient.ForeColor = Color.FromArgb(100, 100, 100);
            lblSoClient.Location = new Point(840, 24);
            lblSoClient.Name = "lblSoClient";
            lblSoClient.Size = new Size(190, 24);
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
            btnListen.Location = new Point(1070, 16);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(146, 44);
            btnListen.TabIndex = 3;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            //
            // grpPhongVe
            //
            grpPhongVe.Controls.Add(lvPhongVe);
            grpPhongVe.Controls.Add(btnDocFile);
            grpPhongVe.Controls.Add(btnGhiFile);
            grpPhongVe.Controls.Add(btnXoaPhong);
            grpPhongVe.Font = new Font("Segoe UI", 10F);
            grpPhongVe.Location = new Point(24, 90);
            grpPhongVe.Name = "grpPhongVe";
            grpPhongVe.Size = new Size(560, 330);
            grpPhongVe.TabIndex = 4;
            grpPhongVe.TabStop = false;
            grpPhongVe.Text = "Phòng vé";
            //
            // lvPhongVe
            //
            lvPhongVe.Font = new Font("Segoe UI", 9F);
            lvPhongVe.Columns.AddRange(new ColumnHeader[] { colPhim, colGia, colDaBan, colDoanhThu });
            lvPhongVe.FullRowSelect = true;
            lvPhongVe.GridLines = true;
            lvPhongVe.Location = new Point(14, 26);
            lvPhongVe.MultiSelect = false;
            lvPhongVe.Name = "lvPhongVe";
            lvPhongVe.Size = new Size(532, 200);
            lvPhongVe.TabIndex = 0;
            lvPhongVe.UseCompatibleStateImageBehavior = false;
            lvPhongVe.View = View.Details;
            //
            // colPhim
            //
            colPhim.Text = "Phim / Phòng";
            colPhim.Width = 200;
            //
            // colGia
            //
            colGia.Text = "Giá";
            colGia.Width = 100;
            //
            // colDaBan
            //
            colDaBan.Text = "Bán";
            colDaBan.Width = 90;
            //
            // colDoanhThu
            //
            colDoanhThu.Text = "Thu";
            colDoanhThu.Width = 120;
            //
            // btnDocFile
            //
            btnDocFile.Font = new Font("Segoe UI", 9.5F);
            btnDocFile.Location = new Point(14, 236);
            btnDocFile.Name = "btnDocFile";
            btnDocFile.Size = new Size(110, 36);
            btnDocFile.TabIndex = 1;
            btnDocFile.Text = "Đọc file";
            btnDocFile.UseVisualStyleBackColor = true;
            btnDocFile.Click += btnDocFile_Click;
            //
            // btnGhiFile
            //
            btnGhiFile.Font = new Font("Segoe UI", 9.5F);
            btnGhiFile.Location = new Point(132, 236);
            btnGhiFile.Name = "btnGhiFile";
            btnGhiFile.Size = new Size(110, 36);
            btnGhiFile.TabIndex = 2;
            btnGhiFile.Text = "Ghi file";
            btnGhiFile.UseVisualStyleBackColor = true;
            btnGhiFile.Click += btnGhiFile_Click;
            //
            // btnXoaPhong
            //
            btnXoaPhong.Font = new Font("Segoe UI", 9.5F);
            btnXoaPhong.Location = new Point(250, 236);
            btnXoaPhong.Name = "btnXoaPhong";
            btnXoaPhong.Size = new Size(296, 36);
            btnXoaPhong.TabIndex = 3;
            btnXoaPhong.Text = "Xóa phòng vé đang chọn";
            btnXoaPhong.UseVisualStyleBackColor = true;
            btnXoaPhong.Click += btnXoaPhong_Click;
            //
            // grpThemPhong
            //
            grpThemPhong.Controls.Add(lblTenPhim);
            grpThemPhong.Controls.Add(txtTenPhim);
            grpThemPhong.Controls.Add(lblGiaVe);
            grpThemPhong.Controls.Add(txtGiaVe);
            grpThemPhong.Controls.Add(lblPhong);
            grpThemPhong.Controls.Add(txtPhong);
            grpThemPhong.Controls.Add(btnThemPhong);
            grpThemPhong.Font = new Font("Segoe UI", 10F);
            grpThemPhong.Location = new Point(24, 430);
            grpThemPhong.Name = "grpThemPhong";
            grpThemPhong.Size = new Size(560, 120);
            grpThemPhong.TabIndex = 5;
            grpThemPhong.TabStop = false;
            grpThemPhong.Text = "Thêm phòng vé";
            //
            // lblTenPhim
            //
            lblTenPhim.AutoSize = true;
            lblTenPhim.Location = new Point(14, 30);
            lblTenPhim.Name = "lblTenPhim";
            lblTenPhim.Size = new Size(72, 23);
            lblTenPhim.TabIndex = 0;
            lblTenPhim.Text = "Tên phim:";
            //
            // txtTenPhim
            //
            txtTenPhim.Font = new Font("Segoe UI", 10F);
            txtTenPhim.Location = new Point(92, 26);
            txtTenPhim.Name = "txtTenPhim";
            txtTenPhim.Size = new Size(198, 30);
            txtTenPhim.TabIndex = 1;
            //
            // lblGiaVe
            //
            lblGiaVe.AutoSize = true;
            lblGiaVe.Location = new Point(14, 70);
            lblGiaVe.Name = "lblGiaVe";
            lblGiaVe.Size = new Size(53, 23);
            lblGiaVe.TabIndex = 2;
            lblGiaVe.Text = "Giá vé:";
            //
            // txtGiaVe
            //
            txtGiaVe.Font = new Font("Segoe UI", 10F);
            txtGiaVe.Location = new Point(92, 66);
            txtGiaVe.Name = "txtGiaVe";
            txtGiaVe.Size = new Size(100, 30);
            txtGiaVe.TabIndex = 3;
            //
            // lblPhong
            //
            lblPhong.AutoSize = true;
            lblPhong.Location = new Point(210, 70);
            lblPhong.Name = "lblPhong";
            lblPhong.Size = new Size(31, 23);
            lblPhong.TabIndex = 4;
            lblPhong.Text = "Phòng:";
            //
            // txtPhong
            //
            txtPhong.Font = new Font("Segoe UI", 10F);
            txtPhong.Location = new Point(255, 66);
            txtPhong.Name = "txtPhong";
            txtPhong.Size = new Size(60, 30);
            txtPhong.TabIndex = 5;
            //
            // btnThemPhong
            //
            btnThemPhong.BackColor = Color.FromArgb(51, 122, 183);
            btnThemPhong.Cursor = Cursors.Hand;
            btnThemPhong.FlatAppearance.BorderSize = 0;
            btnThemPhong.FlatStyle = FlatStyle.Flat;
            btnThemPhong.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThemPhong.ForeColor = Color.White;
            btnThemPhong.Location = new Point(330, 58);
            btnThemPhong.Name = "btnThemPhong";
            btnThemPhong.Size = new Size(216, 38);
            btnThemPhong.TabIndex = 6;
            btnThemPhong.Text = "Thêm phòng";
            btnThemPhong.UseVisualStyleBackColor = false;
            btnThemPhong.Click += btnThemPhong_Click;
            //
            // grpThongKe
            //
            grpThongKe.Controls.Add(rtbThongKe);
            grpThongKe.Controls.Add(progressBar);
            grpThongKe.Controls.Add(btnXuatThongKe);
            grpThongKe.Font = new Font("Segoe UI", 10F);
            grpThongKe.Location = new Point(24, 560);
            grpThongKe.Name = "grpThongKe";
            grpThongKe.Size = new Size(560, 150);
            grpThongKe.TabIndex = 6;
            grpThongKe.TabStop = false;
            grpThongKe.Text = "Thống kê doanh thu";
            //
            // rtbThongKe
            //
            rtbThongKe.BackColor = Color.White;
            rtbThongKe.BorderStyle = BorderStyle.FixedSingle;
            rtbThongKe.DetectUrls = false;
            rtbThongKe.Font = new Font("Segoe UI", 9F);
            rtbThongKe.Location = new Point(14, 26);
            rtbThongKe.Name = "rtbThongKe";
            rtbThongKe.ReadOnly = true;
            rtbThongKe.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbThongKe.Size = new Size(532, 68);
            rtbThongKe.TabIndex = 0;
            rtbThongKe.Text = "";
            //
            // progressBar
            //
            progressBar.Location = new Point(14, 104);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(340, 24);
            progressBar.TabIndex = 1;
            //
            // btnXuatThongKe
            //
            btnXuatThongKe.Font = new Font("Segoe UI", 9.5F);
            btnXuatThongKe.Location = new Point(368, 100);
            btnXuatThongKe.Name = "btnXuatThongKe";
            btnXuatThongKe.Size = new Size(178, 34);
            btnXuatThongKe.TabIndex = 2;
            btnXuatThongKe.Text = "Xuất output5.txt";
            btnXuatThongKe.UseVisualStyleBackColor = true;
            btnXuatThongKe.Click += btnXuatThongKe_Click;
            //
            // grpVe
            //
            grpVe.Controls.Add(lvVe);
            grpVe.Font = new Font("Segoe UI", 10F);
            grpVe.Location = new Point(604, 90);
            grpVe.Name = "grpVe";
            grpVe.Size = new Size(612, 260);
            grpVe.TabIndex = 7;
            grpVe.TabStop = false;
            grpVe.Text = "Vé đã đặt";
            //
            // lvVe
            //
            lvVe.Font = new Font("Segoe UI", 9F);
            lvVe.Columns.AddRange(new ColumnHeader[] { colThoiGian, colKhach, colPhimVe, colGhe, colTien });
            lvVe.FullRowSelect = true;
            lvVe.GridLines = true;
            lvVe.Location = new Point(14, 26);
            lvVe.MultiSelect = false;
            lvVe.Name = "lvVe";
            lvVe.Size = new Size(584, 220);
            lvVe.TabIndex = 0;
            lvVe.UseCompatibleStateImageBehavior = false;
            lvVe.View = View.Details;
            //
            // colThoiGian
            //
            colThoiGian.Text = "Giờ";
            colThoiGian.Width = 90;
            //
            // colKhach
            //
            colKhach.Text = "Khách";
            colKhach.Width = 140;
            //
            // colPhimVe
            //
            colPhimVe.Text = "Phim / Phòng";
            colPhimVe.Width = 150;
            //
            // colGhe
            //
            colGhe.Text = "Ghế";
            colGhe.Width = 80;
            //
            // colTien
            //
            colTien.Text = "Tiền";
            colTien.Width = 95;
            //
            // grpNhatKy
            //
            grpNhatKy.Controls.Add(rtbNhatKy);
            grpNhatKy.Font = new Font("Segoe UI", 10F);
            grpNhatKy.Location = new Point(604, 360);
            grpNhatKy.Name = "grpNhatKy";
            grpNhatKy.Size = new Size(612, 350);
            grpNhatKy.TabIndex = 8;
            grpNhatKy.TabStop = false;
            grpNhatKy.Text = "Nhật ký Server";
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
            rtbNhatKy.Size = new Size(584, 310);
            rtbNhatKy.TabIndex = 0;
            rtbNhatKy.Text = "";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 730);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(1192, 24);
            lblTrangThai.TabIndex = 9;
            lblTrangThai.Text = "Chưa lắng nghe.";
            //
            // Bai04Server
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1240, 770);
            Controls.Add(lblTrangThai);
            Controls.Add(grpNhatKy);
            Controls.Add(grpVe);
            Controls.Add(grpThongKe);
            Controls.Add(grpThemPhong);
            Controls.Add(grpPhongVe);
            Controls.Add(btnListen);
            Controls.Add(lblSoClient);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai04Server";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Server - Bài 04";
            FormClosing += Bai04Server_FormClosing;
            grpPhongVe.ResumeLayout(false);
            grpThemPhong.ResumeLayout(false);
            grpThemPhong.PerformLayout();
            grpThongKe.ResumeLayout(false);
            grpVe.ResumeLayout(false);
            grpNhatKy.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblSoClient;
        private Button btnListen;
        private GroupBox grpPhongVe;
        private ListView lvPhongVe;
        private ColumnHeader colPhim;
        private ColumnHeader colGia;
        private ColumnHeader colDaBan;
        private ColumnHeader colDoanhThu;
        private Button btnDocFile;
        private Button btnGhiFile;
        private Button btnXoaPhong;
        private GroupBox grpThemPhong;
        private Label lblTenPhim;
        private TextBox txtTenPhim;
        private Label lblGiaVe;
        private TextBox txtGiaVe;
        private Label lblPhong;
        private TextBox txtPhong;
        private Button btnThemPhong;
        private GroupBox grpThongKe;
        private RichTextBox rtbThongKe;
        private ProgressBar progressBar;
        private Button btnXuatThongKe;
        private GroupBox grpVe;
        private ListView lvVe;
        private ColumnHeader colThoiGian;
        private ColumnHeader colKhach;
        private ColumnHeader colPhimVe;
        private ColumnHeader colGhe;
        private ColumnHeader colTien;
        private GroupBox grpNhatKy;
        private RichTextBox rtbNhatKy;
        private Label lblTrangThai;
    }
}
