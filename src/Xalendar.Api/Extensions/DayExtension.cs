// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Xalendar.Api.Models;

namespace Xalendar.Api.Extensions
{
    public static class DayExtension
    {
        public static void AddEvent(this Day day, Event @event)
        {
            day.Events.Add(@event);
        }
    }
}
