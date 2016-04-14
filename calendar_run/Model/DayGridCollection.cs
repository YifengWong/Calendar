using calendar_run.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// A DayGrid collection to present all day grids in a month
    /// </summary>
    public class DayGridCollection : ObservableCollection<DayGrid> {
        // 6 rows, 7 columns in a calendar 
        private static readonly int GRID_NUM = 6 * 7;

        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        public int StartWeek { get; set; } = -1;

        public DayGridCollection() {
            for (int i = 0; i < GRID_NUM; ++i) {
                Add(new DayGrid());
            }
        }

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
            int startWeek = CalendarUtil.GetWeekOfTheFirstDay(year, month);
            int daysOfMonth = CalendarUtil.GetDaysOfMonth(year, month);
            for (int i = startWeek, cnt = 0; cnt < daysOfMonth; ++i, ++cnt) {
                this[i].Day = cnt + 1;
                this[i].Enable = true;
            }
            Year = year;
            Month = month;
            StartWeek = startWeek;
        }

        /// <summary>
        /// Bind a TodoItem with the corresponding grid
        /// </summary>
        /// <param name="todoItem"></param>
        public void Bind(TodoItem todoItem) {
            if (todoItem.Date.Year != Year || todoItem.Date.Month != Month) {
                return;
            }
            this[StartWeek + todoItem.Date.Day - 1].TodoItem = todoItem;
        }

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
