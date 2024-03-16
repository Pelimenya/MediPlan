using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class EventName
{
    public int EventNameId { get; set; }

    public string EventName1 { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
