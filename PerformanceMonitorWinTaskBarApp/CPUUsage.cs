
using System.Diagnostics;

namespace StatusesFormApp;
public static class CPUUsage
{
    static PerformanceCounter cpuCounter = new("Processor", "% Processor Time", "_Total");
    public static (string val, string unit) Get()
    {
        try
        {
            return (Math.Round(cpuCounter.NextValue(), 1).ToString(), "%");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}
