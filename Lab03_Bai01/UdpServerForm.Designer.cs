namespace NT106.R14._1_Lab03_Nhom4.Bai01;

partial class UdpServerForm
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
        label1 = new Label();
        txtPort = new TextBox();
        btnListen = new Button();
        label2 = new Label();
        lvMessages = new ListView();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.ForeColor = Color.FromArgb(71, 85, 105);
        label1.Location = new Point(30, 65);
        label1.Name = "label1";
        label1.Size = new Size(44, 25);
        label1.TabIndex = 0;
        label1.Text = "Port";
        // 
        // txtPort
        // 
        txtPort.Location = new Point(30, 90);
        txtPort.Name = "txtPort";
        txtPort.Size = new Size(130, 31);
        txtPort.TabIndex = 1;
        txtPort.Text = "8080";
        // 
        // btnListen
        // 
        btnListen.BackColor = Color.FromArgb(37, 99, 235);
        btnListen.FlatAppearance.BorderSize = 0;
        btnListen.FlatStyle = FlatStyle.Flat;
        btnListen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnListen.ForeColor = Color.White;
        btnListen.Location = new Point(180, 86);
        btnListen.Name = "btnListen";
        btnListen.Size = new Size(130, 36);
        btnListen.TabIndex = 2;
        btnListen.Text = "Listen";
        btnListen.UseVisualStyleBackColor = false;
        btnListen.Click += btnListen_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.ForeColor = Color.FromArgb(71, 85, 105);
        label2.Location = new Point(30, 140);
        label2.Name = "label2";
        label2.Size = new Size(164, 25);
        label2.TabIndex = 3;
        label2.Text = "Received messages";
        // 
        // lvMessages
        // 
        lvMessages.BackColor = Color.White;
        lvMessages.BorderStyle = BorderStyle.FixedSingle;
        lvMessages.Location = new Point(30, 165);
        lvMessages.Name = "lvMessages";
        lvMessages.Size = new Size(460, 230);
        lvMessages.TabIndex = 4;
        lvMessages.UseCompatibleStateImageBehavior = false;
        lvMessages.View = View.List;
        // 
        // UdpServerForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(lvMessages);
        Controls.Add(label2);
        Controls.Add(btnListen);
        Controls.Add(txtPort);
        Controls.Add(label1);
        Name = "UdpServerForm";
        Text = "UdpServerForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox txtPort;
    private Button btnListen;
    private Label label2;
    private ListView lvMessages;
}