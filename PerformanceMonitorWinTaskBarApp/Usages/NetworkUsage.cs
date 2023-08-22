using PerformanceMonitorWinTaskBarApp.Extensions;
using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class NetworkUsage
{
    private static bool _gotError;
    private static TimeSpan? _resetTimeByError;

    public const string UploadSign = "▲";
    public const string DownloadSign = "▼";

    private static NetworkPerformanceCounters[]? _networkPerformanceCounters = null;

    private static string[] units = new string[] { " B", "KB", "MB", "GB", "TB" };

    public static void Initialize()
    {
        Clean();

        var options = GetInstanceOptions();
        _networkPerformanceCounters = options
            .Where(n => !string.IsNullOrEmpty(n))
            .Select(n => new NetworkPerformanceCounters(n))
            .ToArray();
    }

    private static void Clean()
    {
        _gotError = false;
        _resetTimeByError = null;

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
            TryResetIfError();

            return GetInfo(DownloadSign, GetDownloadValue());
        }
        catch
        {
            SetError();
            return ("", "ERR", "");
        }
    }

    public static (string sign, string value, string unit) GetUploadInfo()
    {
        try
        {
            TryResetIfError();

            return GetInfo(UploadSign, GetUploadValue());
        }
        catch
        {
            SetError();
            return ("", "ERR", "");
        }
    }

    private static float GetDownloadValue()
    {
        if (_networkPerformanceCounters == null)
            throw new Exception("ERROR");

        float val = 0;
        foreach (var networkPerformanceCounter in _networkPerformanceCounters)
        {
            if (networkPerformanceCounter == null)
                throw new Exception("ERROR");

            val += networkPerformanceCounter.GetDownloadValue();
        }
        return val;
    }

    private static float GetUploadValue()
    {
        if (_networkPerformanceCounters == null)
            throw new Exception("ERROR");

        float val = 0;
        foreach (var networkPerformanceCounter in _networkPerformanceCounters)
        {
            if (networkPerformanceCounter == null)
                throw new Exception("ERROR");

            val += networkPerformanceCounter.GetUploadValue();
        }
        return val;
    }

    private static (string sign, string value, string unit) GetInfo(string sign, float bytes)
    {
        var unitIdx = 0;
        var val = bytes;
        while (val >= 100)
        {
            val /= 1024;
            unitIdx++;
        }
        val = (float)Math.Round(val, 1);
        return (sign, val.ToString("0.0"), units[unitIdx]);
    }

    class NetworkPerformanceCounters : IDisposable
    {
        private PerformanceCounter _downloadCounter;
        private PerformanceCounter _uploadCounter;

        public NetworkPerformanceCounters(string instanceName)
        {
            _downloadCounter = new("Network Interface", "Bytes Received/sec", instanceName);
            _uploadCounter = new("Network Interface", "Bytes Sent/sec", instanceName);
        }

        public float GetDownloadValue() => _downloadCounter.NextValue();
        public float GetUploadValue() => _uploadCounter.NextValue();

        public void Dispose()
        {
            _downloadCounter.Dispose();
            _uploadCounter.Dispose();
        }
    }

    private static void TryResetIfError()
    {
        if (_gotError && _resetTimeByError.HasValue && _resetTimeByError.Value <= GlobalTimer.NowTimeSpan())
        {
            Initialize();
        }
    }

    private static void SetError()
    {
        if (!_gotError)
        {
            _gotError = true;
            _resetTimeByError = GlobalTimer.AddMillisecondsForNowTimeSpan(30 * 1000);
        }
    }

}
