using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;

        public DateTime Add(int day = 0, int hour = 0, int min = 0, int sec = 0) => DateTime.Now.AddDays(day).AddHours(hour).AddMinutes(min).AddSeconds(sec);

        public DateTime Subtract(int day = 0, int hour = 0, int min = 0, int sec = 0)
        {
            TimeSpan ts = new TimeSpan(day, hour, min, sec);
            return DateTime.Now.Subtract(ts);
        }
    }
}
