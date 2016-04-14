using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace calendar_run.Converter {
    /// <summary>
    /// Convert a boolean value to visibility value.
    /// </summary>
    public class BoolToVisibility : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value == null)
                return null;
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            if (value == null)
                return null;
            return (Visibility)value == Visibility.Visible ? true : false;
        }
    }
}
