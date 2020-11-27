﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xalendar.Api.Models
{
    public class Event
    {

        public object Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public bool IsAllDay { get; private set; }

        public Event(object id, string name, DateTime startDateTime, DateTime endDateTime, bool isAllDay)
        {
            Id = id;
            Name = name;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            IsAllDay = isAllDay;
        }
    }
}
