using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4.Bai04;

public partial class Bai04Client : Form
{
    private readonly Dictionary<string, Button> nutGhe = new();
    private readonly HashSet<string> gheDangChon = new();

    private List<PhongVeTrangThai> dsPhong = new();
    private TcpClient? tcpClient;
    private StreamReader? boDoc;
    private StreamWriter? boGhi;
    private CancellationTokenSource? nguonHuy;
    private bool dangCapNhat;

    public Bai04Client()
    {
        InitializeComponent();
        txtDiaChi.Text = PhongVeHelper.DiaChiMacDinh;
        txtCong.Text = PhongVeHelper.CongMacDinh.ToString();
        TaoBangGhe();
        CapNhatGhe();
        CapNhatTrangThai("Chưa kết nối.");
    }

    private void TaoBangGhe()
    {
        tableGhe.Controls.Clear();
        nutGhe.Clear();

        for (var hang = 0; hang < 3; hang++)
        {
            for (var cot = 0; cot < 5; cot++)
            {
                var tenGhe = $"{(char)('A' + hang)}{cot + 1}";
                var nut = new Button
                {
                    Name = "btnGhe" + tenGhe,
                    Text = tenGhe,
                    Tag = tenGhe,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(4),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    UseVisualStyleBackColor = false,
                };
                nut.FlatAppearance.BorderColor = Color.FromArgb(180, 190, 200);
                nut.Click += NutGhe_Click;

                tableGhe.Controls.Add(nut, cot, hang);
                nutGhe[tenGhe] = nut;
            }
        }
    }

