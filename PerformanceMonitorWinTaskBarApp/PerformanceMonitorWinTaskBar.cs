using Microsoft.Win32;
using PerformanceMonitorWinTaskBarApp.Extensions;
using PerformanceMonitorWinTaskBarApp.Usages;

namespace PerformanceMonitorWinTaskBarApp
{
    public partial class PerformanceMonitorWinTaskBar : Form
    {
        private bool notified;
        private bool heightIsEnough;
        private SessionSwitchReason reason;
        private readonly UsageHandler _usageHandler;
        private bool _mouseInForm;
        private DateTime _setTransparentDateTime;

        const int AdjustFormTimerInterval = 500;
        const int UpdateDataTimerInterval = 1000;
        const int UpdateUsageTimerInterval = 1000;
        const int DetectMouseTimerInterval = 100;

        readonly System.Windows.Forms.Timer _adjustFormTimer;
        readonly System.Windows.Forms.Timer _updateDataTimer;
        readonly System.Windows.Forms.Timer _updateDisplayTimer;
        readonly System.Windows.Forms.Timer _detectMouseTimer;

        public PerformanceMonitorWinTaskBar()
        {
            InitializeComponent();
            this.Visible = false;

            notified = false;
            SetUserSessionSwitchChangeEvent();
            heightIsEnough = false;
            _usageHandler = new();
            _mouseInForm = false;
            _setTransparentDateTime = DateTime.MinValue;

            _adjustFormTimer = GetAdjustFormTimer();
            _updateDataTimer = GetUpdateDataTimer();
            _updateDisplayTimer = GetUpdateDisplayTimer();
            _detectMouseTimer = GetDetectMouseTimer();
            ContextMenuStrip = GetContextMenuStrip();

            StartTimers();

            this.Visible = true;
        }

        private void SetUserSessionSwitchChangeEvent()
        {
            reason = SessionSwitchReason.SessionUnlock;
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            reason = e.Reason;
        }

        private System.Windows.Forms.Timer GetAdjustFormTimer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = AdjustFormTimerInterval;
            timer.Tick += AdjustFormTimer_Tick;
            return timer;
        }
        private void AdjustFormTimer_Tick(object? sender, EventArgs e)
        {
            heightIsEnough = this.SetOnTaskBar();
            if (!heightIsEnough)
            {
                if (!notified)
                {
                    SpinWait.SpinUntil(() => false, 1000);
                    if (!notified && reason == SessionSwitchReason.SessionUnlock)
                    {
                        notified = true;
                        MessageBox.Show("Taskbar高度不足, 視窗未顯示", "效能監視器");
                    }
                }
                return;
            }

            var top1 = this.Top;
            var left1 = this.Left;
            Show();
            var top2 = this.Top;
            var left2 = this.Left;
            if (top1 == top2 && left1 == left2)
                SetFormObviousDegree();

        }

        private void SetFormObviousDegree()
        {
            if (_mouseInForm)
            {
                this.Opacity = 1;
                this.TransparencyKey = Color.Empty;
                _setTransparentDateTime = DateTime.Now.AddSeconds(5);
            }
            else
            {
                if (_setTransparentDateTime < DateTime.Now)
                {
                    this.Opacity = 0.85;
                    this.TransparencyKey = Color.Black;
                }
            }
        }

