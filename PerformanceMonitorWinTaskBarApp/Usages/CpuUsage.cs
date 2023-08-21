
using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class CpuUsage
{
    private static PerformanceCounter? _cpuCounter = null!;

    public static void Initialize()
    {
        Clean();

        _cpuCounter = new("Processor", "% Processor Time", "_Total");
    }

    private static void Clean()
    {
        if (_cpuCounter != null)
        {
            var tmp = _cpuCounter;
            _cpuCounter = null;
            try
            {
                tmp?.Dispose();
            }
            catch { }
        }
    }

    public static (string val, string unit) GetUsageInfo()
    {
        try
        {
            if (_cpuCounter == null)
                throw new Exception("ERROR");

            return (_cpuCounter.NextValue().ToString("0.0"), "%");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}
