using System.Net;
using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4.Bai01;

public static class UdpHelper
{
    public const int CongMacDinh = 8080;

    public static bool DocCong(string cong, out int port) =>
        int.TryParse(cong.Trim(), out port) && port is >= 1 and <= 65535;

    public static (bool HopLe, IPEndPoint? DiemCuoi) DocDiemCuoi(string diaChi, string cong)
    {
        if (!IPAddress.TryParse(diaChi.Trim(), out var ipAddress) || !DocCong(cong, out var port))
        {
            return (false, null);
        }

        return (true, new IPEndPoint(ipAddress, port));
    }

    public static string LayIpv4()
    {
        try
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .FirstOrDefault(diaChi => diaChi.AddressFamily == AddressFamily.InterNetwork)?.ToString()
                ?? "127.0.0.1";
        }
        catch (SocketException)
        {
            return "127.0.0.1";
        }
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
