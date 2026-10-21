namespace NT106.R14._1_Lab03_Nhom4
{
    partial class Lab03_Bai03_Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnListen = new Button();
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListen.Location = new Point(555, 12);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(188, 75);
            btnListen.TabIndex = 2;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // lstLog
            // 
            lstLog.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(12, 106);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(731, 394);
            lstLog.TabIndex = 3;
            // 
            // Lab03_Bai03_Server
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 511);
            Controls.Add(lstLog);
            Controls.Add(btnListen);
            Name = "Lab03_Bai03_Server";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private Button btnListen;
        private ListBox lstLog;
    }
}