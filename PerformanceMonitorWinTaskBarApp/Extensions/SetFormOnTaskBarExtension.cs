
using System.Runtime.InteropServices;

namespace PerformanceMonitorWinTaskBarApp.Extensions;
public static class SetFormOnTaskBarExtension
{
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll")]
    private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);


#pragma warning disable CS8625 // 無法將 null 常值轉換成不可為 Null 的參考型別。
    private static int GetAppNotifyWidth()
    {
        var shellTrayWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);
        var trayNotifyWnd = FindWindowEx(shellTrayWnd, IntPtr.Zero, "TrayNotifyWnd", null);
        RECT rect;
        GetClientRect(trayNotifyWnd, out rect);
        return rect.Right - rect.Left;
    }
#pragma warning restore CS8625 // 無法將 null 常值轉換成不可為 Null 的參考型別。

    public static bool SetOnTaskBar(this Form form)
    {
        var success = true;
        form.SuspendLayout();

        form.FormBorderStyle = FormBorderStyle.None;
        form.MaximizeBox = false;
        form.MinimizeBox = false;
        form.ShowIcon = false;
        form.ShowInTaskbar = false;
        form.TopMost = true;
        form.AutoSize = false;

        int taskbarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
        taskbarHeight = Math.Max(0, taskbarHeight);
        if (taskbarHeight < 10)
        {
            success = false;
        }
        form.Height = taskbarHeight;
        form.Top = Screen.PrimaryScreen.Bounds.Height - taskbarHeight;

        int right = Screen.PrimaryScreen.Bounds.Width - GetAppNotifyWidth();
        form.Left = right - form.Width;

        form.ResumeLayout();
        return success;
    }
}
