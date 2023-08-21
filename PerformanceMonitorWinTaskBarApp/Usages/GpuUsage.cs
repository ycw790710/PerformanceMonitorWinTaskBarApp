using System.Diagnostics;

namespace PerformanceMonitorWinTaskBarApp.Usages;

public static class GpuUsage
{
    private static IReadOnlyList<PerformanceCounter>? _gpuCounters;
    private static IReadOnlyList<PerformanceCounter>? _gpuDedicatedMemoryCounters;

    public static void Initialize()
    {
        Clean();

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

    private static void Clean()
    {
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
            if (_gpuCounters == null)
                throw new Exception("");

            float maxUsage = 0;
            foreach (var gpuCounter in _gpuCounters)
            {
                maxUsage = Math.Max(maxUsage, gpuCounter.NextValue());
            }
            return (maxUsage.ToString("0.0"), "%");
        }
        catch
        {
            return ("ERR", "");
        }
    }

    public static (string val, string unit) GetGpuDedicatedMemoryUsageInfo()
    {
        try
        {
            if (_gpuDedicatedMemoryCounters == null)
                throw new Exception("");

            float bytes = 0;
            foreach (var gpuDedicatedMemoryCounter in _gpuDedicatedMemoryCounters)
            {
                bytes += gpuDedicatedMemoryCounter.NextValue();
            }
            var gb = bytes / 1024 / 1024 / 1024;
            return (gb.ToString("0.0"), "G");
        }
        catch
        {
            return ("ERR", "");
        }
    }
}