using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Type
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
