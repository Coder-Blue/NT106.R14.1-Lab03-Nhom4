namespace NT106.R14._1_Lab03_Nhom4.Bai05;

public partial class Bai05Form : Form
{
    private Bai05Server? serverForm;

    public Bai05Form() => InitializeComponent();

    private void btnMoServer_Click(object sender, EventArgs e)
    {
        if (serverForm is null || serverForm.IsDisposed)
        {
            serverForm = new Bai05Server();
            serverForm.FormClosed += (_, _) => serverForm = null;
            serverForm.Show(this);
            return;
        }

        serverForm.Activate();
    }

    private void btnMoClient_Click(object sender, EventArgs e)
    {
        var client = new Bai05Client();
        client.Show(this);
    }
}
