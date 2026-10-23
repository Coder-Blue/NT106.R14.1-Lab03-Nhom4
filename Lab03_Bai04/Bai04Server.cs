using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai04;

public partial class Bai04Server : Form
{
    private sealed class KetNoiClient
    {
        public readonly TcpClient Client;
        public readonly StreamWriter Ghi;
        public readonly SemaphoreSlim KhoaGui = new(1, 1);

        public KetNoiClient(TcpClient client, StreamWriter ghi)
        {
            Client = client;
            Ghi = ghi;
        }
    }

    private readonly object khoa = new();
    private readonly List<KetNoiClient> dsKetNoi = new();
    private readonly Dictionary<string, HashSet<string>> gheDaBan = new();
    private readonly List<VeDaDat> danhSachVe = new();

    private List<PhongVe> danhSachPhongVe = new();
    private TcpListener? listener;
    private CancellationTokenSource? nguonHuy;

    public Bai04Server()
    {
        InitializeComponent();
        TaiDuLieuTuFile();
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
        var nguon = new CancellationTokenSource();
        nguonHuy = nguon;
        listener = new TcpListener(IPAddress.Loopback, PhongVeHelper.CongMacDinh);

        try
        {
            listener.Start();
            btnListen.Text = "Stop";
            CapNhatTrangThai($"Server đang lắng nghe tại 127.0.0.1:{PhongVeHelper.CongMacDinh}...");
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Server started!");

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
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Error: " + ex.Message);

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
            CapNhatSoClient();

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

        try
        {
            var stream = client.GetStream();
            boDoc = PhongVeHelper.TaoBoDoc(stream);
            boGhi = PhongVeHelper.TaoBoGhi(stream);
            ketNoi = new KetNoiClient(client, boGhi);

            lock (khoa)
            {
                dsKetNoi.Add(ketNoi);
            }

            CapNhatSoClient();
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Connection accepted from " + client.Client.RemoteEndPoint);
            await GuiSnapshotChoMotAsync(ketNoi);

            while (!token.IsCancellationRequested)
            {
                var dong = await boDoc.ReadLineAsync(token);
                if (dong is null)
                {
                    break;
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
            if (ketNoi is not null)
            {
                lock (khoa)
                {
                    dsKetNoi.Remove(ketNoi);
                }
            }

            boDoc?.Dispose();
            boGhi?.Dispose();
            client.Dispose();
            CapNhatSoClient();
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Client disconnected.");
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
            case "DAT":
                await XuLyDatVeAsync(phan, ketNoi);
                break;
            case "QUIT":
                ketNoi.Client.Close();
                break;
        }
    }

    private async Task XuLyDatVeAsync(string[] phan, KetNoiClient ketNoi)
    {
        if (phan.Length < 5 || !int.TryParse(phan[2], out var phongChieu))
        {
            await GuiKetQuaAsync(ketNoi, false, "Yêu cầu đặt vé không hợp lệ.");
            return;
        }

        var tenPhim = phan[1];
        var khachHang = PhongVeHelper.ChuanHoa(phan[3]);
        var danhSachGhe = phan[4]
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(ghe => ghe.ToUpperInvariant())
            .Distinct()
            .ToList();

        var thanhCong = false;
        var thongBao = "";

        lock (khoa)
        {
            var phongVe = danhSachPhongVe.FirstOrDefault(
                pv => pv.TenPhim == tenPhim && pv.PhongChieu == phongChieu);

            if (phongVe is null)
            {
                thongBao = "Phòng vé không tồn tại.";
            }
            else if (khachHang.Length == 0)
            {
                thongBao = "Vui lòng nhập tên khách hàng.";
            }
            else if (danhSachGhe.Count == 0)
            {
                thongBao = "Vui lòng chọn ít nhất 1 ghế.";
            }
            else if (danhSachGhe.Any(ghe => !PhongVeHelper.TatCaGhe.Contains(ghe)))
            {
                thongBao = "Ghế không hợp lệ.";
            }
            else
            {
                var khoaPhong = PhongVeHelper.Khoa(phongVe.TenPhim, phongVe.PhongChieu);
                if (!gheDaBan.TryGetValue(khoaPhong, out var daBan))
                {
                    daBan = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    gheDaBan[khoaPhong] = daBan;
                }

                var gheTrung = danhSachGhe.Where(daBan.Contains).ToList();
                if (gheTrung.Count > 0)
                {
                    thongBao = "Ghế đã được đặt: " + string.Join(", ", gheTrung);
                }
                else
                {
                    foreach (var ghe in danhSachGhe)
                    {
                        daBan.Add(ghe);
                    }

                    var tongTien = PhongVeHelper.TinhTien(phongVe.GiaVeChuan, danhSachGhe);
                    danhSachVe.Add(new VeDaDat(
                        DateTime.Now,
                        khachHang,
                        phongVe.TenPhim,
                        phongVe.PhongChieu,
                        string.Join(", ", danhSachGhe),
                        tongTien));

                    thanhCong = true;
                    thongBao = $"Đặt vé thành công: {string.Join(", ", danhSachGhe)} - {tongTien:N0} VNĐ";
                }
            }
        }

        PhongVeHelper.GhiNhatKy(rtbNhatKy, thanhCong ? thongBao : "Từ chối đặt vé: " + thongBao);
        await GuiKetQuaAsync(ketNoi, thanhCong, thongBao);

        if (thanhCong)
        {
            CapNhatGiaoDien();
            await GuiSnapshotChoTatCaAsync();
        }
    }

    private async Task GuiKetQuaAsync(KetNoiClient ketNoi, bool thanhCong, string thongBao)
    {
        await GuiDongAsync(ketNoi, $"KQ\t{(thanhCong ? "OK" : "LOI")}\t{PhongVeHelper.ChuanHoa(thongBao)}");
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

    private async Task GuiSnapshotChoMotAsync(KetNoiClient ketNoi)
    {
        var snapshot = TaoSnapshot();
        await ketNoi.KhoaGui.WaitAsync();
        try
        {
            foreach (var dong in snapshot)
            {
                await ketNoi.Ghi.WriteLineAsync(dong);
            }
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
        }
        finally
        {
            ketNoi.KhoaGui.Release();
        }
    }

    private async Task GuiSnapshotChoTatCaAsync()
    {
        List<KetNoiClient> danhSach;
        lock (khoa)
        {
            danhSach = dsKetNoi.ToList();
        }

        foreach (var ketNoi in danhSach)
        {
            await GuiSnapshotChoMotAsync(ketNoi);
        }
    }

    private List<string> TaoSnapshot()
    {
        lock (khoa)
        {
            return PhongVeHelper.TaoSnapshot(danhSachPhongVe, gheDaBan);
        }
    }

    private void TaiDuLieuTuFile()
    {
        var duongDan = Path.Combine(AppContext.BaseDirectory, "input5.txt");
        var danhSach = PhongVeHelper.DocInput5(duongDan);
        if (danhSach.Count == 0)
        {
            danhSach = PhongVeHelper.TaoDuLieuMacDinh();
        }

        lock (khoa)
        {
            danhSachPhongVe = danhSach;
            gheDaBan.Clear();
            danhSachVe.Clear();
        }

        CapNhatGiaoDien();
        CapNhatTrangThai($"Đã tải {danhSach.Count} phòng vé từ input5.txt.");
        PhongVeHelper.GhiNhatKy(rtbNhatKy, $"Đã tải {danhSach.Count} phòng vé từ input5.txt.");
    }

    private void CapNhatGiaoDien()
    {
        if (InvokeRequired)
        {
            BeginInvoke(CapNhatGiaoDien);
            return;
        }

        if (IsDisposed)
        {
            return;
        }

        List<PhongVe> danhSachPhong;
        Dictionary<string, HashSet<string>> daBan;
        List<VeDaDat> danhSachVeDaDat;
        List<ThongKePhim> thongKe;

        lock (khoa)
        {
            danhSachPhong = danhSachPhongVe.ToList();
            daBan = gheDaBan.ToDictionary(
                cap => cap.Key,
                cap => new HashSet<string>(cap.Value, StringComparer.OrdinalIgnoreCase));
            danhSachVeDaDat = danhSachVe.OrderByDescending(ve => ve.ThoiGian).ToList();
        }

        thongKe = TinhThongKe();

        lvPhongVe.BeginUpdate();
        lvPhongVe.Items.Clear();
        foreach (var phongVe in danhSachPhong)
        {
            var khoaPhong = PhongVeHelper.Khoa(phongVe.TenPhim, phongVe.PhongChieu);
            var ghe = daBan.TryGetValue(khoaPhong, out var tapGhe)
                ? tapGhe
                : new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            var dong = new ListViewItem($"{phongVe.TenPhim} - P{phongVe.PhongChieu}");
            dong.SubItems.Add(phongVe.GiaVeChuan.ToString("N0"));
            dong.SubItems.Add(ghe.Count.ToString());
            dong.SubItems.Add(PhongVeHelper.TinhTien(phongVe.GiaVeChuan, ghe).ToString("N0"));
            dong.Tag = phongVe;
            lvPhongVe.Items.Add(dong);
        }
        lvPhongVe.EndUpdate();

        lvVe.BeginUpdate();
        lvVe.Items.Clear();
        foreach (var ve in danhSachVeDaDat)
        {
            var dong = new ListViewItem(ve.ThoiGian.ToString("HH:mm:ss"));
            dong.SubItems.Add(ve.KhachHang);
            dong.SubItems.Add($"{ve.TenPhim} - P{ve.PhongChieu}");
            dong.SubItems.Add(ve.Ghe);
            dong.SubItems.Add(ve.TongTien.ToString("N0"));
            lvVe.Items.Add(dong);
        }
        lvVe.EndUpdate();

        rtbThongKe.Text = string.Join(
            Environment.NewLine,
            thongKe.Select(tk =>
                $"{tk.TenPhim}: {tk.SoVeBan}/{tk.SoVeBan + tk.SoVeTon} vé - {tk.DoanhThu:N0} VNĐ - hạng {tk.XepHang}"));

        CapNhatSoClient();
    }

    private List<ThongKePhim> TinhThongKe()
    {
        lock (khoa)
        {
            return danhSachPhongVe
                .GroupBy(phongVe => phongVe.TenPhim)
                .Select(nhom =>
                {
                    var cacPhong = nhom.ToList();
                    var sucChua = cacPhong.Count * PhongVeHelper.TatCaGhe.Length;
                    var soVeBan = cacPhong.Sum(phongVe =>
                        gheDaBan.TryGetValue(PhongVeHelper.Khoa(phongVe.TenPhim, phongVe.PhongChieu), out var ghe)
                            ? ghe.Count
                            : 0);
                    var doanhThu = danhSachVe
                        .Where(ve => ve.TenPhim == nhom.Key)
                        .Sum(ve => ve.TongTien);

                    return new ThongKePhim(
                        nhom.Key,
                        soVeBan,
                        sucChua - soVeBan,
                        sucChua == 0 ? 0 : (double)soVeBan / sucChua,
                        doanhThu,
                        0);
                })
                .OrderByDescending(thongKe => thongKe.DoanhThu)
                .Select((thongKe, viTri) => thongKe with { XepHang = viTri + 1 })
                .ToList();
        }
    }

    private async void btnDocFile_Click(object sender, EventArgs e)
    {
        TaiDuLieuTuFile();
        await GuiSnapshotChoTatCaAsync();
    }

    private void btnGhiFile_Click(object sender, EventArgs e)
    {
        try
        {
            List<PhongVe> danhSach;
            lock (khoa)
            {
                danhSach = danhSachPhongVe.ToList();
            }

            PhongVeHelper.GhiInput5(Path.Combine(AppContext.BaseDirectory, "input5.txt"), danhSach);
            CapNhatTrangThai($"Đã ghi {danhSach.Count} phòng vé xuống input5.txt.");
            PhongVeHelper.GhiNhatKy(rtbNhatKy, $"Đã ghi {danhSach.Count} phòng vé xuống input5.txt.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnThemPhong_Click(object sender, EventArgs e)
    {
        var tenPhim = PhongVeHelper.ChuanHoa(txtTenPhim.Text);
        if (tenPhim.Length == 0)
        {
            MessageBox.Show(this, "Vui lòng nhập tên phim.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenPhim.Focus();
            return;
        }

        if (!int.TryParse(txtGiaVe.Text.Trim(), out var giaVe) || giaVe <= 0)
        {
            MessageBox.Show(this, "Giá vé phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtGiaVe.Focus();
            return;
        }

        if (!int.TryParse(txtPhong.Text.Trim(), out var phongChieu) || phongChieu <= 0)
        {
            MessageBox.Show(this, "Phòng chiếu phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPhong.Focus();
            return;
        }

        lock (khoa)
        {
            if (danhSachPhongVe.Any(pv => pv.TenPhim == tenPhim && pv.PhongChieu == phongChieu))
            {
                MessageBox.Show(this, "Phòng vé này đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            danhSachPhongVe.Add(new PhongVe(tenPhim, giaVe, phongChieu));
        }

        txtTenPhim.Clear();
        txtGiaVe.Clear();
        txtPhong.Clear();
        txtTenPhim.Focus();
        CapNhatGiaoDien();
        CapNhatTrangThai($"Đã thêm phòng vé: {tenPhim} - phòng {phongChieu}");
        PhongVeHelper.GhiNhatKy(rtbNhatKy, $"Đã thêm phòng vé: {tenPhim} - phòng {phongChieu}");
        await GuiSnapshotChoTatCaAsync();
    }

    private async void btnXoaPhong_Click(object sender, EventArgs e)
    {
        if (lvPhongVe.SelectedItems.Count == 0 || lvPhongVe.SelectedItems[0].Tag is not PhongVe phongVe)
        {
            MessageBox.Show(this, "Vui lòng chọn một phòng vé trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        lock (khoa)
        {
            var khoaPhong = PhongVeHelper.Khoa(phongVe.TenPhim, phongVe.PhongChieu);
            if (gheDaBan.TryGetValue(khoaPhong, out var ghe) && ghe.Count > 0)
            {
                MessageBox.Show(this, "Không thể xóa phòng vé đã có người đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            danhSachPhongVe.Remove(phongVe);
            gheDaBan.Remove(khoaPhong);
        }

        CapNhatGiaoDien();
        CapNhatTrangThai($"Đã xóa phòng vé: {phongVe.TenPhim} - phòng {phongVe.PhongChieu}");
        PhongVeHelper.GhiNhatKy(rtbNhatKy, $"Đã xóa phòng vé: {phongVe.TenPhim} - phòng {phongVe.PhongChieu}");
        await GuiSnapshotChoTatCaAsync();
    }

    private async void btnXuatThongKe_Click(object sender, EventArgs e)
    {
        var thongKe = TinhThongKe();
        var dong = new List<string>
        {
            "Tên phim | Số vé bán | Số vé tồn | Tỉ lệ | Doanh thu | Xếp hạng",
        };

        btnXuatThongKe.Enabled = false;
        progressBar.Minimum = 0;
        progressBar.Maximum = Math.Max(1, thongKe.Count);
        progressBar.Value = 0;

        try
        {
            foreach (var tk in thongKe)
            {
                dong.Add($"{tk.TenPhim} | {tk.SoVeBan} | {tk.SoVeTon} | {tk.TiLe:P0} | {tk.DoanhThu:N0} | {tk.XepHang}");
                progressBar.Value++;
                await Task.Delay(120);
            }

            File.WriteAllLines(
                Path.Combine(AppContext.BaseDirectory, "output5.txt"),
                dong,
                new UTF8Encoding(false));
            rtbThongKe.Text = string.Join(Environment.NewLine, dong);
            CapNhatTrangThai("Đã xuất thống kê xuống output5.txt.");
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Đã xuất thống kê xuống output5.txt.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Lỗi khi xuất thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnXuatThongKe.Enabled = true;
        }
    }

    private void CapNhatSoClient()
    {
        if (InvokeRequired)
        {
            BeginInvoke(CapNhatSoClient);
            return;
        }

        if (IsDisposed)
        {
            return;
        }

        int soClient;
        lock (khoa)
        {
            soClient = dsKetNoi.Count;
        }

        lblSoClient.Text = $"{soClient} client đang kết nối";
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
            danhSach = dsKetNoi.ToList();
            dsKetNoi.Clear();
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
        CapNhatSoClient();
    }

    private void Bai04Server_FormClosing(object sender, FormClosingEventArgs e) => DungServer();
}
