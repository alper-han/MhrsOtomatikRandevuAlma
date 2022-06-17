using System;
using System.Windows.Forms;

namespace MhrsRandevu
{
    internal sealed class ZamanMbox // Süreli MessageBox
    {
        private readonly System.Threading.Timer _timeoutTimer;
        private readonly string _caption;

        private ZamanMbox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
            {
                MessageBox.Show(text, caption);
            }
        }
        internal static void Show(string text, string caption, int timeout)
        {
            new ZamanMbox(text, caption, timeout);
        }

        private void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
            {
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }

            _timeoutTimer.Dispose();
        }

        private const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    }
}
