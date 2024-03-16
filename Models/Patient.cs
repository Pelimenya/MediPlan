using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string Photo { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string PassportNumber { get; set; } = null!;

    public string PassportSeries { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public char Gender { get; set; }

    public string? Workplace { get; set; }

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly? LastVisitDate { get; set; }

    public DateOnly? NextVisitDate { get; set; }

    public string? MedicalHistory { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();

    public virtual Insurance? Insurance { get; set; }

    public virtual MedicalCard? MedicalCard { get; set; }
}
