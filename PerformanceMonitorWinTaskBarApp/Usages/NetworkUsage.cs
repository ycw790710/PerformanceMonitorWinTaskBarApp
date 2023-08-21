using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class NetworkUsage
{
    public const string UploadSign = "▲";
    public const string DownloadSign = "▼";

    private static NetworkPerformanceCounters[]? _networkPerformanceCounters = null;

    public static void Initialize()
    {
        Clean();

        var options = GetInstanceOptions();
        _networkPerformanceCounters =
            options.Select(n => new NetworkPerformanceCounters(n)).ToArray();
    }

    private static void Clean()
    {
        if (_networkPerformanceCounters != null)
        {
            var tmp = _networkPerformanceCounters;
            _networkPerformanceCounters = null;
            foreach (var counter in tmp)
            {
                try
                {
                    counter?.Dispose();
                }
                catch { }
            }
        }
    }

    private static IReadOnlyList<string> GetInstanceOptions()
    {
        PerformanceCounterCategory category = new("Network Interface");
        return category.GetInstanceNames();
    }

    public static (string sign, string value, string unit) GetDownloadInfo()
    {
        try
        {
            return GetInfo(DownloadSign, GetDownloadValue());
        }
        catch
        {
            return ("", "ERR", "");
        }
    }

    public static (string sign, string value, string unit) GetUploadInfo()
    {
        try
        {
            return GetInfo(UploadSign, GetUploadValue());
        }
        catch
        {
            return ("", "ERR", "");
        }
    }

    public static float? GetDownloadValue()
    {
        if (_networkPerformanceCounters == null)
            return null;

        float? val = 0;
        try
        {
            foreach (var networkPerformanceCounter in _networkPerformanceCounters)
            {
                if (networkPerformanceCounter == null)
                    continue;
                val += networkPerformanceCounter.GetDownloadValue().GetValueOrDefault();
            }
        }
        catch
        {
            val = null;
        }
        return val;
    }
    public static float? GetUploadValue()
    {
        if (_networkPerformanceCounters == null)
            return null;

        float? val = 0;
        try
        {
            foreach (var networkPerformanceCounter in _networkPerformanceCounters)
            {
                if (networkPerformanceCounter == null)
                    continue;
                val += networkPerformanceCounter.GetUploadValue().GetValueOrDefault();
            }
        }
        catch
        {
            val = null;
        }
        return val;
    }

    private static string[] units = new string[] { "B", "KB", "MB", "GB" };
    private static (string sign, string value, string unit) GetInfo(string sign, float? bytes)
    {
        var unitIdx = 0;
        var val = bytes;
        while (val.HasValue && val >= 1000)
        {
            val /= 1024;
            unitIdx++;
        }
        return (sign, val?.ToString("0.0") ?? "--", units[unitIdx]);
    }

    class NetworkPerformanceCounters : IDisposable
    {
        private PerformanceCounter? _downloadCounter;
        private PerformanceCounter? _uploadCounter;

        public NetworkPerformanceCounters(string instanceName)
        {
            if (string.IsNullOrEmpty(instanceName))
            {
                _downloadCounter = null;
                _uploadCounter = null;
                return;
            }
            _downloadCounter = new("Network Interface", "Bytes Received/sec", instanceName);
            _uploadCounter = new("Network Interface", "Bytes Sent/sec", instanceName);
        }

        public float? GetDownloadValue() => _downloadCounter?.NextValue();
        public float? GetUploadValue() => _uploadCounter?.NextValue();

        public void Dispose()
        {
            _downloadCounter?.Dispose();
            _uploadCounter?.Dispose();
        }
    }
}
