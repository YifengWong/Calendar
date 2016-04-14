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
    /// ViewModel for DayGrid collection in MainPage.
    /// </summary>
    public class DayGridsViewModel {
        public DayGridCollection DayGrids { get; set; } = null;
        public ObservableCollection<Week> Weeks { get; set; } = null;

        /// <summary>
        /// Default constructor.
        /// Initialize DayGrids with current year and month.
        /// </summary>
        public DayGridsViewModel() {
            DateTime now = DateTime.Now;
            DayGrids = new DayGridCollection(now.Year, now.Month);
            InitWeeks();
        }

        /// <summary>
        /// Initialize weeks collection
        /// </summary>
        private void InitWeeks() {
            Weeks = new ObservableCollection<Week>();
            Weeks.Add(new Week("Mon"));
            Weeks.Add(new Week("Tue"));
            Weeks.Add(new Week("Wed"));
            Weeks.Add(new Week("Thu"));
            Weeks.Add(new Week("Fri"));
            Weeks.Add(new Week("Sat"));
            Weeks.Add(new Week("Sun"));
        }

        /// <summary>
        /// Refresh the calendar grids.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void Refresh(int year, int month) {
            DayGrids.Refresh(year, month);
        }

        /// <summary>
        /// Refresh contents to last month.
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
        /// Refresh contents to next month.
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
