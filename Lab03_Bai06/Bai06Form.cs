namespace NT106.R14._1_Lab03_Nhom4.Bai06;

public partial class Bai06Form : Form
{
    private Bai06Server? serverForm;

    public Bai06Form() => InitializeComponent();

    private void btnMoServer_Click(object sender, EventArgs e)
    {
        if (serverForm is null || serverForm.IsDisposed)
        {
            serverForm = new Bai06Server();
            serverForm.FormClosed += (_, _) => serverForm = null;
            serverForm.Show(this);
            return;
        }

        serverForm.Activate();
    }

    private void btnMoClient_Click(object sender, EventArgs e)
    {
        var client = new Bai06Client();
        client.Show(this);
    }
}
