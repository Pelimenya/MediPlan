using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Medication
{
    public int MedicationId { get; set; }

    public string MedicationName { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
