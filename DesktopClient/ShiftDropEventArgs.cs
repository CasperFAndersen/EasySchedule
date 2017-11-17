using Core;
using System;

namespace DesktopClient
{
    public class ShiftDropEventArgs : EventArgs
    {
        public TemplateShift Shift { get; set; }
        public bool IsLastElement { get; set; }
    }
}