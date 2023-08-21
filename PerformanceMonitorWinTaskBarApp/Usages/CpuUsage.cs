﻿using PerformanceMonitorWinTaskBarApp.Extensions;
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

        _cpuCounter = new("Processor", "% Processor Time", "_Total");
    }

    private static void Clean()
    {
        _gotError = false;
        _resetTimeByError = null;

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

            return (_cpuCounter.NextValue().ToString("0.0"), "%");
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
