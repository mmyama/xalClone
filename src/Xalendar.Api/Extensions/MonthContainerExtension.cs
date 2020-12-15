// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xalendar.Api.Models;

namespace Xalendar.Api.Extensions
{
    public static class MonthContainerExtension
    {
        public static void SelectDay(this MonthContainer monthContainer, Day selectedDay) => monthContainer._month.SelectDay(selectedDay);
        public static Day GetSelectedDay(this MonthContainer monthContainer) => monthContainer._month.GetSelectedDay();
        public static void AddEvents(this MonthContainer monthContainer, IList<Event> events) => monthContainer._month.AddEvents(events);
        public static string GetMonthName(this MonthContainer monthContainer) => monthContainer._month.MonthDateTime.ToString("MMMM");
        public static string GetYearName(this MonthContainer monthContainer) => monthContainer._month.MonthDateTime.ToString("yyyy");

        public static void Next(this MonthContainer monthContainer)
        {
            var nextDateTime = monthContainer._month.MonthDateTime.AddMonths(1);
            monthContainer._month = new Month(nextDateTime);
        }

        public static void Previous(this MonthContainer monthContainer)
        {
            var previousDateTime = monthContainer._month.MonthDateTime.AddMonths(-1);
            monthContainer._month = new Month(previousDateTime);
        }

        internal static void GetDayToDiscardAtStartOfMonth(this MonthContainer monthContainer, List<Day?> daysOfContainer)
        {
            var firstDay = monthContainer._month.Days.First();
            var numberOfDaysToDiscard = (int)firstDay.DateTime.DayOfWeek;

            for (var i = 0; i < numberOfDaysToDiscard; i++)
                daysOfContainer.Add(default(Day));
        }

        internal static void GetDayToDiscardAtEndOfMonth(this MonthContainer monthContainer, List<Day?> daysOfContainer)
        {
            var lastDay = monthContainer._month.Days.Last();
            var numberOfDaysToDiscard = 6 - (int)lastDay.DateTime.DayOfWeek;

            for (var i = 0; i < numberOfDaysToDiscard; i++)
                daysOfContainer.Add(default(Day));

            if (daysOfContainer.Count < 42)
                for (var i = daysOfContainer.Count; i < 42; i++)
                    daysOfContainer.Add(default(Day));
        }
    }
}
