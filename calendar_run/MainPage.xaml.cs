using calendar_run.Model;
using calendar_run.Util;
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
    public sealed partial class MainPage : Page {

        public MainPage() {
            this.InitializeComponent();

            TodoItem item = new TodoItem {
                Date = DateTime.Now,
                Title = "Title1",
                Details = "Details1"
            };

            DayGrid grid = new DayGrid {
                Day = 1,
                Enable = true,
                TodoItem = item
            };

            DayGridCollection coll = new DayGridCollection(2016, 4);
            coll.Bind(item);

            textBlock.Text = coll.ToString();
        }

    }
}
