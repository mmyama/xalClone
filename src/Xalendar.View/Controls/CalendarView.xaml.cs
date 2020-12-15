using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xalendar.Api.Extensions;
using Xalendar.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xalendar.View.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarView : ContentView
    {
        private readonly MonthContainer _monthContainer;
        public CalendarView()
        {
            InitializeComponent();

            _monthContainer = new MonthContainer(DateTime.Today);
            BindableLayout.SetItemsSource(CalendarDaysContainer, _monthContainer.Days);
            BindableLayout.SetItemsSource(CalendarDaysOfWeekContainer, _monthContainer.DaysOfWeek);
            MonthName.Text = _monthContainer.GetMonthName();
            YearName.Text = _monthContainer.GetYearName();

        }

        private async void OnPreviousMonthClick(object sender, EventArgs e)
        {
            var result = await Task.Run(() =>
            {
                _monthContainer.Previous();

                var days = _monthContainer.Days;
                var monthName = _monthContainer.GetMonthName();
                var yearName = _monthContainer.GetYearName();

                return (days, monthName, yearName);
            });

            MonthName.Text = result.monthName;
            YearName.Text = result.yearName;
            RecycleDays(result.days);

        }


        private async void OnNextMonthClick(object sender, EventArgs e)
        {
            var result = await Task.Run(() =>
            {
                _monthContainer.Next();

                var days = _monthContainer.Days;
                var monthName = _monthContainer.GetMonthName();
                var yearName = _monthContainer.GetYearName();

                return (days, monthName, yearName);
            });

            MonthName.Text = result.monthName;
            YearName.Text = result.yearName;
            RecycleDays(result.days);
        }

        private void RecycleDays(IReadOnlyList<Day> days)
        {
            for (var i = 0; i < CalendarDaysContainer.Children.Count; i++)
            {
                var dayContainer = days[i];
                var dayView = CalendarDaysContainer.Children[i];
                dayView.BindingContext = dayContainer;
            }
        }

    }
}
