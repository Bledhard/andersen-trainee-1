using System;

namespace AndersenTrainee1.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDbDate(this DateTime dateTime)
        {
            return $"{dateTime.Day}-{dateTime.Month}-{dateTime.Year}";
        }

        public static string ToDbDateTime(this DateTime dateTime)
        {
            return $"{dateTime.Day}-{dateTime.Month}-{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
        }
    }
}