        private System.Windows.Forms.Timer GetUpdateDataTimer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = UpdateDataTimerInterval;
            timer.Tick += UpdateDataTimer_Tick;
            return timer;
        }
        private void UpdateDataTimer_Tick(object? sender, EventArgs e)
        {
            if (!heightIsEnough)
                return;

            _usageHandler.UpdateData();
        }

        private System.Windows.Forms.Timer GetUpdateDisplayTimer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = UpdateUsageTimerInterval;
            timer.Tick += UpdateDisplayTimer_Tick;
            return timer;
        }

        private void UpdateDisplayTimer_Tick(object? sender, EventArgs e)
        {
            if (!heightIsEnough)
                return;

            UpdateCpuInfo();
            UpdateMemoryInfo();
            UpdateNetworkInfo();
            UpdateGpuInfo();
            UpdateGpuMemoryInfo();
            UpdateDiskInfo();
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

            usageBarRam.Usage = _usageHandler.RamPercentVal;
            usageBarRam.Invalidate();
        }
        private void UpdateNetworkInfo()
        {
            FitFontSizeInControl(() =>
            {
                labNetUploadName.Text = _usageHandler.NetworkUploadInfo.sign;
                labNetUpload.Text = _usageHandler.NetworkUploadInfo.value;
                labNetUploadUnit.Text = _usageHandler.NetworkUploadInfo.unit;

                labNetDownloadName.Text = _usageHandler.NetworkDownloadInfo.sign;
                labNetDownload.Text = _usageHandler.NetworkDownloadInfo.value;
                labNetDownloadUnit.Text = _usageHandler.NetworkDownloadInfo.unit;
            });
        }
        private void UpdateGpuInfo()
        {
            FitFontSizeInControl(() =>
            {
                labGpu.Text = _usageHandler.GpuMaxUsageInfo.val;
                labGpuUnit.Text = _usageHandler.GpuMaxUsageInfo.unit;
            }, labGpu);
        }
        private void UpdateGpuMemoryInfo()
        {
            FitFontSizeInControl(() =>
            {
                labGpuRam.Text = _usageHandler.GpuDedicatedRamInfo.val;
                labGpuRamUnit.Text = _usageHandler.GpuDedicatedRamInfo.unit;
            }, labGpuRam);
        }
        private void UpdateDiskInfo()
        {
            FitFontSizeInControl(() =>
            {
                labDiskRead.Text = _usageHandler.DiskReadInfo.val;
                labDiskReadUnit.Text = _usageHandler.DiskReadInfo.unit;

                labDiskWrite.Text = _usageHandler.DiskWriteInfo.val;
                labDiskWriteUnit.Text = _usageHandler.DiskWriteInfo.unit;
            });
        }

        private void FitFontSizeInControl(Action action, params Label[]? fitFontSizeLabels)
        {
            if (fitFontSizeLabels != null)
                foreach (var label in fitFontSizeLabels)
                    label.SuspendLayout();

            action?.Invoke();

            if (fitFontSizeLabels != null)
            {
                foreach (var label in fitFontSizeLabels)
                    label.FitFontSize();

                foreach (var label in fitFontSizeLabels)
                    label.ResumeLayout();
            }
        }

        private System.Windows.Forms.Timer GetDetectMouseTimer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = DetectMouseTimerInterval;
            timer.Tick += DetectMouseTimer_Tick;
            return timer;
        }

        private void DetectMouseTimer_Tick(object? sender, EventArgs e)
        {
            Point mousePos = PointToClient(MousePosition);

            if (ClientRectangle.Contains(mousePos))
            {
                _mouseInForm = true;
                SetFormObviousDegree();
            }
            else
                _mouseInForm = false;
        }

        private ContextMenuStrip GetContextMenuStrip()
        {
            ContextMenuStrip menuStrip = new();

            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("關閉");
            closeMenuItem.Click += CloseMenuItem_Click;
            menuStrip.Items.Add(closeMenuItem);

            ToolStripMenuItem resetCountersMenuItem = new ToolStripMenuItem("重設所有效能監視器");
            resetCountersMenuItem.Click += ResetCountersMenuItem_Click; ;
            menuStrip.Items.Add(resetCountersMenuItem);

            return menuStrip;
        }

        private void CloseMenuItem_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetCountersMenuItem_Click(object? sender, EventArgs e)
        {
            _usageHandler.Reset();
        }

        private void StartTimers()
        {
            _adjustFormTimer.Start();
            _updateDataTimer.Start();
            _updateDisplayTimer.Start();
            _detectMouseTimer.Start();
        }

        private void EndTimers()
        {
            _adjustFormTimer.Stop();
            _updateDataTimer.Stop();
            _updateDisplayTimer.Stop();
            _detectMouseTimer.Stop();
        }

    }
}