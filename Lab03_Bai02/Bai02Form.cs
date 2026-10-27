using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai02;

public partial class Bai02Form : Form
{
    private const int ListenPort = 8080;

    private Socket? listenerSocket;
    private volatile bool isListening;

    public Bai02Form() => InitializeComponent();

    private void btnListen_Click(object sender, EventArgs e)
    {
        try
        {
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(new IPEndPoint(IPAddress.Any, ListenPort));
            listenerSocket.Listen(10);
        }
        catch (SocketException ex)
        {
            listenerSocket?.Close();
            MessageBox.Show(
                $"Không mở được port {ListenPort}: {ex.Message}\n\nHãy tắt chương trình khác đang dùng port này (ví dụ TCP Server của Bài 03).",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        isListening = true;
        btnListen.Enabled = false;

        string localIp = GetLocalIPv4();
        AppendLog($"Telnet running on {localIp}:{ListenPort}");
        lblStatus.Text = $"Đang lắng nghe. Mở CMD và gõ: telnet {localIp} {ListenPort}";

        new Thread(AcceptLoop) { IsBackground = true }.Start();
    }

    private void AcceptLoop()
    {
        try
        {
            while (isListening)
            {
                Socket clientSocket = listenerSocket!.Accept();
                new Thread(() => HandleClient(clientSocket)) { IsBackground = true }.Start();
            }
        }
        catch (SocketException) when (!isListening) { }
        catch (ObjectDisposedException) { }
    }

    private void HandleClient(Socket clientSocket)
    {
        string clientAddress = clientSocket.RemoteEndPoint?.ToString() ?? "unknown";
        AppendLog($"New client connected: {clientAddress}");

        var buffer = new byte[1024];
        var lineBytes = new List<byte>();
        int bytesToSkip = 0; // bỏ qua các byte thương lượng của Telnet (IAC = 0xFF + 2 byte)

        try
        {
            while (true)
            {
                int bytesReceived = clientSocket.Receive(buffer);
                if (bytesReceived == 0) break; // client đã ngắt kết nối

                for (int i = 0; i < bytesReceived; i++)
                {
                    byte current = buffer[i];

                    if (bytesToSkip > 0) { bytesToSkip--; continue; }
                    if (current == 0xFF) { bytesToSkip = 2; continue; }

                    if (current == (byte)'\n')
                    {
                        string text = Encoding.UTF8.GetString(lineBytes.ToArray()).Trim('\r');
                        lineBytes.Clear();
                        if (text.Length > 0) AppendLog($"{clientAddress}: {text}");
                    }
                    else if (current is 0x08 or 0x7F) // phím Backspace
                    {
                        if (lineBytes.Count > 0) lineBytes.RemoveAt(lineBytes.Count - 1);
                    }
                    else
                    {
                        lineBytes.Add(current);
                    }
                }
            }
        }
        catch (SocketException) { }
        finally
        {
            clientSocket.Close();
            AppendLog($"Client disconnected: {clientAddress}");
        }
    }

    private static string GetLocalIPv4()
    {
        try
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork)?.ToString() ?? "127.0.0.1";
        }
        catch (SocketException)
        {
            return "127.0.0.1";
        }
    }

    private void AppendLog(string message)
    {
        if (IsDisposed) return;

        try
        {
            if (lvCommand.InvokeRequired)
            {
                lvCommand.Invoke(new Action<string>(AppendLog), message);
                return;
            }

            var item = new ListViewItem($"[{DateTime.Now:HH:mm:ss}] {message}");
            lvCommand.Items.Add(item);
            item.EnsureVisible();
        }
        catch (ObjectDisposedException) { }
        catch (InvalidOperationException) { }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        isListening = false;
        listenerSocket?.Close();
        base.OnFormClosing(e);
    }
}
