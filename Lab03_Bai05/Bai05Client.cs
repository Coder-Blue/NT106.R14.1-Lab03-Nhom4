using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4.Bai05;

public partial class Bai05Client : Form
{
    private readonly List<MonAn> dsMonAn = new();

    private TcpClient? tcpClient;
    private StreamReader? boDoc;
    private StreamWriter? boGhi;
    private CancellationTokenSource? nguonHuy;
    private NguoiDung? nguoiDung;
    private int? idMonDangChon;
    private bool dangCapNhat;

    public Bai05Client()
    {
        InitializeComponent();
        txtDiaChi.Text = MonAnHelper.DiaChiMacDinh;
        txtCong.Text = MonAnHelper.CongMacDinh.ToString();
        TaiDanhSachHinh();
        CapNhatNut();
        CapNhatTrangThai("Chưa kết nối.");
    }

    private void TaiDanhSachHinh()
    {
        var thuMuc = Path.Combine(AppContext.BaseDirectory, "hinh-anh");
        cmbHinhAnh.Items.Clear();

        if (Directory.Exists(thuMuc))
        {
            foreach (var duongDan in Directory
                         .GetFiles(thuMuc)
                         .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                        file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                        file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                         .OrderBy(file => file))
            {
                cmbHinhAnh.Items.Add(Path.GetFileName(duongDan));
            }
        }

        if (cmbHinhAnh.Items.Count == 0)
        {
            cmbHinhAnh.Items.Add("default.png");
        }

        cmbHinhAnh.SelectedIndex = 0;
    }

    private async void btnKetNoi_Click(object sender, EventArgs e)
    {
        var tenNguoiDung = MonAnHelper.ChuanHoa(txtTenNguoiDung.Text);
        if (tenNguoiDung.Length == 0)
        {
            MessageBox.Show(this, "Vui lòng nhập tên của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenNguoiDung.Focus();
            return;
        }

        var (hopLe, diemCuoi) = MonAnHelper.DocDiemCuoi(txtDiaChi.Text, txtCong.Text);
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
            boDoc = MonAnHelper.TaoBoDoc(stream);
            boGhi = MonAnHelper.TaoBoGhi(stream);
            nguonHuy = new CancellationTokenSource();

            txtTenNguoiDung.Enabled = false;
            txtDiaChi.Enabled = false;
            txtCong.Enabled = false;
            btnNgatKetNoi.Enabled = true;
            CapNhatTrangThai("Đã kết nối, đang đăng nhập...");
            MonAnHelper.GhiNhatKy(rtbNhatKy, "Đã kết nối tới " + diemCuoi + ".");
            CapNhatNut();

            await boGhi.WriteLineAsync("TEN\t" + tenNguoiDung);
            _ = DocDuLieuAsync(nguonHuy.Token);
        }
        catch (Exception ex)
        {
            MonAnHelper.GhiNhatKy(rtbNhatKy, "Không thể kết nối: " + ex.Message);
            NgatKetNoi();
            CapNhatTrangThai("Kết nối thất bại.");
        }
    }

    private async Task DocDuLieuAsync(CancellationToken token)
    {
        var dsMoi = new List<MonAn>();

        try
        {
            while (!token.IsCancellationRequested && boDoc is not null)
            {
                var dong = await boDoc.ReadLineAsync(token);
                if (dong is null)
                {
                    break;
                }

                if (dong == "HET")
                {
                    CapNhatDanhSach(dsMoi);
                    dsMoi = new List<MonAn>();
                    continue;
                }

                if (dong.StartsWith("MON\t"))
                {
                    var monAn = MonAnHelper.DocDongMon(dong);
                    if (monAn is not null)
                    {
                        dsMoi.Add(monAn);
                    }

                    continue;
                }

                if (dong.StartsWith("BAN\t"))
                {
                    XuLyBan(dong);
                    continue;
                }

                if (dong.StartsWith("KQ\t"))
                {
                    XuLyKetQua(dong);
                    continue;
                }

                if (dong.StartsWith("CHON\t"))
                {
                    HienThiKetQua(dong);
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
                MonAnHelper.GhiNhatKy(rtbNhatKy, "Mất kết nối: " + ex.Message);
            }
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                MonAnHelper.GhiNhatKy(rtbNhatKy, "Server đã đóng kết nối.");
                NgatKetNoi();
            }
        }
    }

