using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Hospitalization
{
    public int HospitalizationId { get; set; }

    public int PatientId { get; set; }

    public int GoalId { get; set; }

    public int DepartmentId { get; set; }

    public char Condition { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? AdditionalInformation { get; set; }

    public int StatusId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Goal Goal { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual HospitalizationStatus Status { get; set; } = null!;
}
