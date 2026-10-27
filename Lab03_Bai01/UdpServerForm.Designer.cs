namespace NT106.R14._1_Lab03_Nhom4.Bai01
{
    partial class UdpServerForm
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
            lblCong = new Label();
            txtCong = new TextBox();
            btnListen = new Button();
            grpNhatKy = new GroupBox();
            rtbNhatKy = new RichTextBox();
            lblTrangThai = new Label();
            grpNhatKy.SuspendLayout();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(35, 78, 120);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(600, 38);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "UDP SERVER";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 54);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(700, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Lắng nghe dữ liệu UDP và hiển thị thông điệp nhận được.";
            //
            // lblCong
            //
            lblCong.AutoSize = true;
            lblCong.Font = new Font("Segoe UI", 10F);
            lblCong.Location = new Point(24, 101);
            lblCong.Name = "lblCong";
            lblCong.Size = new Size(42, 23);
            lblCong.TabIndex = 2;
            lblCong.Text = "Port:";
            //
            // txtCong
            //
            txtCong.Font = new Font("Segoe UI", 10.5F);
            txtCong.Location = new Point(74, 96);
            txtCong.MaxLength = 5;
            txtCong.Name = "txtCong";
            txtCong.Size = new Size(90, 31);
            txtCong.TabIndex = 3;
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
            btnListen.Location = new Point(730, 16);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(146, 44);
            btnListen.TabIndex = 4;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            //
            // grpNhatKy
            //
            grpNhatKy.Controls.Add(rtbNhatKy);
            grpNhatKy.Font = new Font("Segoe UI", 10F);
            grpNhatKy.Location = new Point(24, 140);
            grpNhatKy.Name = "grpNhatKy";
            grpNhatKy.Size = new Size(852, 410);
            grpNhatKy.TabIndex = 5;
            grpNhatKy.TabStop = false;
            grpNhatKy.Text = "Thông điệp nhận được";
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
            rtbNhatKy.Size = new Size(824, 370);
            rtbNhatKy.TabIndex = 0;
            rtbNhatKy.Text = "";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 560);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(852, 24);
            lblTrangThai.TabIndex = 6;
            lblTrangThai.Text = "Chưa lắng nghe. Bấm Listen để bắt đầu.";
            //
            // UdpServerForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 600);
            Controls.Add(lblTrangThai);
            Controls.Add(grpNhatKy);
            Controls.Add(btnListen);
            Controls.Add(txtCong);
            Controls.Add(lblCong);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UdpServerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UDP Server - Bài 01";
            FormClosing += UdpServerForm_FormClosing;
            grpNhatKy.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblCong;
        private TextBox txtCong;
        private Button btnListen;
        private GroupBox grpNhatKy;
        private RichTextBox rtbNhatKy;
        private Label lblTrangThai;
    }
}
