// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Xalendar.Api.Extensions;

namespace Xalendar.Api.Models
{
    public class MonthContainer
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Month _month;

        public IReadOnlyList<Day?> Days { get; }
        public IReadOnlyList<string> DaysOfWeek { get; }

        public MonthContainer(DateTime dateTime)
        {
            _month = new Month(dateTime);

            var daysOfContainer = new List<Day?>();
            this.GetDayToDiscardAtStartOfMonth(daysOfContainer);
            daysOfContainer.AddRange(_month.Days);
            this.GetDayToDiscardAtEndOfMonth(daysOfContainer);
            Days = daysOfContainer;

            var cultureInfo = CultureInfo.CurrentCulture;
            var dateTimeFormat = cultureInfo.DateTimeFormat;
            DaysOfWeek = new List<string>
            {
                dateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Sunday).Substring(0,3).ToUpper(),
                dateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Monday).Substring(0,3).ToUpper(),
                dateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Tuesday).Substring(0,3).ToUpper(),
                dateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Wednesday).Substring(0,3).ToUpper(),
                dateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Thursday).Substring(0,3).ToUpper(),
                dateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Friday).Substring(0,3).ToUpper(),
                dateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Saturday).Substring(0,3).ToUpper()
            };
        }
    }
}
