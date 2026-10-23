namespace NT106.R14._1_Lab03_Nhom4;

public partial class Bai03 : Form
{
    private Bai03Server? serverForm;
    private Bai03Client? clientForm;

    public Bai03() => InitializeComponent();

    private void btnMoServer_Click(object sender, EventArgs e)
    {
        if (serverForm is null || serverForm.IsDisposed)
        {
            serverForm = new Bai03Server();
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
            clientForm = new Bai03Client();
            clientForm.FormClosed += (_, _) => clientForm = null;
            clientForm.Show(this);
            return;
        }

        clientForm.Activate();
    }
}
