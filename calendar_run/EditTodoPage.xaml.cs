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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace calendar_run {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditTodoPage : Page {
        private EditTodoPageViewModel ViewModel = null;

        public EditTodoPage() {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            EditTodoPageViewModel vm = e.Parameter as EditTodoPageViewModel;
            if (e != null) {
                ViewModel = vm;
            }
        }

        private void GoBack() {
            Frame.Navigate(typeof(CalendarPage), ViewModel);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            GoBack();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e) {
            ViewModel.TodoItem.Title = titleTxt.Text;
            ViewModel.TodoItem.Details = detailsTxt.Text;
            GoBack();
        }
    }
}
