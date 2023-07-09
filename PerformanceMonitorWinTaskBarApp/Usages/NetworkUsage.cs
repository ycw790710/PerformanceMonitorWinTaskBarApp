using System.Diagnostics;
using System.Net.NetworkInformation;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class NetworkUsage
{
    public const string UploadSign = "▲";
    public const string DownloadSign = "▼";

    public static string InstanceName { get; private set; } = "";

    private static PerformanceCounter downloadCounter = null!;
    private static PerformanceCounter uploadCounter = null!;

    public static void Initialize()
    {
        InstanceName = GetInstanceOptions().First().instanceName;
        downloadCounter = new("Network Interface", "Bytes Received/sec", InstanceName);
        uploadCounter = new("Network Interface", "Bytes Sent/sec", InstanceName);
    }

    public static (string sign, string value, string unit) GetDownload()
    {

        try
        {
            return GetInfo(DownloadSign, downloadCounter.NextValue());
        }
        catch
        {
            return ("", "ERR", "");
        }
    }

    public static (string sign, string value, string unit) GetUpload()
    {
        try
        {
            return GetInfo(UploadSign, uploadCounter.NextValue());
        }
        catch
        {
            return ("", "ERR", "");
        }
    }

    private static string[] units = new string[] { "B", "KB", "MB", "GB" };
    private static (string sign, string value, string unit) GetInfo(string sign, float bytes)
    {
        var unitIdx = 0;
        var val = bytes;
        while (val >= 1000)
        {
            val /= 1024;
            unitIdx++;
        }
        return (sign, val.ToString("0.0"), units[unitIdx]);
    }

    public static void SetPerformanceCounter(string instanceName)
    {
        InstanceName = instanceName ?? "";
        downloadCounter = new("Network Interface", "Bytes Received/sec", InstanceName);
        uploadCounter = new("Network Interface", "Bytes Sent/sec", InstanceName);
    }

    public static IReadOnlyList<(string instanceName, string description)> GetInstanceOptions()
    {
        PerformanceCounterCategory category = new("Network Interface");

        (string instanceName, string comparingName)[] instanceNames =
            category.GetInstanceNames().Select(n => (n, KeepLetterOrDigits(n))).ToArray();

        List<(string instanceName, string description)> availableInstanceNames = new();
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var networkInterface in networkInterfaces)
            if (IsAvailableNetworkInterface(networkInterface))
                foreach (var instancename in instanceNames)
                    if (instancename.comparingName == KeepLetterOrDigits(networkInterface.Description))
                        availableInstanceNames.Add((instancename.instanceName, networkInterface.Description));

        return availableInstanceNames.ToList();
    }

    private static bool IsAvailableNetworkInterface(NetworkInterface? networkInterface)
    {
        return networkInterface != null &&
                networkInterface.OperationalStatus == OperationalStatus.Up &&
                networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel;
    }
    private static string KeepLetterOrDigits(string str)
    {
        return new string(str.ToArray().Where(n => char.IsLetterOrDigit(n)).ToArray());
    }
}
