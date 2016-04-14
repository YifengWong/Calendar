using calendar_run.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.ViewModel {
    /// <summary>
    /// ViewModel for DayGrid collection
    /// </summary>
    public class DayGridsViewModel {
        public DayGridCollection DayGrids { get; set; } = null;

        /// <summary>
        /// Default constructor.
        /// Initialize DayGrids with current year and month.
        /// </summary>
        public DayGridsViewModel() {
            DateTime now = DateTime.Now;
            DayGrids = new DayGridCollection(now.Year, now.Month);
        }

    }
}
