using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyScheduleWebClient.Services
{
    public class MockShifts
    {

        public static List<Shift> GetAListOfShifts()
        {
            List<Shift> res = new List<Shift>();

            Shift s1 = new Shift() { Id = 1, StartTime = new DateTime(2017, 11, 14), Hours = 8 };

            res.Add(s1);

            return res;
        }
    }
}