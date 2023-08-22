using PerformanceMonitorWinTaskBarApp.Extensions;
using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;

public static class GpuUsage
{
    private static bool _gotError;
    private static TimeSpan? _resetTimeByError;

    private static IReadOnlyList<PerformanceCounter>? _gpuCounters;
    private static IReadOnlyList<PerformanceCounter>? _gpuDedicatedMemoryCounters;

    public static void Initialize()
    {
        Clean();

        try
        {
            var gpuCounters = new List<PerformanceCounter>();
            foreach (var instanceName in new PerformanceCounterCategory("GPU Engine").GetInstanceNames())
            {
                var counter = new PerformanceCounter("GPU Engine", "Utilization Percentage", instanceName);
                gpuCounters.Add(counter);
            }
            _gpuCounters = gpuCounters;

            var gpuDedicatedMemoryCounters = new List<PerformanceCounter>();
            foreach (var instanceName in new PerformanceCounterCategory("GPU Adapter Memory").GetInstanceNames())
            {
                var counter = new PerformanceCounter("GPU Adapter Memory", "Dedicated Usage", instanceName);
                gpuDedicatedMemoryCounters.Add(counter);
            }
            _gpuDedicatedMemoryCounters = gpuDedicatedMemoryCounters;
        }
        catch 
        {
            //
        };
    }

    private static void Clean()
    {
        ResetError();

        if (_gpuCounters != null)
        {
            var tmp = _gpuCounters;
            _gpuCounters = null;
            foreach (var counter in tmp)
            {
                try
                {
                    counter?.Dispose();
                }
                catch { }
            }
        }
        if (_gpuDedicatedMemoryCounters != null)
        {
            var tmp = _gpuDedicatedMemoryCounters;
            _gpuDedicatedMemoryCounters = null;
            foreach (var counter in tmp)
            {
                try
                {
                    counter?.Dispose();
                }
                catch { }
            }
        }
    }

    public static (string val, string unit) GetGpuMaxUsageInfo()
    {
        try
        {
            TryResetIfError();

            if (_gpuCounters == null)
                throw new Exception("");

            float maxUsage = 0;
            foreach (var gpuCounter in _gpuCounters)
            {
                maxUsage = Math.Max(maxUsage, gpuCounter.NextValue());
            }
            maxUsage = (float)Math.Round(maxUsage, 1);

            var res = (maxUsage.ToString("0.0"), "%");
            ResetError();
            return res;
        }
        catch
        {
            SetError();
            return ("ERR", "");
        }
    }

    public static (string val, string unit) GetGpuDedicatedMemoryUsageInfo()
    {
        try
        {
            TryResetIfError();

            if (_gpuDedicatedMemoryCounters == null)
                throw new Exception("");

            float bytes = 0;
            foreach (var gpuDedicatedMemoryCounter in _gpuDedicatedMemoryCounters)
            {
                bytes += gpuDedicatedMemoryCounter.NextValue();
            }
            var gb = bytes / 1024 / 1024 / 1024;
            gb = (float)Math.Round(gb, 1);

            var res = (gb.ToString("0.0"), "G");
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