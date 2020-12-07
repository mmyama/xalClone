using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Xalendar.View.ViewModels;

namespace Xalendar.View.Tests.ViewModels
{
    [TestFixture]
    public class CalendarViewModelTests
    {
        [Test]
        public void ConstructorShouldPopulateDays()
        {
            var viewModel = new CalendarViewModel();

            Assert.NotNull(viewModel.Days);
        }

        [Test]
        public void ConstructorShouldPopulateDaysOfWeek()
        {
            var viewModel = new CalendarViewModel();

            Assert.NotNull(viewModel.DaysOfWeek);
        }

        [Test]
        public void ConstructorShouldPopulateMonthName()
        {
            var viewModel = new CalendarViewModel();

            Assert.NotNull(viewModel.MonthName);
        }

    }
}
