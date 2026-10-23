using System.Net;
using System.Net.Sockets;
using Microsoft.Data.Sqlite;

namespace NT106.R14._1_Lab03_Nhom4.Bai05;

public partial class Bai05Server : Form
{
    private sealed class KetNoiClient
    {
        public readonly TcpClient Client;
        public readonly StreamWriter Ghi;
        public readonly SemaphoreSlim KhoaGui = new(1, 1);
        public NguoiDung? NguoiDung;

        public KetNoiClient(TcpClient client, StreamWriter ghi)
        {
            Client = client;
            Ghi = ghi;
        }
    }

    private const string TenDb = "homnayangi.db";

    private readonly object khoa = new();
    private readonly List<KetNoiClient> dsKetNoi = new();

    private TcpListener? listener;
    private CancellationTokenSource? nguonHuy;

    public Bai05Server()
    {
        InitializeComponent();
        TaoBangVaDuLieuMau();
        CapNhatGiaoDien();
    }

    private static string LayDuongDanDb() => Path.Combine(AppContext.BaseDirectory, TenDb);

    private static SqliteConnection MoKetNoi()
    {
        var ketNoi = new SqliteConnection($"Data Source={LayDuongDanDb()}");
        ketNoi.Open();
        return ketNoi;
    }

    private static void TaoBangVaDuLieuMau()
    {
        using var ketNoi = MoKetNoi();

        using (var lenh = ketNoi.CreateCommand())
        {
            lenh.CommandText =
                "CREATE TABLE IF NOT EXISTS NguoiDung (" +
                "IDNCC INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "HoVaTen TEXT NOT NULL UNIQUE, " +
                "QuyenHan TEXT NOT NULL);";
            lenh.ExecuteNonQuery();
        }

        using (var lenh = ketNoi.CreateCommand())
        {
            lenh.CommandText =
                "CREATE TABLE IF NOT EXISTS MonAn (" +
                "IDMA INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "TenMonAn TEXT NOT NULL, " +
                "HinhAnh TEXT NOT NULL, " +
                "IDNCC INTEGER NOT NULL, " +
                "FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC));";
            lenh.ExecuteNonQuery();
        }

        long soNguoiDung;
        using (var lenh = ketNoi.CreateCommand())
        {
            lenh.CommandText = "SELECT COUNT(*) FROM NguoiDung;";
            soNguoiDung = (long)lenh.ExecuteScalar()!;
        }

        if (soNguoiDung > 0)
        {
            return;
        }

        var idA = ThemNguoiDung(ketNoi, "Nguyễn Văn A", "Admin");
        var idB = ThemNguoiDung(ketNoi, "Trần Thị B", "Thành viên");
        var idC = ThemNguoiDung(ketNoi, "Lê Văn C", "Thành viên");

        ThemMonAn(ketNoi, "Bún riêu", Path.Combine("hinh-anh", "bun-rieu.jpg"), idA);
        ThemMonAn(ketNoi, "Bún thịt nướng", Path.Combine("hinh-anh", "bun-thit-nuong.jpg"), idB);
        ThemMonAn(ketNoi, "Cơm tấm sườn trứng", Path.Combine("hinh-anh", "com-tam.jpg"), idC);
        ThemMonAn(ketNoi, "Phở", Path.Combine("hinh-anh", "pho.jpg"), idA);
        ThemMonAn(ketNoi, "Gỏi cuốn", Path.Combine("hinh-anh", "goi-cuon.jpg"), idB);
    }

    private static int ThemNguoiDung(SqliteConnection ketNoi, string hoVaTen, string quyenHan)
    {
        using (var lenh = ketNoi.CreateCommand())
        {
            lenh.CommandText = "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ($ten, $quyen);";
            lenh.Parameters.AddWithValue("$ten", hoVaTen);
            lenh.Parameters.AddWithValue("$quyen", quyenHan);
            lenh.ExecuteNonQuery();
        }

        using var lenhId = ketNoi.CreateCommand();
        lenhId.CommandText = "SELECT last_insert_rowid();";
        return Convert.ToInt32(lenhId.ExecuteScalar());
    }

