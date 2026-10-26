namespace NT106.R14._1_Lab03_Nhom4.Bai01;

partial class Bai01Form
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
        lblSubtitle = new Label();
        btnUdpServer = new Button();
        btnUdpClient = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitle.Location = new Point(0, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(440, 36);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Truyền dữ liệu qua UDP";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitle
        // 
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitle.Location = new Point(0, 60);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(440, 24);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Chọn vai trò để mở cửa sổ tương ứng";
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnUdpServer
        // 
        btnUdpServer.BackColor = Color.RoyalBlue;
        btnUdpServer.Cursor = Cursors.Hand;
        btnUdpServer.FlatStyle = FlatStyle.Flat;
        btnUdpServer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnUdpServer.ForeColor = Color.White;
        btnUdpServer.Location = new Point(40, 120);
        btnUdpServer.Name = "btnUdpServer";
        btnUdpServer.Size = new Size(160, 56);
        btnUdpServer.TabIndex = 2;
        btnUdpServer.Text = "UDP Server";
        btnUdpServer.UseVisualStyleBackColor = false;
        btnUdpServer.Click += btnUdpServer_Click;
        // 
        // btnUdpClient
        // 
        btnUdpClient.BackColor = Color.RoyalBlue;
        btnUdpClient.Cursor = Cursors.Hand;
        btnUdpClient.FlatStyle = FlatStyle.Flat;
        btnUdpClient.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnUdpClient.ForeColor = Color.White;
        btnUdpClient.Location = new Point(240, 120);
        btnUdpClient.Name = "btnUdpClient";
        btnUdpClient.Size = new Size(160, 56);
        btnUdpClient.TabIndex = 3;
        btnUdpClient.Text = "UDP Client";
        btnUdpClient.UseVisualStyleBackColor = false;
        btnUdpClient.Click += btnUdpClient_Click;
        // 
        // Bai01Form
        // 
        AutoScaleDimensions = new SizeF(11F, 28F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(460, 184);
        Controls.Add(btnUdpClient);
        Controls.Add(btnUdpServer);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Bai01Form";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab 03 - Bài 01: UDP";
        ResumeLayout(false);
    }

    #endregion

    private Label lblTitle;
    private Label lblSubtitle;
    private Button btnUdpServer;
    private Button btnUdpClient;
}