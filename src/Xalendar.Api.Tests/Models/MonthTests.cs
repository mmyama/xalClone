using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xalendar.Api.Models;
using Xalendar.Api.Extensions;

namespace Xalendar.Api.Tests.Models
{
    [TestFixture]
    public class MonthTests
    {
        [Test]
        public void November2020ShouldContain30Days()
        {
            var dateTime = new DateTime(2020, 11, 1);
            var month = new Month(dateTime);

            var result = month.Days;

            Assert.AreEqual(30, result.Count);
        }

        [Test]
        public void LeapYearFebruaryShouldContain29Days()
        {
            var dateTime = new DateTime(2020, 2, 1);
            var month = new Month(dateTime);

            var result = month.Days;

            Assert.AreEqual(29, result.Count);
        }

        [Test]
        public void ShouldNotExistSelectedDay()
        {
            var dateTime = new DateTime(2020, 2, 1);
            var month = new Month(dateTime);

            var selectedDay = month.GetSelectedDay();

            Assert.IsNull(selectedDay);
        }

        [Test]
        public void SelectedDayShouldBeTheFirstDayOfMonth()
        {
            var dateTime = new DateTime(2020, 2, 1);
            var month = new Month(dateTime);
            var isSelected = true;
            var day = new Day(dateTime, isSelected);
            month.SelectDay(day);

            var selectedDay = month.GetSelectedDay();

            Assert.AreEqual(day.DateTime.Date.Ticks, selectedDay.DateTime.Date.Ticks);
        }

        [Test]
        public void SelectedDayShouldBeChanged()
        {
            var dateTime = new DateTime(2020, 2, 1);
            var month = new Month(dateTime);
            var isSelected = true;
            var day = new Day(dateTime, isSelected);
            month.SelectDay(day);
            var newDaySelected = new Day(dateTime.AddDays(10), isSelected);
            month.SelectDay(newDaySelected);

            var selectedDay = month.GetSelectedDay();

            Assert.AreEqual(newDaySelected.DateTime.Date.Ticks, selectedDay.DateTime.Date.Ticks);
        }

        [Test]
        public void SelectDayFromAnotherMonthShouldFail()
        {
            var dateTime = new DateTime(2020, 2, 1);
            var month = new Month(dateTime);
            var isSelected = true;
            var day = new Day(dateTime.AddMonths(1), isSelected);
            month.SelectDay(day);

            var selectedDay = month.GetSelectedDay();

            Assert.IsNull(selectedDay);
        }
    }
}
