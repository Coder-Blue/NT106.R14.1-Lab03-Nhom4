using System.Net;
using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4;

public partial class Bai03Server : Form
{
    private TcpListener? listener;
    private TcpClient? clientHienTai;
    private CancellationTokenSource? nguonHuy;

    public Bai03Server() => InitializeComponent();

    private async void btnListen_Click(object sender, EventArgs e)
    {
        if (nguonHuy is not null)
        {
            DungServer();
            return;
        }

        await ChayServerAsync();
    }

    private async Task ChayServerAsync()
    {
        var nguon = new CancellationTokenSource();
        nguonHuy = nguon;
        listener = new TcpListener(IPAddress.Loopback, TcpHelper.CongMacDinh);

        try
        {
            listener.Start();
            btnListen.Text = "Stop";
            CapNhatTrangThai("Server đang lắng nghe tại 127.0.0.1:8080...");
            TcpHelper.GhiNhatKy(rtbNhatKy, "Server started!");

            while (!nguon.IsCancellationRequested)
            {
                clientHienTai = await listener.AcceptTcpClientAsync(nguon.Token);
                TcpHelper.GhiNhatKy(rtbNhatKy, "Connection accepted from " + clientHienTai.Client.RemoteEndPoint);

                try
                {
                    await NhanTinNhanAsync(clientHienTai, nguon.Token);
                }
                finally
                {
                    clientHienTai.Dispose();
                    clientHienTai = null;
                }
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
            TcpHelper.GhiNhatKy(rtbNhatKy, "Error: " + ex.Message);

            if (!IsDisposed)
            {
                MessageBox.Show(this, "Không thể mở Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        finally
        {
            clientHienTai?.Dispose();
            clientHienTai = null;
            listener?.Stop();
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

    private async Task NhanTinNhanAsync(TcpClient client, CancellationToken token)
    {
        try
        {
            using var stream = client.GetStream();
            using var reader = TcpHelper.TaoBoDoc(stream);
            using var writer = TcpHelper.TaoBoGhi(stream);

            while (!token.IsCancellationRequested)
            {
                var dong = await reader.ReadLineAsync(token);
                if (dong is null)
                {
                    TcpHelper.GhiNhatKy(rtbNhatKy, "Client disconnected.");
                    return;
                }

                if (dong.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    TcpHelper.GhiNhatKy(rtbNhatKy, "Client disconnected.");
                    await writer.WriteLineAsync("Tạm biệt!");
                    return;
                }

                TcpHelper.GhiNhatKy(rtbNhatKy, "From client: " + dong);
                await writer.WriteLineAsync("Đã nhận: " + dong);
            }
        }
        catch (OperationCanceledException) when (token.IsCancellationRequested)
        {
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            if (!token.IsCancellationRequested)
            {
                TcpHelper.GhiNhatKy(rtbNhatKy, "Client disconnected.");
            }
        }
    }

    private void DungServer()
    {
        if (nguonHuy is null)
        {
            return;
        }

        btnListen.Text = "Đang dừng...";
        nguonHuy.Cancel();
        listener?.Stop();
        clientHienTai?.Close();
    }

    private void CapNhatTrangThai(string noiDung)
    {
        if (!IsDisposed)
        {
            lblTrangThai.Text = noiDung;
        }
    }

    private void Bai03Server_FormClosing(object sender, FormClosingEventArgs e) => DungServer();
}
