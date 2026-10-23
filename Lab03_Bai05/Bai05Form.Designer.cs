namespace NT106.R14._1_Lab03_Nhom4.Bai05
{
    partial class Bai05Form
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
            btnMoServer = new Button();
            btnMoClient = new Button();
            lblLuuY = new Label();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(35, 78, 120);
            lblTieuDe.Location = new Point(0, 26);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(720, 40);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "BÀI 05 - HÔM NAY ĂN GÌ?";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblMoTa
            //
            lblMoTa.Font = new Font("Segoe UI", 10F);
            lblMoTa.ForeColor = Color.FromArgb(90, 90, 90);
            lblMoTa.Location = new Point(0, 72);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(720, 26);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Dữ liệu món ăn được lưu tại SQLite của Server và cập nhật cho mọi Client.";
            lblMoTa.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnMoServer
            //
            btnMoServer.BackColor = Color.FromArgb(51, 122, 183);
            btnMoServer.Cursor = Cursors.Hand;
            btnMoServer.FlatAppearance.BorderSize = 0;
            btnMoServer.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnMoServer.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnMoServer.FlatStyle = FlatStyle.Flat;
            btnMoServer.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnMoServer.ForeColor = Color.White;
            btnMoServer.Location = new Point(50, 126);
            btnMoServer.Name = "btnMoServer";
            btnMoServer.Size = new Size(290, 120);
            btnMoServer.TabIndex = 2;
            btnMoServer.Text = "Mở TCP Server\nQuản lý món ăn";
            btnMoServer.UseVisualStyleBackColor = false;
            btnMoServer.Click += btnMoServer_Click;
            //
            // btnMoClient
            //
            btnMoClient.BackColor = Color.FromArgb(51, 122, 183);
            btnMoClient.Cursor = Cursors.Hand;
            btnMoClient.FlatAppearance.BorderSize = 0;
            btnMoClient.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnMoClient.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnMoClient.FlatStyle = FlatStyle.Flat;
            btnMoClient.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnMoClient.ForeColor = Color.White;
            btnMoClient.Location = new Point(380, 126);
            btnMoClient.Name = "btnMoClient";
            btnMoClient.Size = new Size(290, 120);
            btnMoClient.TabIndex = 3;
            btnMoClient.Text = "Mở TCP Client\nChọn món ăn";
            btnMoClient.UseVisualStyleBackColor = false;
            btnMoClient.Click += btnMoClient_Click;
            //
            // lblLuuY
            //
            lblLuuY.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblLuuY.ForeColor = Color.FromArgb(120, 120, 120);
            lblLuuY.Location = new Point(0, 276);
            lblLuuY.Name = "lblLuuY";
            lblLuuY.Size = new Size(720, 50);
            lblLuuY.TabIndex = 4;
            lblLuuY.Text = "Mở Server trước, nhấn Listen, sau đó mở nhiều Client để thêm món và chọn ngẫu nhiên.";
            lblLuuY.TextAlign = ContentAlignment.MiddleCenter;
            //
            // Bai05Form
            //
            AcceptButton = btnMoServer;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(720, 350);
            Controls.Add(lblLuuY);
            Controls.Add(btnMoClient);
            Controls.Add(btnMoServer);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Bai05Form";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bài 05 - Hôm nay ăn gì?";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMoTa;
        private Button btnMoServer;
        private Button btnMoClient;
        private Label lblLuuY;
    }
}
