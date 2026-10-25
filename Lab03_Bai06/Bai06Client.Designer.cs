namespace NT106.R14._1_Lab03_Nhom4.Bai06
{
    partial class Bai06Client
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
            grpChat = new GroupBox();
            rtbChat = new RichTextBox();
            picAnh = new PictureBox();
            grpNguoiDung = new GroupBox();
            lstNguoiDung = new ListBox();
            lblTongNguoi = new Label();
            grpGui = new GroupBox();
            lblNguoiNhan = new Label();
            cmbNguoiNhan = new ComboBox();
            txtNoiDung = new TextBox();
            btnGui = new Button();
            btnGuiTep = new Button();
            lblGoiY = new Label();
            lblTrangThai = new Label();
            grpChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            grpNguoiDung.SuspendLayout();
            grpGui.SuspendLayout();
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
            lblTieuDe.Text = "TCP CLIENT - CHAT ROOM";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(800, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Chat chung với cả phòng hoặc chọn một người để nhắn tin riêng.";
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
            txtTenNguoiDung.MaxLength = 30;
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.Size = new Size(150, 31);
            txtTenNguoiDung.TabIndex = 3;
            //
            // lblDiaChi
            //
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(236, 93);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(26, 23);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "IP:";
            //
            // txtDiaChi
            //
            txtDiaChi.Font = new Font("Segoe UI", 10.5F);
            txtDiaChi.Location = new Point(268, 88);
            txtDiaChi.MaxLength = 45;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(130, 31);
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
            txtCong.Text = "8083";
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
            // grpChat
            //
            grpChat.Controls.Add(picAnh);
            grpChat.Controls.Add(rtbChat);
            grpChat.Font = new Font("Segoe UI", 10F);
            grpChat.Location = new Point(24, 136);
            grpChat.Name = "grpChat";
            grpChat.Size = new Size(710, 520);
            grpChat.TabIndex = 10;
            grpChat.TabStop = false;
            grpChat.Text = "Phòng chat";
            //
            // rtbChat
            //
            rtbChat.BackColor = Color.White;
            rtbChat.BorderStyle = BorderStyle.FixedSingle;
            rtbChat.DetectUrls = false;
            rtbChat.Font = new Font("Segoe UI", 10F);
            rtbChat.Location = new Point(14, 26);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChat.Size = new Size(682, 480);
            rtbChat.TabIndex = 0;
            rtbChat.Text = "";
            //
            // picAnh
            //
            picAnh.BackColor = Color.White;
            picAnh.BorderStyle = BorderStyle.FixedSingle;
            picAnh.Location = new Point(14, 388);
            picAnh.Name = "picAnh";
            picAnh.Size = new Size(682, 118);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picAnh.TabIndex = 1;
            picAnh.TabStop = false;
            picAnh.Visible = false;
            //
            // grpNguoiDung
            //
            grpNguoiDung.Controls.Add(lstNguoiDung);
            grpNguoiDung.Controls.Add(lblTongNguoi);
            grpNguoiDung.Font = new Font("Segoe UI", 10F);
            grpNguoiDung.Location = new Point(748, 136);
            grpNguoiDung.Name = "grpNguoiDung";
            grpNguoiDung.Size = new Size(328, 300);
            grpNguoiDung.TabIndex = 11;
            grpNguoiDung.TabStop = false;
            grpNguoiDung.Text = "Người dùng";
            //
            // lstNguoiDung
            //
            lstNguoiDung.Font = new Font("Segoe UI", 10F);
            lstNguoiDung.FormattingEnabled = true;
            lstNguoiDung.IntegralHeight = false;
            lstNguoiDung.ItemHeight = 23;
            lstNguoiDung.Location = new Point(14, 26);
            lstNguoiDung.Name = "lstNguoiDung";
            lstNguoiDung.Size = new Size(300, 230);
            lstNguoiDung.TabIndex = 0;
            //
            // lblTongNguoi
            //
            lblTongNguoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTongNguoi.ForeColor = Color.FromArgb(100, 100, 100);
            lblTongNguoi.Location = new Point(14, 264);
            lblTongNguoi.Name = "lblTongNguoi";
            lblTongNguoi.Size = new Size(300, 24);
            lblTongNguoi.TabIndex = 1;
            lblTongNguoi.Text = "0 người trong phòng";
            //
            // grpGui
            //
            grpGui.Controls.Add(lblGoiY);
            grpGui.Controls.Add(btnGuiTep);
            grpGui.Controls.Add(lblNguoiNhan);
            grpGui.Controls.Add(cmbNguoiNhan);
            grpGui.Controls.Add(txtNoiDung);
            grpGui.Controls.Add(btnGui);
            grpGui.Font = new Font("Segoe UI", 10F);
            grpGui.Location = new Point(748, 446);
            grpGui.Name = "grpGui";
            grpGui.Size = new Size(328, 210);
            grpGui.TabIndex = 12;
            grpGui.TabStop = false;
            grpGui.Text = "Gửi tin nhắn";
            //
            // lblNguoiNhan
            //
            lblNguoiNhan.AutoSize = true;
            lblNguoiNhan.Location = new Point(14, 26);
            lblNguoiNhan.Name = "lblNguoiNhan";
            lblNguoiNhan.Size = new Size(99, 23);
            lblNguoiNhan.TabIndex = 0;
            lblNguoiNhan.Text = "Người nhận:";
            //
            // cmbNguoiNhan
            //
            cmbNguoiNhan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNguoiNhan.Font = new Font("Segoe UI", 10F);
            cmbNguoiNhan.FormattingEnabled = true;
            cmbNguoiNhan.Location = new Point(14, 52);
            cmbNguoiNhan.Name = "cmbNguoiNhan";
            cmbNguoiNhan.Size = new Size(300, 31);
            cmbNguoiNhan.TabIndex = 1;
            //
            // txtNoiDung
            //
            txtNoiDung.Font = new Font("Segoe UI", 10F);
            txtNoiDung.Location = new Point(14, 96);
            txtNoiDung.MaxLength = 1000;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.PlaceholderText = "Nhập tin nhắn...";
            txtNoiDung.Size = new Size(300, 30);
            txtNoiDung.TabIndex = 2;
            //
            // btnGui
            //
            btnGui.BackColor = Color.FromArgb(51, 122, 183);
            btnGui.Cursor = Cursors.Hand;
            btnGui.FlatAppearance.BorderSize = 0;
            btnGui.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnGui.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnGui.FlatStyle = FlatStyle.Flat;
            btnGui.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGui.ForeColor = Color.White;
            btnGui.Location = new Point(167, 142);
            btnGui.Name = "btnGui";
            btnGui.Size = new Size(147, 42);
            btnGui.TabIndex = 3;
            btnGui.Text = "Gửi";
            btnGui.UseVisualStyleBackColor = false;
            btnGui.Click += btnGui_Click;
            //
            // btnGuiTep
            //
            btnGuiTep.BackColor = Color.FromArgb(46, 160, 100);
            btnGuiTep.Cursor = Cursors.Hand;
            btnGuiTep.FlatAppearance.BorderSize = 0;
            btnGuiTep.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 125, 75);
            btnGuiTep.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 180, 115);
            btnGuiTep.FlatStyle = FlatStyle.Flat;
            btnGuiTep.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuiTep.ForeColor = Color.White;
            btnGuiTep.Location = new Point(14, 142);
            btnGuiTep.Name = "btnGuiTep";
            btnGuiTep.Size = new Size(145, 42);
            btnGuiTep.TabIndex = 4;
            btnGuiTep.Text = "Gửi file/ảnh";
            btnGuiTep.UseVisualStyleBackColor = false;
            btnGuiTep.Click += btnGuiTep_Click;
            //
            // lblGoiY
            //
            lblGoiY.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblGoiY.ForeColor = Color.FromArgb(120, 120, 120);
            lblGoiY.Location = new Point(14, 188);
            lblGoiY.Name = "lblGoiY";
            lblGoiY.Size = new Size(300, 18);
            lblGoiY.TabIndex = 5;
            lblGoiY.Text = "Hỗ trợ .jpg, .jpeg, .png, .txt (tối đa 5 MB).";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 666);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(1052, 24);
            lblTrangThai.TabIndex = 13;
            lblTrangThai.Text = "Chưa kết nối.";
            //
            // Bai06Client
            //
            AcceptButton = btnGui;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 700);
            Controls.Add(lblTrangThai);
            Controls.Add(grpGui);
            Controls.Add(grpNguoiDung);
            Controls.Add(grpChat);
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
            Name = "Bai06Client";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Client - Bài 06";
            FormClosing += Bai06Client_FormClosing;
            grpChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            grpNguoiDung.ResumeLayout(false);
            grpGui.ResumeLayout(false);
            grpGui.PerformLayout();
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
        private GroupBox grpChat;
        private RichTextBox rtbChat;
        private PictureBox picAnh;
        private GroupBox grpNguoiDung;
        private ListBox lstNguoiDung;
        private Label lblTongNguoi;
        private GroupBox grpGui;
        private Label lblNguoiNhan;
        private ComboBox cmbNguoiNhan;
        private TextBox txtNoiDung;
        private Button btnGui;
        private Button btnGuiTep;
        private Label lblGoiY;
        private Label lblTrangThai;
    }
}
