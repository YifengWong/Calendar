using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// Present one specific to-do item.
    /// </summary>
    public class TodoItem {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public TodoItem() {
            Reset();
        }

        /// <summary>
        /// Reset the properties to the origin.
        /// </summary>
        public void Reset() {
            Date = DateTime.Today;
            Title = "";
            Details = "";
        }

        /// <summary>
        /// Get items in the specific month and year from the db
        /// TODO Get TodoItems from database
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static List<TodoItem> GetItems(int year, int month) {
            List<TodoItem> res = new List<TodoItem>();

            // Use some temp data first
            DateTime date1 = new DateTime(year, month, 10);
            DateTime date2 = date1.AddDays(3);
            DateTime date3 = date2.AddDays(3);

            TodoItem item1 = new TodoItem() {
                Date = date1,
                Title = "Do cleaning",
                Details = "As soon as possible"
            };

            TodoItem item2 = new TodoItem() {
                Date = date2,
                Title = "Do studying",
                Details = "As smart as possible"
            };

            TodoItem item3 = new TodoItem() {
                Date = date3,
                Title = "Do playing",
                Details = "As happy as possible"
            };

            res.Add(item1);
            res.Add(item2);
            res.Add(item3);

            return res;
        }

        /// <summary>
        /// Override ToString() to show messages about the object.
        /// </summary>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ Title: ");
            sb.Append(Title);
            sb.Append(", Details: ");
            sb.Append(Details);
            sb.Append(", Date: ");
            sb.Append(Date.ToString());
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
