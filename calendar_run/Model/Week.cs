using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// Present a week number.
    /// </summary>
    public class Week {
        public string Name { get; set; }

        public Week(string name) {
            Name = name;
        }
    }
}
