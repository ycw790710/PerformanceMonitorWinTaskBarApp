﻿namespace PerformanceMonitorWinTaskBarApp
{
    partial class PerformanceMonitorWinTaskBar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labCpu = new Label();
            labRam = new Label();
            labNetUpload = new Label();
            labNetDownload = new Label();
            monitorTableLayoutPanel = new TableLayoutPanel();
            labCpuUnit = new Label();
            labRamUnit = new Label();
            labNetUploadUnit = new Label();
            labNetDownloadUnit = new Label();
            labCpuName = new Label();
            labNetUploadName = new Label();
            labNetDownloadName = new Label();
            usageBarRam = new Controls.VerticalUsageBar();
            labGpuUnit = new Label();
            labGpuRamUnit = new Label();
            labGpu = new Label();
            labGpuRam = new Label();
            labGpuName = new Label();
            labDiskReadName = new Label();
            labDiskRead = new Label();
            labDiskReadUnit = new Label();
            labDiskWriteUnit = new Label();
            labDiskWrite = new Label();
            labDiskWriteName = new Label();
            btnHide = new Label();
            toolTipForm = new ToolTip(components);
            monitorTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // labCpu
            // 
            labCpu.Dock = DockStyle.Fill;
            labCpu.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labCpu.Location = new Point(6, 10);
            labCpu.Margin = new Padding(1, 0, 0, 0);
            labCpu.Name = "labCpu";
            labCpu.Size = new Size(31, 24);
            labCpu.TabIndex = 0;
            labCpu.Text = "00.0";
            labCpu.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labCpu, "CPU 使用率");
            // 
            // labRam
            // 
            labRam.Dock = DockStyle.Fill;
            labRam.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labRam.Location = new Point(6, 34);
            labRam.Margin = new Padding(1, 0, 0, 0);
            labRam.Name = "labRam";
            labRam.Size = new Size(31, 24);
            labRam.TabIndex = 1;
            labRam.Text = "00.0";
            labRam.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labRam, "記憶體使用量");
            // 
            // labNetUpload
            // 
            labNetUpload.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labNetUpload.Location = new Point(59, 10);
            labNetUpload.Margin = new Padding(1, 0, 0, 0);
            labNetUpload.Name = "labNetUpload";
            labNetUpload.Size = new Size(31, 24);
            labNetUpload.TabIndex = 2;
            labNetUpload.Text = "00.0";
            labNetUpload.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labNetUpload, "網路上傳速度(s)");
            // 
            // labNetDownload
            // 
            labNetDownload.Dock = DockStyle.Fill;
            labNetDownload.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labNetDownload.Location = new Point(59, 34);
            labNetDownload.Margin = new Padding(1, 0, 0, 0);
            labNetDownload.Name = "labNetDownload";
            labNetDownload.Size = new Size(31, 24);
            labNetDownload.TabIndex = 3;
            labNetDownload.Text = "00.0";
            labNetDownload.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labNetDownload, "網路下載速度(s)");
            // 
            // monitorTableLayoutPanel
            // 
            monitorTableLayoutPanel.ColumnCount = 12;
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 7F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 7F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            monitorTableLayoutPanel.Controls.Add(labCpuUnit, 2, 1);
            monitorTableLayoutPanel.Controls.Add(labRamUnit, 2, 2);
            monitorTableLayoutPanel.Controls.Add(labNetUploadUnit, 5, 1);
            monitorTableLayoutPanel.Controls.Add(labNetDownloadUnit, 5, 2);
            monitorTableLayoutPanel.Controls.Add(labNetUpload, 4, 1);
            monitorTableLayoutPanel.Controls.Add(labNetDownload, 4, 2);
            monitorTableLayoutPanel.Controls.Add(labCpu, 1, 1);
            monitorTableLayoutPanel.Controls.Add(labRam, 1, 2);
            monitorTableLayoutPanel.Controls.Add(labCpuName, 0, 1);
            monitorTableLayoutPanel.Controls.Add(labNetUploadName, 3, 1);
            monitorTableLayoutPanel.Controls.Add(labNetDownloadName, 3, 2);
            monitorTableLayoutPanel.Controls.Add(usageBarRam, 0, 2);
            monitorTableLayoutPanel.Controls.Add(labGpuUnit, 8, 1);
            monitorTableLayoutPanel.Controls.Add(labGpuRamUnit, 8, 2);
            monitorTableLayoutPanel.Controls.Add(labGpu, 7, 1);
            monitorTableLayoutPanel.Controls.Add(labGpuRam, 7, 2);
            monitorTableLayoutPanel.Controls.Add(labGpuName, 6, 1);
            monitorTableLayoutPanel.Controls.Add(labDiskReadName, 9, 1);
            monitorTableLayoutPanel.Controls.Add(labDiskRead, 10, 1);
            monitorTableLayoutPanel.Controls.Add(labDiskReadUnit, 11, 1);
            monitorTableLayoutPanel.Controls.Add(labDiskWriteUnit, 11, 2);
            monitorTableLayoutPanel.Controls.Add(labDiskWrite, 10, 2);
            monitorTableLayoutPanel.Controls.Add(labDiskWriteName, 9, 2);
            monitorTableLayoutPanel.Controls.Add(btnHide, 0, 0);
            monitorTableLayoutPanel.Dock = DockStyle.Fill;
            monitorTableLayoutPanel.Location = new Point(0, 0);
            monitorTableLayoutPanel.Margin = new Padding(0);
            monitorTableLayoutPanel.Name = "monitorTableLayoutPanel";
            monitorTableLayoutPanel.RowCount = 3;
            monitorTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            monitorTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            monitorTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            monitorTableLayoutPanel.Size = new Size(226, 58);
            monitorTableLayoutPanel.TabIndex = 4;
            // 
            // labCpuUnit
            // 
            labCpuUnit.Dock = DockStyle.Fill;
            labCpuUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labCpuUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labCpuUnit.Location = new Point(37, 10);
            labCpuUnit.Margin = new Padding(0);
            labCpuUnit.Name = "labCpuUnit";
            labCpuUnit.Size = new Size(11, 24);
            labCpuUnit.TabIndex = 6;
            labCpuUnit.Text = "%";
            labCpuUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labRamUnit
            // 
            labRamUnit.Dock = DockStyle.Fill;
            labRamUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labRamUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labRamUnit.Location = new Point(37, 34);
            labRamUnit.Margin = new Padding(0);
            labRamUnit.Name = "labRamUnit";
            labRamUnit.Size = new Size(11, 24);
            labRamUnit.TabIndex = 7;
            labRamUnit.Text = "G";
            labRamUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetUploadUnit
            // 
            labNetUploadUnit.Dock = DockStyle.Fill;
            labNetUploadUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labNetUploadUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labNetUploadUnit.Location = new Point(90, 10);
            labNetUploadUnit.Margin = new Padding(0);
            labNetUploadUnit.Name = "labNetUploadUnit";
            labNetUploadUnit.Size = new Size(25, 24);
            labNetUploadUnit.TabIndex = 5;
            labNetUploadUnit.Text = "MB";
            labNetUploadUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetDownloadUnit
            // 
            labNetDownloadUnit.Dock = DockStyle.Fill;
            labNetDownloadUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labNetDownloadUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labNetDownloadUnit.Location = new Point(90, 34);
            labNetDownloadUnit.Margin = new Padding(0);
            labNetDownloadUnit.Name = "labNetDownloadUnit";
            labNetDownloadUnit.Size = new Size(25, 24);
            labNetDownloadUnit.TabIndex = 4;
            labNetDownloadUnit.Text = "MB";
            labNetDownloadUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labCpuName
            // 
            labCpuName.Dock = DockStyle.Fill;
            labCpuName.Font = new Font("Microsoft JhengHei UI", 4F, FontStyle.Bold, GraphicsUnit.Point);
            labCpuName.Location = new Point(0, 10);
            labCpuName.Margin = new Padding(0);
            labCpuName.Name = "labCpuName";
            labCpuName.Size = new Size(5, 24);
            labCpuName.TabIndex = 8;
            labCpuName.Text = "CPU";
            labCpuName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetUploadName
            // 
            labNetUploadName.Dock = DockStyle.Fill;
            labNetUploadName.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labNetUploadName.ForeColor = Color.White;
            labNetUploadName.Location = new Point(50, 10);
            labNetUploadName.Margin = new Padding(2, 0, 0, 0);
            labNetUploadName.Name = "labNetUploadName";
            labNetUploadName.Size = new Size(8, 24);
            labNetUploadName.TabIndex = 10;
            labNetUploadName.Text = "▲";
            labNetUploadName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetDownloadName
            // 
            labNetDownloadName.Dock = DockStyle.Fill;
            labNetDownloadName.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labNetDownloadName.Location = new Point(50, 34);
            labNetDownloadName.Margin = new Padding(2, 0, 0, 0);
            labNetDownloadName.Name = "labNetDownloadName";
            labNetDownloadName.Size = new Size(8, 24);
            labNetDownloadName.TabIndex = 11;
            labNetDownloadName.Text = "▼";
            labNetDownloadName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usageBarRam
            // 
            usageBarRam.Dock = DockStyle.Fill;
            usageBarRam.Location = new Point(0, 34);
            usageBarRam.Margin = new Padding(0);
            usageBarRam.Name = "usageBarRam";
            usageBarRam.Size = new Size(5, 24);
            usageBarRam.TabIndex = 12;
            toolTipForm.SetToolTip(usageBarRam, "記憶體使用率");
            usageBarRam.Usage = 0F;
            // 
            // labGpuUnit
            // 
            labGpuUnit.AutoSize = true;
            labGpuUnit.Dock = DockStyle.Fill;
            labGpuUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labGpuUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labGpuUnit.Location = new Point(154, 10);
            labGpuUnit.Margin = new Padding(0);
            labGpuUnit.Name = "labGpuUnit";
            labGpuUnit.Size = new Size(11, 24);
            labGpuUnit.TabIndex = 13;
            labGpuUnit.Text = "%";
            labGpuUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labGpuRamUnit
            // 
            labGpuRamUnit.AutoSize = true;
            labGpuRamUnit.Dock = DockStyle.Fill;
            labGpuRamUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labGpuRamUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labGpuRamUnit.Location = new Point(154, 34);
            labGpuRamUnit.Margin = new Padding(0);
            labGpuRamUnit.Name = "labGpuRamUnit";
            labGpuRamUnit.Size = new Size(11, 24);
            labGpuRamUnit.TabIndex = 14;
            labGpuRamUnit.Text = "G";
            labGpuRamUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labGpu
            // 
            labGpu.AutoSize = true;
            labGpu.Dock = DockStyle.Fill;
            labGpu.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labGpu.Location = new Point(123, 10);
            labGpu.Margin = new Padding(1, 0, 0, 0);
            labGpu.Name = "labGpu";
            labGpu.Size = new Size(31, 24);
            labGpu.TabIndex = 15;
            labGpu.Text = "00.0";
            labGpu.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labGpu, "GPU 最高使用率");
            // 
            // labGpuRam
            // 
            labGpuRam.AutoSize = true;
            labGpuRam.Dock = DockStyle.Fill;
            labGpuRam.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labGpuRam.Location = new Point(123, 34);
            labGpuRam.Margin = new Padding(1, 0, 0, 0);
            labGpuRam.Name = "labGpuRam";
            labGpuRam.Size = new Size(31, 24);
            labGpuRam.TabIndex = 16;
            labGpuRam.Text = "00.0";
            labGpuRam.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labGpuRam, "顯示卡專屬記憶體使用量");
            // 
            // labGpuName
            // 
            labGpuName.AutoSize = true;
            labGpuName.Dock = DockStyle.Fill;
            labGpuName.Font = new Font("Microsoft JhengHei UI", 4F, FontStyle.Bold, GraphicsUnit.Point);
            labGpuName.Location = new Point(117, 10);
            labGpuName.Margin = new Padding(2, 0, 0, 0);
            labGpuName.Name = "labGpuName";
            labGpuName.Size = new Size(5, 24);
            labGpuName.TabIndex = 17;
            labGpuName.Text = "GPU";
            labGpuName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDiskReadName
            // 
            labDiskReadName.AutoSize = true;
            labDiskReadName.Dock = DockStyle.Fill;
            labDiskReadName.Font = new Font("Microsoft JhengHei UI", 4F, FontStyle.Bold, GraphicsUnit.Point);
            labDiskReadName.Location = new Point(167, 10);
            labDiskReadName.Margin = new Padding(2, 0, 0, 0);
            labDiskReadName.Name = "labDiskReadName";
            labDiskReadName.Size = new Size(5, 24);
            labDiskReadName.TabIndex = 18;
            labDiskReadName.Text = "DR";
            labDiskReadName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDiskRead
            // 
            labDiskRead.AutoSize = true;
            labDiskRead.Dock = DockStyle.Fill;
            labDiskRead.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labDiskRead.Location = new Point(173, 10);
            labDiskRead.Margin = new Padding(1, 0, 0, 0);
            labDiskRead.Name = "labDiskRead";
            labDiskRead.Size = new Size(31, 24);
            labDiskRead.TabIndex = 19;
            labDiskRead.Text = "00.0";
            labDiskRead.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labDiskRead, "硬碟讀取速度(s)");
            // 
            // labDiskReadUnit
            // 
            labDiskReadUnit.AutoSize = true;
            labDiskReadUnit.Dock = DockStyle.Fill;
            labDiskReadUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labDiskReadUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labDiskReadUnit.Location = new Point(204, 10);
            labDiskReadUnit.Margin = new Padding(0);
            labDiskReadUnit.Name = "labDiskReadUnit";
            labDiskReadUnit.Size = new Size(25, 24);
            labDiskReadUnit.TabIndex = 20;
            labDiskReadUnit.Text = "MB";
            labDiskReadUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDiskWriteUnit
            // 
            labDiskWriteUnit.AutoSize = true;
            labDiskWriteUnit.Dock = DockStyle.Fill;
            labDiskWriteUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labDiskWriteUnit.ForeColor = Color.FromArgb(230, 230, 0);
            labDiskWriteUnit.Location = new Point(204, 34);
            labDiskWriteUnit.Margin = new Padding(0);
            labDiskWriteUnit.Name = "labDiskWriteUnit";
            labDiskWriteUnit.Size = new Size(25, 24);
            labDiskWriteUnit.TabIndex = 21;
            labDiskWriteUnit.Text = "MB";
            labDiskWriteUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDiskWrite
            // 
            labDiskWrite.AutoSize = true;
            labDiskWrite.Dock = DockStyle.Fill;
            labDiskWrite.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labDiskWrite.Location = new Point(173, 34);
            labDiskWrite.Margin = new Padding(1, 0, 0, 0);
            labDiskWrite.Name = "labDiskWrite";
            labDiskWrite.Size = new Size(31, 24);
            labDiskWrite.TabIndex = 22;
            labDiskWrite.Text = "00.0";
            labDiskWrite.TextAlign = ContentAlignment.MiddleRight;
            toolTipForm.SetToolTip(labDiskWrite, "硬碟寫入速度(s)");
            // 
            // labDiskWriteName
            // 
            labDiskWriteName.AutoSize = true;
            labDiskWriteName.Dock = DockStyle.Fill;
            labDiskWriteName.Font = new Font("Microsoft JhengHei UI", 4F, FontStyle.Bold, GraphicsUnit.Point);
            labDiskWriteName.Location = new Point(167, 34);
            labDiskWriteName.Margin = new Padding(2, 0, 0, 0);
            labDiskWriteName.Name = "labDiskWriteName";
            labDiskWriteName.Size = new Size(5, 24);
            labDiskWriteName.TabIndex = 23;
            labDiskWriteName.Text = "DW";
            labDiskWriteName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHide
            // 
            btnHide.AutoSize = true;
            monitorTableLayoutPanel.SetColumnSpan(btnHide, 12);
            btnHide.Dock = DockStyle.Fill;
            btnHide.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnHide.Location = new Point(0, 0);
            btnHide.Margin = new Padding(0);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(229, 10);
            btnHide.TabIndex = 24;
            btnHide.Text = "▼";
            btnHide.TextAlign = ContentAlignment.MiddleCenter;
            btnHide.Click += btnHide_Click;
            // 
            // PerformanceMonitorWinTaskBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(226, 58);
            ControlBox = false;
            Controls.Add(monitorTableLayoutPanel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerformanceMonitorWinTaskBar";
            Opacity = 0D;
            ShowIcon = false;
            ShowInTaskbar = false;
            TransparencyKey = Color.Black;
            monitorTableLayoutPanel.ResumeLayout(false);
            monitorTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labCpu;
        private Label labRam;
        private Label labNetUpload;
        private Label labNetDownload;
        private TableLayoutPanel monitorTableLayoutPanel;
        private Label labNetDownloadUnit;
        private Label labCpuUnit;
        private Label labRamUnit;
        private Label labNetUploadUnit;
        private Label labCpuName;
        private Label labNetUploadName;
        private Label labNetDownloadName;
        private Controls.VerticalUsageBar usageBarRam;
        private Label labGpuUnit;
        private Label labGpuRamUnit;
        private Label labGpu;
        private Label labGpuRam;
        private Label labGpuName;
        private ToolTip toolTipForm;
        private Label labDiskReadName;
        private Label labDiskRead;
        private Label labDiskReadUnit;
        private Label labDiskWriteUnit;
        private Label labDiskWrite;
        private Label labDiskWriteName;
        private Label btnHide;
    }
}