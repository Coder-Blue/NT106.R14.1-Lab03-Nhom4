using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai05;

public record NguoiDung(int IDNCC, string HoVaTen, string QuyenHan);

public record MonAn(int IDMA, string TenMonAn, string HinhAnh, int IDNCC, string TenNguoiDongGop);

public static class MonAnHelper
{
    public const string DiaChiMacDinh = "127.0.0.1";
    public const int CongMacDinh = 8082;

    public static string ChuanHoa(string noiDung) =>
        noiDung.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ').Trim();

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

    public static List<string> TaoSnapshot(IEnumerable<MonAn> danhSach)
    {
        var dong = new List<string>();
        foreach (var monAn in danhSach)
        {
            dong.Add(
                $"MON\t{monAn.IDMA}\t{ChuanHoa(monAn.TenMonAn)}\t{ChuanHoa(monAn.HinhAnh)}\t{monAn.IDNCC}\t{ChuanHoa(monAn.TenNguoiDongGop)}");
        }

        dong.Add("HET");
        return dong;
    }

    public static MonAn? DocDongMon(string dong)
    {
        var phan = dong.Split('\t');
        if (phan.Length < 6 || phan[0] != "MON" ||
            !int.TryParse(phan[1], out var idMonAn) ||
            !int.TryParse(phan[4], out var idNguoiDung))
        {
            return null;
        }

        return new MonAn(idMonAn, phan[2], phan[3], idNguoiDung, phan[5]);
    }

    public static StreamReader TaoBoDoc(NetworkStream stream) =>
        new(stream, new UTF8Encoding(false), detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true);

    public static StreamWriter TaoBoGhi(NetworkStream stream) =>
        new(stream, new UTF8Encoding(false), bufferSize: 1024, leaveOpen: true)
        {
            AutoFlush = true,
            NewLine = "\n",
        };

    public static Image? TaiHinh(string duongDan)
    {
        if (!File.Exists(duongDan))
        {
            return null;
        }

        using var luong = new FileStream(duongDan, FileMode.Open, FileAccess.Read);
        using var hinh = Image.FromStream(luong);
        return new Bitmap(hinh);
    }

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
