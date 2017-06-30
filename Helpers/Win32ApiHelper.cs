using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace CommandTestAutomation.Helpers
{
    public class Win32ApiHelper
    {
        public const int WM_GETTEXT = 0xD;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_ERASEBKGND = 0x14;
        public const int WM_PAINT = 0x0F;
        // private const int WM_PAINT = 15;
        private const int WH_GETMESSAGE = 3;
        public const int SW_MAXIMISE = 3;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public RECT(int left_, int top_, int right_, int bottom_)
            {
                Left = left_;
                Top = top_;
                Right = right_;
                Bottom = bottom_;
            }

            public override string ToString()
            {
                return "Left: " + Left + "Top: " + Top + "Width: " + Width + " Height: " + Height;
            }

            public int Height { get { return Bottom - Top; } }
            public int Width { get { return Right - Left; } }
            public Size Size { get { return new Size(Width, Height); } }

            public POINT Location { get { return new POINT(Left, Top); } }
            // Handy method for converting to a System.Drawing.Rectangle
            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }
            public static RECT FromRectangle(Rectangle rectangle)
            {
                return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }
            public override int GetHashCode()
            {
                return Left ^ ((Top << 13) | (Top >> 0x13))
                ^ ((Width << 0x1a) | (Width >> 6))
                ^ ((Height << 7) | (Height >> 0x19));
            }
            #region Operator overloads
            public static implicit operator Rectangle(RECT rect)
            {
                return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }
            public static implicit operator RECT(Rectangle rect)
            {
                return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }
            #endregion
        }

        public class WindowInfo
        {
            public IntPtr Handle;
            public string ClassName;
            public string PartentWindowTitle;
            public string Text;
            public Rectangle rectangle;
            public RECT rect;
            public string dotNetClassName;



            public WindowInfo(IntPtr Handle)
            {
                this.Handle = Handle;
                this.ClassName = GetWindowClassName(Handle);
                this.Text = GetWindowTextRaw(Handle);
                this.rectangle = GetWindowRectangle(Handle);
                this.rect = GetWindowRECT(Handle);
                this.PartentWindowTitle = GetParentWindowTitle(Handle);
                this.dotNetClassName = RealGetWindowClassM(Handle);
            }
        }

        public static void ShowWindow(IntPtr hWnd)
        {
            bool hdc;

            hdc = Win32Api.ShowWindow(hWnd, Win32ApiHelper.SW_MAXIMISE);

            return;

        }

        public static void PaintControl(WindowInfo curWindow)
        {
            IntPtr hdc;

            hdc = Win32Api.GetWindowDC(curWindow.Handle);

            if (hdc != IntPtr.Zero)
            {
                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    //g.DrawRectangle(Pens.Red, curWindow.rect);
                    g.DrawRectangle(Pens.Red, curWindow.rectangle);
                }
                Win32Api.ReleaseDC(curWindow.Handle, hdc);
            }

        }


        public static string GetParentWindowTitle(IntPtr hWnd)
        {
            //gets the Parent of pointed control
            IntPtr hWndParent = Win32Api.GetParent(hWnd);
            if (hWndParent.ToInt64() > 0)
            {
                return Win32ApiHelper.GetCaptionOfWindow(hWndParent);
            }
            return string.Empty;

        }

        public static string RealGetWindowClassM(IntPtr hWnd)
        {
            StringBuilder pszType = new StringBuilder();
            pszType.Capacity = 255;
            Win32Api.RealGetWindowClass(hWnd, pszType, (UInt32)pszType.Capacity);
            return pszType.ToString();
        }

        public static string GetWindowClassName(IntPtr hWnd)
        {

            string classNameText = string.Empty;
            StringBuilder className = null;
            try
            {
                // Pre-allocate 256 characters, since this is the maximum class name length.
                className = new StringBuilder(128);//working with 50
                //Get the window class name                
                if (Win32Api.GetClassName(hWnd, className, className.Capacity) == 0)
                    throw new Win32Exception();

                if (!String.IsNullOrEmpty(className.ToString()) && !String.IsNullOrWhiteSpace(className.ToString()))
                    classNameText = className.ToString();
            }
            catch (Exception ex)
            {
                classNameText = ex.Message;
            }
            finally
            {
                className = null;
            }
            return classNameText;
        }

        public static string GetCaptionOfWindow(IntPtr hWnd)
        {
            string caption = "";
            String windowText = null;
            try
            {
                int max_length = Win32Api.GetWindowTextLength(hWnd);
                //windowText = new StringBuilder(max_length + 5);
                windowText = GetWindowTextRaw(hWnd);
                // GetWindowText(hWnd, windowText, windowText.Capacity);

                if (!String.IsNullOrEmpty(windowText.ToString()) && !String.IsNullOrWhiteSpace(windowText.ToString()))
                    caption = windowText.ToString();
            }
            catch (Exception ex)
            {
                caption = ex.Message;
            }
            finally
            {
                windowText = null;
            }
            return caption;
        }

        public static String GetWindowTextRaw(IntPtr hWnd)
        {


            //StringBuilder sb = new StringBuilder(65535);
            //// needs to be big enough for the whole text
            //Win32Api.SendMessage(hWnd, WM_GETTEXT, (IntPtr)sb.Capacity, sb);
            //Console.WriteLine(sb.ToString());
            //return sb;

            StringBuilder buffer = new StringBuilder(Win32Api.SendMessage(hWnd, WM_GETTEXTLENGTH, 0, 0) + 1);
            Win32Api.SendMessage(hWnd, WM_GETTEXT, buffer.Capacity, buffer);
            return buffer.ToString();
        }

        public static Rectangle GetWindowRectangle(IntPtr handle)
        {
            RECT rect = new RECT();
            Rectangle rectangle = new Rectangle();
            Win32Api.GetWindowRect(handle, out rect);
            Win32Api.GetWindowRectangle(handle, out rectangle);
            return rectangle;
            //return new Rectangle(rect.Left, rect.Top, (rect.Right - rect.Left) + 1, (rect.Bottom - rect.Top) + 1);
        }

        public static RECT GetWindowRECT(IntPtr handle)
        {
            RECT rect = new RECT();
            Win32Api.GetWindowRect(handle, out rect);
            return rect;
            //return new Rectangle(rect.Left, rect.Top, (rect.Right - rect.Left) + 1, (rect.Bottom - rect.Top) + 1);
        }

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (Win32Api.GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static IntPtr GetForegroundWindow()
        {
            throw new NotImplementedException();
        }

        #region enumwindows to conver to process id to hwnd

        public static IntPtr[] GetProcessWindows(int process)
        {
            IntPtr[] apRet = (new IntPtr[256]);
            int iCount = 0;
            IntPtr pLast = IntPtr.Zero;
            do
            {
                pLast = Win32Api.FindWindowEx(IntPtr.Zero, pLast, null, null);
                int iProcess_;
                Win32Api.GetWindowThreadProcessId(pLast, out iProcess_);
                if (iProcess_ == process) apRet[iCount++] = pLast;
            } while (pLast != IntPtr.Zero);
            System.Array.Resize(ref apRet, iCount);
            return apRet;
        }
        #endregion


    }//end of class

}
