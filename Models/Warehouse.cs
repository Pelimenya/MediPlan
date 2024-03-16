using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
