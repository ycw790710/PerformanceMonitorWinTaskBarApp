namespace PerformanceMonitorWinTaskBarApp.Usages;
internal class UsageHandler
{
    public (string val, string unit) CpuInfo { get; private set; }
    public (string val, string unit) RamInfo { get; private set; }
    public (string sign, string value, string unit) NetworkUploadInfo { get; private set; }
    public (string sign, string value, string unit) NetworkDownloadInfo { get; private set; }

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

        CpuInfo = CpuUsage.Get();
        RamInfo = MemoryUsage.Get();
        NetworkUploadInfo = NetworkUsage.GetUpload();
        NetworkDownloadInfo = NetworkUsage.GetDownload();
    }

    public void UpdateNetwork()
    {
        NetworkUsage.UpdatePerformanceCounters();
    }
}
