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
    /// Page to edit a TodoItem
    /// </summary>
    public sealed partial class EditTodoPage : Page {
        private EditTodoPageViewModel ViewModel = null;

        /// <summary>
        /// Initialize.
        /// Author: ChuyangLiu
        /// </summary>
        public EditTodoPage() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Override OnNavigatedTo.
        /// Author: ChuyangLiu
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            EditTodoPageViewModel vm = e.Parameter as EditTodoPageViewModel;
            if (e != null) {
                ViewModel = vm;
                if (ViewModel.TodoItem.Id.Length == 0) {
                    deleteBtn.Visibility = Visibility.Collapsed;
                }
            }
        }
        
        /// <summary>
        /// Go to previous page.
        /// Author: ChuyangLiu
        /// </summary>
        private void GoBack() {
            Frame.Navigate(typeof(CalendarPage), ViewModel);
        }

        /// <summary>
        /// Back button click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e) {
            GoBack();
        }

        /// <summary>
        /// Accept button click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void AcceptButton_Click(object sender, RoutedEventArgs e) {
            if (titleTxt.Text.Length > 0) {  // Require the title text not empty
                ViewModel.TodoItem.Title = titleTxt.Text;
                ViewModel.TodoItem.Details = detailsTxt.Text;
                ViewModel.TodoItem.Year = ViewModel.Year;
                ViewModel.TodoItem.Month = ViewModel.Month;
                ViewModel.TodoItem.Day = ViewModel.Day;
                ViewModel.TodoItem.Save();
                //ViewModel.TodoItem.Remove();
            }
            GoBack();
        }

        /// <summary>
        /// Delete button click event.
        /// Author: ChuyangLiu
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            ViewModel.TodoItem.Remove();
            GoBack();
        }
    }
}
