using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4.Bai06;

public static class ChatHelper
{
    public const string DiaChiMacDinh = "127.0.0.1";
    public const int CongMacDinh = 8083;

    public static string ChuanHoaTen(string ten) =>
        ten.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ').Replace(',', ' ').Trim();

    public static string ChuanHoaTinNhan(string noiDung) =>
        noiDung.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ').Trim();

    public static bool TenHopLe(string ten) => ten.Length is >= 1 and <= 30;

    public static string GioHienTai() => DateTime.Now.ToString("HH:mm:ss");

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

        richTextBox.AppendText($"[{GioHienTai()}] {noiDung}{Environment.NewLine}");
        richTextBox.SelectionStart = richTextBox.TextLength;
        richTextBox.ScrollToCaret();
    }

    public static void GhiChat(RichTextBox richTextBox, string noiDung)
    {
        if (richTextBox.IsDisposed || !richTextBox.IsHandleCreated)
        {
            return;
        }

        if (richTextBox.InvokeRequired)
        {
            richTextBox.BeginInvoke(() => GhiChat(richTextBox, noiDung));
            return;
        }

        var mauChu = noiDung.Contains("[Riêng]", StringComparison.Ordinal)
            ? Color.FromArgb(35, 125, 75)
            : noiDung.Contains("[Hệ thống]", StringComparison.Ordinal)
                ? Color.Gray
                : Color.FromArgb(35, 35, 35);

        richTextBox.SelectionStart = richTextBox.TextLength;
        richTextBox.SelectionLength = 0;
        richTextBox.SelectionColor = mauChu;
        richTextBox.AppendText(noiDung + Environment.NewLine);
        richTextBox.SelectionColor = richTextBox.ForeColor;
        richTextBox.ScrollToCaret();
    }
}
