using PerformanceMonitorWinTaskBarApp.Extensions;
using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class CpuUsage
{
    private static bool _gotError;
    private static TimeSpan? _resetTimeByError;

    private static PerformanceCounter? _cpuCounter = null!;

    public static void Initialize()
    {
        Clean();

        try
        {
            _cpuCounter = new("Processor", "% Processor Time", "_Total");
        }
        catch
        {
            //
        }
    }

    private static void Clean()
    {
        ResetError();

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
            TryResetIfError();

            if (_cpuCounter == null)
                throw new Exception("ERROR");

            var val = _cpuCounter.NextValue();
            val = (float)Math.Round(val, 1);

            var res = (val.ToString("0.0"), "%");
            ResetError();
            return res;
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
