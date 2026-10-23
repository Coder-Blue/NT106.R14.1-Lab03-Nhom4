namespace NT106.R14._1_Lab03_Nhom4
{
    partial class FormChinh
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
            lblPhuDe = new Label();
            lblHuongDan = new Label();
            btnBai01 = new Button();
            btnBai02 = new Button();
            btnBai03 = new Button();
            btnBai04 = new Button();
            btnBai05 = new Button();
            btnBai06 = new Button();
            lblGhiChu = new Label();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(35, 78, 120);
            lblTieuDe.Location = new Point(0, 26);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(980, 46);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "LAB 03 - LẬP TRÌNH SOCKETS TRONG C#";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblPhuDe
            //
            lblPhuDe.Font = new Font("Segoe UI", 11F);
            lblPhuDe.ForeColor = Color.FromArgb(100, 100, 100);
            lblPhuDe.Location = new Point(0, 78);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Size = new Size(980, 28);
            lblPhuDe.TabIndex = 1;
            lblPhuDe.Text = "NT106.R14.1 - Nhóm 4";
            lblPhuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblHuongDan
            //
            lblHuongDan.Font = new Font("Segoe UI", 10F);
            lblHuongDan.ForeColor = Color.FromArgb(70, 70, 70);
            lblHuongDan.Location = new Point(0, 128);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(980, 26);
            lblHuongDan.TabIndex = 2;
            lblHuongDan.Text = "Chọn một bài thực hành để mở form điều hướng.";
            lblHuongDan.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnBai01
            //
            btnBai01.BackColor = Color.FromArgb(236, 240, 245);
            btnBai01.Cursor = Cursors.Default;
            btnBai01.Enabled = false;
            btnBai01.FlatAppearance.BorderSize = 0;
            btnBai01.FlatStyle = FlatStyle.Flat;
            btnBai01.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBai01.ForeColor = Color.FromArgb(120, 130, 140);
            btnBai01.Location = new Point(40, 190);
            btnBai01.Name = "btnBai01";
            btnBai01.Size = new Size(280, 112);
            btnBai01.TabIndex = 3;
            btnBai01.Text = "Bài 01\nUDP Client - Server";
            btnBai01.UseVisualStyleBackColor = false;
            //
            // btnBai02
            //
            btnBai02.BackColor = Color.FromArgb(236, 240, 245);
            btnBai02.Cursor = Cursors.Default;
            btnBai02.Enabled = false;
            btnBai02.FlatAppearance.BorderSize = 0;
            btnBai02.FlatStyle = FlatStyle.Flat;
            btnBai02.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBai02.ForeColor = Color.FromArgb(120, 130, 140);
            btnBai02.Location = new Point(350, 190);
            btnBai02.Name = "btnBai02";
            btnBai02.Size = new Size(280, 112);
            btnBai02.TabIndex = 4;
            btnBai02.Text = "Bài 02\nTelnet Server";
            btnBai02.UseVisualStyleBackColor = false;
            //
            // btnBai03
            //
            btnBai03.BackColor = Color.FromArgb(51, 122, 183);
            btnBai03.Cursor = Cursors.Hand;
            btnBai03.FlatAppearance.BorderSize = 0;
            btnBai03.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnBai03.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnBai03.FlatStyle = FlatStyle.Flat;
            btnBai03.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBai03.ForeColor = Color.White;
            btnBai03.Location = new Point(660, 190);
            btnBai03.Name = "btnBai03";
            btnBai03.Size = new Size(280, 112);
            btnBai03.TabIndex = 5;
            btnBai03.Text = "Bài 03\nTCP 1 Server - 1 Client";
            btnBai03.UseVisualStyleBackColor = false;
            btnBai03.Click += btnBai03_Click;
            //
            // btnBai04
            //
            btnBai04.BackColor = Color.FromArgb(236, 240, 245);
            btnBai04.Cursor = Cursors.Default;
            btnBai04.Enabled = false;
            btnBai04.FlatAppearance.BorderSize = 0;
            btnBai04.FlatStyle = FlatStyle.Flat;
            btnBai04.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBai04.ForeColor = Color.FromArgb(120, 130, 140);
            btnBai04.Location = new Point(40, 330);
            btnBai04.Name = "btnBai04";
            btnBai04.Size = new Size(280, 112);
            btnBai04.TabIndex = 6;
            btnBai04.Text = "Bài 04\nQuản lý phòng vé";
            btnBai04.UseVisualStyleBackColor = false;
            //
            // btnBai05
            //
            btnBai05.BackColor = Color.FromArgb(236, 240, 245);
            btnBai05.Cursor = Cursors.Default;
            btnBai05.Enabled = false;
            btnBai05.FlatAppearance.BorderSize = 0;
            btnBai05.FlatStyle = FlatStyle.Flat;
            btnBai05.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBai05.ForeColor = Color.FromArgb(120, 130, 140);
            btnBai05.Location = new Point(350, 330);
            btnBai05.Name = "btnBai05";
            btnBai05.Size = new Size(280, 112);
            btnBai05.TabIndex = 7;
            btnBai05.Text = "Bài 05\nHôm nay ăn gì?";
            btnBai05.UseVisualStyleBackColor = false;
            //
            // btnBai06
            //
            btnBai06.BackColor = Color.FromArgb(236, 240, 245);
            btnBai06.Cursor = Cursors.Default;
            btnBai06.Enabled = false;
            btnBai06.FlatAppearance.BorderSize = 0;
            btnBai06.FlatStyle = FlatStyle.Flat;
            btnBai06.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBai06.ForeColor = Color.FromArgb(120, 130, 140);
            btnBai06.Location = new Point(660, 330);
            btnBai06.Name = "btnBai06";
            btnBai06.Size = new Size(280, 112);
            btnBai06.TabIndex = 8;
            btnBai06.Text = "Bài 06\nChat Room";
            btnBai06.UseVisualStyleBackColor = false;
            //
            // lblGhiChu
            //
            lblGhiChu.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblGhiChu.ForeColor = Color.FromArgb(120, 120, 120);
            lblGhiChu.Location = new Point(0, 486);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(980, 24);
            lblGhiChu.TabIndex = 9;
            lblGhiChu.Text = "Bài 03 đã hoàn thành. Các bài còn lại sẽ được cập nhật sau.";
            lblGhiChu.TextAlign = ContentAlignment.MiddleCenter;
            //
            // FormChinh
            //
            AcceptButton = btnBai03;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(980, 540);
            Controls.Add(lblGhiChu);
            Controls.Add(btnBai06);
            Controls.Add(btnBai05);
            Controls.Add(btnBai04);
            Controls.Add(btnBai03);
            Controls.Add(btnBai02);
            Controls.Add(btnBai01);
            Controls.Add(lblHuongDan);
            Controls.Add(lblPhuDe);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormChinh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab 03 - NT106.R14.1 - Nhóm 4";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Label lblPhuDe;
        private Label lblHuongDan;
        private Button btnBai01;
        private Button btnBai02;
        private Button btnBai03;
        private Button btnBai04;
        private Button btnBai05;
        private Button btnBai06;
        private Label lblGhiChu;
    }
}
