using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4.Bai03;

public partial class Bai03Client : Form
{
    private TcpClient? tcpClient;
    private StreamReader? boDoc;
    private StreamWriter? boGhi;
    private CancellationTokenSource? nguonHuy;

    public Bai03Client()
    {
        InitializeComponent();
        txtDiaChi.Text = TcpHelper.DiaChiMacDinh;
        txtCong.Text = TcpHelper.CongMacDinh.ToString();
        CapNhatTrangThai("Chưa kết nối.");
    }

    private async void btnKetNoi_Click(object sender, EventArgs e)
    {
        var (hopLe, diemCuoi) = TcpHelper.DocDiemCuoi(txtDiaChi.Text, txtCong.Text);
        if (!hopLe || diemCuoi is null)
        {
            MessageBox.Show(this, "Địa chỉ IP hoặc cổng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnKetNoi.Enabled = false;
        CapNhatTrangThai("Đang kết nối...");

        try
        {
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(diemCuoi.Address, diemCuoi.Port);

            var stream = tcpClient.GetStream();
            boDoc = TcpHelper.TaoBoDoc(stream);
            boGhi = TcpHelper.TaoBoGhi(stream);
            nguonHuy = new CancellationTokenSource();

            txtDiaChi.Enabled = false;
            txtCong.Enabled = false;
            btnGui.Enabled = true;
            btnNgatKetNoi.Enabled = true;
            CapNhatTrangThai("Đã kết nối tới " + diemCuoi + ".");
            TcpHelper.GhiNhatKy(rtbNhatKy, "Đã kết nối tới " + diemCuoi + ".");
            txtNoiDung.Focus();

            _ = DocPhanHoiAsync(nguonHuy.Token);
        }
        catch (Exception ex)
        {
            TcpHelper.GhiNhatKy(rtbNhatKy, "Không thể kết nối: " + ex.Message);
            NgatKetNoi();
            CapNhatTrangThai("Kết nối thất bại.");
        }
    }

    private async Task DocPhanHoiAsync(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested && boDoc is not null)
            {
                var dong = await boDoc.ReadLineAsync(token);
                if (dong is null)
                {
                    break;
                }

                TcpHelper.GhiNhatKy(rtbNhatKy, "Server: " + dong);
            }
        }
        catch (OperationCanceledException) when (token.IsCancellationRequested)
        {
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            if (!token.IsCancellationRequested)
            {
                TcpHelper.GhiNhatKy(rtbNhatKy, "Mất kết nối: " + ex.Message);
            }
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                TcpHelper.GhiNhatKy(rtbNhatKy, "Server đã đóng kết nối.");
                NgatKetNoi();
            }
        }
    }

    private async void btnGui_Click(object sender, EventArgs e)
    {
        var noiDung = txtNoiDung.Text.Trim();
        if (noiDung.Length == 0 || boGhi is null)
        {
            txtNoiDung.Focus();
            return;
        }

        btnGui.Enabled = false;

        try
        {
            await boGhi.WriteLineAsync(noiDung);
            TcpHelper.GhiNhatKy(rtbNhatKy, "Bạn: " + noiDung);
            CapNhatTrangThai("Đã gửi lúc " + DateTime.Now.ToString("HH:mm:ss") + ".");
            txtNoiDung.Clear();
            txtNoiDung.Focus();
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            TcpHelper.GhiNhatKy(rtbNhatKy, "Gửi thất bại: " + ex.Message);
            NgatKetNoi();
        }
        finally
        {
            if (!IsDisposed && boGhi is not null)
            {
                btnGui.Enabled = true;
            }
        }
    }

    private async void btnNgatKetNoi_Click(object sender, EventArgs e)
    {
        if (boGhi is not null)
        {
            try
            {
                await boGhi.WriteLineAsync("quit");
            }
            catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
            {
            }
        }

        NgatKetNoi();
    }

    private void NgatKetNoi()
    {
        var daKetNoi = tcpClient is not null;

        nguonHuy?.Cancel();
        boGhi?.Dispose();
        boDoc?.Dispose();
        tcpClient?.Close();

        boGhi = null;
        boDoc = null;
        tcpClient = null;
        nguonHuy = null;

        if (IsDisposed)
        {
            return;
        }

        btnKetNoi.Enabled = true;
        btnGui.Enabled = false;
        btnNgatKetNoi.Enabled = false;
        txtDiaChi.Enabled = true;
        txtCong.Enabled = true;
        CapNhatTrangThai(daKetNoi ? "Đã ngắt kết nối." : "Chưa kết nối.");
    }

    private void CapNhatTrangThai(string noiDung)
    {
        if (!IsDisposed)
        {
            lblTrangThai.Text = noiDung;
        }
    }

    private void Bai03Client_FormClosing(object sender, FormClosingEventArgs e) => NgatKetNoi();
}