    private static NguoiDung? DangKyNguoiDung(string hoVaTen)
    {
        var ten = MonAnHelper.ChuanHoa(hoVaTen);
        if (ten.Length == 0)
        {
            return null;
        }

        using var ketNoi = MoKetNoi();

        using (var lenh = ketNoi.CreateCommand())
        {
            lenh.CommandText = "SELECT IDNCC, HoVaTen, QuyenHan FROM NguoiDung WHERE HoVaTen = $ten;";
            lenh.Parameters.AddWithValue("$ten", ten);
            using var doc = lenh.ExecuteReader();
            if (doc.Read())
            {
                return new NguoiDung(doc.GetInt32(0), doc.GetString(1), doc.GetString(2));
            }
        }

        var id = ThemNguoiDung(ketNoi, ten, "Thành viên");
        return new NguoiDung(id, ten, "Thành viên");
    }

    private static List<MonAn> LayDanhSachMonAn()
    {
        var ketQua = new List<MonAn>();

        using var ketNoi = MoKetNoi();
        using var lenh = ketNoi.CreateCommand();
        lenh.CommandText =
            "SELECT ma.IDMA, ma.TenMonAn, ma.HinhAnh, ma.IDNCC, nd.HoVaTen " +
            "FROM MonAn ma JOIN NguoiDung nd ON ma.IDNCC = nd.IDNCC " +
            "ORDER BY ma.IDMA;";

        using var doc = lenh.ExecuteReader();
        while (doc.Read())
        {
            ketQua.Add(DocMonAn(doc));
        }

        return ketQua;
    }

    private static MonAn? LayMonAn(int idMonAn)
    {
        using var ketNoi = MoKetNoi();
        using var lenh = ketNoi.CreateCommand();
        lenh.CommandText =
            "SELECT ma.IDMA, ma.TenMonAn, ma.HinhAnh, ma.IDNCC, nd.HoVaTen " +
            "FROM MonAn ma JOIN NguoiDung nd ON ma.IDNCC = nd.IDNCC " +
            "WHERE ma.IDMA = $id;";
        lenh.Parameters.AddWithValue("$id", idMonAn);

        using var doc = lenh.ExecuteReader();
        return doc.Read() ? DocMonAn(doc) : null;
    }

    private static MonAn? ChonMonAnNgauNhien(int? idNguoiDung)
    {
        using var ketNoi = MoKetNoi();
        using var lenh = ketNoi.CreateCommand();
        lenh.CommandText =
            "SELECT ma.IDMA, ma.TenMonAn, ma.HinhAnh, ma.IDNCC, nd.HoVaTen " +
            "FROM MonAn ma JOIN NguoiDung nd ON ma.IDNCC = nd.IDNCC ";

        if (idNguoiDung.HasValue)
        {
            lenh.CommandText += "WHERE ma.IDNCC = $idncc ";
            lenh.Parameters.AddWithValue("$idncc", idNguoiDung.Value);
        }

        lenh.CommandText += "ORDER BY RANDOM() LIMIT 1;";

        using var doc = lenh.ExecuteReader();
        return doc.Read() ? DocMonAn(doc) : null;
    }

    private static MonAn DocMonAn(SqliteDataReader doc) =>
        new(doc.GetInt32(0), doc.GetString(1), doc.GetString(2), doc.GetInt32(3), doc.GetString(4));

    private static void ThemMonAn(SqliteConnection ketNoi, string tenMon, string hinhAnh, int idNguoiDung)
    {
        using var lenh = ketNoi.CreateCommand();
        lenh.CommandText = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES ($ten, $hinh, $idncc);";
        lenh.Parameters.AddWithValue("$ten", tenMon);
        lenh.Parameters.AddWithValue("$hinh", hinhAnh);
        lenh.Parameters.AddWithValue("$idncc", idNguoiDung);
        lenh.ExecuteNonQuery();
    }

