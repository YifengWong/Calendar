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
        public bool Enable { get; set; } = false;

        /// <summary>
        /// The day number of the grid
        /// Author: ChuyangLiu
        /// </summary>
        public int Day { get; set; } = 0;

        /// <summary>
        /// A TodoItem in this day.
        /// Author: ChuyangLiu
        /// </summary>
        public TodoItem TodoItem { get; set; } = new TodoItem();

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
            sb.Append(", TodoItem: ");
            sb.Append(TodoItem == null ? "null" : TodoItem.ToString());
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
