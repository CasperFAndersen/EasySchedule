using System;

namespace Core
{
    public class TempShift
    {
        public DateTime WeekNumber { get; set; }
        public int Hours { get; set; }
        public DateTime StartTime { get; set; }
        public Employee ShiftEmployee { get; set; }

        public TempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            WeekNumber = weekNumber;
            Hours = hours;
            StartTime = startTime;
            ShiftEmployee = shiftEmployee;
        }
    }
}