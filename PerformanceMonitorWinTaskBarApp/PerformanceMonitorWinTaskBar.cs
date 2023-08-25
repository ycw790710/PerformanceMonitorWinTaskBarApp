﻿using Microsoft.Win32;
using PerformanceMonitorWinTaskBarApp.Extensions;
using PerformanceMonitorWinTaskBarApp.Usages;

namespace PerformanceMonitorWinTaskBarApp
{
    public partial class PerformanceMonitorWinTaskBar : Form
    {
        private bool _notifiedHeightIsEnough;
        private bool _heightIsEnough;
        private SessionSwitchReason _userSessionSwitchReason;
        private bool _shouldHighlightForm;
        private bool _shouldUpdatePosition;
        private (int Height, int Top, int Left) _positionInfo;
        private DateTime _setTransparentDateTime;

        private readonly UsageHandler _usageHandler;

        const int DisplayFormTimerInterval = 1000;
        const int UpdateDataTimerInterval = 1000;
        const int DetectTimerInterval = 200;

        readonly System.Windows.Forms.Timer _displayTimer;
        readonly System.Windows.Forms.Timer _updateDataTimer;
        readonly System.Windows.Forms.Timer _detectTimer;

        public PerformanceMonitorWinTaskBar()
        {
            this.Visible = false;
            InitializeComponent();
            this.SetOnTaskBarStyle();

            _notifiedHeightIsEnough = false;
            SetUserSessionSwitchChangeEvent();
            _heightIsEnough = false;
            _usageHandler = new();
            _shouldHighlightForm = false;
            _shouldUpdatePosition = false;
            _setTransparentDateTime = DateTime.MinValue;

            _displayTimer = GetDisplayTimer();
            _updateDataTimer = GetUpdateDataTimer();
            _detectTimer = GetDetectTimer();
            ContextMenuStrip = GetContextMenuStrip();

            StartTimers();

            this.Visible = true;
        }

        private void SetUserSessionSwitchChangeEvent()
        {
            _userSessionSwitchReason = SessionSwitchReason.SessionUnlock;
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            _userSessionSwitchReason = e.Reason;
        }

        private System.Windows.Forms.Timer GetDisplayTimer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = DisplayFormTimerInterval;
            timer.Tick += DisplayTimer_Tick;
            return timer;
        }
        private void DisplayTimer_Tick(object? sender, EventArgs e)
        {
            if (!_heightIsEnough && !_shouldUpdatePosition)
                return;
            SuspendAllLayout(this);

            if (_shouldUpdatePosition)
            {
                this.Top = _positionInfo.Top;
                this.Left = _positionInfo.Left;
                this.Height = _positionInfo.Height;
                _shouldUpdatePosition = false;
            }

            SetFormObviousDegree();

            UpdateCpuInfo();
            UpdateMemoryInfo();
            UpdateNetworkInfo();
            UpdateGpuInfo();
            UpdateGpuMemoryInfo();
            UpdateDiskInfo();

            this.TopMost = true;

            ResumeAllLayout(this);
        }
        private void SuspendAllLayout(Control control)
        {
            if (control == null)
                return;
            control.SuspendLayout();
            if (control.Controls == null)
                return;
            foreach (Control child in control.Controls)
                SuspendAllLayout(child);
        }
        private void ResumeAllLayout(Control control)
        {
            if (control == null)
                return;
            control.ResumeLayout(false);
            if (control.Controls == null)
                return;
            foreach (Control child in control.Controls)
                ResumeAllLayout(child);
        }

        private void SetFormObviousDegree()
        {
            if (_shouldHighlightForm)
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
            action?.Invoke();

            if (fitFontSizeLabels != null)
            {
                foreach (var label in fitFontSizeLabels)
                    label.FitFontSize();
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
            if (!_heightIsEnough)
                return;

            _usageHandler.UpdateData();
        }

        private System.Windows.Forms.Timer GetDetectTimer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = DetectTimerInterval;
            timer.Tick += DetectTimer_Tick;
            return timer;
        }

        private void DetectTimer_Tick(object? sender, EventArgs e)
        {
            PreparePositions();

            DetectShouldHighlightForm();
            DetectHeightIsEnough();
            DetectShouldUpdatePositions();

            TryNotifyHeightIsNotEnough();
        }

        private void PreparePositions()
        {
            _positionInfo = this.GetOnTaskBarPositionInfo();
        }

        private void DetectShouldHighlightForm()
        {
            Point mousePos = PointToClient(MousePosition);

            if (ClientRectangle.Contains(mousePos))
            {
                _shouldHighlightForm = true;
                SetFormObviousDegree();
            }
            else
                _shouldHighlightForm = false;
        }

        private void DetectHeightIsEnough()
        {
            _heightIsEnough = _positionInfo.Height >= 12;
        }

        private void DetectShouldUpdatePositions()
        {
            _shouldUpdatePosition = _positionInfo.Top != this.Top || _positionInfo.Left != this.Left
                || _positionInfo.Height != this.Height;
        }

        private void TryNotifyHeightIsNotEnough()
        {
            if (!_heightIsEnough)
            {
                if (!_notifiedHeightIsEnough)
                {
                    SpinWait.SpinUntil(() => false, 1000);
                    if (!_notifiedHeightIsEnough && _userSessionSwitchReason == SessionSwitchReason.SessionUnlock)
                    {
                        _notifiedHeightIsEnough = true;
                        MessageBox.Show("Taskbar高度不足, 視窗未顯示", "效能監視器");
                    }
                }
            }
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
            _displayTimer.Start();
            _updateDataTimer.Start();
            _detectTimer.Start();
        }

        private void EndTimers()
        {
            _displayTimer.Stop();
            _updateDataTimer.Stop();
            _detectTimer.Stop();
        }

    }
}