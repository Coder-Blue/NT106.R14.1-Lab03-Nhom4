using System.Net;
using System.Net.Sockets;

namespace NT106.R14._1_Lab03_Nhom4.Bai02;

public static class TelnetHelper
{
    public const int CongMacDinh = 8080;

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
