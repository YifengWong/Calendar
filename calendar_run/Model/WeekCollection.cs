using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// A collection contains seven week numbers
    /// </summary>
    public class WeekCollection : ObservableCollection<Week> {
        public WeekCollection() {
            Add(new Week("Mon"));
            Add(new Week("Tue"));
            Add(new Week("Wed"));
            Add(new Week("Thu"));
            Add(new Week("Fri"));
            Add(new Week("Sat"));
            Add(new Week("Sun"));
        }
    }
}
