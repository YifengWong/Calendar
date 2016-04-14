using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace calendar_run.Converter {
    /// <summary>
    /// Used in MainPage.
    /// Convert the width of the GridView to the width of each grid item.
    /// </summary>
    public class TotalWidthToGridWidth : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value == null)
                return null;
            return (double)value / 7.0 - 8.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return null;  // Not implemented
        }
    }
}
