using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai01;

public partial class UdpClientForm : Form
{
    public UdpClientForm()
    {
        InitializeComponent();
        txtDiaChi.Text = "127.0.0.1";
        txtCong.Text = UdpHelper.CongMacDinh.ToString();
        CapNhatTrangThai("Sẵn sàng gửi.");
    }

    private void btnGui_Click(object sender, EventArgs e)
    {
        var (hopLe, diemCuoi) = UdpHelper.DocDiemCuoi(txtDiaChi.Text, txtCong.Text);
        if (!hopLe || diemCuoi is null)
        {
            MessageBox.Show(this, "Địa chỉ IP hoặc cổng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var noiDung = txtNoiDung.Text;
        if (string.IsNullOrWhiteSpace(noiDung))
        {
            MessageBox.Show(this, "Hãy nhập thông điệp cần gửi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNoiDung.Focus();
            return;
        }

        try
        {
            using var udpClient = new UdpClient();
            var duLieu = Encoding.UTF8.GetBytes(noiDung);
            udpClient.Send(duLieu, duLieu.Length, diemCuoi);
            CapNhatTrangThai($"Đã gửi {duLieu.Length} byte tới {diemCuoi} lúc {DateTime.Now:HH:mm:ss}.");
        }
        catch (SocketException ex)
        {
            MessageBox.Show(this, "Không thể gửi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CapNhatTrangThai(string noiDung)
    {
        if (!IsDisposed)
        {
            lblTrangThai.Text = noiDung;
        }
    }
}
