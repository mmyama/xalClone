// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Xalendar.Api.Models;

namespace Xalendar.View.ViewModels
{
    public class CalendarViewModel
    {
        private readonly MonthContainer _monthContainer;

        public IReadOnlyList<Day?> Days { get; }
        public IReadOnlyList<string> DaysOfWeek { get; }

        public CalendarViewModel()
        {
            _monthContainer = new MonthContainer(DateTime.Today);
            Days = _monthContainer.Days;
            DaysOfWeek = _monthContainer.DaysOfWeek;
        }
    }
}
