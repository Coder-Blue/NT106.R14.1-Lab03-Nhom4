namespace NT106.R14._1_Lab03_Nhom4.Bai03
{
    partial class Bai03Client
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
            lblHoiThoai = new Label();
            rtbNhatKy = new RichTextBox();
            lblNoiDung = new Label();
            txtNoiDung = new TextBox();
            btnGui = new Button();
            lblHuongDan = new Label();
            lblTrangThai = new Label();
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
            lblTieuDe.Text = "TCP CLIENT";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(500, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Kết nối tới Server, gửi tin nhắn và xem phản hồi.";
            //
            // lblDiaChi
            //
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(24, 89);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(26, 23);
            lblDiaChi.TabIndex = 2;
            lblDiaChi.Text = "IP:";
            //
            // txtDiaChi
            //
            txtDiaChi.Font = new Font("Segoe UI", 10.5F);
            txtDiaChi.Location = new Point(56, 84);
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
            lblCong.Location = new Point(226, 89);
            lblCong.Name = "lblCong";
            lblCong.Size = new Size(42, 23);
            lblCong.TabIndex = 4;
            lblCong.Text = "Port:";
            //
            // txtCong
            //
            txtCong.Font = new Font("Segoe UI", 10.5F);
            txtCong.Location = new Point(278, 84);
            txtCong.MaxLength = 5;
            txtCong.Name = "txtCong";
            txtCong.Size = new Size(70, 31);
            txtCong.TabIndex = 5;
            txtCong.Text = "8080";
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
            btnKetNoi.Location = new Point(372, 82);
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
            btnNgatKetNoi.Location = new Point(516, 82);
            btnNgatKetNoi.Name = "btnNgatKetNoi";
            btnNgatKetNoi.Size = new Size(150, 38);
            btnNgatKetNoi.TabIndex = 7;
            btnNgatKetNoi.Text = "Ngắt kết nối";
            btnNgatKetNoi.UseVisualStyleBackColor = false;
            btnNgatKetNoi.Click += btnNgatKetNoi_Click;
            //
            // lblHoiThoai
            //
            lblHoiThoai.AutoSize = true;
            lblHoiThoai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHoiThoai.ForeColor = Color.FromArgb(60, 60, 60);
            lblHoiThoai.Location = new Point(24, 140);
            lblHoiThoai.Name = "lblHoiThoai";
            lblHoiThoai.Size = new Size(91, 23);
            lblHoiThoai.TabIndex = 8;
            lblHoiThoai.Text = "Hội thoại";
            //
            // rtbNhatKy
            //
            rtbNhatKy.BackColor = Color.White;
            rtbNhatKy.BorderStyle = BorderStyle.FixedSingle;
            rtbNhatKy.DetectUrls = false;
            rtbNhatKy.Font = new Font("Segoe UI", 10F);
            rtbNhatKy.Location = new Point(24, 164);
            rtbNhatKy.Name = "rtbNhatKy";
            rtbNhatKy.ReadOnly = true;
            rtbNhatKy.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbNhatKy.Size = new Size(520, 350);
            rtbNhatKy.TabIndex = 9;
            rtbNhatKy.TabStop = false;
            rtbNhatKy.Text = "";
            //
            // lblNoiDung
            //
            lblNoiDung.AutoSize = true;
            lblNoiDung.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNoiDung.ForeColor = Color.FromArgb(60, 60, 60);
            lblNoiDung.Location = new Point(568, 140);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(156, 23);
            lblNoiDung.TabIndex = 10;
            lblNoiDung.Text = "Nội dung tin nhắn";
            //
            // txtNoiDung
            //
            txtNoiDung.Font = new Font("Segoe UI", 10.5F);
            txtNoiDung.Location = new Point(568, 164);
            txtNoiDung.MaxLength = 1000;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.PlaceholderText = "Nhập tin nhắn rồi nhấn Gửi...";
            txtNoiDung.Size = new Size(280, 31);
            txtNoiDung.TabIndex = 11;
            //
            // btnGui
            //
            btnGui.BackColor = Color.FromArgb(51, 122, 183);
            btnGui.Cursor = Cursors.Hand;
            btnGui.Enabled = false;
            btnGui.FlatAppearance.BorderSize = 0;
            btnGui.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnGui.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnGui.FlatStyle = FlatStyle.Flat;
            btnGui.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGui.ForeColor = Color.White;
            btnGui.Location = new Point(568, 210);
            btnGui.Name = "btnGui";
            btnGui.Size = new Size(280, 44);
            btnGui.TabIndex = 12;
            btnGui.Text = "Gửi";
            btnGui.UseVisualStyleBackColor = false;
            btnGui.Click += btnGui_Click;
            //
            // lblHuongDan
            //
            lblHuongDan.Font = new Font("Segoe UI", 9F);
            lblHuongDan.ForeColor = Color.FromArgb(120, 120, 120);
            lblHuongDan.Location = new Point(568, 270);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(280, 90);
            lblHuongDan.TabIndex = 13;
            lblHuongDan.Text = "Nhấn Enter hoặc bấm Gửi để gửi tin nhắn.\r\nServer sẽ trả lời để xác nhận đã nhận.\r\nNhấn Ngắt kết nối để đóng phiên.";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 528);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(832, 24);
            lblTrangThai.TabIndex = 14;
            lblTrangThai.Text = "Chưa kết nối.";
            //
            // Bai03Client
            //
            AcceptButton = btnGui;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(880, 580);
            Controls.Add(lblTrangThai);
            Controls.Add(lblHuongDan);
            Controls.Add(btnGui);
            Controls.Add(txtNoiDung);
            Controls.Add(lblNoiDung);
            Controls.Add(rtbNhatKy);
            Controls.Add(lblHoiThoai);
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
            Name = "Bai03Client";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Client - Bài 03";
            FormClosing += Bai03Client_FormClosing;
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
        private Label lblHoiThoai;
        private RichTextBox rtbNhatKy;
        private Label lblNoiDung;
        private TextBox txtNoiDung;
        private Button btnGui;
        private Label lblHuongDan;
        private Label lblTrangThai;
    }
}
