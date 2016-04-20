using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace calendar_run.Converter {
    /// <summary>
    /// Binding Converter:
    ///     convert between boolean value and int value.
    /// </summary>
    public class IntToVisibility : IValueConverter {

        /// <summary>
        /// Convert int to visibility.
        /// Author: ChuyangLiu
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value == null)
                return null;
            return ((int?)value == 0) ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// Convert visibility to int.
        /// Author: ChuyangLiu
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return null;  // Not implement for no usage
        }
    }
}
