using calendar_run.Model;
using calendar_run.Util;
using calendar_run.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace calendar_run {
    public sealed partial class CalendarPage : Page {
        private DayGridsViewModel ViewModel;

        public CalendarPage() {
            this.InitializeComponent();
            ViewModel = new DayGridsViewModel();
        }

        private void AppBarButtonBack_Click(object sender, RoutedEventArgs e) {
            ViewModel.RefreshToLastMonth();
        }

        private void AppBarButtonNext_Click(object sender, RoutedEventArgs e) {
            ViewModel.RefreshToNextMonth();
        }
    }
}
