using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Xalendar.Api.Extensions.MonthExtention;

namespace Xalendar.Api.Models
{
    public struct Month : IEquatable<Month>
    {
        public DateTime MonthDateTime { get; }
        public IReadOnlyList<Day> Days;

        public Month(DateTime dateTime)
        {
            MonthDateTime = dateTime;
            Days = GenerateDaysOfMonth(dateTime);
        }

        public bool Equals(Month other)
        {
            var yearValue = MonthDateTime.Year == other.MonthDateTime.Year;
            var monthValue = MonthDateTime.Month == other.MonthDateTime.Month;
            var days = Days.SequenceEqual(other.Days);

            return yearValue && monthValue;
            //return yearValue && monthValue && days;
        }

        public static bool operator ==(Month left, Month right) =>
            left.Equals(right);
        public static bool operator !=(Month left, Month right) =>
            !left.Equals(right);

        public override bool Equals(object obj) =>
            (obj is Month month) && (this.Equals(month));

        public override int GetHashCode() =>
            (MonthDateTime, Days).GetHashCode();
    }
}
