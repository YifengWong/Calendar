using calendar_run.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.ViewModel {
    /// <summary>
    /// ViewModel for TodoListPage
    /// </summary>
    public class TodoListPageViewModel {
        /// <summary>
        /// The year, month, day of the current page.
        /// Author: ChuyangLiu
        /// </summary>
        public int Year { get; set; } = -1;
        public int Month { get; set; } = -1;
        public int Day { get; set; } = -1;

        /// <summary>
        /// TodoItems in current year, day and month
        /// Author: ChuyangLiu
        /// </summary>
        public TodoItemCollection TodoItems { get; set; } = null;

        /// <summary>
        /// Initialize fields.
        /// Author: ChuyangLiu
        /// </summary>
        public TodoListPageViewModel() {
            Year = Month = Day = -1;
            TodoItems = null;
        }

        /// <summary>
        /// Reload TodoItems in current year, month and day.
        /// Author: ChuyangLiu
        /// </summary>
        public void ReloadItems() {
            if (TodoItems == null) {
                TodoItems = new TodoItemCollection();
            }
            TodoItems.ReloadItems(Year, Month, Day);
        }
    }
}
