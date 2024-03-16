using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class StatusName
{
    public int StatusNameId { get; set; }

    public string StatusName1 { get; set; } = null!;

    public virtual ICollection<HospitalizationStatus> HospitalizationStatuses { get; set; } = new List<HospitalizationStatus>();
}
