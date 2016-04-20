using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// An obserbable TodoItem collection.
    /// </summary>
    public class TodoItemCollection : ObservableCollection<TodoItem> {

        /// <summary>
        /// Default constructor
        /// Author: ChuyangLiu
        /// </summary>
        public TodoItemCollection() {
        }

        /// <summary>
        /// Reload TodoItems in given year, month and day from db.
        /// Author: ChuyangLiu
        /// </summary>
        public void ReloadItems(int year, int month, int day) {
            Clear();  // Clear old contents
            List<TodoItem> res = TodoItem.GetItems(year, month, day);
            foreach (TodoItem item in res) {
                Add(item);
            }
        }

        /// <summary>
        /// Initialize TodoItems list with given year, month and day.
        /// Author: ChuyangLiu
        /// </summary>
        //public TodoItemCollection(int year, int month, int day) {
        //    List<TodoItem> res = TodoItem.GetItems(year, month, day);
        //    foreach (TodoItem item in res) {
        //        Add(item);
        //    }
        //}
    }
}
