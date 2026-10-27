namespace NT106.R14._1_Lab03_Nhom4.Bai01;

public partial class Bai01Form : Form
{
    private UdpServerForm? serverForm;
    private UdpClientForm? clientForm;

    public Bai01Form() => InitializeComponent();

    private void btnMoServer_Click(object sender, EventArgs e)
    {
        if (serverForm is null || serverForm.IsDisposed)
        {
            serverForm = new UdpServerForm();
            serverForm.FormClosed += (_, _) => serverForm = null;
            serverForm.Show(this);
            return;
        }

        serverForm.Activate();
    }

    private void btnMoClient_Click(object sender, EventArgs e)
    {
        if (clientForm is null || clientForm.IsDisposed)
        {
            clientForm = new UdpClientForm();
            clientForm.FormClosed += (_, _) => clientForm = null;
            clientForm.Show(this);
            return;
        }

        clientForm.Activate();
    }
}
