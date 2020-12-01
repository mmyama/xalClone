// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xalendar.Api.Extensions;

namespace Xalendar.Api.Models
{
    public class MonthContainer
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Month _month;

        public IReadOnlyList<Day> Days { get; }

        public MonthContainer(DateTime dateTime)
        {
            _month = new Month(dateTime);
            Days = _month.Days;
        }



    }
}
