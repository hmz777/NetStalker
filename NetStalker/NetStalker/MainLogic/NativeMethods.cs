using System;
using System.Runtime.InteropServices;

namespace NetStalker.MainLogic
{
    public class NativeMethods
    {
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        [DllImport("user32.dll")]
        internal static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        internal static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public enum ScrollbarDirection
        {
            Horizontal = 0,
            Vertical = 1,
        }

        public enum Messages
        {
            WM_HSCROLL = 0x0114,
            WM_VSCROLL = 0x0115
        }

        public static int GetScrollPosition(IntPtr hWnd, ScrollbarDirection direction)
        {
            return GetScrollPos(hWnd, (int)direction);
        }

        public static void GetScrollPosition(IntPtr hWnd, out int horizontalPosition, out int verticalPosition)
        {
            horizontalPosition = GetScrollPos(hWnd, (int)ScrollbarDirection.Horizontal);
            verticalPosition = GetScrollPos(hWnd, (int)ScrollbarDirection.Vertical);
        }

        public static void SetScrollPosition(IntPtr hwnd, int hozizontalPosition, int verticalPosition)
        {
            SetScrollPosition(hwnd, ScrollbarDirection.Horizontal, hozizontalPosition);
            SetScrollPosition(hwnd, ScrollbarDirection.Vertical, verticalPosition);
        }

        public static void SetScrollPosition(IntPtr hwnd, ScrollbarDirection direction, int position)
        {
            //move the scroll bar
            SetScrollPos(hwnd, (int)direction, position, true);

            //convert the position to the windows message equivalent
            IntPtr msgPosition = new IntPtr((position << 16) + 4);
            Messages msg = (direction == ScrollbarDirection.Horizontal) ? Messages.WM_HSCROLL : Messages.WM_VSCROLL;
            SendMessage(hwnd, (int)msg, msgPosition, IntPtr.Zero);
        }
    }
}
