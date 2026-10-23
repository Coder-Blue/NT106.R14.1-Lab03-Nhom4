namespace NT106.R14._1_Lab03_Nhom4.Bai04;

public partial class Bai04Form : Form
{
    private Bai04Server? serverForm;

    public Bai04Form() => InitializeComponent();

    private void btnMoServer_Click(object sender, EventArgs e)
    {
        if (serverForm is null || serverForm.IsDisposed)
        {
            serverForm = new Bai04Server();
            serverForm.FormClosed += (_, _) => serverForm = null;
            serverForm.Show(this);
            return;
        }

        serverForm.Activate();
    }

    private void btnMoClient_Click(object sender, EventArgs e)
    {
        var client = new Bai04Client();
        client.Show(this);
    }
}
