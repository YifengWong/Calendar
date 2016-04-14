﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// Present one specific day grid in a calendar
    /// </summary>
    public class DayGrid {
        public bool Enable { get; set; }
        public int Day { get; set; }
        public TodoItem TodoItem { get; set; } = null;

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("DayGrid: ");
            sb.Append("Enable: ");
            sb.Append(Enable);
            sb.Append(" Day: ");
            sb.Append(Day);
            sb.Append(" TodoItem: ");
            sb.Append(TodoItem == null ? "null" : TodoItem.ToString());
            return sb.ToString();
        }
    }
}
