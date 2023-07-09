using PerformanceMonitorWinTaskBarApp.Controls;
using PerformanceMonitorWinTaskBarApp.Extensions;
using PerformanceMonitorWinTaskBarApp.Usages;

namespace PerformanceMonitorWinTaskBarApp
{
    public partial class PerformanceMonitorWinTaskBar : Form
    {
        readonly System.Windows.Forms.Timer _dataTimer;
        readonly System.Windows.Forms.Timer _showTimer;
        readonly NetworkMenuOptions _networkMenuOptions;

        public PerformanceMonitorWinTaskBar()
        {
            InitializeComponent();

            _dataTimer = GetDataTimer();
            _showTimer = GetShowTimer();
            ContextMenuStrip = GetContextMenuStrip();
            _networkMenuOptions = new(ContextMenuStrip);

            this.SetOnTaskBar();

            InitializeUsages.Initialize();
        }

        private System.Windows.Forms.Timer GetDataTimer()
        {
            var dataTimer = new System.Windows.Forms.Timer();
            dataTimer.Interval = 1000;
            dataTimer.Tick += DataTimer_Tick;
            dataTimer.Start();
            return dataTimer;
        }
        private void DataTimer_Tick(object? sender, EventArgs e)
        {
            _networkMenuOptions.UpdateNetworkOptions();

            UpdateCpuInfo();
            UpdateMemoryInfo();
            UpdateNetworkInfo();
        }

        private System.Windows.Forms.Timer GetShowTimer()
        {
            var showTimer = new System.Windows.Forms.Timer();
            showTimer.Interval = 16;
            showTimer.Tick += ShowTimer_Tick;
            showTimer.Start();
            return showTimer;
        }
        private void ShowTimer_Tick(object? sender, EventArgs e)
        {
            this.SetOnTaskBar();
            Show();
        }

        private ContextMenuStrip GetContextMenuStrip()
        {
            ContextMenuStrip menuStrip = new();
            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("關閉");
            closeMenuItem.Click += CloseMenuItem_Click;
            menuStrip.Items.Add(closeMenuItem);
            return menuStrip;
        }
        private void CloseMenuItem_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCpuInfo()
        {
            var cpuInfo = CpuUsage.Get();
            labCpu.Text = cpuInfo.val;
            labCpuUnit.Text = cpuInfo.unit;

            labCpu.FitFontSize();
        }
        private void UpdateMemoryInfo()
        {
            var ramInfo = MemoryUsage.Get();
            labRam.Text = ramInfo.val;
            labRamUnit.Text = ramInfo.unit;

            labRam.FitFontSize();
        }
        private void UpdateNetworkInfo()
        {
            var networkUploadInfo = NetworkUsage.GetUpload();
            labNetUploadName.Text = networkUploadInfo.sign;
            labNetUpload.Text = networkUploadInfo.value;
            labNetUploadUnit.Text = networkUploadInfo.unit;

            labNetUpload.FitFontSize();
            labNetUploadUnit.FitFontSize();

            var netDownloadInfo = NetworkUsage.GetDownload();
            labNetDownloadName.Text = netDownloadInfo.sign;
            labNetDownload.Text = netDownloadInfo.value;
            labNetDownloadUnit.Text = netDownloadInfo.unit;

            labNetDownload.FitFontSize();
            labNetDownloadUnit.FitFontSize();
        }
    }
}