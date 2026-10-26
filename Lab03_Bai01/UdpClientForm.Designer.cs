namespace NT106.R14._1_Lab03_Nhom4.Bai01;

partial class UdpClientForm
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
        lblTitle = new Label();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        txtPort = new TextBox();
        txtMessage = new TextBox();
        txtRemoteHost = new TextBox();
        btnSend = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.CornflowerBlue;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitle.Location = new Point(0, 15);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(460, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "UDP Client";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.ForeColor = Color.FromArgb(71, 85, 105);
        label1.Location = new Point(30, 65);
        label1.Name = "label1";
        label1.Size = new Size(143, 28);
        label1.TabIndex = 1;
        label1.Text = "IP Remote host";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.ForeColor = Color.FromArgb(71, 85, 105);
        label2.Location = new Point(320, 65);
        label2.Name = "label2";
        label2.Size = new Size(48, 28);
        label2.TabIndex = 2;
        label2.Text = "Port";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.ForeColor = Color.FromArgb(71, 85, 105);
        label3.Location = new Point(30, 135);
        label3.Name = "label3";
        label3.Size = new Size(88, 28);
        label3.TabIndex = 3;
        label3.Text = "Message";
        // 
        // txtPort
        // 
        txtPort.Location = new Point(320, 90);
        txtPort.Name = "txtPort";
        txtPort.Size = new Size(110, 34);
        txtPort.TabIndex = 4;
        txtPort.Text = "8080";
        // 
        // txtMessage
        // 
        txtMessage.Location = new Point(30, 166);
        txtMessage.Multiline = true;
        txtMessage.Name = "txtMessage";
        txtMessage.ScrollBars = ScrollBars.Vertical;
        txtMessage.Size = new Size(400, 120);
        txtMessage.TabIndex = 5;
        // 
        // txtRemoteHost
        // 
        txtRemoteHost.Location = new Point(30, 90);
        txtRemoteHost.Name = "txtRemoteHost";
        txtRemoteHost.Size = new Size(270, 34);
        txtRemoteHost.TabIndex = 6;
        txtRemoteHost.Text = "127.0.0.1";
        // 
        // btnSend
        // 
        btnSend.BackColor = Color.FromArgb(22, 163, 74);
        btnSend.FlatAppearance.BorderSize = 0;
        btnSend.FlatStyle = FlatStyle.Flat;
        btnSend.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnSend.ForeColor = Color.White;
        btnSend.Location = new Point(30, 295);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(400, 44);
        btnSend.TabIndex = 7;
        btnSend.Text = "Gửi";
        btnSend.UseVisualStyleBackColor = false;
        btnSend.Click += btnSend_Click;
        // 
        // UdpClientForm
        // 
        AutoScaleDimensions = new SizeF(11F, 28F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(482, 340);
        Controls.Add(btnSend);
        Controls.Add(txtRemoteHost);
        Controls.Add(txtMessage);
        Controls.Add(txtPort);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(lblTitle);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "UdpClientForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "UDP Client";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox txtPort;
    private TextBox txtMessage;
    private TextBox txtRemoteHost;
    private Button btnSend;
}