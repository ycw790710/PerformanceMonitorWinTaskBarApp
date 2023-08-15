using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class NetworkUsage
{
    public const string UploadSign = "▲";
    public const string DownloadSign = "▼";

    public static string InstanceName { get; private set; } = "";

    private static PerformanceCounter? downloadCounter;
    private static PerformanceCounter? uploadCounter;

    public static void Initialize()
    {
        SetPerformanceCounter(GetInstanceOptions().FirstOrDefault().instanceName);
    }

    public static (string sign, string value, string unit) GetDownload()
    {
        try
        {
            return GetInfo(DownloadSign, downloadCounter?.NextValue());
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
            return GetInfo(UploadSign, uploadCounter?.NextValue());
        }
        catch
        {
            return ("", "ERR", "");
        }
    }

    private static string[] units = new string[] { "B", "KB", "MB", "GB" };
    private static (string sign, string value, string unit) GetInfo(string sign, float? bytes)
    {
        var unitIdx = 0;
        var val = bytes;
        while (bytes.HasValue && val >= 1000)
        {
            val /= 1024;
            unitIdx++;
        }
        return (sign, val?.ToString("0.0") ?? "--", units[unitIdx]);
    }

    public static void SetPerformanceCounter(string instanceName)
    {
        InstanceName = instanceName ?? "";
        if (string.IsNullOrEmpty(InstanceName))
        {
            downloadCounter = null;
            uploadCounter = null;
            return;
        }
        downloadCounter = new("Network Interface", "Bytes Received/sec", InstanceName);
        uploadCounter = new("Network Interface", "Bytes Sent/sec", InstanceName);
    }

    public static IReadOnlyList<(string instanceName, string description)> GetInstanceOptions()
    {
        PerformanceCounterCategory category = new("Network Interface");
        return category.GetInstanceNames().Select(n => (n, n)).ToArray();
    }

}
