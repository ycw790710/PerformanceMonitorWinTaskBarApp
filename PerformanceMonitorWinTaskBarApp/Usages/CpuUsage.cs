
using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class CpuUsage
{
    private static PerformanceCounter cpuCounter = null!;

    public static void Initialize()
    {
        cpuCounter = new("Processor", "% Processor Time", "_Total");
    }

    public static (string val, string unit) Get()
    {
        try
        {
            return (cpuCounter.NextValue().ToString("0.0"), "%");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}
