// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
using Xalendar.Api.Extensions;
using Xalendar.Api.Models;

namespace Xalendar.Api.Tests.Models
{
    [TestFixture]
    public class MonthContainerTests
    {
        [Test]
        [TestCaseSource(nameof(MonthsValuesTests))]
        public void MonthContainerShouldContain42Days(DateTime dateTime)
        {
            var monthContainer = new MonthContainer(dateTime);

            Assert.IsNotEmpty(monthContainer.Days);
            Assert.AreEqual(42, monthContainer.Days.Count);
        }

        private static object[] MonthsValuesTests =
        {
            new object[] {new DateTime(2020, 7, 1)},
            new object[] {new DateTime(2020, 8, 1)},
            new object[] {new DateTime(2015, 2, 1)}
        };

        [Test]
        public void MonthContainerCanSelectDay()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);
            var selectedDay = new Day(dateTime);

            monthContainer.SelectDay(selectedDay);

            Assert.AreEqual(selectedDay, monthContainer.GetSelectedDay());
        }

        [Test]
        public void MonthContainerShouldNotContainEvents()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);

            Assert.IsFalse(monthContainer._month.Days.Any(Day => Day.HasEvents));
        }

        [Test]
        public void MonthContainerShouldContainEvents()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);
            var events = new List<Event>
            {
                new Event(1, "Name", dateTime, dateTime, false)
            };

            monthContainer.AddEvents(events);

            Assert.IsTrue(monthContainer._month.Days.Any(Day => Day.HasEvents));
        }

        [Test]
        public void MonthContainerShouldHaveAName()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);

            var result = monthContainer.GetMonthName();

            Assert.AreEqual(monthContainer._month.MonthDateTime.ToString("MMMM"), result);
        }

        [Test]
        public void MonthContainerShouldNavigateToNextMonth()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);

            monthContainer.Next();

            Assert.AreEqual(monthContainer._month.MonthDateTime.ToString("MMMM"), monthContainer.GetMonthName());
        }

        [Test]
        public void MonthContainerShouldNavigateToPreivousMonth()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);

            monthContainer.Previous();

            Assert.AreEqual(monthContainer._month.MonthDateTime.ToString("MMMM"), monthContainer.GetMonthName());
        }

        [Test]
        [TestCaseSource(nameof(ValuesForDaysOfWeekTests))]
        public void MonthContainerShouldLocalizeDaysOfWeekCorrectly(string language, string dayOfWeekName)
        {
            CultureInfo.CurrentCulture = new CultureInfo(language);
            var dateTime = DateTime.Today;

            var monthContainer = new MonthContainer(dateTime);

            Assert.AreEqual(dayOfWeekName, monthContainer.DaysOfWeek.First());
        }

        private static object[] ValuesForDaysOfWeekTests =
        {
            new object[] { "pt-BR", "DOM" },
            new object[] { "en-US", "SUN" },
            new object[] { "fr-FR", "DIM" }
        };

    }
}