    private static void XoaMonAn(int idMonAn)
    {
        using var ketNoi = MoKetNoi();
        using var lenh = ketNoi.CreateCommand();
        lenh.CommandText = "DELETE FROM MonAn WHERE IDMA = $id;";
        lenh.Parameters.AddWithValue("$id", idMonAn);
        lenh.ExecuteNonQuery();
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
        listener = new TcpListener(IPAddress.Loopback, MonAnHelper.CongMacDinh);

        try
        {
            listener.Start();
            btnListen.Text = "Stop";
            CapNhatTrangThai($"Server đang lắng nghe tại 127.0.0.1:{MonAnHelper.CongMacDinh}...");
            MonAnHelper.GhiNhatKy(rtbNhatKy, "Server started!");

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
            MonAnHelper.GhiNhatKy(rtbNhatKy, "Error: " + ex.Message);

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
        var daDangKy = false;

        try
        {
            var stream = client.GetStream();
            boDoc = MonAnHelper.TaoBoDoc(stream);
            boGhi = MonAnHelper.TaoBoGhi(stream);
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
                        await GuiDongAsync(ketNoi, "KQ\tLOI\tVui lòng gửi tên người dùng trước.");
                        continue;
                    }

                    var nguoiDung = DangKyNguoiDung(phan[1]);
                    if (nguoiDung is null)
                    {
                        await GuiDongAsync(ketNoi, "KQ\tLOI\tTên người dùng không hợp lệ.");
                        break;
                    }

                    ketNoi.NguoiDung = nguoiDung;
                    lock (khoa)
                    {
                        dsKetNoi.Add(ketNoi);
                    }

                    daDangKy = true;
                    CapNhatSoClient();
                    MonAnHelper.GhiNhatKy(rtbNhatKy, $"Client {nguoiDung.HoVaTen} đã kết nối.");
                    await GuiDongAsync(
                        ketNoi,
                        $"BAN\t{nguoiDung.IDNCC}\t{nguoiDung.HoVaTen}\t{nguoiDung.QuyenHan}");
                    await GuiSnapshotChoMotAsync(ketNoi);
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
                lock (khoa)
                {
                    dsKetNoi.Remove(ketNoi);
                }

                CapNhatSoClient();
                MonAnHelper.GhiNhatKy(
                    rtbNhatKy,
                    $"Client {ketNoi.NguoiDung?.HoVaTen} đã ngắt kết nối.");
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
            case "THEM":
                await XuLyThemMonAsync(phan, ketNoi);
                break;
            case "XOA":
                await XuLyXoaMonAsync(phan, ketNoi);
                break;
            case "RANDOM":
                await XuLyChonNgauNhienAsync(phan, ketNoi);
                break;
            case "QUIT":
                ketNoi.Client.Close();
                break;
        }
    }

    private async Task XuLyThemMonAsync(string[] phan, KetNoiClient ketNoi)
    {
        if (phan.Length < 3 || ketNoi.NguoiDung is null)
        {
            await GuiKetQuaAsync(ketNoi, false, "Dữ liệu món ăn không hợp lệ.");
            return;
        }

        var tenMon = MonAnHelper.ChuanHoa(phan[1]);
        if (tenMon.Length == 0)
        {
            await GuiKetQuaAsync(ketNoi, false, "Vui lòng nhập tên món ăn.");
            return;
        }

        var tenHinh = Path.GetFileName(MonAnHelper.ChuanHoa(phan[2]));
        var duongDanHinh = Path.Combine(AppContext.BaseDirectory, "hinh-anh", tenHinh);
        var hinhAnh = File.Exists(duongDanHinh)
            ? Path.Combine("hinh-anh", tenHinh)
            : Path.Combine("hinh-anh", "default.png");

        using (var ketNoiDb = MoKetNoi())
        {
            ThemMonAn(ketNoiDb, tenMon, hinhAnh, ketNoi.NguoiDung.IDNCC);
        }

        CapNhatGiaoDien();
        MonAnHelper.GhiNhatKy(rtbNhatKy, $"{ketNoi.NguoiDung.HoVaTen} đã thêm món: {tenMon}");
        await GuiKetQuaAsync(ketNoi, true, $"Đã thêm món: {tenMon}");
        await GuiSnapshotChoTatCaAsync();
    }

    private async Task XuLyXoaMonAsync(string[] phan, KetNoiClient ketNoi)
    {
        if (phan.Length < 2 || !int.TryParse(phan[1], out var idMonAn) || ketNoi.NguoiDung is null)
        {
            await GuiKetQuaAsync(ketNoi, false, "Món ăn không hợp lệ.");
            return;
        }

        var monAn = LayMonAn(idMonAn);
        if (monAn is null)
        {
            await GuiKetQuaAsync(ketNoi, false, "Món ăn không tồn tại.");
            return;
        }

        if (monAn.IDNCC != ketNoi.NguoiDung.IDNCC)
        {
            await GuiKetQuaAsync(ketNoi, false, "Chỉ được xóa món do mình đóng góp.");
            return;
        }

        XoaMonAn(idMonAn);
        CapNhatGiaoDien();
        MonAnHelper.GhiNhatKy(rtbNhatKy, $"{ketNoi.NguoiDung.HoVaTen} đã xóa món: {monAn.TenMonAn}");
        await GuiKetQuaAsync(ketNoi, true, $"Đã xóa món: {monAn.TenMonAn}");
        await GuiSnapshotChoTatCaAsync();
    }

