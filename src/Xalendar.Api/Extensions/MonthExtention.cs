using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xalendar.Api.Models;

namespace Xalendar.Api.Extensions
{
    public static class MonthExtention
    {
        public static void SelectDay(this Month month, Day selectedDay)
        {
            UnselectCurrentDay(month);
            SelectNewDay(selectedDay, month);
        }

        private static void UnselectCurrentDay(Month month)
        {
            var selectedDay = month.GetSelectedDay();

            if (selectedDay is null)
                return;

            selectedDay.IsSelected = false;
        }

        private static void SelectNewDay(Day selectedDay, Month month)
        {
            var newSelectedDay = month.Days.FirstOrDefault(day => day.DateTime.Equals(selectedDay.DateTime));

            if (newSelectedDay is null)
                return;

            newSelectedDay.IsSelected = true;
        }

        public static Day GetSelectedDay(this Month month)
        {
            return month.Days.FirstOrDefault(day => day.IsSelected);
        }

        public static List<Day> GenerateDaysOfMonth(DateTime dateTime)
        {
            return Enumerable
                .Range(1, DateTime.DaysInMonth(dateTime.Year, dateTime.Month))
                .Select(dayValue => new DateTime(dateTime.Year, dateTime.Month, dayValue))
                .Select(dateTime => new Day(dateTime))
                .ToList();
        }

        public static void AddEvents(this Month month, IList<Event> events)
        {
            foreach (var @event in events)
            {
                var eventDate = @event.StartDateTime;
                month.Days.FirstOrDefault(day => day.DateTime.Date.Equals(eventDate))?.AddEvent(@event);
            }
        }

    }
}
