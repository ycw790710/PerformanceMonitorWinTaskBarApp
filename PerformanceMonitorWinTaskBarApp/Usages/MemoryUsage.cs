using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public class MemoryUsage
{
    private static PerformanceCounter memCounter = null!;

    public static void Initialize()
    {
        memCounter = new("Memory", "% Committed Bytes In Use");
    }

    public static (string val, string unit) Get()
    {
        try
        {
            return (memCounter.NextValue().ToString("0.0"), "%");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}