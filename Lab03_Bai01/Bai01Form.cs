namespace NT106.R14._1_Lab03_Nhom4.Bai01;

public partial class Bai01Form : Form
{
    private UdpServerForm? udpServerForm;
    private UdpClientForm? udpClientForm;

    public Bai01Form() => InitializeComponent();

    private void btnUdpServer_Click(object sender, EventArgs e)
    {
        if (udpServerForm is null || udpServerForm.IsDisposed)
        {
            udpServerForm = new UdpServerForm();
            udpServerForm.FormClosed += (_, _) => udpServerForm = null;
            udpServerForm.Show(this);
            return;
        }

        udpServerForm.Activate();
    }

    private void btnUdpClient_Click(object sender, EventArgs e)
    {
        if (udpClientForm is null || udpClientForm.IsDisposed)
        {
            udpClientForm = new UdpClientForm();
            udpClientForm.FormClosed += (_, _) => udpClientForm = null;
            udpClientForm.Show(this);
            return;
        }

        udpClientForm.Activate();
    }
}
