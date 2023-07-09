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
        int increment = 1;
        while (true)
        {
            var testFont = new Font(font.FontFamily, fontSize);
            var textSize = TextRenderer.MeasureText(text, testFont);

            if (textSize.Height > height || textSize.Width > width)
                break;

            fontSize += increment;
            testFont.Dispose();
        }
        var newFontSize = fontSize - increment;

        label.Font = new Font(label.Font.FontFamily, newFontSize);
    }
}
