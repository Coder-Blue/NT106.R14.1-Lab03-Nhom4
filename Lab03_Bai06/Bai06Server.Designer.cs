namespace NT106.R14._1_Lab03_Nhom4.Bai06
{
    partial class Bai06Server
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
            grpNguoiDung = new GroupBox();
            lvNguoiDung = new ListView();
            colTen = new ColumnHeader();
            colDiaChi = new ColumnHeader();
            lblTongClient = new Label();
            grpNhatKy = new GroupBox();
            rtbNhatKy = new RichTextBox();
            lblTrangThai = new Label();
            grpNguoiDung.SuspendLayout();
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
            lblTieuDe.Text = "TCP SERVER - CHAT ROOM";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(800, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Quản lý nhiều Client, chat chung và chuyển tin nhắn riêng.";
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
            // grpNguoiDung
            //
            grpNguoiDung.Controls.Add(lvNguoiDung);
            grpNguoiDung.Controls.Add(lblTongClient);
            grpNguoiDung.Font = new Font("Segoe UI", 10F);
            grpNguoiDung.Location = new Point(24, 90);
            grpNguoiDung.Name = "grpNguoiDung";
            grpNguoiDung.Size = new Size(360, 520);
            grpNguoiDung.TabIndex = 4;
            grpNguoiDung.TabStop = false;
            grpNguoiDung.Text = "Người dùng trong phòng";
            //
            // lvNguoiDung
            //
            lvNguoiDung.Columns.AddRange(new ColumnHeader[] { colTen, colDiaChi });
            lvNguoiDung.Font = new Font("Segoe UI", 9.5F);
            lvNguoiDung.FullRowSelect = true;
            lvNguoiDung.GridLines = true;
            lvNguoiDung.Location = new Point(14, 26);
            lvNguoiDung.MultiSelect = false;
            lvNguoiDung.Name = "lvNguoiDung";
            lvNguoiDung.Size = new Size(332, 440);
            lvNguoiDung.TabIndex = 0;
            lvNguoiDung.UseCompatibleStateImageBehavior = false;
            lvNguoiDung.View = View.Details;
            //
            // colTen
            //
            colTen.Text = "Tên";
            colTen.Width = 160;
            //
            // colDiaChi
            //
            colDiaChi.Text = "Địa chỉ";
            colDiaChi.Width = 160;
            //
            // lblTongClient
            //
            lblTongClient.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTongClient.ForeColor = Color.FromArgb(100, 100, 100);
            lblTongClient.Location = new Point(14, 476);
            lblTongClient.Name = "lblTongClient";
            lblTongClient.Size = new Size(332, 24);
            lblTongClient.TabIndex = 1;
            lblTongClient.Text = "0 người trong phòng";
            //
            // grpNhatKy
            //
            grpNhatKy.Controls.Add(rtbNhatKy);
            grpNhatKy.Font = new Font("Segoe UI", 10F);
            grpNhatKy.Location = new Point(400, 90);
            grpNhatKy.Name = "grpNhatKy";
            grpNhatKy.Size = new Size(696, 520);
            grpNhatKy.TabIndex = 5;
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
            rtbNhatKy.Size = new Size(668, 480);
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
            lblTrangThai.TabIndex = 6;
            lblTrangThai.Text = "Chưa lắng nghe.";
            //
            // Bai06Server
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1120, 670);
            Controls.Add(lblTrangThai);
            Controls.Add(grpNhatKy);
            Controls.Add(grpNguoiDung);
            Controls.Add(btnListen);
            Controls.Add(lblSoClient);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai06Server";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Server - Bài 06";
            FormClosing += Bai06Server_FormClosing;
            grpNguoiDung.ResumeLayout(false);
            grpNhatKy.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblSoClient;
        private Button btnListen;
        private GroupBox grpNguoiDung;
        private ListView lvNguoiDung;
        private ColumnHeader colTen;
        private ColumnHeader colDiaChi;
        private Label lblTongClient;
        private GroupBox grpNhatKy;
        private RichTextBox rtbNhatKy;
        private Label lblTrangThai;
    }
}
