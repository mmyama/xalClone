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

        public bool Equals(Month other) =>
            (MonthDateTime, Days) == (other.MonthDateTime, other.Days);


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
