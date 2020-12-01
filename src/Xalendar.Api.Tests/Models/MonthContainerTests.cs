// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Xalendar.Api.Models;

namespace Xalendar.Api.Tests.Models
{
    [TestFixture]
    public class MonthContainerTests
    {
        [Test]
        public void MonthContainerShouldContainDaysOfMonth()
        {
            var dateTime = DateTime.Now;

            var monthContainer = new MonthContainer(dateTime);

            Assert.IsNotEmpty(monthContainer.Days);
        }

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

            var result = monthContainer.GetName();

            Assert.AreEqual("dezembro", result);
        }

        [Test]
        public void MonthContainerShouldNavigateToNextMonth()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);

            monthContainer.Next();

            Assert.AreEqual("janeiro", monthContainer.GetName());
        }

        [Test]
        public void MonthContainerShouldNavigateToPreivousMonth()
        {
            var dateTime = new DateTime(2020, 12, 1);
            var monthContainer = new MonthContainer(dateTime);

            monthContainer.Previous();

            Assert.AreEqual("novembro", monthContainer.GetName());
        }

    }
}
