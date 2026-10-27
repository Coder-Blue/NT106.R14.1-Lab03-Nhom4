namespace NT106.R14._1_Lab03_Nhom4.Bai01
{
    partial class UdpClientForm
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
            lblNoiDung = new Label();
            txtNoiDung = new TextBox();
            btnGui = new Button();
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
            lblTieuDe.Text = "UDP CLIENT";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(560, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Nhập IP, port và thông điệp cần gửi tới UDP Server.";
            //
            // lblDiaChi
            //
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(24, 101);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(26, 23);
            lblDiaChi.TabIndex = 2;
            lblDiaChi.Text = "IP:";
            //
            // txtDiaChi
            //
            txtDiaChi.Font = new Font("Segoe UI", 10.5F);
            txtDiaChi.Location = new Point(60, 96);
            txtDiaChi.MaxLength = 45;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(180, 31);
            txtDiaChi.TabIndex = 3;
            //
            // lblCong
            //
            lblCong.AutoSize = true;
            lblCong.Font = new Font("Segoe UI", 10F);
            lblCong.Location = new Point(256, 101);
            lblCong.Name = "lblCong";
            lblCong.Size = new Size(42, 23);
            lblCong.TabIndex = 4;
            lblCong.Text = "Port:";
            //
            // txtCong
            //
            txtCong.Font = new Font("Segoe UI", 10.5F);
            txtCong.Location = new Point(306, 96);
            txtCong.MaxLength = 5;
            txtCong.Name = "txtCong";
            txtCong.Size = new Size(80, 31);
            txtCong.TabIndex = 5;
            //
            // lblNoiDung
            //
            lblNoiDung.AutoSize = true;
            lblNoiDung.Font = new Font("Segoe UI", 10F);
            lblNoiDung.Location = new Point(24, 147);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(81, 23);
            lblNoiDung.TabIndex = 6;
            lblNoiDung.Text = "Nội dung:";
            //
            // txtNoiDung
            //
            txtNoiDung.Font = new Font("Segoe UI", 10.5F);
            txtNoiDung.Location = new Point(24, 173);
            txtNoiDung.MaxLength = 4000;
            txtNoiDung.Multiline = true;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.PlaceholderText = "Nhập thông điệp cần gửi...";
            txtNoiDung.ScrollBars = ScrollBars.Vertical;
            txtNoiDung.Size = new Size(592, 110);
            txtNoiDung.TabIndex = 7;
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
            btnGui.Location = new Point(24, 298);
            btnGui.Name = "btnGui";
            btnGui.Size = new Size(592, 44);
            btnGui.TabIndex = 8;
            btnGui.Text = "Gửi thông điệp";
            btnGui.UseVisualStyleBackColor = false;
            btnGui.Click += btnGui_Click;
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 354);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(592, 24);
            lblTrangThai.TabIndex = 9;
            lblTrangThai.Text = "Sẵn sàng gửi.";
            //
            // UdpClientForm
            //
            AcceptButton = btnGui;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(640, 420);
            Controls.Add(lblTrangThai);
            Controls.Add(btnGui);
            Controls.Add(txtNoiDung);
            Controls.Add(lblNoiDung);
            Controls.Add(txtCong);
            Controls.Add(lblCong);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiaChi);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UdpClientForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UDP Client - Bài 01";
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
        private Label lblNoiDung;
        private TextBox txtNoiDung;
        private Button btnGui;
        private Label lblTrangThai;
    }
}
