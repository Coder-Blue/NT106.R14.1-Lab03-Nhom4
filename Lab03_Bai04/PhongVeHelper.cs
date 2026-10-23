using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai04;

public record PhongVe(string TenPhim, int GiaVeChuan, int PhongChieu);

public record PhongVeTrangThai(string TenPhim, int GiaVeChuan, int PhongChieu, HashSet<string> GheDaBan);

public record VeDaDat(DateTime ThoiGian, string KhachHang, string TenPhim, int PhongChieu, string Ghe, int TongTien);

public record ThongKePhim(string TenPhim, int SoVeBan, int SoVeTon, double TiLe, int DoanhThu, int XepHang);

public static class PhongVeHelper
{
    public const string DiaChiMacDinh = "127.0.0.1";
    public const int CongMacDinh = 8081;

    public static readonly string[] TatCaGhe =
    {
        "A1", "A2", "A3", "A4", "A5",
        "B1", "B2", "B3", "B4", "B5",
        "C1", "C2", "C3", "C4", "C5",
    };

    public static string Khoa(string tenPhim, int phongChieu) => $"{tenPhim}|{phongChieu}";

    public static string ChuanHoa(string noiDung) =>
        noiDung.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ').Trim();

    public static double HeSoGhe(string ghe) => ghe switch
    {
        "A1" or "A5" or "C1" or "C5" => 0.25,
        "B2" or "B3" or "B4" => 2.0,
        _ => 1.0,
    };

    public static int TinhTien(int giaVeChuan, string ghe) =>
        (int)Math.Round(giaVeChuan * HeSoGhe(ghe), MidpointRounding.AwayFromZero);

    public static int TinhTien(int giaVeChuan, IEnumerable<string> danhSachGhe) =>
        danhSachGhe.Sum(ghe => TinhTien(giaVeChuan, ghe));

    public static (bool HopLe, IPEndPoint? DiemCuoi) DocDiemCuoi(string diaChi, string cong)
    {
        if (!IPAddress.TryParse(diaChi.Trim(), out var ipAddress))
        {
            return (false, null);
        }

        if (!int.TryParse(cong.Trim(), out var port) || port is < 1 or > 65535)
        {
            return (false, null);
        }

        return (true, new IPEndPoint(ipAddress, port));
    }

    public static List<PhongVe> DocInput5(string duongDan)
    {
        var ketQua = new List<PhongVe>();
        if (!File.Exists(duongDan))
        {
            return ketQua;
        }

        var dong = File.ReadAllLines(duongDan)
            .Select(line => line.Trim())
            .Where(line => line.Length > 0)
            .ToArray();

        for (var i = 0; i + 2 < dong.Length; i += 3)
        {
            if (!int.TryParse(dong[i + 1], out var giaVe) ||
                !int.TryParse(dong[i + 2], out var phongChieu))
            {
                continue;
            }

            ketQua.Add(new PhongVe(dong[i], giaVe, phongChieu));
        }

        return ketQua;
    }

    public static void GhiInput5(string duongDan, IEnumerable<PhongVe> danhSach)
    {
        var dong = new List<string>();
        foreach (var phongVe in danhSach)
        {
            dong.Add(phongVe.TenPhim);
            dong.Add(phongVe.GiaVeChuan.ToString());
            dong.Add(phongVe.PhongChieu.ToString());
        }

        File.WriteAllLines(duongDan, dong, new UTF8Encoding(false));
    }

    public static List<PhongVe> TaoDuLieuMacDinh() =>
    [
        new PhongVe("Bố Già", 90000, 1),
        new PhongVe("Bố Già", 90000, 2),
        new PhongVe("Mai", 100000, 1),
        new PhongVe("Mai", 100000, 2),
        new PhongVe("Dune: Hành Tinh Cát", 120000, 1),
        new PhongVe("Lật Mặt 7", 80000, 1),
    ];

    public static List<string> TaoSnapshot(
        IEnumerable<PhongVe> danhSachPhongVe,
        Dictionary<string, HashSet<string>> gheDaBan)
    {
        var dong = new List<string>();
        foreach (var phongVe in danhSachPhongVe)
        {
            var ghe = gheDaBan.TryGetValue(Khoa(phongVe.TenPhim, phongVe.PhongChieu), out var daBan)
                ? string.Join(",", daBan.OrderBy(g => g, StringComparer.Ordinal))
                : "";

            dong.Add($"PHONG\t{ChuanHoa(phongVe.TenPhim)}\t{phongVe.GiaVeChuan}\t{phongVe.PhongChieu}\t{ghe}");
        }

        dong.Add("HET");
        return dong;
    }

    public static PhongVeTrangThai? DocDongPhong(string dong)
    {
        var phan = dong.Split('\t');
        if (phan.Length < 5 || phan[0] != "PHONG" ||
            !int.TryParse(phan[2], out var giaVe) ||
            !int.TryParse(phan[3], out var phongChieu))
        {
            return null;
        }

        var gheDaBan = phan[4]
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return new PhongVeTrangThai(phan[1], giaVe, phongChieu, gheDaBan);
    }

    public static StreamReader TaoBoDoc(NetworkStream stream) =>
        new(stream, new UTF8Encoding(false), detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true);

    public static StreamWriter TaoBoGhi(NetworkStream stream) =>
        new(stream, new UTF8Encoding(false), bufferSize: 1024, leaveOpen: true)
        {
            AutoFlush = true,
            NewLine = "\n",
        };

    public static void GhiNhatKy(RichTextBox richTextBox, string noiDung)
    {
        if (richTextBox.IsDisposed || !richTextBox.IsHandleCreated)
        {
            return;
        }

        if (richTextBox.InvokeRequired)
        {
            richTextBox.BeginInvoke(() => GhiNhatKy(richTextBox, noiDung));
            return;
        }

        richTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {noiDung}{Environment.NewLine}");
        richTextBox.SelectionStart = richTextBox.TextLength;
        richTextBox.ScrollToCaret();
    }
}
