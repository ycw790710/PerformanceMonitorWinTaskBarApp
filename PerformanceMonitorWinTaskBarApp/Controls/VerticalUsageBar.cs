using System.ComponentModel;

namespace PerformanceMonitorWinTaskBarApp.Controls
{
    public partial class VerticalUsageBar : UserControl
    {
        [Description("Usage"), Category("_Data")]
        public float Usage { get; set; }

        public VerticalUsageBar()
        {
            InitializeComponent();

            this.Paint += VerticalUsageBar_Paint;
        }

        private void VerticalUsageBar_Paint(object? sender, PaintEventArgs e)
        {
            Color barColor;

            if (Usage > 90)
                barColor = Color.Red;
            else if (Usage > 80)
                barColor = Color.Orange;
            else if (Usage > 70)
                barColor = Color.Yellow;
            else
                barColor = Color.Gray;

            using SolidBrush brush = new(barColor);
            int barHeight = (int)(Usage / 100 * this.Height);
            Rectangle barRect = new(0, this.Height - barHeight, this.Width, barHeight);

            e.Graphics.FillRectangle(brush, barRect);
        }
    }
}
