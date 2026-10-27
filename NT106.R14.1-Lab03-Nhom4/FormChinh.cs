using NT106.R14._1_Lab03_Nhom4.Bai02;
using NT106.R14._1_Lab03_Nhom4.Bai03;
using NT106.R14._1_Lab03_Nhom4.Bai04;
using NT106.R14._1_Lab03_Nhom4.Bai05;
using NT106.R14._1_Lab03_Nhom4.Bai06;

namespace NT106.R14._1_Lab03_Nhom4;

public partial class FormChinh : Form
{
    private Bai02Form? bai02Form;
    private Bai03Form? bai03Form;
    private Bai04Form? bai04Form;
    private Bai05Form? bai05Form;
    private Bai06Form? bai06Form;

    public FormChinh() => InitializeComponent();

    private void btnBai02_Click(object sender, EventArgs e)
    {
        if (bai02Form is null || bai02Form.IsDisposed)
        {
            bai02Form = new Bai02Form();
            bai02Form.FormClosed += (_, _) => bai02Form = null;
            bai02Form.Show(this);
            return;
        }

        bai02Form.Activate();
    }

    private void btnBai03_Click(object sender, EventArgs e)
    {
        if (bai03Form is null || bai03Form.IsDisposed)
        {
            bai03Form = new Bai03Form();
            bai03Form.FormClosed += (_, _) => bai03Form = null;
            bai03Form.Show(this);
            return;
        }

        bai03Form.Activate();
    }

    private void btnBai04_Click(object sender, EventArgs e)
    {
        if (bai04Form is null || bai04Form.IsDisposed)
        {
            bai04Form = new Bai04Form();
            bai04Form.FormClosed += (_, _) => bai04Form = null;
            bai04Form.Show(this);
            return;
        }

        bai04Form.Activate();
    }

    private void btnBai05_Click(object sender, EventArgs e)
    {
        if (bai05Form is null || bai05Form.IsDisposed)
        {
            bai05Form = new Bai05Form();
            bai05Form.FormClosed += (_, _) => bai05Form = null;
            bai05Form.Show(this);
            return;
        }

        bai05Form.Activate();
    }

    private void btnBai06_Click(object sender, EventArgs e)
    {
        if (bai06Form is null || bai06Form.IsDisposed)
        {
            bai06Form = new Bai06Form();
            bai06Form.FormClosed += (_, _) => bai06Form = null;
            bai06Form.Show(this);
            return;
        }

        bai06Form.Activate();
    }
}
