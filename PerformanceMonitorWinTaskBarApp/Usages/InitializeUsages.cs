namespace PerformanceMonitorWinTaskBarApp.Usages;
public static class InitializeUsages
{
    static bool initialized = false;
    public static void TryInitialize()
    {
        if (!initialized)
        {
            initialized = true;

            CpuUsage.Initialize();
            MemoryUsage.Initialize();
            NetworkUsage.Initialize();
            GpuUsage.Initialize();
        }
    }
}
