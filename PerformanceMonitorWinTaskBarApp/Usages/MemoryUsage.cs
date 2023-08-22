using PerformanceMonitorWinTaskBarApp.Extensions;
using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public class MemoryUsage
{
    private static bool _gotError;
    private static TimeSpan? _resetTimeByError;

    private static PerformanceCounter? _memoryUsageCounter = null!;
    private static PerformanceCounter? _memoryBytesCounter = null!;

    public static void Initialize()
    {
        Clean();

        _memoryUsageCounter = new("Memory", "% Committed Bytes In Use");
        _memoryBytesCounter = new("Memory", "Available Bytes");
    }

    private static void Clean()
    {
        _gotError = false;
        _resetTimeByError = null;

        if (_memoryUsageCounter != null)
        {
            var tmp = _memoryUsageCounter;
            _memoryUsageCounter = null;
            try
            {
                tmp?.Dispose();
            }
            catch { }
        }
        if (_memoryBytesCounter != null)
        {
            var tmp = _memoryBytesCounter;
            _memoryBytesCounter = null;
            try
            {
                tmp?.Dispose();
            }
            catch { }
        }
    }

    public static (string val, string unit, float percent) GetUsageInfo()
    {
        try
        {
            TryResetIfError();

            if (_memoryUsageCounter == null)
                throw new Exception("ERROR");

            var val = _memoryUsageCounter.NextValue();
            val = (float)Math.Round(val, 1);
            return (val.ToString("0.0"), "%", val);
        }
        catch
        {
            SetError();
            return ("ERR", "", 0);
        }
    }

    public static (string val, string unit) GetUsedSizeInfo()
    {
        try
        {
            TryResetIfError();

            if (_memoryBytesCounter == null)
                throw new Exception("ERROR");

            float totalPhysicalMemoryBytes = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            float bytes = totalPhysicalMemoryBytes - _memoryBytesCounter.NextValue();
            float gb = bytes / (1024 * 1024 * 1024);
            gb = (float)Math.Round(gb, 1);
            return (gb.ToString("0.0"), "G");
        }
        catch
        {
            SetError();
            return ("ERR", "");
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