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

        public DayGridCollection() {
            for (int i = 0; i < GRID_NUM; ++i) {
                Add(new DayGrid() {
                    Enable = true,
                    Day = i + 1
                });
            }
        }

        public DayGridCollection(int year, int month) : this() {
            refresh(year, month);
        }

        /// <summary>
        /// Refresh the content of day grids according to year and month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void refresh(int year, int month) {

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
