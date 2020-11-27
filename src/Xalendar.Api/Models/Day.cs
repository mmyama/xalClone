using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xalendar.Api.Models
{
    public class Day
    {
        public DateTime DateTime { get; }

        public IList<Event> Events { get; }

        public bool IsWeekend => DateTime.DayOfWeek switch
        {
            DayOfWeek.Saturday => true,
            DayOfWeek.Sunday => true,
            _ => false
        };

        public Day(DateTime dateTime, bool isSelected = false)
        {
            DateTime = dateTime;
            _isSelected = isSelected;
            Events = new List<Event>();
        }

        public bool IsToday => DateTime.Now.Day == DateTime.Day;

        public bool HasEvents => Events.Any();

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Day dayToCompare)
                return dayToCompare.DateTime.Date.Ticks == DateTime.Date.Ticks;
            return false;
        }

        public override int GetHashCode() =>
            (DateTime.Date.Ticks).GetHashCode();

        public override string ToString() => DateTime.Day.ToString();


    }
}
