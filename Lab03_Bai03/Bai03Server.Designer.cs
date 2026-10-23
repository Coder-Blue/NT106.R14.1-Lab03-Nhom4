namespace NT106.R14._1_Lab03_Nhom4.Bai03
{
    partial class Bai03Server
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
            btnListen = new Button();
            rtbNhatKy = new RichTextBox();
            lblTrangThai = new Label();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(35, 78, 120);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(540, 38);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "TCP SERVER";
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 9.5F);
            lblMoTa.ForeColor = Color.FromArgb(100, 100, 100);
            lblMoTa.Location = new Point(24, 56);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(560, 24);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Lắng nghe kết nối tại 127.0.0.1:8080 và hiển thị thông điệp từ Client.";
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
            btnListen.Location = new Point(620, 18);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(136, 44);
            btnListen.TabIndex = 2;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            //
            // rtbNhatKy
            //
            rtbNhatKy.BackColor = Color.White;
            rtbNhatKy.BorderStyle = BorderStyle.FixedSingle;
            rtbNhatKy.DetectUrls = false;
            rtbNhatKy.Font = new Font("Segoe UI", 10F);
            rtbNhatKy.Location = new Point(24, 96);
            rtbNhatKy.Name = "rtbNhatKy";
            rtbNhatKy.ReadOnly = true;
            rtbNhatKy.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbNhatKy.Size = new Size(732, 370);
            rtbNhatKy.TabIndex = 3;
            rtbNhatKy.TabStop = false;
            rtbNhatKy.Text = "";
            //
            // lblTrangThai
            //
            lblTrangThai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
            lblTrangThai.Location = new Point(24, 480);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(732, 24);
            lblTrangThai.TabIndex = 4;
            lblTrangThai.Text = "Chưa lắng nghe.";
            //
            // Bai03Server
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(780, 520);
            Controls.Add(lblTrangThai);
            Controls.Add(rtbNhatKy);
            Controls.Add(btnListen);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai03Server";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TCP Server - Bài 03";
            FormClosing += Bai03Server_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Button btnListen;
        private RichTextBox rtbNhatKy;
        private Label lblTrangThai;
    }
}
