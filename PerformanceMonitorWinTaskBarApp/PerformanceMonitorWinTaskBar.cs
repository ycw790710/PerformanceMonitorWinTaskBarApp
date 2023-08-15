using PerformanceMonitorWinTaskBarApp.Extensions;
using PerformanceMonitorWinTaskBarApp.Usages;

namespace PerformanceMonitorWinTaskBarApp
{
    public partial class PerformanceMonitorWinTaskBar : Form
    {
        const int ShowTimerInterval = 500;
        const int DataTimerInterval = 1000;

        readonly System.Windows.Forms.Timer _dataTimer;
        readonly System.Windows.Forms.Timer _showTimer;
        readonly System.Windows.Forms.Timer _usageTimer;
        readonly UsageHandler _usageHandler;

        public PerformanceMonitorWinTaskBar()
        {
            InitializeComponent();

            _dataTimer = GetDataTimer();
            _showTimer = GetShowTimer();
            _usageTimer = GetUsageTimer();
            ContextMenuStrip = GetContextMenuStrip();
            _usageHandler = new();

            StartTimers();
        }

        private void StartTimers()
        {
            _dataTimer.Start();
            _showTimer.Start();
            _usageTimer.Start();
        }
        private void EndTimers()
        {
            _showTimer.Stop();
            _dataTimer.Stop();
            _usageTimer.Stop();
        }

        private System.Windows.Forms.Timer GetDataTimer()
        {
            var dataTimer = new System.Windows.Forms.Timer();
            dataTimer.Interval = DataTimerInterval;
            dataTimer.Tick += DataTimer_Tick;
            return dataTimer;
        }
        private void DataTimer_Tick(object? sender, EventArgs e)
        {
            _usageHandler.UpdateData();
        }

        private System.Windows.Forms.Timer GetShowTimer()
        {
            var showTimer = new System.Windows.Forms.Timer();
            showTimer.Interval = ShowTimerInterval;
            showTimer.Tick += ShowTimer_Tick;
            return showTimer;
        }
        private void ShowTimer_Tick(object? sender, EventArgs e)
        {
            var success = this.SetOnTaskBar();
            if (!success)
            {
                //EndTimers();
                //MessageBox.Show("Taskbar高度不足,結束程式", "效能監視器");
                //this.Close();
                return;
            }

            var top1 = this.Top;
            var left1 = this.Left;
            Show();
            var top2 = this.Top;
            var left2 = this.Left;
            if (this.Opacity != 1 && top1 == top2 && left1 == left2)
                this.Opacity = 1;

        }

        private System.Windows.Forms.Timer GetUsageTimer()
        {
            var usageTimer = new System.Windows.Forms.Timer();
            usageTimer.Interval = DataTimerInterval;
            usageTimer.Tick += UsageTimer_Tick;
            return usageTimer;
        }

        private void UsageTimer_Tick(object? sender, EventArgs e)
        {
            UpdateCpuInfo();
            UpdateMemoryInfo();
            UpdateNetworkInfo();
        }

        private ContextMenuStrip GetContextMenuStrip()
        {
            ContextMenuStrip menuStrip = new();

            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("關閉");
            closeMenuItem.Click += CloseMenuItem_Click;
            menuStrip.Items.Add(closeMenuItem);

            ToolStripMenuItem updateNetworkMenuItem = new ToolStripMenuItem("更新網路卡");
            updateNetworkMenuItem.Click += UpdateNetworkMenuItem_Click;
            menuStrip.Items.Add(updateNetworkMenuItem);

            return menuStrip;
        }

        private void CloseMenuItem_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateNetworkMenuItem_Click(object? sender, EventArgs e)
        {
            _usageHandler.UpdateNetwork();
        }

        private void UpdateCpuInfo()
        {
            FitFontSizeInControl(() =>
            {
                labCpu.Text = _usageHandler.CpuInfo.val;
                labCpuUnit.Text = _usageHandler.CpuInfo.unit;
            }, labCpu);
        }
        private void UpdateMemoryInfo()
        {
            FitFontSizeInControl(() =>
            {
                labRam.Text = _usageHandler.RamInfo.val;
                labRamUnit.Text = _usageHandler.RamInfo.unit;
            }, labRam);
        }
        private void UpdateNetworkInfo()
        {
            // TODO: update
            FitFontSizeInControl(() =>
            {
                labNetUploadName.Text = _usageHandler.NetworkUploadInfo.sign;
                labNetUpload.Text = _usageHandler.NetworkUploadInfo.value;
                labNetUploadUnit.Text = _usageHandler.NetworkUploadInfo.unit;

                labNetDownloadName.Text = _usageHandler.NetworkDownloadInfo.sign;
                labNetDownload.Text = _usageHandler.NetworkDownloadInfo.value;
                labNetDownloadUnit.Text = _usageHandler.NetworkDownloadInfo.unit;
            }, labNetUpload, labNetUploadUnit, labNetDownload, labNetDownloadUnit);
        }

        private void FitFontSizeInControl(Action action, params Label[]? labels)
        {
            if (labels != null)
                foreach (var label in labels)
                    label.SuspendLayout();

            action?.Invoke();

            if (labels != null)
            {
                foreach (var label in labels)
                    label.FitFontSize();

                foreach (var label in labels)
                    label.ResumeLayout();
            }
        }
    }
}