using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace CommandTestAutomation.Helpers
{
    public class Win32Api
    {
        public const int SPI_SETCURSORS = 0x0057;
        public const int SPIF_UPDATEINIFILE = 0x01;
        public const int SPIF_SENDCHANGE = 0x02;

        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
        public struct POINTAPI
        {
            public long x;
            public long y;
        }
        [DllImport("user32.dll")]
        public static extern bool DrawFocusRect(IntPtr hDC, [In] ref System.Drawing.Rectangle lprc);

        [DllImport("user32.dll")]
        public static extern bool DrawFocusRect(IntPtr hDC, [In] ref System.Drawing.Rectangle lprc, ref Color foreColor, ref Color backColor);

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static IntPtr GetDesktopWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern System.IntPtr FindWindowByCaption(int ZeroOnly, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetWindowsHookEx", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetCursorPos(int X, int Y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        // When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern bool ValidateRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        [DllImport("User32.dll")]
        public static extern long WindowFromPoint(long x, long y);

        [DllImport("User32.dll")]
        public static extern long GetCursorPos(ref POINTAPI p);

        [DllImport("User32.dll")]
        public static extern long GetWindowTextA(long hWnd, ref string lpString, long cch);

        [DllImport("user32.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);

        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        [DllImport("User32.dll")]
        public static extern long ChildWindowFromPoint(long hWndParent, long x, long y);

        [DllImport("User32.dll")]
        public static extern long GetclassNameA(long hWnd, string lpClassName, long nMaxCount);

        [DllImport("User32.dll")]
        public static extern IntPtr WindowFromPoint(POINT p);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint GetWindowModuleFileName(IntPtr hwnd, StringBuilder lpszFileName,
            uint cchFileNameMax);


        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll")]
        public static extern uint RealGetWindowClass(IntPtr hwnd, [Out] StringBuilder pszType,
           uint cchType);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(ref POINT p);


        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(ref Point p);


        [DllImport("user32.dll")]
        public static extern uint ClientToScreen(IntPtr hwnd, ref Point lpPoint);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern long GetWindowText(IntPtr hWnd, StringBuilder lpString, long cch);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr handle, int msg, int Param1, int Param2);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr handle, int msg, int Param, System.Text.StringBuilder text);


        [DllImport("User32.dll")]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, POINT p);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr hWndParent,
                                      IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        //[DllImport("user32.dll")]
        //public static extern IntPtr FindWindowEx(IntPtr parentWindow, IntPtr previousChildWindow, string windowClass, string windowTitle);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr window, out int process);

        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRectangle(IntPtr hWnd, out Rectangle lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr handle, out Win32ApiHelper.RECT Rect);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref ANIMATIONINFO pvParam, uint fWinIni);

    }

}
