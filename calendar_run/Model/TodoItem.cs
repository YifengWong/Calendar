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
