using calendar_run.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// A DayGrid collection to present all calendar grids in a month.
    /// </summary>
    public class DayGridCollection : ObservableCollection<DayGrid> {
        /// <summary>
        /// A calendar has at most 42 grids,
        /// that is, 6 rows and 7 columns.
        /// </summary>
        private static readonly int GRID_NUM = 6 * 7;

        /// <summary>
        /// Current year of the grids.
        /// </summary>
        public int Year { get; set; } = 0;

        /// <summary>
        /// Current month of the grids.
        /// </summary>
        public int Month { get; set; } = 0;

        /// <summary>
        /// The first day index of the grids
        /// </summary>
        public int FirstDayIndex { get; set; } = -1;

        /// <summary>
        /// Initilize all grids with default constructor
        /// </summary>
        public DayGridCollection() {
            for (int i = 0; i < GRID_NUM; ++i) {
                Add(new DayGrid());
            }
        }

        /// <summary>
        /// Initialize all grids with specific year and month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public DayGridCollection(int year, int month) : this() {
            if (year <= 0 || month < 1 || month > 12) {
                return;
            }
            refresh(year, month);
        }

        /// <summary>
        /// Refresh the content of day grids according to year and month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void refresh(int year, int month) {
            int firstDayIndex = CalendarUtil.GetWeekOfTheFirstDay(year, month);
            int daysOfMonth = CalendarUtil.GetDaysOfMonth(year, month);
            for (int i = firstDayIndex, cnt = 0; cnt < daysOfMonth; ++i, ++cnt) {
                this[i].Day = cnt + 1;
                this[i].Enable = true;
            }
            Year = year;
            Month = month;
            FirstDayIndex = firstDayIndex;
        }

        /// <summary>
        /// Bind a TodoItem with the corresponding grid
        /// </summary>
        /// <param name="todoItem"></param>
        public void Bind(TodoItem todoItem) {
            if (todoItem.Date.Year != Year || todoItem.Date.Month != Month) {
                return;
            }
            this[FirstDayIndex + todoItem.Date.Day - 1].TodoItem = todoItem;
        }

        /// <summary>
        /// Override ToString() to show messages about the object.
        /// </summary>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < GRID_NUM; ++i) {
                sb.Append(this[i].Enable ? this[i].Day : 0);
                sb.Append("  ");
                if (i != 0 && (i + 1) % 7 == 0) {
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
    }
}
