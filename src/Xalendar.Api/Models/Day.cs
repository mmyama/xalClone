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

        public override string ToString() => DateTime.Day.ToString();


    }
}
