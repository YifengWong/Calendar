using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace calendar_run.Converter {
    /// <summary>
    /// Binding converter:
    ///     convert between A and B.
    ///     A: the width of the GridView in CalendarPage.
    ///     B: the width of one grid in CalendarPage.
    /// </summary>
    public class TotalWidthToGridWidth : IValueConverter {

        /// <summary>
        /// Convert A to B.
        /// Author: ChuyangLiu
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value == null)
                return null;
            return (double)value / 7.0 - 8.0;
        }

        /// <summary>
        /// Convert B to A.
        /// Author: ChuyangLiu
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return null;  // Not implemented for no usage
        }
    }
}
