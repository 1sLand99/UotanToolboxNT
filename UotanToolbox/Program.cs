﻿using Avalonia;
using Avalonia.Media;
using ShowMeTheXaml;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using UotanToolbox.Common;

namespace UotanToolbox;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        Global.runpath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);//获取工具运行路径
        Global.bin_path = Path.Combine(Global.runpath, "bin", Global.System);
    FontManagerOptions options = new();
        if (OperatingSystem.IsLinux())
        {
            FileHelper.CopyDirectory("SukiUI/CustomFont/","/home/localhost/.local/share/fonts/");
            options.DefaultFamilyName = "MiSans";
            if(RuntimeInformation.OSArchitecture == Architecture.X64)
            {
                Global.System = "Linux_AMD64";
            }
            else if (RuntimeInformation.OSArchitecture == Architecture.Arm64)
            {
                Global.System = "Linux_AArch64";
            }
            else if (RuntimeInformation.OSArchitecture == Architecture.LoongArch64)
            {
                Global.System = "Linux_LoongArch64";
            }
        }
        else if (OperatingSystem.IsMacOS())
        {
            Global.System = "macOS";
            options.DefaultFamilyName = "MiSans";
        }
        // No need to set default for Windows
        return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .UseXamlDisplay()
                .With(options);
    }
}