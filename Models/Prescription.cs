using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int EventId { get; set; }

    public int MedicationId { get; set; }

    public string? Dosage { get; set; }

    public string? AdministrationFormat { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Medication Medication { get; set; } = null!;
}
