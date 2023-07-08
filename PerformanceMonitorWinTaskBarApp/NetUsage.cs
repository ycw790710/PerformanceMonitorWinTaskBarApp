using System.Diagnostics;
using System.Net.NetworkInformation;

namespace StatusesFormApp;
public static class NetUsage
{
    private static PerformanceCounter downloadCounter
        = new("Network Interface", "Bytes Received/sec", GetExternalNetworkInterface());
    private static PerformanceCounter uploadCounter
        = new("Network Interface", "Bytes Sent/sec", GetExternalNetworkInterface());


    public static (string sign, string value, string unit) GetDownload()
    {

        try
        {
            return GetSpeedStr("▼", downloadCounter.NextValue() / 1024);
        }
        catch
        {
            return ("", "ERR", "");
        }
    }

    private static (string sign, string value, string unit) GetSpeedStr(string sign, float kBytes)
    {
        var unit = "KB";
        if (kBytes >= 1000)
        {
            kBytes /= 1024;
            unit = "MB";
        }
        return (sign, Math.Round(kBytes, 2).ToString(), unit);
    }

    public static (string sign, string value, string unit) GetUpload()
    {
        try
        {
            return GetSpeedStr("▲", uploadCounter.NextValue() / 1024);
        }
        catch
        {
            return ("", "ERR", "");
        }
    }

    private static string GetExternalNetworkInterface()
    {
        PerformanceCounterCategory category = new("Network Interface");
        var instancenames = category.GetInstanceNames();

        var interfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface networkInterface in interfaces)
        {
            if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
            {
                foreach (var instancename in instancenames)
                {
                    var a = ReplaceSymbols(instancename);
                    var b = ReplaceSymbols(networkInterface.Description);
                    if (a.StartsWith(b))
                        return instancename;
                }
            }
        }
        return null;
    }
    private static string ReplaceSymbols(string str)
    {
        return new string(str.ToArray().Select(n => char.IsLetterOrDigit(n) ? n : ' ').ToArray());
    }
}
