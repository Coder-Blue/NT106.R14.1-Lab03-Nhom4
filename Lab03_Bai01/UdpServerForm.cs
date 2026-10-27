using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai01;

public partial class UdpServerForm : Form
{
    private Socket? serverSocket;
    private CancellationTokenSource? nguonHuy;

    public UdpServerForm()
    {
        InitializeComponent();
        txtCong.Text = UdpHelper.CongMacDinh.ToString();
        CapNhatTrangThai("Chưa lắng nghe. Bấm Listen để bắt đầu.");
    }

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
        if (!UdpHelper.DocCong(txtCong.Text, out var port))
        {
            MessageBox.Show(this, "Port không hợp lệ (1-65535).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCong.Focus();
            return;
        }

        var nguon = new CancellationTokenSource();
        nguonHuy = nguon;
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        try
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            btnListen.Text = "Stop";
            txtCong.Enabled = false;
            UdpHelper.GhiNhatKy(rtbNhatKy, "UDP server started on port " + port);
            CapNhatTrangThai();

            await NhanDuLieuAsync(serverSocket, nguon.Token);
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
            UdpHelper.GhiNhatKy(rtbNhatKy, "Lỗi: " + ex.Message);

            if (!IsDisposed)
            {
                MessageBox.Show(
                    this,
                    $"Không mở được port {port}: {ex.Message}\n\n" +
                    "Hãy tắt chương trình khác đang dùng port này.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        finally
        {
            serverSocket?.Close();
            serverSocket = null;
            nguonHuy = null;
            nguon.Dispose();

            if (!IsDisposed)
            {
                btnListen.Text = "Listen";
                txtCong.Enabled = true;
                CapNhatTrangThai("Server đã dừng.");
            }
        }
    }

    private async Task NhanDuLieuAsync(Socket socket, CancellationToken token)
    {
        var buffer = new byte[65535];
        EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        while (!token.IsCancellationRequested)
        {
            var ketQua = await socket.ReceiveFromAsync(buffer.AsMemory(), SocketFlags.None, remoteEndPoint, token);
            if (ketQua.ReceivedBytes == 0)
            {
                continue;
            }

            var noiDung = Encoding.UTF8.GetString(buffer, 0, ketQua.ReceivedBytes);
            var diaChi = (IPEndPoint)ketQua.RemoteEndPoint;
            UdpHelper.GhiNhatKy(rtbNhatKy, $"{diaChi.Address}:{diaChi.Port}: {noiDung}");
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

        var diaChi = UdpHelper.LayIpv4();
        lblTrangThai.Text = $"Đang lắng nghe tại {diaChi}:{txtCong.Text}. Mở UDP Client để gửi thông điệp.";
    }

    private void DungServer()
    {
        if (nguonHuy is null)
        {
            return;
        }

        btnListen.Text = "Đang dừng...";
        nguonHuy.Cancel();
        serverSocket?.Close();
    }

    private void UdpServerForm_FormClosing(object sender, FormClosingEventArgs e) => DungServer();
}
