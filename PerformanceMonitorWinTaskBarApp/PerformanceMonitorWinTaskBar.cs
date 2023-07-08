using StatusesFormApp;

namespace PerformanceMonitorWinTaskBarApp
{
    public partial class PerformanceMonitorWinTaskBar : Form
    {
        System.Windows.Forms.Timer dataTimer;
        System.Windows.Forms.Timer showTimer;
        ContextMenuStrip menuStrip;

        public PerformanceMonitorWinTaskBar()
        {
            Hide();

            InitializeComponent();

            dataTimer = new System.Windows.Forms.Timer();
            dataTimer.Interval = 1000;
            dataTimer.Tick += DataTimer_Tick;
            dataTimer.Start();

            showTimer = new System.Windows.Forms.Timer();
            showTimer.Interval = 16;
            showTimer.Tick += ShowTimer_Tick;
            showTimer.Start();

            menuStrip = new();
            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("關閉");
            closeMenuItem.Click += CloseMenuItem_Click;
            menuStrip.Items.Add(closeMenuItem);
            ContextMenuStrip = menuStrip;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowTimer_Tick(object? sender, EventArgs e)
        {
            SetFormOnTaskBar.SetForm(this);
            Show();
        }

        private void DataTimer_Tick(object? sender, EventArgs e)
        {
            var cpuInfo = CPUUsage.Get();
            labCpu.Text = cpuInfo.val;
            labCpuUnit.Text = cpuInfo.unit;

            var ramInfo = MemoryUsage.Get();
            labRam.Text = ramInfo.val;
            labRamUnit.Text = ramInfo.unit;

            var netUploadInfo = NetUsage.GetUpload();
            labNetUploadSign.Text = netUploadInfo.sign;
            labNetUpload.Text = netUploadInfo.value;
            labNetUploadUnit.Text = netUploadInfo.unit;

            var netDownloadInfo = NetUsage.GetDownload();
            labNetDownloadSign.Text = netDownloadInfo.sign;
            labNetDownload.Text = netDownloadInfo.value;
            labNetDownloadUnit.Text = netDownloadInfo.unit;
        }
    }
}