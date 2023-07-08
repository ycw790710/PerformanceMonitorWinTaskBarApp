using System.Diagnostics;

namespace StatusesFormApp;
public class MemoryUsage
{
    static PerformanceCounter memCounter = new("Memory", "% Committed Bytes In Use");
    public static (string val, string unit) Get()
    {
        try
        {
            return (Math.Round(memCounter.NextValue(), 1).ToString(), "%");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}