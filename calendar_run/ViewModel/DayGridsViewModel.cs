﻿using calendar_run.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace calendar_run.ViewModel {
    /// <summary>
    /// ViewModel for DayGrid collection in MainPage.
    /// </summary>
    public class DayGridsViewModel {
        public DayGridCollection DayGrids { get; set; } = null;

        /// <summary>
        /// Default constructor.
        /// Initialize DayGrids with current year and month.
        /// </summary>
        public DayGridsViewModel() {
            DateTime now = DateTime.Now;
            DayGrids = new DayGridCollection(now.Year, now.Month);
        }

        /// <summary>
        /// Refresh the calendar grids.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void refresh(int year, int month) {
            DayGrids.refresh(year, month);
        }

        /// <summary>
        /// Refresh contents to last month.
        /// </summary>
        public void refreshToLastMonth() {
            int year = DayGrids.Year;
            int month = DayGrids.Month;
            if (month == 1) {
                --year;
                month = 12;
            } else {
                --month;
            }
            refresh(year, month);
        }

        /// <summary>
        /// Refresh contents to next month.
        /// </summary>
        public void refreshToNextMonth() {
            int year = DayGrids.Year;
            int month = DayGrids.Month;
            if (month == 12) {
                ++year;
                month = 1;
            } else {
                ++month;
            }
            refresh(year, month);
        }

    }
}
