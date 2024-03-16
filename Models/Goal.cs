using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Goal
{
    public int GoalId { get; set; }

    public string GoalName { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
}
