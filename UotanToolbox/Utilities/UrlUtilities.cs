using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using UotanToolbox.Common;

namespace UotanToolbox.Utilities
{
    public static class UrlUtilities
    {
        public static void OpenURL(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    WorkingDirectory = Path.Combine(Global.bin_path, "platform-tools"),
                    UseShellExecute = true
                });
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Process.Start(new ProcessStartInfo
                {
                    FileName = "/usr/bin/gnome-terminal",  // ���Ը���ʵ�����ѡ����ʵ��ն˳���
                    Arguments = $"--working-directory={Path.Combine(Global.bin_path, "platform-tools", "adb")}",
                    UseShellExecute = false
                });
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                Process.Start("open", "-a Terminal " + Path.Combine(Global.bin_path, "platform-tools", "adb"));
        }
    }
}