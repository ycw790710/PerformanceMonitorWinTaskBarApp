using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public class MemoryUsage
{
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
            if (_memoryUsageCounter == null)
                throw new Exception("ERROR");

            var percent = _memoryUsageCounter.NextValue();
            return (percent.ToString("0.0"), "%", percent);
        }
        catch
        {
            return ("ERR", "", 0);
        }
    }

    public static (string val, string unit) GetUsedSizeInfo()
    {
        try
        {
            if (_memoryBytesCounter == null)
                throw new Exception("ERROR");

            float totalPhysicalMemoryBytes = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            float bytes = totalPhysicalMemoryBytes - _memoryBytesCounter.NextValue();
            float gb = bytes / (1024 * 1024 * 1024);
            return (gb.ToString("0.0"), "G");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}