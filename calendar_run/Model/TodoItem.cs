﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    public class TodoItem {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Todo: ");
            sb.Append("Title: ");
            sb.Append(Title);
            sb.Append(" Details: ");
            sb.Append(Details);
            sb.Append(" Date: ");
            sb.Append(Date.ToString());
            return sb.ToString();
        }
    }
}