using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xalendar.Api.Models;

namespace Xalendar.Api.Tests.Models
{
    [TestFixture]
    public class DayTests
    {
        [Test]
        public void DayShouldBeToday()
        {
            var dateTime = DateTime.Today;
            var day = new Day(dateTime);

            var result = day.IsToday;

            Assert.IsTrue(result);
        }

        [Test]
        public void DayShouldNotBeToday()
        {
            var dateTime = DateTime.Today.AddDays(1);
            var day = new Day(dateTime);

            var result = day.IsToday;

            Assert.IsFalse(result);
        }

        [Test]
        public void DayIsUnselected()
        {
            var dateTime = DateTime.Today;
            var day = new Day(dateTime);

            var result = day.IsSelected;

            Assert.IsFalse(result);
        }

        [Test]
        public void DayIsSelected()
        {
            var dateTime = DateTime.Today;
            var day = new Day(dateTime);
            day.IsSelected = true;

            var result = day.IsSelected;

            Assert.IsTrue(result);
        }

        [Test]
        public void ParameterOfEqualComparisonShouldNotBeDayClass()
        {
            var day = new Day(DateTime.Now);

            var comparison = day.Equals(new DateTime());

            Assert.IsFalse(comparison);
        }

        [Test]
        public void DayShouldBeEquals()
        {
            var dayOne = new Day(DateTime.Now);
            var dayTwo = new Day(DateTime.Now);

            var comparison = dayOne.DateTime.Date.Ticks.Equals(dayTwo.DateTime.Date.Ticks);

            var hashCodeComparison = dayOne.DateTime.Date.Ticks.GetHashCode()
                .Equals(dayTwo.DateTime.Date.Ticks.GetHashCode());
            Assert.IsTrue(comparison);
            Assert.IsTrue(hashCodeComparison);
        }

        [Test]
        public void DayShouldNotBeEquals()
        {
            var dayOne = new Day(DateTime.Now);
            var dayTwo = new Day(DateTime.Now.AddDays(1));

            var comparison = dayOne.DateTime.Date.Ticks.Equals(dayTwo.DateTime.Date.Ticks);

            Assert.IsFalse(comparison);
        }

        [Test]
        public void EventsShouldBeEmpty()
        {
            var day = new Day(DateTime.Now);

            var events = day.Events;

            Assert.IsEmpty(events);
        }
    }
}














