using System.Net;
using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4.Bai06;

public partial class Bai06Server : Form
{
    private sealed class KetNoiClient
    {
        public readonly TcpClient Client;
        public readonly StreamWriter Ghi;
        public readonly SemaphoreSlim KhoaGui = new(1, 1);
        public readonly string DiaChi;
        public string Ten = "";

        public KetNoiClient(TcpClient client, StreamWriter ghi)
        {
            Client = client;
            Ghi = ghi;
            DiaChi = client.Client.RemoteEndPoint?.ToString() ?? "?";
        }
    }

    private readonly object khoa = new();
    private readonly Dictionary<string, KetNoiClient> dsNguoiDung = new(StringComparer.OrdinalIgnoreCase);

    private TcpListener? listener;
    private CancellationTokenSource? nguonHuy;

    public Bai06Server() => InitializeComponent();

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
        listener = new TcpListener(IPAddress.Loopback, ChatHelper.CongMacDinh);

        try
        {
            listener.Start();
            btnListen.Text = "Stop";
            CapNhatTrangThai($"Server đang lắng nghe tại 127.0.0.1:{ChatHelper.CongMacDinh}...");
            ChatHelper.GhiNhatKy(rtbNhatKy, "Server started!");

            while (!nguon.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync(nguon.Token);
                _ = XuLyClientAsync(client, nguon.Token);
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
            ChatHelper.GhiNhatKy(rtbNhatKy, "Error: " + ex.Message);

            if (!IsDisposed)
            {
                MessageBox.Show(this, "Không thể mở Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        finally
        {
            DongTatCaClient();
            listener?.Stop();
            listener = null;
            nguonHuy = null;
            nguon.Dispose();
            CapNhatGiaoDienNguoiDung();

            if (!IsDisposed)
            {
                btnListen.Text = "Listen";
                CapNhatTrangThai("Server đã dừng.");
            }
        }
    }

    private async Task XuLyClientAsync(TcpClient client, CancellationToken token)
    {
        StreamReader? boDoc = null;
        StreamWriter? boGhi = null;
        KetNoiClient? ketNoi = null;
        var daDangKy = false;

        try
        {
            var stream = client.GetStream();
            boDoc = ChatHelper.TaoBoDoc(stream);
            boGhi = ChatHelper.TaoBoGhi(stream);
            ketNoi = new KetNoiClient(client, boGhi);

            while (!token.IsCancellationRequested)
            {
                var dong = await boDoc.ReadLineAsync(token);
                if (dong is null)
                {
                    break;
                }

                if (!daDangKy)
                {
                    var phan = dong.Split('\t');
                    if (phan.Length < 2 || phan[0] != "TEN")
                    {
                        await GuiDongAsync(ketNoi, "LOI\tVui lòng gửi tên người dùng trước.");
                        break;
                    }

                    var ten = ChatHelper.ChuanHoaTen(phan[1]);
                    if (!ChatHelper.TenHopLe(ten))
                    {
                        await GuiDongAsync(ketNoi, "LOI\tTên phải có từ 1 đến 30 ký tự.");
                        break;
                    }

                    var trungTen = false;
                    lock (khoa)
                    {
                        if (dsNguoiDung.ContainsKey(ten))
                        {
                            trungTen = true;
                        }
                        else
                        {
                            ketNoi.Ten = ten;
                            dsNguoiDung[ten] = ketNoi;
                        }
                    }

                    if (trungTen)
                    {
                        await GuiDongAsync(ketNoi, "LOI\tTên này đã có người sử dụng. Vui lòng chọn tên khác.");
                        break;
                    }

                    daDangKy = true;
                    CapNhatGiaoDienNguoiDung();
                    ChatHelper.GhiNhatKy(rtbNhatKy, $"Client {ten} đã kết nối từ {ketNoi.DiaChi}.");
                    await GuiDongAsync(ketNoi, "TEN_OK\t" + ten);
                    await GuiDanhSachNguoiDungChoTatCaAsync();
                    await GuiDongChoTatCaAsync($"[Hệ thống] {ten} đã tham gia phòng chat.");
                    continue;
                }

                await XuLyLenhAsync(dong, ketNoi);
            }
        }
        catch (OperationCanceledException) when (token.IsCancellationRequested)
        {
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
        }
        finally
        {
            if (daDangKy && ketNoi is not null)
            {
                var ten = ketNoi.Ten;
                lock (khoa)
                {
                    dsNguoiDung.Remove(ten);
                }

                CapNhatGiaoDienNguoiDung();
                ChatHelper.GhiNhatKy(rtbNhatKy, $"{ten} đã rời phòng chat.");
                await GuiDanhSachNguoiDungChoTatCaAsync();
                await GuiDongChoTatCaAsync($"[Hệ thống] {ten} đã rời phòng chat.");
            }

            boDoc?.Dispose();
            boGhi?.Dispose();
            client.Dispose();
        }
    }

    private async Task XuLyLenhAsync(string dong, KetNoiClient ketNoi)
    {
        var phan = dong.Split('\t');
        if (phan.Length == 0)
        {
            return;
        }

        switch (phan[0])
        {
            case "PUBLIC" when phan.Length >= 2:
                {
                    var noiDung = ChatHelper.ChuanHoaTinNhan(phan[1]);
                    if (noiDung.Length == 0)
                    {
                        return;
                    }

                    ChatHelper.GhiNhatKy(rtbNhatKy, $"{ketNoi.Ten}: {noiDung}");
                    await GuiDongChoTatCaAsync($"[{ChatHelper.GioHienTai()}] {ketNoi.Ten}: {noiDung}");
                    break;
                }

            case "PRIVATE" when phan.Length >= 3:
                {
                    var nguoiNhan = ChatHelper.ChuanHoaTen(phan[1]);
                    var noiDung = ChatHelper.ChuanHoaTinNhan(phan[2]);
                    if (noiDung.Length == 0)
                    {
                        return;
                    }

                    KetNoiClient? dich;
                    lock (khoa)
                    {
                        dsNguoiDung.TryGetValue(nguoiNhan, out dich);
                    }

                    if (dich is null)
                    {
                        await GuiDongAsync(
                            ketNoi,
                            $"MSG\t[Hệ thống] Không tìm thấy người dùng \"{nguoiNhan}\".");
                        return;
                    }

                    ChatHelper.GhiNhatKy(rtbNhatKy, $"[Riêng] {ketNoi.Ten} -> {nguoiNhan}: {noiDung}");
                    await GuiDongAsync(
                        ketNoi,
                        $"MSG\t[{ChatHelper.GioHienTai()}] [Riêng] Bạn -> {nguoiNhan}: {noiDung}");
                    await GuiDongAsync(
                        dich,
                        $"MSG\t[{ChatHelper.GioHienTai()}] [Riêng] {ketNoi.Ten} -> bạn: {noiDung}");
                    break;
                }

            case "FILE" when phan.Length >= 4:
                {
                    var nguoiNhan = ChatHelper.ChuanHoaTen(phan[1]);
                    var tenTep = ChatHelper.ChuanHoaTen(Path.GetFileName(phan[2]));
                    var duLieu = phan[3];

                    if (!ChatHelper.LaTepChoPhep(tenTep))
                    {
                        await GuiDongAsync(
                            ketNoi,
                            "MSG\t[Hệ thống] Chỉ hỗ trợ ảnh .jpg, .jpeg, .png và tệp .txt.");
                        return;
                    }

                    if (duLieu.Length > ChatHelper.KichThuocBase64ToiDa)
                    {
                        await GuiDongAsync(
                            ketNoi,
                            "MSG\t[Hệ thống] Tệp quá lớn. Giới hạn 5 MB.");
                        return;
                    }

                    if (nguoiNhan.Length == 0 || nguoiNhan == "*")
                    {
                        ChatHelper.GhiNhatKy(rtbNhatKy, $"{ketNoi.Ten} gửi tệp: {tenTep}");
                        await GuiTepChoTatCaAsync($"FILE\t{ketNoi.Ten}\t{tenTep}\t{duLieu}\tPUBLIC");
                        return;
                    }

                    KetNoiClient? dich;
                    lock (khoa)
                    {
                        dsNguoiDung.TryGetValue(nguoiNhan, out dich);
                    }

                    if (dich is null)
                    {
                        await GuiDongAsync(
                            ketNoi,
                            $"MSG\t[Hệ thống] Không tìm thấy người dùng \"{nguoiNhan}\".");
                        return;
                    }

                    ChatHelper.GhiNhatKy(
                        rtbNhatKy,
                        $"[Riêng] {ketNoi.Ten} -> {nguoiNhan} gửi tệp: {tenTep}");
                    await GuiDongAsync(
                        ketNoi,
                        $"FILE\t{ketNoi.Ten}\t{tenTep}\t{duLieu}\tPRIVATE");
                    await GuiDongAsync(
                        dich,
                        $"FILE\t{ketNoi.Ten}\t{tenTep}\t{duLieu}\tPRIVATE");
                    break;
                }

            case "QUIT":
                ketNoi.Client.Close();
                break;
        }
    }

    private async Task GuiDongAsync(KetNoiClient ketNoi, string dong)
    {
        await ketNoi.KhoaGui.WaitAsync();
        try
        {
            await ketNoi.Ghi.WriteLineAsync(dong);
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
        }
        finally
        {
            ketNoi.KhoaGui.Release();
        }
    }

    private async Task GuiDongChoTatCaAsync(string noiDung)
    {
        List<KetNoiClient> danhSach;
        lock (khoa)
        {
            danhSach = dsNguoiDung.Values.ToList();
        }

        foreach (var ketNoi in danhSach)
        {
            await GuiDongAsync(ketNoi, "MSG\t" + noiDung);
        }
    }

    private async Task GuiTepChoTatCaAsync(string dong)
    {
        List<KetNoiClient> danhSach;
        lock (khoa)
        {
            danhSach = dsNguoiDung.Values.ToList();
        }

        foreach (var ketNoi in danhSach)
        {
            await GuiDongAsync(ketNoi, dong);
        }
    }

    private async Task GuiDanhSachNguoiDungChoTatCaAsync()
    {
        string danhSachTen;
        lock (khoa)
        {
            danhSachTen = string.Join(",", dsNguoiDung.Keys.OrderBy(ten => ten, StringComparer.OrdinalIgnoreCase));
        }

        List<KetNoiClient> danhSach;
        lock (khoa)
        {
            danhSach = dsNguoiDung.Values.ToList();
        }

        foreach (var ketNoi in danhSach)
        {
            await GuiDongAsync(ketNoi, "USERS\t" + danhSachTen);
        }
    }

    private void CapNhatGiaoDienNguoiDung()
    {
        if (InvokeRequired)
        {
            BeginInvoke(CapNhatGiaoDienNguoiDung);
            return;
        }

        if (IsDisposed)
        {
            return;
        }

        List<(string Ten, string DiaChi)> danhSach;
        lock (khoa)
        {
            danhSach = dsNguoiDung.Values
                .Select(ketNoi => (ketNoi.Ten, ketNoi.DiaChi))
                .OrderBy(item => item.Ten, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        lvNguoiDung.BeginUpdate();
        lvNguoiDung.Items.Clear();
        foreach (var (ten, diaChi) in danhSach)
        {
            var dong = new ListViewItem(ten);
            dong.SubItems.Add(diaChi);
            lvNguoiDung.Items.Add(dong);
        }
        lvNguoiDung.EndUpdate();

        lblTongClient.Text = $"{danhSach.Count} người trong phòng";
        lblSoClient.Text = $"{danhSach.Count} client đang kết nối";
    }

    private void CapNhatTrangThai(string noiDung)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => CapNhatTrangThai(noiDung));
            return;
        }

        if (!IsDisposed)
        {
            lblTrangThai.Text = noiDung;
        }
    }

    private void DongTatCaClient()
    {
        List<KetNoiClient> danhSach;
        lock (khoa)
        {
            danhSach = dsNguoiDung.Values.ToList();
            dsNguoiDung.Clear();
        }

        foreach (var ketNoi in danhSach)
        {
            try
            {
                ketNoi.Client.Close();
            }
            catch
            {
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
        DongTatCaClient();
        CapNhatGiaoDienNguoiDung();
    }

    private void Bai06Server_FormClosing(object sender, FormClosingEventArgs e) => DungServer();
}
