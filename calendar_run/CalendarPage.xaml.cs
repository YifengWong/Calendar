﻿using calendar_run.Model;
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
        private CalendarPageViewModel ViewModel = null;

        public CalendarPage() {
            this.InitializeComponent();
            ViewModel = new CalendarPageViewModel();
        }

        private void AppBarButtonBack_Click(object sender, RoutedEventArgs e) {
            ViewModel.RefreshToLastMonth();
        }

        private void AppBarButtonNext_Click(object sender, RoutedEventArgs e) {
            ViewModel.RefreshToNextMonth();
        }

        private void CalendarGridView_ItemClick(object sender, ItemClickEventArgs e) {
            // Get clicked item
            DayGrid grid = e.ClickedItem as DayGrid;

            // Create a view model for EditTodoPage
            EditTodoPageViewModel vm = new EditTodoPageViewModel() {
                Item = grid.TodoItem,
                Year = ViewModel.DayGrids.Year,
                Month = ViewModel.DayGrids.Month,
                Day = grid.Day
            };

            Frame.Navigate(typeof(EditTodoPage), vm);
        }
    }
}
