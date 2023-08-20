namespace PerformanceMonitorWinTaskBarApp
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
            monitorTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // labCpu
            // 
            labCpu.Dock = DockStyle.Fill;
            labCpu.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labCpu.Location = new Point(6, 0);
            labCpu.Margin = new Padding(1, 0, 0, 0);
            labCpu.Name = "labCpu";
            labCpu.Size = new Size(31, 24);
            labCpu.TabIndex = 0;
            labCpu.Text = "00.0";
            labCpu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labRam
            // 
            labRam.Dock = DockStyle.Fill;
            labRam.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labRam.Location = new Point(6, 24);
            labRam.Margin = new Padding(1, 0, 0, 0);
            labRam.Name = "labRam";
            labRam.Size = new Size(31, 24);
            labRam.TabIndex = 1;
            labRam.Text = "00.0";
            labRam.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labNetUpload
            // 
            labNetUpload.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labNetUpload.Location = new Point(59, 0);
            labNetUpload.Margin = new Padding(1, 0, 0, 0);
            labNetUpload.Name = "labNetUpload";
            labNetUpload.Size = new Size(38, 24);
            labNetUpload.TabIndex = 2;
            labNetUpload.Text = "000.0";
            labNetUpload.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labNetDownload
            // 
            labNetDownload.Dock = DockStyle.Fill;
            labNetDownload.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labNetDownload.Location = new Point(59, 24);
            labNetDownload.Margin = new Padding(1, 0, 0, 0);
            labNetDownload.Name = "labNetDownload";
            labNetDownload.Size = new Size(38, 24);
            labNetDownload.TabIndex = 3;
            labNetDownload.Text = "000.0";
            labNetDownload.TextAlign = ContentAlignment.MiddleRight;
            // 
            // monitorTableLayoutPanel
            // 
            monitorTableLayoutPanel.ColumnCount = 6;
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
            monitorTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            monitorTableLayoutPanel.Controls.Add(labCpuUnit, 2, 0);
            monitorTableLayoutPanel.Controls.Add(labRamUnit, 2, 1);
            monitorTableLayoutPanel.Controls.Add(labNetUploadUnit, 5, 0);
            monitorTableLayoutPanel.Controls.Add(labNetDownloadUnit, 5, 1);
            monitorTableLayoutPanel.Controls.Add(labNetUpload, 4, 0);
            monitorTableLayoutPanel.Controls.Add(labNetDownload, 4, 1);
            monitorTableLayoutPanel.Controls.Add(labCpu, 1, 0);
            monitorTableLayoutPanel.Controls.Add(labRam, 1, 1);
            monitorTableLayoutPanel.Controls.Add(labCpuName, 0, 0);
            monitorTableLayoutPanel.Controls.Add(labNetUploadName, 3, 0);
            monitorTableLayoutPanel.Controls.Add(labNetDownloadName, 3, 1);
            monitorTableLayoutPanel.Controls.Add(usageBarRam, 0, 1);
            monitorTableLayoutPanel.Dock = DockStyle.Fill;
            monitorTableLayoutPanel.Location = new Point(0, 0);
            monitorTableLayoutPanel.Margin = new Padding(0);
            monitorTableLayoutPanel.Name = "monitorTableLayoutPanel";
            monitorTableLayoutPanel.RowCount = 2;
            monitorTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            monitorTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            monitorTableLayoutPanel.Size = new Size(122, 48);
            monitorTableLayoutPanel.TabIndex = 4;
            // 
            // labCpuUnit
            // 
            labCpuUnit.Dock = DockStyle.Fill;
            labCpuUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labCpuUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labCpuUnit.Location = new Point(37, 0);
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
            labRamUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labRamUnit.Location = new Point(37, 24);
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
            labNetUploadUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labNetUploadUnit.Location = new Point(97, 0);
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
            labNetDownloadUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labNetDownloadUnit.Location = new Point(97, 24);
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
            labCpuName.Location = new Point(0, 0);
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
            labNetUploadName.Location = new Point(50, 0);
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
            labNetDownloadName.Location = new Point(50, 24);
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
            usageBarRam.Location = new Point(0, 24);
            usageBarRam.Margin = new Padding(0);
            usageBarRam.Name = "usageBarRam";
            usageBarRam.Size = new Size(5, 24);
            usageBarRam.TabIndex = 12;
            usageBarRam.Usage = 0F;
            // 
            // PerformanceMonitorWinTaskBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(122, 48);
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
            monitorTableLayoutPanel.ResumeLayout(false);
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
    }
}