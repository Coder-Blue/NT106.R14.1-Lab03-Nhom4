using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai01;

public partial class UdpClientForm : Form
{
    public UdpClientForm() => InitializeComponent();

    private void btnSend_Click(object sender, EventArgs e)
    {
        if (!IPAddress.TryParse(txtRemoteHost.Text.Trim(), out IPAddress? ipAddress))
        {
            MessageBox.Show("IP không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(txtPort.Text, out int port) || port is < 1 or > 65535)
        {
            MessageBox.Show("Port không hợp lệ (1-65535).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtMessage.Text))
        {
            MessageBox.Show("Hãy nhập thông điệp cần gửi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var udpClient = new UdpClient();
        byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text);
        udpClient.Send(data, data.Length, new IPEndPoint(ipAddress, port));
    }
}