    private async Task XuLyChonNgauNhienAsync(string[] phan, KetNoiClient ketNoi)
    {
        if (ketNoi.NguoiDung is null)
        {
            return;
        }

        var caNhan = phan.Length > 1 && phan[1] == "1";
        var monAn = ChonMonAnNgauNhien(caNhan ? ketNoi.NguoiDung.IDNCC : null);

        if (monAn is null)
        {
            await GuiKetQuaAsync(
                ketNoi,
                false,
                caNhan ? "Bạn chưa có món ăn nào." : "Chưa có món ăn nào trong cộng đồng.");
            return;
        }

        await GuiDongAsync(
            ketNoi,
            $"CHON\t{monAn.IDMA}\t{MonAnHelper.ChuanHoa(monAn.TenMonAn)}\t{MonAnHelper.ChuanHoa(monAn.HinhAnh)}\t{monAn.IDNCC}\t{MonAnHelper.ChuanHoa(monAn.TenNguoiDongGop)}");
        MonAnHelper.GhiNhatKy(
            rtbNhatKy,
            $"{ketNoi.NguoiDung.HoVaTen} chọn ngẫu nhiên: {monAn.TenMonAn}");
    }

    private async Task GuiKetQuaAsync(KetNoiClient ketNoi, bool thanhCong, string thongBao)
    {
        await GuiDongAsync(ketNoi, $"KQ\t{(thanhCong ? "OK" : "LOI")}\t{MonAnHelper.ChuanHoa(thongBao)}");
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
        var snapshot = MonAnHelper.TaoSnapshot(LayDanhSachMonAn());
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

        var idDangChon = lvMonAn.SelectedItems.Count > 0 && lvMonAn.SelectedItems[0].Tag is MonAn monDangChon
            ? monDangChon.IDMA
            : (int?)null;

        var danhSach = LayDanhSachMonAn();
        lvMonAn.BeginUpdate();
        lvMonAn.Items.Clear();
        foreach (var monAn in danhSach)
        {
            var dong = new ListViewItem(monAn.IDMA.ToString());
            dong.SubItems.Add(monAn.TenMonAn);
            dong.SubItems.Add(monAn.TenNguoiDongGop);
            dong.Tag = monAn;
            lvMonAn.Items.Add(dong);
        }
        lvMonAn.EndUpdate();

        lblTongMon.Text = $"{danhSach.Count} món ăn";

        if (idDangChon.HasValue)
        {
            foreach (ListViewItem item in lvMonAn.Items)
            {
                if (item.Tag is MonAn monAn && monAn.IDMA == idDangChon.Value)
                {
                    item.Selected = true;
                    break;
                }
            }
        }
        else if (lvMonAn.Items.Count > 0)
        {
            lvMonAn.Items[0].Selected = true;
        }

        HienThiChiTiet();
        CapNhatSoClient();
    }

    private void HienThiChiTiet()
    {
        var monAn = lvMonAn.SelectedItems.Count > 0
            ? lvMonAn.SelectedItems[0].Tag as MonAn
            : null;
        var hinhCu = picMonAn.Image;

        if (monAn is null)
        {
            lblTenMon.Text = "Chưa chọn món ăn.";
            lblNguoiDongGop.Text = "";
            picMonAn.Image = null;
        }
        else
        {
            lblTenMon.Text = monAn.TenMonAn;
            lblNguoiDongGop.Text = "Đóng góp bởi: " + monAn.TenNguoiDongGop;
            picMonAn.Image = MonAnHelper.TaiHinh(Path.Combine(AppContext.BaseDirectory, monAn.HinhAnh));
        }

        hinhCu?.Dispose();
    }

    private async void btnXoaMon_Click(object sender, EventArgs e)
    {
        if (lvMonAn.SelectedItems.Count == 0 || lvMonAn.SelectedItems[0].Tag is not MonAn monAn)
        {
            MessageBox.Show(this, "Vui lòng chọn một món ăn trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show(
                this,
                $"Xóa món \"{monAn.TenMonAn}\" khỏi cơ sở dữ liệu?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        XoaMonAn(monAn.IDMA);
        CapNhatGiaoDien();
        MonAnHelper.GhiNhatKy(rtbNhatKy, "Đã xóa món: " + monAn.TenMonAn);
        await GuiSnapshotChoTatCaAsync();
    }

    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        CapNhatGiaoDien();
        await GuiSnapshotChoTatCaAsync();
    }

    private void lvMonAn_SelectedIndexChanged(object sender, EventArgs e) => HienThiChiTiet();

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

    private void Bai05Server_FormClosing(object sender, FormClosingEventArgs e) => DungServer();
}
