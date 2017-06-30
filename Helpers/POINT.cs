using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CommandTestAutomation.Helpers
{

    /// <summary>
    ///     The Point structure defines the X- and Y- coordinates of a point.
    /// </summary>
    /// <remarks>
    ///     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/gdi/rectangl_0tiq.asp
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>
        ///     Specifies the X-coordinate of the point.
        /// </summary>
        public int X;

        /// <summary>
        ///     Specifies the Y-coordinate of the point.
        /// </summary>
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator ==(POINT a, POINT b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(POINT a, POINT b)
        {
            return !(a == b);
        }

        public bool Equals(POINT other)
        {
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(POINT)) return false;
            return Equals((POINT)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
       
}
