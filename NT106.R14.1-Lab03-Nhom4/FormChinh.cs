using NT106.R14._1_Lab03_Nhom4.Bai03;

namespace NT106.R14._1_Lab03_Nhom4;

public partial class FormChinh : Form
{
    private Bai03Form? bai03Form;

    public FormChinh() => InitializeComponent();

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
}
