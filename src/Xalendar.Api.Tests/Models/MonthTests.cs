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

        [Test]
        public void MonthsShouldBeEqual()
        {
            var month1 = new Month(new DateTime(2020, 1, 1));
            var month2 = new Month(new DateTime(2020, 1, 10));

            var result = month1.Equals(month2);

            Assert.IsTrue(result);
        }

        [Test]
        public void MonthsShouldNotBeEqual()
        {
            var month1 = new Month(new DateTime(2020, 1, 1));
            var month2 = new Month(new DateTime(2020, 2, 1));

            var result = month1.Equals(month2);

            Assert.IsFalse(result);
        }

        [Test]
        public void ObjectsShouldBeEqual()
        {
            object obj1 = new Month(new DateTime(2020, 1, 1));
            object obj2 = new Month(new DateTime(2020, 1, 10));

            var result = obj1.Equals(obj2);

            Assert.IsTrue(result);
        }

        [Test]
        public void ObjectsShouldNotBeEqual()
        {
            object obj1 = new Month(new DateTime(2020, 1, 1));
            object obj2 = new Month(new DateTime(2020, 2, 1));

            var result = obj1.Equals(obj2);

            Assert.IsFalse(result);
        }

        [Test]
        public void MonthEqualsOperatorShouldBeEqual()
        {
            var month1 = new Month(new DateTime(2020, 1, 1));
            var month2 = new Month(new DateTime(2020, 1, 10));

            var result = month1 == month2;

            Assert.IsTrue(result);
        }

        [Test]
        public void MonthNotEqualsOperatorShouldNotBeEqual()
        {
            var month1 = new Month(new DateTime(2020, 1, 1));
            var month2 = new Month(new DateTime(2020, 2, 1));

            var result = month1 != month2;

            Assert.IsTrue(result);
        }

    }
}
