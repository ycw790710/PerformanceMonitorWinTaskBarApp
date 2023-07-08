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
            tableLayoutPanel1 = new TableLayoutPanel();
            labCpuUnit = new Label();
            labRamUnit = new Label();
            labNetUploadUnit = new Label();
            labNetDownloadUnit = new Label();
            label5 = new Label();
            label6 = new Label();
            labNetUploadSign = new Label();
            labNetDownloadSign = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // labCpu
            // 
            labCpu.Dock = DockStyle.Fill;
            labCpu.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labCpu.Location = new Point(17, 0);
            labCpu.Name = "labCpu";
            labCpu.Size = new Size(34, 25);
            labCpu.TabIndex = 0;
            labCpu.Text = "00.0";
            labCpu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labRam
            // 
            labRam.Dock = DockStyle.Fill;
            labRam.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labRam.Location = new Point(17, 25);
            labRam.Name = "labRam";
            labRam.Size = new Size(34, 25);
            labRam.TabIndex = 1;
            labRam.Text = "00.0";
            labRam.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labNetUpload
            // 
            labNetUpload.Dock = DockStyle.Fill;
            labNetUpload.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labNetUpload.Location = new Point(89, 0);
            labNetUpload.Name = "labNetUpload";
            labNetUpload.Size = new Size(45, 25);
            labNetUpload.TabIndex = 2;
            labNetUpload.Text = "000.00";
            labNetUpload.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labNetDownload
            // 
            labNetDownload.Dock = DockStyle.Fill;
            labNetDownload.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labNetDownload.Location = new Point(89, 25);
            labNetDownload.Name = "labNetDownload";
            labNetDownload.Size = new Size(45, 25);
            labNetDownload.TabIndex = 3;
            labNetDownload.Text = "000.00";
            labNetDownload.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 14F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 14F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(labCpuUnit, 2, 0);
            tableLayoutPanel1.Controls.Add(labRamUnit, 2, 1);
            tableLayoutPanel1.Controls.Add(labNetUploadUnit, 5, 0);
            tableLayoutPanel1.Controls.Add(labNetDownloadUnit, 5, 1);
            tableLayoutPanel1.Controls.Add(labNetUpload, 4, 0);
            tableLayoutPanel1.Controls.Add(labNetDownload, 4, 1);
            tableLayoutPanel1.Controls.Add(labCpu, 1, 0);
            tableLayoutPanel1.Controls.Add(labRam, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 1);
            tableLayoutPanel1.Controls.Add(labNetUploadSign, 3, 0);
            tableLayoutPanel1.Controls.Add(labNetDownloadSign, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(168, 50);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // labCpuUnit
            // 
            labCpuUnit.Dock = DockStyle.Fill;
            labCpuUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labCpuUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labCpuUnit.Location = new Point(57, 0);
            labCpuUnit.Name = "labCpuUnit";
            labCpuUnit.Size = new Size(12, 25);
            labCpuUnit.TabIndex = 6;
            labCpuUnit.Text = "%";
            labCpuUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labRamUnit
            // 
            labRamUnit.Dock = DockStyle.Fill;
            labRamUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labRamUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labRamUnit.Location = new Point(57, 25);
            labRamUnit.Name = "labRamUnit";
            labRamUnit.Size = new Size(12, 25);
            labRamUnit.TabIndex = 7;
            labRamUnit.Text = "%";
            labRamUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetUploadUnit
            // 
            labNetUploadUnit.Dock = DockStyle.Fill;
            labNetUploadUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labNetUploadUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labNetUploadUnit.Location = new Point(140, 0);
            labNetUploadUnit.Name = "labNetUploadUnit";
            labNetUploadUnit.Size = new Size(25, 25);
            labNetUploadUnit.TabIndex = 5;
            labNetUploadUnit.Text = "MB";
            labNetUploadUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetDownloadUnit
            // 
            labNetDownloadUnit.Dock = DockStyle.Fill;
            labNetDownloadUnit.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labNetDownloadUnit.ForeColor = Color.FromArgb(192, 192, 0);
            labNetDownloadUnit.Location = new Point(140, 25);
            labNetDownloadUnit.Name = "labNetDownloadUnit";
            labNetDownloadUnit.Size = new Size(25, 25);
            labNetDownloadUnit.TabIndex = 4;
            labNetDownloadUnit.Text = "MB";
            labNetDownloadUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft JhengHei UI", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(8, 25);
            label5.TabIndex = 8;
            label5.Text = "CPU";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft JhengHei UI", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 25);
            label6.Name = "label6";
            label6.Size = new Size(8, 25);
            label6.TabIndex = 9;
            label6.Text = "RAM";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetUploadSign
            // 
            labNetUploadSign.Dock = DockStyle.Fill;
            labNetUploadSign.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labNetUploadSign.ForeColor = Color.White;
            labNetUploadSign.Location = new Point(75, 0);
            labNetUploadSign.Name = "labNetUploadSign";
            labNetUploadSign.Size = new Size(8, 25);
            labNetUploadSign.TabIndex = 10;
            labNetUploadSign.Text = "▲";
            labNetUploadSign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNetDownloadSign
            // 
            labNetDownloadSign.Dock = DockStyle.Fill;
            labNetDownloadSign.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labNetDownloadSign.Location = new Point(75, 25);
            labNetDownloadSign.Name = "labNetDownloadSign";
            labNetDownloadSign.Size = new Size(8, 25);
            labNetDownloadSign.TabIndex = 11;
            labNetDownloadSign.Text = "▼";
            labNetDownloadSign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PerformanceMonitorWinTaskBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(168, 50);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerformanceMonitorWinTaskBar";
            ShowIcon = false;
            ShowInTaskbar = false;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label labCpu;
        private Label labRam;
        private Label labNetUpload;
        private Label labNetDownload;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labNetDownloadUnit;
        private Label labCpuUnit;
        private Label labRamUnit;
        private Label labNetUploadUnit;
        private Label label5;
        private Label label6;
        private Label labNetUploadSign;
        private Label labNetDownloadSign;
    }
}