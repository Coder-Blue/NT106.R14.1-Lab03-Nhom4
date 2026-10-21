namespace NT106.R14._1_Lab03_Nhom4
{
    partial class Lab03_Bai03
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
            btnOpenServer = new Button();
            btnOpenClient = new Button();
            SuspendLayout();
            // 
            // btnOpenServer
            // 
            btnOpenServer.Font = new Font("Segoe UI", 16F);
            btnOpenServer.Location = new Point(132, 57);
            btnOpenServer.Name = "btnOpenServer";
            btnOpenServer.Size = new Size(373, 96);
            btnOpenServer.TabIndex = 0;
            btnOpenServer.Text = "Open TCP Server";
            btnOpenServer.UseVisualStyleBackColor = true;
            btnOpenServer.Click += btnOpenServer_Click;
            // 
            // btnOpenClient
            // 
            btnOpenClient.Font = new Font("Segoe UI", 16F);
            btnOpenClient.Location = new Point(128, 197);
            btnOpenClient.Name = "btnOpenClient";
            btnOpenClient.Size = new Size(377, 96);
            btnOpenClient.TabIndex = 1;
            btnOpenClient.Text = "Open new TCP client";
            btnOpenClient.UseVisualStyleBackColor = true;
            btnOpenClient.Click += btnOpenClient_Click;
            // 
            // Lab03_Bai03
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 346);
            Controls.Add(btnOpenClient);
            Controls.Add(btnOpenServer);
            Name = "Lab03_Bai03";
            Text = "Lab03_Bai03";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpenServer;
        private Button btnOpenClient;
    }
}