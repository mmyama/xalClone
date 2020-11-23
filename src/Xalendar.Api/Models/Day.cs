﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xalendar.Api.Models
{
    public class Day
    {
        private readonly DateTime _dateTime;

        public Day(DateTime dateTime, bool isSelected = false)
        {
            _dateTime = dateTime;
            _isSelected = isSelected;
        }

        public bool IsToday => DateTime.Now.Day == _dateTime.Day;

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

        public DateTime DateTime => _dateTime;

    }
}
