using calendar_run.Model;
using calendar_run.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace calendar_run {
    /// <summary>
    /// Page to show TodoItems list in a specific year, month and day.
    /// </summary>
    public sealed partial class TodoListPage : Page {
        private TodoListPageViewModel ViewModel = null;

        /// <summary>
        /// Default constructor.
        /// Author: ChuyangLiu
        /// </summary>
        public TodoListPage() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Override OnNavigatedTo().
        /// Author: ChuyangLiu
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            TodoListPageViewModel vm = e.Parameter as TodoListPageViewModel;
            if (e != null) {
                ViewModel = vm;
                ViewModel.ReloadItems();
            } else {
                ViewModel = new TodoListPageViewModel();
            }
        }

        /// <summary>
        /// Back button click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(CalendarPage), ViewModel);
        }

        /// <summary>
        /// Add button click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e) {
            EditTodoPageViewModel vm = new EditTodoPageViewModel {
                TodoItem = null,
                Year = ViewModel.Year,
                Month = ViewModel.Month,
                Day = ViewModel.Day
            };
            Frame.Navigate(typeof(EditTodoPage), vm);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e) {
            TodoItem item = e.ClickedItem as TodoItem;
            EditTodoPageViewModel vm = new EditTodoPageViewModel {
                TodoItem = item,
                Year = ViewModel.Year,
                Month = ViewModel.Month,
                Day = ViewModel.Day
            };
            Frame.Navigate(typeof(EditTodoPage), vm);
        }
    }
}
