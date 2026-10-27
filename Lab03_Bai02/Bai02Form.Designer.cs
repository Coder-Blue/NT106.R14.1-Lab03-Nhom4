namespace NT106.R14._1_Lab03_Nhom4.Bai02;

partial class Bai02Form
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
        btnListen = new Button();
        lvCommand = new ListView();
        lblStatus = new Label();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(31, 78, 121);
        lblTitle.Location = new Point(25, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(316, 48);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "TELNET LISTENER";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitle.Location = new Point(28, 62);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(634, 28);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Lắng nghe kết nối TCP từ dịch vụ Telnet và hiển thị nội dung nhận được.";
        // 
        // btnListen
        // 
        btnListen.BackColor = Color.FromArgb(46, 117, 182);
        btnListen.FlatAppearance.BorderSize = 0;
        btnListen.FlatStyle = FlatStyle.Flat;
        btnListen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnListen.ForeColor = Color.White;
        btnListen.Location = new Point(410, 20);
        btnListen.Name = "btnListen";
        btnListen.Size = new Size(125, 44);
        btnListen.TabIndex = 2;
        btnListen.Text = "Listen";
        btnListen.UseVisualStyleBackColor = false;
        btnListen.Click += btnListen_Click;
        // 
        // lvCommand
        // 
        lvCommand.BorderStyle = BorderStyle.FixedSingle;
        lvCommand.HideSelection = false;
        lvCommand.Location = new Point(28, 105);
        lvCommand.Name = "lvCommand";
        lvCommand.Size = new Size(505, 290);
        lvCommand.TabIndex = 3;
        lvCommand.UseCompatibleStateImageBehavior = false;
        lvCommand.View = View.List;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
        lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatus.Location = new Point(28, 410);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(337, 25);
        lblStatus.TabIndex = 4;
        lblStatus.Text = "Chưa lắng nghe. Bấm Listen để bắt đầu.";
        // 
        // Bai02Form
        // 
        AutoScaleDimensions = new SizeF(11F, 28F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(699, 510);
        Controls.Add(lblStatus);
        Controls.Add(lvCommand);
        Controls.Add(btnListen);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Bai02Form";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Telnet Listener - Bài 02";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Label lblSubtitle;
    private Button btnListen;
    private ListView lvCommand;
    private Label lblStatus;
}
