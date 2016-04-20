using calendar_run.Model;
using calendar_run.Util;
using calendar_run.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace calendar_run {
    /// <summary>
    /// Page to show the calendar view.
    /// </summary>
    public sealed partial class CalendarPage : Page {
        private CalendarPageViewModel ViewModel = null;

        /// <summary>
        /// Initialize.
        /// Author: ChuyangLiu
        /// </summary>
        public CalendarPage() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Override OnNavigatedTo.
        /// Author: ChuyangLiu
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            TodoListPageViewModel vm = e.Parameter as TodoListPageViewModel;
            if (vm != null) {  // Navigated from EditTodoPage
                ViewModel = new CalendarPageViewModel(vm.Year, vm.Month);
            } else {  // First open
                ViewModel = new CalendarPageViewModel();
            }
        }

        /// <summary>
        /// Back button click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void AppBarButtonBack_Click(object sender, RoutedEventArgs e) {
            ViewModel.RefreshToLastMonth();
        }

        /// <summary>
        /// Next button click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void AppBarButtonNext_Click(object sender, RoutedEventArgs e) {
            ViewModel.RefreshToNextMonth();
        }

        /// <summary>
        /// GridView item click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void CalendarGridView_ItemClick(object sender, ItemClickEventArgs e) {
            // Get clicked item
            DayGrid grid = e.ClickedItem as DayGrid;

            if (!grid.Enable) {
                return;
            }

            // Create a view model for TodoListPage
            TodoListPageViewModel vm = new TodoListPageViewModel() {
                Year = ViewModel.DayGrids.Year,
                Month = ViewModel.DayGrids.Month,
                Day = grid.Day,
                TodoItems = null
            };

            Frame.Navigate(typeof(TodoListPage), vm);
        }

        /// <summary>
        /// Show data button click event.
        /// Click to show the datas in database (for fast debugging).
        /// Author: ChuyangLiu
        /// </summary>
        private void ShowDataButton_Click(object sender, RoutedEventArgs e) {
            List<TodoItem> items = TodoItem.GetAllItems();
            StringBuilder sb = new StringBuilder();
            foreach (TodoItem item in items) {
                sb.Append(item.ToString());
                sb.Append(Environment.NewLine);
            }
            var i = new MessageDialog(sb.ToString()).ShowAsync();
        }
    }
}
