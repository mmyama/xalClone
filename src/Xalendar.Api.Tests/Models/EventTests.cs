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
    public class EventTests
    {
        [Test]
        public void ShouldAssignPropertyValues()
        {
            var id = int.MaxValue;
            var name = "Event Name";
            var startDateTime = new DateTime(2020, 1, 1, 10, 0, 0);
            var endDateTime = new DateTime(2020, 1, 1, 12, 0, 0);
            var isAllDay = false;

            var @event = new Event(id, name, startDateTime, endDateTime, isAllDay);

            Assert.AreEqual(id, @event.Id);
            Assert.AreEqual(name, @event.Name);
            Assert.AreEqual(startDateTime, @event.StartDateTime);
            Assert.AreEqual(endDateTime, @event.EndDateTime);
            Assert.AreEqual(isAllDay, @event.IsAllDay);
        }
    }
}
