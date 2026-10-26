using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai01;

public partial class UdpServerForm : Form
{
    private UdpClient? udpServer;
    private volatile bool isListening;

    public UdpServerForm() => InitializeComponent();

    private void btnListen_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtPort.Text, out int port) || port is < 1 or > 65535)
        {
            MessageBox.Show("Port không hợp lệ (1-65535).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            udpServer = new UdpClient(port);
        }
        catch (SocketException ex)
        {
            MessageBox.Show($"Không mở được port {port}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        isListening = true;
        new Thread(ListenLoop) { IsBackground = true }.Start();

        btnListen.Enabled = false;
        txtPort.Enabled = false;
        AppendMessage($"Đang lắng nghe tại port {port}...");
    }

    private void ListenLoop()
    {
        try
        {
            while (isListening)
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receivedBytes = udpServer!.Receive(ref remoteEndPoint);
                string message = Encoding.UTF8.GetString(receivedBytes);
                AppendMessage($"{remoteEndPoint.Address}:{message}");
            }
        }
        catch (SocketException) when (!isListening) { }
        catch (ObjectDisposedException) { }
    }

    private void AppendMessage(string message)
    {
        if (lvMessages.InvokeRequired)
        {
            lvMessages.Invoke(new Action<string>(AppendMessage), message);
            return;
        }

        lvMessages.Items.Add(new ListViewItem(message));
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        isListening = false;
        udpServer?.Close();
        base.OnFormClosing(e);
    }
}
