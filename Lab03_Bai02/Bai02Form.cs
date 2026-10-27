using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai02;

public partial class Bai02Form : Form
{
    private readonly object khoa = new();
    private readonly List<Socket> dsClient = new();

    private Socket? listener;
    private CancellationTokenSource? nguonHuy;

    public Bai02Form()
    {
        InitializeComponent();
        CapNhatTrangThai("Chưa lắng nghe. Bấm Listen để bắt đầu.");
    }

    private async void btnListen_Click(object sender, EventArgs e)
    {
        if (nguonHuy is not null)
        {
            DungLangNghe();
            return;
        }

        await ChayLangNgheAsync();
    }

    private async Task ChayLangNgheAsync()
    {
        var nguon = new CancellationTokenSource();
        nguonHuy = nguon;
        listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(new IPEndPoint(IPAddress.Any, TelnetHelper.CongMacDinh));
            listener.Listen(10);
            btnListen.Text = "Stop";
            TelnetHelper.GhiNhatKy(rtbNhatKy, "Telnet listener started on port " + TelnetHelper.CongMacDinh);
            CapNhatTrangThai();

            while (!nguon.IsCancellationRequested)
            {
                var client = await listener.AcceptAsync(nguon.Token);
                lock (khoa)
                {
                    dsClient.Add(client);
                }

                _ = XuLyClientAsync(client, nguon.Token);
                CapNhatSoClient();
            }
        }
        catch (OperationCanceledException) when (nguon.IsCancellationRequested)
        {
        }
        catch (ObjectDisposedException) when (nguon.IsCancellationRequested)
        {
        }
        catch (SocketException) when (nguon.IsCancellationRequested)
        {
        }
        catch (Exception ex)
        {
            TelnetHelper.GhiNhatKy(rtbNhatKy, "Lỗi: " + ex.Message);

            if (!IsDisposed)
            {
                MessageBox.Show(
                    this,
                    $"Không mở được port {TelnetHelper.CongMacDinh}: {ex.Message}\n\n" +
                    "Hãy tắt chương trình khác đang dùng port này (ví dụ TCP Server của Bài 03).",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        finally
        {
            DongTatCaClient();
            listener?.Close();
            listener = null;
            nguonHuy = null;
            nguon.Dispose();

            if (!IsDisposed)
            {
                btnListen.Text = "Listen";
                CapNhatTrangThai("Server đã dừng.");
            }
        }
    }

    private async Task XuLyClientAsync(Socket clientSocket, CancellationToken token)
    {
        var diaChi = clientSocket.RemoteEndPoint?.ToString() ?? "unknown";
        TelnetHelper.GhiNhatKy(rtbNhatKy, $"New client connected: {diaChi}");

        var buffer = new byte[1024];
        var lineBytes = new List<byte>();
        var bytesToSkip = 0; // bỏ qua các byte thương lượng Telnet (IAC + 2 byte)

        try
        {
            while (!token.IsCancellationRequested)
            {
                var bytesReceived = await clientSocket.ReceiveAsync(buffer.AsMemory(), SocketFlags.None, token);
                if (bytesReceived == 0)
                {
                    break;
                }

                for (var i = 0; i < bytesReceived; i++)
                {
                    var current = buffer[i];

                    if (bytesToSkip > 0)
                    {
                        bytesToSkip--;
                        continue;
                    }

                    if (current == 0xFF)
                    {
                        bytesToSkip = 2;
                        continue;
                    }

                    if (current == (byte)'\n')
                    {
                        var text = Encoding.UTF8.GetString(lineBytes.ToArray()).Trim('\r');
                        lineBytes.Clear();
                        if (text.Length > 0)
                        {
                            TelnetHelper.GhiNhatKy(rtbNhatKy, $"{diaChi}: {text}");
                        }
                    }
                    else if (current is 0x08 or 0x7F)
                    {
                        if (lineBytes.Count > 0)
                        {
                            lineBytes.RemoveAt(lineBytes.Count - 1);
                        }
                    }
                    else
                    {
                        lineBytes.Add(current);
                    }
                }
            }
        }
        catch (OperationCanceledException) when (token.IsCancellationRequested)
        {
        }
        catch (Exception ex) when (ex is SocketException or ObjectDisposedException)
        {
            if (!token.IsCancellationRequested)
            {
                TelnetHelper.GhiNhatKy(rtbNhatKy, $"Mất kết nối với {diaChi}: {ex.Message}");
            }
        }
        finally
        {
            lock (khoa)
            {
                dsClient.Remove(clientSocket);
            }

            clientSocket.Close();
            TelnetHelper.GhiNhatKy(rtbNhatKy, $"Client disconnected: {diaChi}");
            CapNhatSoClient();
        }
    }

    private void CapNhatSoClient()
    {
        if (InvokeRequired)
        {
            BeginInvoke(CapNhatSoClient);
            return;
        }

        if (!IsDisposed)
        {
            CapNhatTrangThai();
        }
    }

    private void CapNhatTrangThai(string? thongBao = null)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => CapNhatTrangThai(thongBao));
            return;
        }

        if (IsDisposed)
        {
            return;
        }

        if (thongBao is not null)
        {
            lblTrangThai.Text = thongBao;
            return;
        }

        int soClient;
        lock (khoa)
        {
            soClient = dsClient.Count;
        }

        var diaChi = TelnetHelper.LayIpv4();
        lblTrangThai.Text =
            $"Đang lắng nghe tại {diaChi}:{TelnetHelper.CongMacDinh} - {soClient} client. " +
            $"Mở CMD và gõ: telnet {diaChi} {TelnetHelper.CongMacDinh}";
    }

    private void DongTatCaClient()
    {
        List<Socket> danhSach;
        lock (khoa)
        {
            danhSach = dsClient.ToList();
            dsClient.Clear();
        }

        foreach (var client in danhSach)
        {
            try
            {
                client.Close();
            }
            catch
            {
            }
        }
    }

    private void DungLangNghe()
    {
        if (nguonHuy is null)
        {
            return;
        }

        btnListen.Text = "Đang dừng...";
        nguonHuy.Cancel();
        listener?.Close();
        DongTatCaClient();
        CapNhatSoClient();
    }

    private void Bai02Form_FormClosing(object sender, FormClosingEventArgs e) => DungLangNghe();
}
