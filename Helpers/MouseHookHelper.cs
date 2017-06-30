using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CommandTestAutomation.Helpers
{
    public static class LowLevelMouseListener
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate void MyEventHandler(object source, MyMouseEventArgs e);

        public static event EventHandler MouseAction = delegate { };

        public static event MyEventHandler MouseLeftClickAction;

        public static event MyEventHandler MouseMoveAction;  

        private static LowLevelMouseProc _proc = HookCallbackLBUTTONDOWN;

        private static IntPtr _hookID = IntPtr.Zero;

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        static LowLevelMouseListener()
        {
            
        }

   

        public static void Start()
        {
            _hookID = SetHook(_proc);


        }
        public static void stop()
        {
            UnhookWindowsHookEx(_hookID);
        }


        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallbackLBUTTONDOWN(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                int vkCode = Marshal.ReadInt32(lParam);
                MouseLeftClickAction(null, new MyMouseEventArgs(hookStruct));
            }
            //else if (nCode >= 0 && MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
            //{
            //    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            //    int vkCode = Marshal.ReadInt32(lParam);
            //    MouseMoveAction(null, new MyMouseEventArgs(hookStruct));
            //}
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
            
        }

        private static IntPtr HookCallbackMouseMove(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                int vkCode = Marshal.ReadInt32(lParam);
                MouseMoveAction(null, new MyMouseEventArgs(hookStruct));
            }
            //else if (nCode >= 0 && MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
            //{
            //    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            //    int vkCode = Marshal.ReadInt32(lParam);
            //    MouseMoveAction(null, new MyMouseEventArgs(hookStruct));
            //}
            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }

       

    }
    

    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public uint mouseData;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    public class MyMouseEventArgs:EventArgs
    {
        private MSLLHOOKSTRUCT p;
        public MyMouseEventArgs(MSLLHOOKSTRUCT hookStruct)
        {
            p = hookStruct;
        }
        public MSLLHOOKSTRUCT GetLeftClickPoint()
        {
            return p;
        }
    }
}