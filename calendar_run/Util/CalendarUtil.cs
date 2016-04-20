using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Util {
    /// <summary>
    /// Algorithms related to calendar
    /// </summary>
    public class CalendarUtil {
        private static readonly int[] daysOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// Get the days count of a month.
        /// Author: ChuyangLiu
        /// </summary>
        public static int GetDaysOfMonth(int year, int month) {
            if (month == 2 && IsLeapYear(year)) {
                return 29;
            } else {
                return daysOfMonth[month - 1];
            }
        }

        /// <summary>
        /// Check if a given year is a leap year.
        /// Author: ChuyangLiu
        /// </summary>
        public static bool IsLeapYear(int year) {
            return year % 400 == 0 || (year % 100 != 0 && year % 4 == 0);
        }

        /// <summary>
        /// Get weeks name of the first day in a month
        /// Algorithm reference: 
        /// http://baike.baidu.com/link?url=_dKvIZZdG47HmkpHUhOKGzcmym3s5TMwQ62HR-tBRFQj4FRKnIpP5iSfnqJ32e6PF3LOhhuEbhrsXtObawDWuK
        /// Author: ChuyangLiu
        /// </summary>
        /// <returns>
        ///     0 to 6
        ///     Monday to Sunday
        /// </returns>
        public static int GetWeekOfTheFirstDay(int year, int month) {
            if (month == 1 || month == 2) {
                --year;
                month += 12;
            }
            int week = (1 + 2 * month + 3 * (month + 1) / 5
                + year + year / 4 - year / 100 + year / 400) % 7;
            return week;
        }
    }
}
