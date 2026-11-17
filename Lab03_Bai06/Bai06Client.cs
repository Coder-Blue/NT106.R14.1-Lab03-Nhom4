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
            ThemTinNhan($"[Hệ thống] Đã kết nối tới {diemCuoi}.");

            await boGhi.WriteLineAsync("TEN\t" + ten);
            _ = DocDuLieuAsync(nguonHuy.Token);
        }
        catch (Exception ex)
        {
            ThemTinNhan("[Hệ thống] Không thể kết nối: " + ex.Message);
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
                    ThemTinNhan($"[Hệ thống] Xin chào {tenCuaToi}!");
                    CapNhatTrangThai($"Đã tham gia phòng chat với tên {tenCuaToi}.");
                    CapNhatNut();
                    continue;
                }

                if (dong.StartsWith("LOI\t"))
                {
                    var thongBao = dong[4..];
                    ThemTinNhan("[Hệ thống] " + thongBao);
                    MessageBox.Show(this, thongBao, "Không thể tham gia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NgatKetNoi();
                    return;
                }

                if (dong.StartsWith("MSG\t"))
                {
                    ThemTinNhan(dong[4..]);
                    continue;
                }

                if (dong.StartsWith("FILE\t"))
                {
                    NhanTep(dong);
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
                ThemTinNhan("[Hệ thống] Mất kết nối: " + ex.Message);
            }
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                ThemTinNhan("[Hệ thống] Server đã đóng kết nối.");
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
            ThemTinNhan("[Hệ thống] Gửi tin nhắn thất bại: " + ex.Message);
            NgatKetNoi();
        }
    }

    private async void btnGuiTep_Click(object sender, EventArgs e)
    {
        if (boGhi is null || tenCuaToi is null)
        {
            CapNhatTrangThai("Chưa kết nối tới Server.");
            return;
        }

        using var hopThoai = new OpenFileDialog
        {
            Title = "Chọn ảnh hoặc tệp văn bản",
            Filter = "Ảnh và tệp văn bản|*.jpg;*.jpeg;*.png;*.txt|Ảnh|*.jpg;*.jpeg;*.png|Tệp văn bản|*.txt",
        };

        if (hopThoai.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var tep = new FileInfo(hopThoai.FileName);
        if (!tep.Exists)
        {
            MessageBox.Show(this, "Không tìm thấy tệp đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ChatHelper.LaTepChoPhep(tep.Name))
        {
            MessageBox.Show(this, "Chỉ hỗ trợ ảnh .jpg, .jpeg, .png và tệp .txt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (tep.Length > ChatHelper.KichThuocTepToiDa)
        {
            MessageBox.Show(this, "Tệp vượt quá giới hạn 5 MB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var duLieu = Convert.ToBase64String(await File.ReadAllBytesAsync(tep.FullName));
            var nguoiNhan = cmbNguoiNhan.SelectedItem as string;
            var dich = string.IsNullOrEmpty(nguoiNhan) || nguoiNhan == "Mọi người" ? "*" : nguoiNhan;
            await boGhi.WriteLineAsync($"FILE\t{dich}\t{ChatHelper.ChuanHoaTen(tep.Name)}\t{duLieu}");
            CapNhatTrangThai("Đang gửi tệp...");
        }
        catch (Exception ex) when (ex is IOException or SocketException or ObjectDisposedException or UnauthorizedAccessException)
        {
            ThemTinNhan("[Hệ thống] Gửi tệp thất bại: " + ex.Message);
        }
    }

    private void NhanTep(string dong)
    {
        var phan = dong.Split('\t');
        if (phan.Length < 5)
        {
            return;
        }

        try
        {
            var nguoiGui = phan[1];
            var tenTep = Path.GetFileName(phan[2]);
            var duLieu = Convert.FromBase64String(phan[3]);
            var cheDo = phan[4];

            try
            {
                var thuMuc = Path.Combine(AppContext.BaseDirectory, "tep-nhan-duoc");
                Directory.CreateDirectory(thuMuc);
                var tenLuu = $"{DateTime.Now:yyyyMMdd-HHmmss-fff}_{tenTep}";
                File.WriteAllBytes(Path.Combine(thuMuc, tenLuu), duLieu);
            }
            catch (Exception ex)
            {
                CapNhatTrangThai("Không lưu tạm được tệp: " + ex.Message);
            }

            ThemTepVaoChat(nguoiGui, tenTep, duLieu, cheDo);
        }
        catch (Exception ex)
        {
            ThemTinNhan("[Hệ thống] Không thể nhận tệp: " + ex.Message);
        }
    }

    private void ThemTinNhan(string noiDung)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => ThemTinNhan(noiDung));
            return;
        }

        if (IsDisposed || flpChat.IsDisposed)
        {
            return;
        }

        if (noiDung.Contains("[Hệ thống]", StringComparison.Ordinal))
        {
            var fontHeThong = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            var chieuRong = Math.Max(200, flpChat.ClientSize.Width - 40);
            var kichThuoc = TextRenderer.MeasureText(
                noiDung,
                fontHeThong,
                new Size(Math.Max(100, chieuRong - 16), int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
            var chieuCao = Math.Max(24, kichThuoc.Height + 4);
            var dongHeThong = TaoDongChat(false, chieuCao);
            var nhan = new Label
            {
                AutoSize = false,
                Font = fontHeThong,
                ForeColor = Color.FromArgb(110, 110, 110),
                Height = chieuCao,
                Margin = new Padding(8, 2, 8, 2),
                Text = noiDung,
                TextAlign = ContentAlignment.MiddleCenter,
                UseMnemonic = false,
                Width = Math.Max(200, dongHeThong.Width - 16),
            };

            dongHeThong.Controls.Add(nhan);
            ThemDongVaoChat(dongHeThong);
            return;
        }

        var cuaToi = LaTinNhanCuaToi(noiDung);
        var font = new Font("Segoe UI", 10F);
        var bongBong = new Label
        {
            AutoSize = false,
            BackColor = cuaToi ? Color.FromArgb(0, 132, 255) : Color.FromArgb(240, 240, 240),
            Font = font,
            ForeColor = cuaToi ? Color.White : Color.FromArgb(30, 30, 30),
            Margin = new Padding(4, 3, 4, 3),
            Padding = new Padding(10, 7, 10, 7),
            Size = DoKichThuocChu(noiDung, font, 420),
            Text = noiDung,
            TextAlign = ContentAlignment.TopLeft,
            UseMnemonic = false,
        };

        var dong = TaoDongChat(cuaToi, bongBong.Height);
        dong.Controls.Add(bongBong);
        ThemDongVaoChat(dong);
    }

    private static Size DoKichThuocChu(string noiDung, Font font, int chieuRongToiDa)
    {
        var kichThuoc = TextRenderer.MeasureText(
            noiDung,
            font,
            new Size(chieuRongToiDa, int.MaxValue),
            TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

        return new Size(Math.Min(chieuRongToiDa, kichThuoc.Width) + 20, kichThuoc.Height + 14);
    }

    private FlowLayoutPanel TaoDongChat(bool canPhai, int chieuCao)
    {
        return new FlowLayoutPanel
        {
            AutoSize = false,
            BackColor = Color.Transparent,
            FlowDirection = canPhai ? FlowDirection.RightToLeft : FlowDirection.LeftToRight,
            Height = chieuCao + 8,
            Margin = new Padding(0),
            Padding = new Padding(0),
            Width = Math.Max(200, flpChat.ClientSize.Width - 40),
            WrapContents = false,
        };
    }

    private void ThemDongVaoChat(Control dong)
    {
        flpChat.Controls.Add(dong);
        flpChat.PerformLayout();
        flpChat.ScrollControlIntoView(dong);
    }

    private bool LaTinNhanCuaToi(string noiDung)
    {
        if (tenCuaToi is null)
        {
            return false;
        }

        return noiDung.Contains($"] {tenCuaToi}:", StringComparison.Ordinal) ||
               noiDung.Contains("] [Riêng] Bạn ->", StringComparison.Ordinal);
    }

    private void ThemTepVaoChat(string nguoiGui, string tenTep, byte[] duLieu, string cheDo)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => ThemTepVaoChat(nguoiGui, tenTep, duLieu, cheDo));
            return;
        }

        if (IsDisposed || flpChat.IsDisposed)
        {
            return;
        }

        var cuaToi = nguoiGui == tenCuaToi;
        var nguoiHienThi = cuaToi ? "Bạn" : nguoiGui;
        var bongBong = TaoBongBongTep(nguoiHienThi, tenTep, duLieu, cheDo, cuaToi);
        var dong = TaoDongChat(cuaToi, bongBong.Height);
        dong.Controls.Add(bongBong);
        ThemDongVaoChat(dong);
    }

    private Control TaoBongBongTep(string nguoiHienThi, string tenTep, byte[] duLieu, string cheDo, bool cuaToi)
    {
        var laAnh = ChatHelper.LaAnh(tenTep);
        var chieuRong = laAnh ? 292 : 320;
        var chieuRongNoiDung = chieuRong - 16;
        var bongBong = new FlowLayoutPanel
        {
            AutoSize = false,
            BackColor = cuaToi ? Color.FromArgb(225, 240, 255) : Color.FromArgb(242, 242, 242),
            FlowDirection = FlowDirection.TopDown,
            Height = 1,
            Margin = new Padding(4, 3, 4, 3),
            Padding = new Padding(8),
            Width = chieuRong,
            WrapContents = false,
        };

        var tieuDe = new Label
        {
            AutoEllipsis = true,
            AutoSize = false,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(60, 60, 60),
            Height = 20,
            Margin = new Padding(0, 0, 0, 4),
            Text = $"{(cheDo == "PRIVATE" ? "[Riêng] " : "")}{nguoiHienThi} · {ChatHelper.GioHienTai()}",
            TextAlign = ContentAlignment.MiddleLeft,
            UseMnemonic = false,
            Width = chieuRongNoiDung,
        };
        bongBong.Controls.Add(tieuDe);

        if (laAnh)
        {
            bongBong.Height = 242;

            var pic = new PictureBox
            {
                BackColor = Color.FromArgb(232, 232, 232),
                Cursor = Cursors.Hand,
                Height = 170,
                Image = TaoAnh(duLieu),
                Margin = new Padding(0, 0, 0, 4),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 260,
            };
            pic.Click += (_, _) => TaiTep(duLieu, tenTep);
            bongBong.Controls.Add(pic);

            var goiY = new Label
            {
                AutoSize = false,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(70, 110, 170),
                Height = 20,
                Text = "Bấm vào ảnh để tải về máy",
                TextAlign = ContentAlignment.MiddleLeft,
                UseMnemonic = false,
                Width = 260,
            };
            goiY.Click += (_, _) => TaiTep(duLieu, tenTep);
            bongBong.Controls.Add(goiY);
        }
        else
        {
            var noiDungLienKet = $"Tệp: {tenTep}\nBấm để tải về máy";
            var fontLienKet = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            var kichThuocLienKet = TextRenderer.MeasureText(
                noiDungLienKet,
                fontLienKet,
                new Size(chieuRongNoiDung, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
            var chieuCaoLienKet = Math.Max(40, kichThuocLienKet.Height + 4);

            bongBong.Height = 62 + chieuCaoLienKet;

            var lienKet = new LinkLabel
            {
                AutoSize = false,
                Font = fontLienKet,
                Height = chieuCaoLienKet,
                LinkBehavior = LinkBehavior.HoverUnderline,
                LinkColor = Color.FromArgb(35, 95, 165),
                Margin = new Padding(0, 0, 0, 4),
                Text = noiDungLienKet,
                UseMnemonic = false,
                Width = chieuRongNoiDung,
            };
            lienKet.LinkClicked += (_, _) => TaiTep(duLieu, tenTep);
            bongBong.Controls.Add(lienKet);

            var kichThuoc = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 100, 100),
                Height = 18,
                Text = $"{duLieu.Length / 1024.0:F1} KB",
                TextAlign = ContentAlignment.MiddleLeft,
                UseMnemonic = false,
                Width = chieuRongNoiDung,
            };
            bongBong.Controls.Add(kichThuoc);
        }

        return bongBong;
    }

    private static Image? TaoAnh(byte[] duLieu)
    {
        try
        {
            using var luong = new MemoryStream(duLieu);
            using var hinh = Image.FromStream(luong);
            return new Bitmap(hinh);
        }
        catch
        {
            return null;
        }
    }

    private void TaiTep(byte[] duLieu, string tenTep)
    {
        using var hopThoai = new SaveFileDialog
        {
            FileName = tenTep,
            Filter = ChatHelper.LaAnh(tenTep)
                ? "Ảnh|*.jpg;*.jpeg;*.png|Tất cả tệp|*.*"
                : "Tệp văn bản|*.txt|Tất cả tệp|*.*",
            Title = "Tải tệp về máy",
        };

        var thuMucTai = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads");
        if (Directory.Exists(thuMucTai))
        {
            hopThoai.InitialDirectory = thuMucTai;
        }

        if (hopThoai.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            File.WriteAllBytes(hopThoai.FileName, duLieu);
            CapNhatTrangThai("Đã lưu tệp: " + hopThoai.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                this,
                "Không thể lưu tệp: " + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
        btnGuiTep.Enabled = daVaoPhong;
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
