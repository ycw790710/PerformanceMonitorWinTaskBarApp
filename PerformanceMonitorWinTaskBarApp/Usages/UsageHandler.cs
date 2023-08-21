namespace PerformanceMonitorWinTaskBarApp.Usages;
internal class UsageHandler
{
    public (string val, string unit) CpuInfo { get; private set; }

    public (string val, string unit) RamInfo { get; private set; }
    public float RamPercentVal { get; private set; }

    public (string sign, string value, string unit) NetworkUploadInfo { get; private set; }
    public (string sign, string value, string unit) NetworkDownloadInfo { get; private set; }

    public (string val, string unit) GpuMaxUsageInfo { get; private set; }
    public (string val, string unit) GpuDedicatedRamInfo { get; private set; }

    public UsageHandler()
    {
        NetworkUploadInfo = (NetworkUsage.UploadSign, "", "");
        NetworkDownloadInfo = (NetworkUsage.DownloadSign, "", "");
    }

    private void TryInitialize()
    {
        InitializeUsages.TryInitialize();
    }

    public void UpdateData()
    {
        TryInitialize();

        CpuInfo = Usages.CpuUsage.GetUsageInfo();

        RamPercentVal = MemoryUsage.GetUsageInfo().percent;
        RamInfo = MemoryUsage.GetUsedSizeInfo();

        NetworkUploadInfo = NetworkUsage.GetUploadInfo();
        NetworkDownloadInfo = NetworkUsage.GetDownloadInfo();

        GpuMaxUsageInfo = GpuUsage.GetGpuMaxUsageInfo();
        GpuDedicatedRamInfo = GpuUsage.GetGpuDedicatedMemoryUsageInfo();
    }

    public void UpdateNetwork()
    {
        NetworkUsage.UpdatePerformanceCounters();
    }

    public void Reset()
    {
        InitializeUsages.Reset();
    }
}
