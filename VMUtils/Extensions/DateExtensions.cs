using System;

namespace VMUtils.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Checks if the time elapsed is within a certain amount of seconds
        /// </summary>
        /// <param name="sourceDate">Source Date</param>
        /// <param name="numOfSecs">Is within X amount of Seconds</param>
        /// <returns></returns>
        public static bool IsTimeWithinXSeconds(this DateTime sourceDate, int numOfSecs)
        {
            return DateTime.UtcNow.Subtract(sourceDate) < TimeSpan.FromSeconds(numOfSecs);
        }
    }
}
