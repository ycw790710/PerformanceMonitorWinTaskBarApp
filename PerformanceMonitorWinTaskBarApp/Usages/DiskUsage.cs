using PerformanceMonitorWinTaskBarApp.Extensions;
using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;

public static class DiskUsage
{
    private static bool _gotError;
    private static TimeSpan? _resetTimeByError;

    private static PerformanceCounter? _diskReadBytesCounter = null!;
    private static PerformanceCounter? _diskWriteBytesCounter = null!;

    private static string[] units = new string[] { " B", "KB", "MB", "GB", "TB" };

    public static void Initialize()
    {
        Clean();

        try
        {
            _diskReadBytesCounter = new("PhysicalDisk", "Disk Read Bytes/sec", "_Total");
            _diskWriteBytesCounter = new("PhysicalDisk", "Disk Write Bytes/sec", "_Total");
        }
        catch
        {
            //
        }
    }

    private static void Clean()
    {
        ResetError();

        if (_diskReadBytesCounter != null)
        {
            var tmp = _diskReadBytesCounter;
            _diskReadBytesCounter = null;
            try
            {
                tmp?.Dispose();
            }
            catch { }
        }

        if (_diskWriteBytesCounter != null)
        {
            var tmp = _diskWriteBytesCounter;
            _diskWriteBytesCounter = null;
            try
            {
                tmp?.Dispose();
            }
            catch { }
        }
    }

    public static (string val, string unit) GetReadInfo()
    {
        try
        {
            TryResetIfError();

            if (_diskReadBytesCounter == null)
                throw new Exception("ERROR");

            var res = GetInfo(_diskReadBytesCounter.NextValue());
            ResetError();
            return res;
        }
        catch
        {
            SetError();
            return ("ERR", "");
        }
    }

    public static (string val, string unit) GetWriteInfo()
    {
        try
        {
            TryResetIfError();

            if (_diskWriteBytesCounter == null)
                throw new Exception("ERROR");

            var res = GetInfo(_diskWriteBytesCounter.NextValue());
            ResetError();
            return res;
        }
        catch
        {
            SetError();
            return ("ERR", "");
        }
    }

    private static (string value, string unit) GetInfo(float bytes)
    {
        var unitIdx = 0;
        var val = bytes;
        while (val >= 100)
        {
            val /= 1024;
            unitIdx++;
        }
        val = (float)Math.Round(val, 1);

        return (val.ToString("0.0"), units[unitIdx]);
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
            Initialize();

            _gotError = true;
            _resetTimeByError = GlobalTimer.AddMillisecondsForNowTimeSpan(30 * 1000);
        }
    }

    private static void ResetError()
    {
        _gotError = false;
        _resetTimeByError = null;
    }
}