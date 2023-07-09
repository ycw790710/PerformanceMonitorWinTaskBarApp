namespace PerformanceMonitorWinTaskBarApp.Extensions;
public static class FitFontSizeExtension
{
    public static void FitFontSize(this Label label)
    {
        var font = label.Font;
        var text = label.Text;
        var height = label.Height;
        var width = label.Width;

        int fontSize = 1;
        int increment = Math.Max(1, (int)(label.Font.Size / 2) - 1);
        fontSize += increment;
        var count = 0;
        while (true && !string.IsNullOrEmpty(text))
        {
            count++;
            var testFont = new Font(font.FontFamily, fontSize);
            var textSize = TextRenderer.MeasureText(text, testFont);

            if (textSize.Height > height || textSize.Width > width)
            {
                if (increment == 1)
                    break;
                else
                {
                    fontSize -= increment;
                    increment /= 2;
                }
            }
            fontSize += increment;

            testFont.Dispose();
        }
        var newFontSize = fontSize - increment;

        label.Font = new Font(label.Font.FontFamily, newFontSize);
    }
}
