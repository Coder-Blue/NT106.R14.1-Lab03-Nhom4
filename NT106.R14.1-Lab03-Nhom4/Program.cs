namespace NT106.R14._1_Lab03_Nhom4;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormChinh());
    }
}
