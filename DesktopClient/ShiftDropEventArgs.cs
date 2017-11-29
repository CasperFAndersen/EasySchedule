using Core;
using System;

namespace DesktopClient
{
    public class ShiftDropEventArgs : EventArgs
    {
        public Shift Shift { get; set; }
        public bool IsLastElement { get; set; }
    }
}