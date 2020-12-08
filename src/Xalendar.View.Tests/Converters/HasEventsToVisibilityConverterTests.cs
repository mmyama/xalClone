// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NUnit.Framework;
using Xalendar.Api.Extensions;
using Xalendar.Api.Models;
using Xalendar.View.Converters;

namespace Xalendar.View.Tests.Converters
{
    [TestFixture]
    public class HasEventsToVisibilityConverterTests
    {
        [Test]
        public void VisibilityShouldBeFalseIfDayIsNull()
        {
            var day = default(Day);
            var converter = new HasEventsToVisibilityConverter();

            var result = (bool)converter.Convert(day, null, null, null);

            Assert.IsFalse(result);
        }

        [Test]
        public void VisibilityShouldBeFalseIfDayDoesntHaveEvents()
        {
            var day = new Day(DateTime.Now);
            var converter = new HasEventsToVisibilityConverter();

            var result = (bool)converter.Convert(day, null, null, null);

            Assert.IsFalse(result);
        }

        [Test]
        public void VisibilityShouldBeTrueIfDayHasEvents()
        {
            var dateTime = DateTime.Now;
            var day = new Day(dateTime);
            day.AddEvent(new Event(1, "Name", dateTime, dateTime, false));
            var converter = new HasEventsToVisibilityConverter();

            var result = (bool)converter.Convert(day, null, null, null);

            Assert.IsTrue(result);
        }
    }
}
