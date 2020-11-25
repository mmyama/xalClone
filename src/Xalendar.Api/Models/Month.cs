using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Xalendar.Api.Extensions.MonthExtention;

namespace Xalendar.Api.Models
{
    public struct Month
    {
        public DateTime MonthDateTime { get; }
        public IReadOnlyList<Day> Days;

        public Month(DateTime dateTime)
        {
            MonthDateTime = dateTime;
            Days = GenerateDaysOfMonth(dateTime);
        }
    }

}
