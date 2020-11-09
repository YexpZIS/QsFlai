using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;

namespace QsFlai.VirtualFolderModuls
{
    /// <summary>
    /// Закрепляет окно на рабочем столе, прячет из трея, игнорирует Alt+Tab
    /// </summary>
    class BackgroundPiner
    {
        Window window;
        
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public const int HWND_BOTTOM = 0x1;
        public const uint SWP_NOSIZE = 0x1;
        public const uint SWP_NOMOVE = 0x2;
        public const uint SWP_SHOWWINDOW = 0x40;


        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr window, int index, int value);
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr window, int index);
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public BackgroundPiner(Window window)
        {
            this.window = window;

            window.Loaded += HideFromAltTab;
            window.Activated += ShoveToBackground;
        }
        public void HideFromAltTab(object sender, RoutedEventArgs e)
        {
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }
        public void ShoveToBackground(object sender, EventArgs e)
        {
            SetWindowPos((int)this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }
        private IntPtr Handle
        {
            get
            {
                return new WindowInteropHelper(window).Handle;
            }
        }
    }
}
