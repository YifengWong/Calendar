using calendar_run.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// An observable DayGrid collection to present all calendar grids in a month.
    /// </summary>
    public class DayGridCollection : ObservableCollection<DayGrid> {
        /// <summary>
        /// A calendar has at most 42 grids,
        /// that is, 6 rows and 7 columns.
        /// Author: ChuyangLiu
        /// </summary>
        private static readonly int GRID_NUM = 6 * 7;

        /// <summary>
        /// Current year of the grids.
        /// Author: ChuyangLiu
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Current month of the grids.
        /// Author: ChuyangLiu
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// The first day index of the grids
        /// Author: ChuyangLiu
        /// </summary>
        public int FirstDayIndex { get; set; }

        /// <summary>
        /// Initilize all grids with default constructor
        /// Author: ChuyangLiu
        /// </summary>
        public DayGridCollection() {
            Year = -1;
            Month = -1;
            FirstDayIndex = -1;
            for (int i = 0; i < GRID_NUM; ++i) {
                Add(new DayGrid());
            }
        }

        /// <summary>
        /// Initialize all grids with specific year and month
        /// Author: ChuyangLiu
        /// </summary>
        public DayGridCollection(int year, int month) : this() {
            if (year <= 0 || month < 1 || month > 12) {
                return;
            }
            Refresh(year, month);
        }

        /// <summary>
        /// Initialize the contents to default.
        /// Author: ChuyangLiu
        /// </summary>
        public void Reset() {
            for (int i = 0; i < GRID_NUM; ++i) {
                this[i].Enable = false;
                this[i].Day = -1;
                this[i].ClearAllItems();
            }
        }

        /// <summary>
        /// Refresh the content of day grids according to year and month
        /// Author: ChuyangLiu
        /// </summary>
        public void Refresh(int year, int month) {
            Reset();
            int firstDayIndex = CalendarUtil.GetWeekOfTheFirstDay(year, month);
            int daysOfMonth = CalendarUtil.GetDaysOfMonth(year, month);
            for (int i = firstDayIndex, cnt = 0; cnt < daysOfMonth; ++i, ++cnt) {
                this[i].Day = cnt + 1;
                this[i].Enable = true;
                this[i].ReloadItems(year, month);
            }
            Year = year;
            Month = month;
            FirstDayIndex = firstDayIndex;
        }

        /// <summary>
        /// Trigger an event to notify collection changed.
        /// This method will cause the binded views to update.
        /// Author: ChuyangLiu
        /// </summary>
        public void NotifyDataSetChanged() {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Override ToString() to show messages about the object.
        /// Author: ChuyangLiu
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
