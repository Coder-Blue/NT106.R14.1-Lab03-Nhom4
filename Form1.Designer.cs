namespace NT106.R14._1_Lab03_Nhom4
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 22F);
            button1.Location = new Point(47, 214);
            button1.Name = "button1";
            button1.Size = new Size(342, 94);
            button1.TabIndex = 0;
            button1.Text = "Lab03_Bai01";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 22F);
            button2.Location = new Point(425, 214);
            button2.Name = "button2";
            button2.Size = new Size(342, 94);
            button2.TabIndex = 1;
            button2.Text = "Lab03_Bai02";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 22F);
            button3.Location = new Point(809, 214);
            button3.Name = "button3";
            button3.Size = new Size(342, 94);
            button3.TabIndex = 2;
            button3.Text = "Lab03_Bai03";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 22F);
            button4.Location = new Point(47, 389);
            button4.Name = "button4";
            button4.Size = new Size(342, 94);
            button4.TabIndex = 3;
            button4.Text = "Lab03_Bai04";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 22F);
            button5.Location = new Point(425, 389);
            button5.Name = "button5";
            button5.Size = new Size(342, 94);
            button5.TabIndex = 4;
            button5.Text = "Lab03_Bai05";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 22F);
            button6.Location = new Point(809, 389);
            button6.Name = "button6";
            button6.Size = new Size(342, 94);
            button6.TabIndex = 5;
            button6.Text = "Lab03_Bai06";
            button6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 731);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Lab03";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
