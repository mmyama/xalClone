// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
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
    }
}
