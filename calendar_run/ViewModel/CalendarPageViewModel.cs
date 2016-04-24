using calendar_run.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace calendar_run.ViewModel {
    /// <summary>
    /// ViewModel for CalendarPage.
    /// </summary>
    public class CalendarPageViewModel {
        /// <summary>
        /// Day grids in a calendar.
        /// Author: ChuyangLiu
        /// </summary>
        public DayGridCollection DayGrids { get; set; } = null;
     
        /// <summary>
        /// Title weeks name in a calendar.
        /// Author: ChuyangLiu
        /// </summary>
        public WeekCollection Weeks { get; set; } = null;

        /// <summary>
        /// Initiailize with current year and month.
        /// Author: ChuyangLiu
        /// </summary>
        public CalendarPageViewModel() {
            DateTime today = DateTime.Today;
            DayGrids = new DayGridCollection(today.Year, today.Month);
            Weeks = new WeekCollection();
        }

        /// <summary>
        /// Initiailize with given year and month.
        /// Author: ChuyangLiu
        /// </summary>
        public CalendarPageViewModel(int year, int month) {
            DayGrids = new DayGridCollection(year, month);
            Weeks = new WeekCollection();
        }

        /// <summary>
        /// Refresh the calendar grids.
        /// Author: ChuyangLiu
        /// </summary>
        public void Refresh(int year, int month) {
            DayGrids.Refresh(year, month);
            DayGrids.NotifyDataSetChanged();
        }

        /// <summary>
        /// Refresh DayGridCollection to last month.
        /// Author: ChuyangLiu
        /// </summary>
        public void RefreshToLastMonth() {
            int year = DayGrids.Year;
            int month = DayGrids.Month;
            if (month == 1) {
                --year;
                month = 12;
            } else {
                --month;
            }
            Refresh(year, month);
        }

        /// <summary>
        /// Refresh DayGridCollection to next month.
        /// Author: ChuyangLiu
        /// </summary>
        public void RefreshToNextMonth() {
            int year = DayGrids.Year;
            int month = DayGrids.Month;
            if (month == 12) {
                ++year;
                month = 1;
            } else {
                ++month;
            }
            Refresh(year, month);
        }

    }
}