    private async void btnKetNoi_Click(object sender, EventArgs e)
    {
        var (hopLe, diemCuoi) = PhongVeHelper.DocDiemCuoi(txtDiaChi.Text, txtCong.Text);
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
            boDoc = PhongVeHelper.TaoBoDoc(stream);
            boGhi = PhongVeHelper.TaoBoGhi(stream);
            nguonHuy = new CancellationTokenSource();

            txtDiaChi.Enabled = false;
            txtCong.Enabled = false;
            btnNgatKetNoi.Enabled = true;
            CapNhatTrangThai("Đã kết nối tới " + diemCuoi + ".");
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Đã kết nối tới " + diemCuoi + ".");
            CapNhatGhe();

            _ = DocDuLieuAsync(nguonHuy.Token);
        }
        catch (Exception ex)
        {
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Không thể kết nối: " + ex.Message);
            NgatKetNoi();
            CapNhatTrangThai("Kết nối thất bại.");
        }
    }

    private async Task DocDuLieuAsync(CancellationToken token)
    {
        var dsMoi = new List<PhongVeTrangThai>();

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
                    dsMoi = new List<PhongVeTrangThai>();
                    continue;
                }

                if (dong.StartsWith("PHONG\t"))
                {
                    var phongVe = PhongVeHelper.DocDongPhong(dong);
                    if (phongVe is not null)
                    {
                        dsMoi.Add(phongVe);
                    }

                    continue;
                }

                if (dong.StartsWith("KQ\t"))
                {
                    XuLyKetQua(dong);
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
                PhongVeHelper.GhiNhatKy(rtbNhatKy, "Mất kết nối: " + ex.Message);
            }
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                PhongVeHelper.GhiNhatKy(rtbNhatKy, "Server đã đóng kết nối.");
                NgatKetNoi();
            }
        }
    }

    private void CapNhatDanhSach(List<PhongVeTrangThai> danhSach)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => CapNhatDanhSach(danhSach));
            return;
        }

        dsPhong = danhSach;
        PhongVeHelper.GhiNhatKy(rtbNhatKy, $"Đã đồng bộ {dsPhong.Count} phòng vé từ Server.");
        var phimDangChon = cmbPhim.Text;
        var phongDangChon = cmbPhong.SelectedItem is int phong ? phong : (int?)null;

        dangCapNhat = true;
        cmbPhim.BeginUpdate();
        cmbPhim.Items.Clear();
        foreach (var tenPhim in dsPhong.Select(pv => pv.TenPhim).Distinct())
        {
            cmbPhim.Items.Add(tenPhim);
        }
        cmbPhim.EndUpdate();

        if (phimDangChon.Length > 0 && cmbPhim.Items.Contains(phimDangChon))
        {
            cmbPhim.SelectedItem = phimDangChon;
        }
        else if (cmbPhim.Items.Count > 0)
        {
            cmbPhim.SelectedIndex = 0;
        }
        dangCapNhat = false;

        CapNhatPhong(phongDangChon);
    }

    private void CapNhatPhong(int? phongDangChon = null)
    {
        var tenPhim = cmbPhim.Text;
        var danhSach = dsPhong
            .Where(pv => pv.TenPhim == tenPhim)
            .OrderBy(pv => pv.PhongChieu)
            .ToList();

        if (phongDangChon is null && cmbPhong.SelectedItem is int phong)
        {
            phongDangChon = phong;
        }

        dangCapNhat = true;
        cmbPhong.BeginUpdate();
        cmbPhong.Items.Clear();
        foreach (var phongVe in danhSach)
        {
            cmbPhong.Items.Add(phongVe.PhongChieu);
        }
        cmbPhong.EndUpdate();

        if (phongDangChon.HasValue && cmbPhong.Items.Contains(phongDangChon.Value))
        {
            cmbPhong.SelectedItem = phongDangChon.Value;
        }
        else if (cmbPhong.Items.Count > 0)
        {
            cmbPhong.SelectedIndex = 0;
        }
        dangCapNhat = false;

        gheDangChon.Clear();
        CapNhatGhe();
    }

    private void CapNhatGhe()
    {
        var phongVe = LayPhongDangChon();
        var daBan = phongVe?.GheDaBan ?? new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var ghe in gheDangChon.Where(daBan.Contains).ToList())
        {
            gheDangChon.Remove(ghe);
            if (tcpClient is not null)
            {
                PhongVeHelper.GhiNhatKy(rtbNhatKy, $"Ghế {ghe} vừa được Client khác đặt.");
            }
        }

        foreach (var (tenGhe, nut) in nutGhe)
        {
            var daDat = daBan.Contains(tenGhe);
            var dangChon = gheDangChon.Contains(tenGhe);

            nut.Enabled = tcpClient is not null && phongVe is not null && !daDat;
            nut.Text = daDat ? $"{tenGhe}\nĐã bán" : tenGhe;
            nut.BackColor = daDat
                ? Color.FromArgb(235, 235, 235)
                : dangChon
                    ? Color.FromArgb(46, 160, 100)
                    : Color.White;
            nut.ForeColor = daDat
                ? Color.Gray
                : dangChon
                    ? Color.White
                    : Color.FromArgb(45, 45, 45);
        }

        if (phongVe is null)
        {
            lblThongTinPhong.Text = "Chưa có dữ liệu phòng vé.";
        }
        else
        {
            var conTrong = PhongVeHelper.TatCaGhe.Length - daBan.Count;
            lblThongTinPhong.Text =
                $"{phongVe.TenPhim} - phòng {phongVe.PhongChieu} - còn {conTrong}/{PhongVeHelper.TatCaGhe.Length} ghế";
        }

        CapNhatTongTien();
        btnDatVe.Enabled = tcpClient is not null && phongVe is not null && gheDangChon.Count > 0;
    }

    private void CapNhatTongTien()
    {
        var phongVe = LayPhongDangChon();
        var tongTien = phongVe is null
            ? 0
            : PhongVeHelper.TinhTien(phongVe.GiaVeChuan, gheDangChon);
        lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
    }

    private PhongVeTrangThai? LayPhongDangChon()
    {
        if (cmbPhong.SelectedItem is not int phong)
        {
            return null;
        }

        return dsPhong.FirstOrDefault(
            pv => pv.TenPhim == cmbPhim.Text && pv.PhongChieu == phong);
    }

    private void NutGhe_Click(object? sender, EventArgs e)
    {
        if (sender is not Button nut || nut.Tag is not string tenGhe)
        {
            return;
        }

        var phongVe = LayPhongDangChon();
        if (phongVe is null || phongVe.GheDaBan.Contains(tenGhe))
        {
            return;
        }

        if (!gheDangChon.Add(tenGhe))
        {
            gheDangChon.Remove(tenGhe);
        }

        CapNhatGhe();
    }

    private async void btnDatVe_Click(object sender, EventArgs e)
    {
        var phongVe = LayPhongDangChon();
        if (phongVe is null)
        {
            MessageBox.Show(this, "Vui lòng chọn phim và phòng chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var khachHang = PhongVeHelper.ChuanHoa(txtKhachHang.Text);
        if (khachHang.Length == 0)
        {
            MessageBox.Show(this, "Vui lòng nhập họ tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtKhachHang.Focus();
            return;
        }

        if (gheDangChon.Count == 0)
        {
            MessageBox.Show(this, "Vui lòng chọn ít nhất 1 ghế.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (boGhi is null)
        {
            CapNhatTrangThai("Chưa kết nối tới Server.");
            return;
        }

        var dong =
            $"DAT\t{PhongVeHelper.ChuanHoa(phongVe.TenPhim)}\t{phongVe.PhongChieu}\t{khachHang}\t{string.Join(",", gheDangChon.OrderBy(ghe => ghe))}";

        btnDatVe.Enabled = false;
        CapNhatTrangThai("Đang chờ Server xác nhận...");

        try
        {
            await boGhi.WriteLineAsync(dong);
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException)
        {
            PhongVeHelper.GhiNhatKy(rtbNhatKy, "Gửi yêu cầu thất bại: " + ex.Message);
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

        PhongVeHelper.GhiNhatKy(rtbNhatKy, (thanhCong ? "Server: " : "Lỗi: ") + thongBao);
        CapNhatTrangThai(thongBao);

        if (thanhCong)
        {
            txtKhachHang.Clear();
            gheDangChon.Clear();
            CapNhatGhe();
            return;
        }

        MessageBox.Show(this, thongBao, "Không thể đặt vé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        CapNhatGhe();
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
        dsPhong.Clear();
        gheDangChon.Clear();

        if (IsDisposed)
        {
            return;
        }

        dangCapNhat = true;
        cmbPhim.Items.Clear();
        cmbPhong.Items.Clear();
        dangCapNhat = false;

        btnKetNoi.Enabled = true;
        btnNgatKetNoi.Enabled = false;
        txtDiaChi.Enabled = true;
        txtCong.Enabled = true;
        CapNhatGhe();
        CapNhatTrangThai(daKetNoi ? "Đã ngắt kết nối." : "Chưa kết nối.");
    }

    private void cmbPhim_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dangCapNhat)
        {
            return;
        }

        CapNhatPhong();
    }

    private void cmbPhong_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dangCapNhat)
        {
            return;
        }

        gheDangChon.Clear();
        CapNhatGhe();
    }

    private void CapNhatTrangThai(string noiDung)
    {
        if (!IsDisposed)
        {
            lblTrangThai.Text = noiDung;
        }
    }

    private void Bai04Client_FormClosing(object sender, FormClosingEventArgs e) => NgatKetNoi();
}
