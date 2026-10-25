using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4.Bai06;

public partial class Bai06Client : Form
{
    private TcpClient? tcpClient;
    private StreamReader? boDoc;
    private StreamWriter? boGhi;
    private CancellationTokenSource? nguonHuy;
    private string? tenCuaToi;

    public Bai06Client()
    {
        InitializeComponent();
        txtDiaChi.Text = ChatHelper.DiaChiMacDinh;
        txtCong.Text = ChatHelper.CongMacDinh.ToString();
        cmbNguoiNhan.Items.Add("Mọi người");
        cmbNguoiNhan.SelectedIndex = 0;
        CapNhatNut();
        CapNhatTrangThai("Chưa kết nối.");
    }

    private async void btnKetNoi_Click(object sender, EventArgs e)
    {
        var ten = ChatHelper.ChuanHoaTen(txtTenNguoiDung.Text);
        if (!ChatHelper.TenHopLe(ten))
        {
            MessageBox.Show(this, "Tên phải có từ 1 đến 30 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenNguoiDung.Focus();
            return;
        }

        var (hopLe, diemCuoi) = ChatHelper.DocDiemCuoi(txtDiaChi.Text, txtCong.Text);
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
            boDoc = ChatHelper.TaoBoDoc(stream);
            boGhi = ChatHelper.TaoBoGhi(stream);
            nguonHuy = new CancellationTokenSource();

            txtTenNguoiDung.Enabled = false;
            txtDiaChi.Enabled = false;
            txtCong.Enabled = false;
            btnNgatKetNoi.Enabled = true;
            CapNhatTrangThai("Đã kết nối, đang tham gia phòng chat...");
            ChatHelper.GhiChat(rtbChat, $"[Hệ thống] Đã kết nối tới {diemCuoi}.");

            await boGhi.WriteLineAsync("TEN\t" + ten);
            _ = DocDuLieuAsync(nguonHuy.Token);
        }
        catch (Exception ex)
        {
            ChatHelper.GhiChat(rtbChat, "[Hệ thống] Không thể kết nối: " + ex.Message);
            NgatKetNoi();
            CapNhatTrangThai("Kết nối thất bại.");
        }
    }

    private async Task DocDuLieuAsync(CancellationToken token)
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

                if (dong.StartsWith("TEN_OK\t"))
                {
                    tenCuaToi = dong[7..];
                    Text = "Chat - " + tenCuaToi;
                    ChatHelper.GhiChat(rtbChat, $"[Hệ thống] Xin chào {tenCuaToi}!");
                    CapNhatTrangThai($"Đã tham gia phòng chat với tên {tenCuaToi}.");
                    CapNhatNut();
                    continue;
                }

                if (dong.StartsWith("LOI\t"))
                {
                    var thongBao = dong[4..];
                    ChatHelper.GhiChat(rtbChat, "[Hệ thống] " + thongBao);
                    MessageBox.Show(this, thongBao, "Không thể tham gia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NgatKetNoi();
                    return;
                }

                if (dong.StartsWith("MSG\t"))
                {
                    ChatHelper.GhiChat(rtbChat, dong[4..]);
                    continue;
                }

                if (dong.StartsWith("USERS\t"))
                {
                    CapNhatNguoiDung(dong[6..]);
                }
            }
        }
        catch (OperationCanceledException) when (token.IsCancellationRequested)
        {
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            if (!token.IsCancellationRequested)
            {
                ChatHelper.GhiChat(rtbChat, "[Hệ thống] Mất kết nối: " + ex.Message);
            }
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                ChatHelper.GhiChat(rtbChat, "[Hệ thống] Server đã đóng kết nối.");
                NgatKetNoi();
            }
        }
    }

    private void CapNhatNguoiDung(string danhSach)
    {
        var dsTen = danhSach
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .ToList();

        lstNguoiDung.BeginUpdate();
        lstNguoiDung.Items.Clear();
        foreach (var ten in dsTen)
        {
            lstNguoiDung.Items.Add(ten == tenCuaToi ? ten + " (bạn)" : ten);
        }
        lstNguoiDung.EndUpdate();

        var nguoiNhanDangChon = cmbNguoiNhan.SelectedItem as string;
        cmbNguoiNhan.BeginUpdate();
        cmbNguoiNhan.Items.Clear();
        cmbNguoiNhan.Items.Add("Mọi người");
        foreach (var ten in dsTen.Where(ten => ten != tenCuaToi))
        {
            cmbNguoiNhan.Items.Add(ten);
        }
        cmbNguoiNhan.EndUpdate();

        if (nguoiNhanDangChon is not null && cmbNguoiNhan.Items.Contains(nguoiNhanDangChon))
        {
            cmbNguoiNhan.SelectedItem = nguoiNhanDangChon;
        }
        else if (cmbNguoiNhan.Items.Count > 0)
        {
            cmbNguoiNhan.SelectedIndex = 0;
        }

        lblTongNguoi.Text = $"{dsTen.Count} người trong phòng";
    }

    private async void btnGui_Click(object sender, EventArgs e)
    {
        if (boGhi is null || tenCuaToi is null)
        {
            CapNhatTrangThai("Chưa kết nối tới Server.");
            return;
        }

        var noiDung = ChatHelper.ChuanHoaTinNhan(txtNoiDung.Text);
        if (noiDung.Length == 0)
        {
            txtNoiDung.Focus();
            return;
        }

        var nguoiNhan = cmbNguoiNhan.SelectedItem as string;
        var dong = string.IsNullOrEmpty(nguoiNhan) || nguoiNhan == "Mọi người"
            ? "PUBLIC\t" + noiDung
            : $"PRIVATE\t{nguoiNhan}\t{noiDung}";

        try
        {
            await boGhi.WriteLineAsync(dong);
            txtNoiDung.Clear();
            txtNoiDung.Focus();
            CapNhatTrangThai("Đã gửi tin nhắn.");
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            ChatHelper.GhiChat(rtbChat, "[Hệ thống] Gửi tin nhắn thất bại: " + ex.Message);
            NgatKetNoi();
        }
    }

    private async void btnNgatKetNoi_Click(object sender, EventArgs e)
    {
        if (boGhi is not null)
        {
            try
            {
                await boGhi.WriteLineAsync("QUIT");
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
        tenCuaToi = null;

        if (IsDisposed)
        {
            return;
        }

        lstNguoiDung.Items.Clear();
        cmbNguoiNhan.Items.Clear();
        cmbNguoiNhan.Items.Add("Mọi người");
        cmbNguoiNhan.SelectedIndex = 0;
        lblTongNguoi.Text = "0 người trong phòng";
        txtTenNguoiDung.Enabled = true;
        txtDiaChi.Enabled = true;
        txtCong.Enabled = true;
        btnKetNoi.Enabled = true;
        Text = "TCP Client - Bài 06";
        CapNhatNut();
        CapNhatTrangThai(daKetNoi ? "Đã ngắt kết nối." : "Chưa kết nối.");
    }

    private void CapNhatNut()
    {
        var daVaoPhong = tcpClient is not null && tenCuaToi is not null;

        txtNoiDung.Enabled = daVaoPhong;
        cmbNguoiNhan.Enabled = daVaoPhong;
        btnGui.Enabled = daVaoPhong;
        btnNgatKetNoi.Enabled = tcpClient is not null;
    }

    private void CapNhatTrangThai(string noiDung)
    {
        if (!IsDisposed)
        {
            lblTrangThai.Text = noiDung;
        }
    }

    private void Bai06Client_FormClosing(object sender, FormClosingEventArgs e) => NgatKetNoi();
}
