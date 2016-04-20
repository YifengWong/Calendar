using calendar_run.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// Present one specific grid in a calendar
    /// </summary>
    public class DayGrid {

        /// <summary>
        /// If the grid is not need to shown, this value is false.
        /// Otherwise, it is true.
        /// Author: ChuyangLiu
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// The day number of the grid
        /// Author: ChuyangLiu
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// TodoItem list in this day.
        /// Author: ChuyangLiu
        /// </summary>
        public List<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// Initialize fields.
        /// Author: ChuyangLiu
        /// </summary>
        public DayGrid() {
            Enable = false;
            Day = -1;
            TodoItems = new List<TodoItem>();
        }

        /// <summary>
        /// Reload Todoitems in given year,month and day from db.
        /// Author: ChuyangLiu
        /// </summary>
        public void ReloadItems(int year, int month) {
            TodoItems = TodoItem.GetItems(year, month, Day);
        }

        /// <summary>
        /// Clear all elements in TodoItems.
        /// Author: ChuyangLiu
        /// </summary>
        public void ClearAllItems() {
            TodoItems.Clear();
        }

        /// <summary>
        /// Override ToString() to show messages about the object.
        /// Author: ChuyangLiu
        /// </summary>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ Enable: ");
            sb.Append(Enable);
            sb.Append(", Day: ");
            sb.Append(Day);
            sb.Append(", TodoItems: [");
            for (int i = 0; i < TodoItems.Count; ++i) {
                if (i != 0) {
                    sb.Append(", ");
                }
                sb.Append(TodoItems[i].ToString());
            }
            sb.Append("] }");
            return sb.ToString();
        }
    }
}