    private void XuLyBan(string dong)
    {
        var phan = dong.Split('\t');
        if (phan.Length < 4 || !int.TryParse(phan[1], out var idNguoiDung))
        {
            return;
        }

        nguoiDung = new NguoiDung(idNguoiDung, phan[2], phan[3]);
        MonAnHelper.GhiNhatKy(rtbNhatKy, $"Xin chào {nguoiDung.HoVaTen}!");
        CapNhatTrangThai($"Đã đăng nhập với tên {nguoiDung.HoVaTen}.");
        CapNhatNut();
    }

    private void CapNhatDanhSach(List<MonAn> danhSach)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => CapNhatDanhSach(danhSach));
            return;
        }

        dsMonAn.Clear();
        dsMonAn.AddRange(danhSach);
        MonAnHelper.GhiNhatKy(rtbNhatKy, $"Đã đồng bộ {dsMonAn.Count} món ăn từ Server.");

        var idDangChon = idMonDangChon;
        dangCapNhat = true;
        lvMonAn.BeginUpdate();
        lvMonAn.Items.Clear();
        foreach (var monAn in dsMonAn)
        {
            var dong = new ListViewItem(monAn.IDMA.ToString());
            dong.SubItems.Add(monAn.TenMonAn);
            dong.SubItems.Add(monAn.TenNguoiDongGop);
            dong.Tag = monAn;
            lvMonAn.Items.Add(dong);
        }
        lvMonAn.EndUpdate();
        dangCapNhat = false;

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

        idMonDangChon = LayMonDangChon()?.IDMA;
        HienThiChiTiet();
        CapNhatNut();
    }

    private MonAn? LayMonDangChon()
    {
        if (lvMonAn.SelectedItems.Count == 0)
        {
            return null;
        }

        return lvMonAn.SelectedItems[0].Tag as MonAn;
    }

    private void HienThiChiTiet()
    {
        var monAn = LayMonDangChon();
        var hinhCu = picMonAn.Image;

        if (monAn is null)
        {
            lblKetQua.Text = "Chưa chọn món.";
            lblNguoiDongGop.Text = "";
            picMonAn.Image = null;
            hinhCu?.Dispose();
        }
        else
        {
            lblKetQua.Text = monAn.TenMonAn;
            lblNguoiDongGop.Text = "Đóng góp bởi: " + monAn.TenNguoiDongGop;
            HienThiHinh(monAn.HinhAnh);
        }
    }

    private void HienThiHinh(string tenHinh)
    {
        var duongDan = Path.Combine(AppContext.BaseDirectory, tenHinh);
        if (!File.Exists(duongDan))
        {
            duongDan = Path.Combine(AppContext.BaseDirectory, "hinh-anh", "default.png");
        }

        var hinhCu = picMonAn.Image;
        picMonAn.Image = MonAnHelper.TaiHinh(duongDan);
        hinhCu?.Dispose();
    }

    private void btnThemMon_Click(object sender, EventArgs e)
    {
        if (boGhi is null)
        {
            CapNhatTrangThai("Chưa kết nối tới Server.");
            return;
        }

        var tenMon = MonAnHelper.ChuanHoa(txtTenMonAn.Text);
        if (tenMon.Length == 0)
        {
            MessageBox.Show(this, "Vui lòng nhập tên món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenMonAn.Focus();
            return;
        }

        var hinhAnh = cmbHinhAnh.SelectedItem as string ?? "default.png";
        btnThemMon.Enabled = false;
        _ = GuiThemMonAsync(tenMon, hinhAnh);
    }

    private async Task GuiThemMonAsync(string tenMon, string hinhAnh)
    {
        if (boGhi is null)
        {
            return;
        }

        try
        {
            await boGhi.WriteLineAsync($"THEM\t{tenMon}\t{hinhAnh}");
            CapNhatTrangThai("Đang gửi món ăn tới Server...");
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            MonAnHelper.GhiNhatKy(rtbNhatKy, "Gửi món ăn thất bại: " + ex.Message);
            NgatKetNoi();
        }
    }

    private void btnXoaMon_Click(object sender, EventArgs e)
    {
        var monAn = LayMonDangChon();
        if (monAn is null || nguoiDung is null || boGhi is null)
        {
            return;
        }

        if (monAn.IDNCC != nguoiDung.IDNCC)
        {
            MessageBox.Show(this, "Chỉ được xóa món do mình đóng góp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnXoaMon.Enabled = false;
        _ = GuiXoaMonAsync(monAn.IDMA);
    }

    private async Task GuiXoaMonAsync(int idMonAn)
    {
        if (boGhi is null)
        {
            return;
        }

        try
        {
            await boGhi.WriteLineAsync("XOA\t" + idMonAn);
            CapNhatTrangThai("Đang xóa món ăn...");
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            MonAnHelper.GhiNhatKy(rtbNhatKy, "Xóa món thất bại: " + ex.Message);
            NgatKetNoi();
        }
    }

    private void btnAnGiCaNhan_Click(object sender, EventArgs e) => _ = GuiChonNgauNhienAsync(true);

    private void btnAnGiCongDong_Click(object sender, EventArgs e) => _ = GuiChonNgauNhienAsync(false);

    private async Task GuiChonNgauNhienAsync(bool caNhan)
    {
        if (boGhi is null)
        {
            CapNhatTrangThai("Chưa kết nối tới Server.");
            return;
        }

        try
        {
            await boGhi.WriteLineAsync(caNhan ? "RANDOM\t1" : "RANDOM\t0");
            CapNhatTrangThai("Đang chọn món ngẫu nhiên...");
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            MonAnHelper.GhiNhatKy(rtbNhatKy, "Chọn món thất bại: " + ex.Message);
            NgatKetNoi();
        }
    }

    private void XuLyKetQua(string dong)
    {
        var phan = dong.Split('\t');
        if (phan.Length < 3)
        {
            return;
        }

        var thanhCong = phan[1] == "OK";
        var thongBao = phan[2];
        MonAnHelper.GhiNhatKy(rtbNhatKy, (thanhCong ? "Server: " : "Lỗi: ") + thongBao);
        CapNhatTrangThai(thongBao);

        if (thanhCong)
        {
            txtTenMonAn.Clear();
        }
        else if (thongBao.Length > 0)
        {
            MessageBox.Show(this, thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        CapNhatNut();
    }

    private void HienThiKetQua(string dong)
    {
        var phan = dong.Split('\t');
        if (phan.Length < 6)
        {
            return;
        }

        var tenMon = phan[2];
        var tenNguoiDongGop = phan[5];
        lblKetQua.Text = $"Hôm nay ăn:\r\n\r\n{tenMon}";
        lblNguoiDongGop.Text = "Đóng góp bởi: " + tenNguoiDongGop;
        HienThiHinh(phan[3]);
        MonAnHelper.GhiNhatKy(rtbNhatKy, $"Món được chọn: {tenMon} (bởi {tenNguoiDongGop})");
        CapNhatTrangThai("Đã chọn món ngẫu nhiên.");
        CapNhatNut();
    }

    private void CapNhatNut()
    {
        var coKetNoi = tcpClient is not null && nguoiDung is not null;
        var monDangChon = LayMonDangChon();

        btnThemMon.Enabled = coKetNoi;
        btnXoaMon.Enabled = coKetNoi &&
                            monDangChon is not null &&
                            nguoiDung is not null &&
                            monDangChon.IDNCC == nguoiDung.IDNCC;
        btnAnGiCaNhan.Enabled = coKetNoi && nguoiDung is not null && dsMonAn.Any(mon => mon.IDNCC == nguoiDung.IDNCC);
        btnAnGiCongDong.Enabled = coKetNoi && dsMonAn.Count > 0;
        btnNgatKetNoi.Enabled = tcpClient is not null;
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
        nguoiDung = null;
        idMonDangChon = null;
        dsMonAn.Clear();

        if (IsDisposed)
        {
            return;
        }

        dangCapNhat = true;
        lvMonAn.Items.Clear();
        dangCapNhat = false;

        var hinhCu = picMonAn.Image;
        picMonAn.Image = null;
        hinhCu?.Dispose();

        lblKetQua.Text = "Chưa chọn món.";
        lblNguoiDongGop.Text = "";
        txtTenNguoiDung.Enabled = true;
        txtDiaChi.Enabled = true;
        txtCong.Enabled = true;
        btnKetNoi.Enabled = true;
        CapNhatNut();
        CapNhatTrangThai(daKetNoi ? "Đã ngắt kết nối." : "Chưa kết nối.");
    }

    private void lvMonAn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dangCapNhat)
        {
            return;
        }

        idMonDangChon = LayMonDangChon()?.IDMA;
        HienThiChiTiet();
        CapNhatNut();
    }

    private void CapNhatTrangThai(string noiDung)
    {
        if (!IsDisposed)
        {
            lblTrangThai.Text = noiDung;
        }
    }

    private void Bai05Client_FormClosing(object sender, FormClosingEventArgs e) => NgatKetNoi();
}
