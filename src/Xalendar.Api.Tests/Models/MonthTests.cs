using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xalendar.Api.Models;

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

            var result = month.GetDaysOfMonth();

            Assert.AreEqual(30, result.Count);
        }

        [Test]
        public void LeapYearFebruaryShouldContain29Days()
        {
            var dateTime = new DateTime(2020, 2, 1);
            var month = new Month(dateTime);

            var result = month.GetDaysOfMonth();

            Assert.AreEqual(29, result.Count);
        }

    }
}
