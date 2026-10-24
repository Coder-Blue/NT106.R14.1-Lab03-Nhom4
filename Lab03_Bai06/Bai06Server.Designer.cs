namespace Lab03_Bai06
{
    partial class Bai06Server
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
            this.btnListen = new System.Windows.Forms.Button();
            this.lstServerLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListen.Location = new System.Drawing.Point(571, 21);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(155, 73);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // lstServerLog
            // 
            this.lstServerLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstServerLog.FormattingEnabled = true;
            this.lstServerLog.ItemHeight = 26;
            this.lstServerLog.Location = new System.Drawing.Point(12, 116);
            this.lstServerLog.Name = "lstServerLog";
            this.lstServerLog.Size = new System.Drawing.Size(731, 368);
            this.lstServerLog.TabIndex = 1;
            // 
            // Bai06Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 499);
            this.Controls.Add(this.lstServerLog);
            this.Controls.Add(this.btnListen);
            this.Name = "Bai06Server";
            this.Text = "TCP Server - Bài 06";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListBox lstServerLog;
    }
}
