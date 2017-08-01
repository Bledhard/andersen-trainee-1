using System;

namespace Fifth.Extensions
{
    //Почитать про методы расширения (Extension methods)
    public static class DateTimeExtensions
    {
        public static string ToDbDate(this DateTime dateTime)
        {
            return $"{dateTime.Day}-{dateTime.Month}-{dateTime.Year}";
        }
    }
}
