using calendar_run.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.ViewModel {
    /// <summary>
    /// ViewModel for EditTodoPage.
    /// </summary>
    public class EditTodoPageViewModel {
        public TodoItem TodoItem { get; set; } = null;
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
