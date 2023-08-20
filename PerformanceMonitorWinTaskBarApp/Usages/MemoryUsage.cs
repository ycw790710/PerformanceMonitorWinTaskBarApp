using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public class MemoryUsage
{
    private static PerformanceCounter ramUsageCounter = null!;
    private static PerformanceCounter ramBytesCounter = null!;

    public static void Initialize()
    {
        ramUsageCounter = new("Memory", "% Committed Bytes In Use");
        ramBytesCounter = new("Memory", "Available Bytes");
    }

    public static (string val, string unit, float percent) GetUsageInfo()
    {
        try
        {
            var percent = ramUsageCounter.NextValue();
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
            float totalPhysicalMemoryBytes = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            float bytes = totalPhysicalMemoryBytes - ramBytesCounter.NextValue();
            float gb = bytes / (1024 * 1024 * 1024);
            return (gb.ToString("0.0"), "G");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}