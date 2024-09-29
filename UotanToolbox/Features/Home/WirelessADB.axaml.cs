using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using SukiUI.Controls;
using System.IO;
using UotanToolbox.Common;

using UotanToolbox.Features.Components;


namespace UotanToolbox.Features.Home;

public partial class WirelessADB : SukiWindow
{
    private static string GetTranslation(string key) => FeaturesHelper.GetTranslation(key);
    public static Bitmap ConvertToBitmap(byte[] imageData)
    {
        using (var stream = new MemoryStream(imageData))
        {
            return new Bitmap(stream);
        }
    }
    public  WirelessADB()
    {
        InitializeComponent();
        QRCode.Source = ConvertToBitmap(ADBPairHelper.QRCodeInit(Global.serviceID, Global.password));
    }
    private async void WConnect(object sender, RoutedEventArgs args)
    {
        string input = IPAndPort.Text;
        string password = PairingCode.Text;
        string result = await CallExternalProgram.ADB($"pair {input} {password}");
        if (result.Contains("Successfully paired to "))
        {
            SukiHost.ShowDialog(this, new PureDialog("���ӳɹ�"), allowBackgroundClose: true);
        }
        else
        {
            SukiHost.ShowDialog(this, new ErrorDialog(result), allowBackgroundClose: true);
        }
    }
}