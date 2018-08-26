using System;

namespace Library.Interfaces
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        DateTime Add(int day = 0, int hour = 0, int min = 0, int sec = 0);
        DateTime Subtract(int day = 0, int hour = 0, int min = 0, int sec = 0);
    }
}
