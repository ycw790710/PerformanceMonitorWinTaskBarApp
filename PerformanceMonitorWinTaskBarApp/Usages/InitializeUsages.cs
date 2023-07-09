namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class InitializeUsages
{
    public static void Initialize()
    {
        CpuUsage.Initialize();
        MemoryUsage.Initialize();
        NetworkUsage.Initialize();
    }
}
