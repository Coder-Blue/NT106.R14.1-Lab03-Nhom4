using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NT106.R14._1_Lab03_Nhom4;

public static class TcpHelper
{
    public const string DiaChiMacDinh = "127.0.0.1";
    public const int CongMacDinh = 8080;

    public static (bool HopLe, IPEndPoint? DiemCuoi) DocDiemCuoi(string diaChi, string cong)
    {
        var diaChiDaNhap = diaChi.Trim();
        var congDaNhap = cong.Trim();

        if (!IPAddress.TryParse(diaChiDaNhap, out var ipAddress))
        {
            return (false, null);
        }

        if (!int.TryParse(congDaNhap, out var port) || port is < 1 or > 65535)
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

        richTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {noiDung}{Environment.NewLine}");
        richTextBox.SelectionStart = richTextBox.TextLength;
        richTextBox.ScrollToCaret();
    }
}
