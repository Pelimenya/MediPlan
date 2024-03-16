using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int PatientId { get; set; }

    public int TypeId { get; set; }

    public int DoctorId { get; set; }

    public int DiagnosisId { get; set; }

    public int EventNameId { get; set; }

    public int ResultId { get; set; }

    public DateOnly EventDate { get; set; }

    public string? Recommendations { get; set; }

    public string? MedicalHistory { get; set; }

    public string? Symptoms { get; set; }

    public DateTime? EventStart { get; set; }

    public DateTime? EventEnd { get; set; }

    public virtual Diagnosis Diagnosis { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual EventName EventName { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual Result Result { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;

    public string PatientName => App.db.Patients.FirstOrDefault(x => x.PatientId == PatientId).LastName;  
    
    public string TypeName => App.db.Types.FirstOrDefault(x => x.TypeId == TypeId).TypeName;

    public string DocName => App.db.Doctors.FirstOrDefault(x => x.DoctorId == DoctorId).LastName;

    public TimeOnly? DocStartTime => App.db.Doctors.FirstOrDefault(x => x.DoctorId == DoctorId).StartTime;

    public TimeOnly? DocEndTime => App.db.Doctors.FirstOrDefault(x => x.DoctorId == DoctorId).EndTime;
}
