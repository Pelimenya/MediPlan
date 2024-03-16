using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MediPlan.Models;

public partial class Dbcontext : DbContext
{
    public Dbcontext()
    {
    }

    public Dbcontext(DbContextOptions<Dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventName> EventNames { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Hospitalization> Hospitalizations { get; set; }

    public virtual DbSet<HospitalizationStatus> HospitalizationStatuses { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<MedicalCard> MedicalCards { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<StatusName> StatusNames { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; port=5432; database=MedicalCenterEn; Username=Pelimenya; Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasColumnName("department_name");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.DiagnosisId).HasName("diagnosis_pkey");

            entity.ToTable("diagnosis");

            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.DiagnosisName)
                .HasMaxLength(100)
                .HasColumnName("diagnosis_name");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("doctors_pkey");

            entity.ToTable("doctors");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.Specialty)
                .HasMaxLength(100)
                .HasColumnName("specialty");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_end");
            entity.Property(e => e.EventNameId).HasColumnName("event_name_id");
            entity.Property(e => e.EventStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_start");
            entity.Property(e => e.MedicalHistory).HasColumnName("medical_history");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Recommendations).HasColumnName("recommendations");
            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.Symptoms).HasColumnName("symptoms");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Diagnosis).WithMany(p => p.Events)
                .HasForeignKey(d => d.DiagnosisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_diagnosis_id_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Events)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_doctor_id_fkey");

            entity.HasOne(d => d.EventName).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_event_name_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Events)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("events_patient_id_fkey");

            entity.HasOne(d => d.Result).WithMany(p => p.Events)
                .HasForeignKey(d => d.ResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_result_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.Events)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_type_id_fkey");
        });

        modelBuilder.Entity<EventName>(entity =>
        {
            entity.HasKey(e => e.EventNameId).HasName("event_name_pkey");

            entity.ToTable("event_name");

            entity.Property(e => e.EventNameId).HasColumnName("event_name_id");
            entity.Property(e => e.EventName1)
                .HasMaxLength(100)
                .HasColumnName("event_name");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("goal_pkey");

            entity.ToTable("goal");

            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.GoalName)
                .HasMaxLength(100)
                .HasColumnName("goal_name");
        });

        modelBuilder.Entity<Hospitalization>(entity =>
        {
            entity.HasKey(e => e.HospitalizationId).HasName("hospitalization_pkey");

            entity.ToTable("hospitalization");

            entity.Property(e => e.HospitalizationId).HasColumnName("hospitalization_id");
            entity.Property(e => e.AdditionalInformation).HasColumnName("additional_information");
            entity.Property(e => e.Condition)
                .HasMaxLength(1)
                .HasColumnName("condition");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Department).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("hospitalization_department_id_fkey");

            entity.HasOne(d => d.Goal).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.GoalId)
                .HasConstraintName("hospitalization_goal_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("hospitalization_patient_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("hospitalization_status_id_fkey");
        });

        modelBuilder.Entity<HospitalizationStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("hospitalization_status_pkey");

            entity.ToTable("hospitalization_status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusDescription).HasColumnName("status_description");
            entity.Property(e => e.StatusNameId).HasColumnName("status_name_id");

            entity.HasOne(d => d.StatusName).WithMany(p => p.HospitalizationStatuses)
                .HasForeignKey(d => d.StatusNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hospitalization_status_status_name_id_fkey");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("insurance_pkey");

            entity.ToTable("insurance");

            entity.Property(e => e.InsuranceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("insurance_id");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.InsuranceCompany)
                .HasMaxLength(100)
                .HasColumnName("insurance_company");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(20)
                .HasColumnName("policy_number");

            entity.HasOne(d => d.InsuranceNavigation).WithOne(p => p.Insurance)
                .HasForeignKey<Insurance>(d => d.InsuranceId)
                .HasConstraintName("insurance_insurance_id_fkey");
        });

        modelBuilder.Entity<MedicalCard>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("medical_card_pkey");

            entity.ToTable("medical_card");

            entity.Property(e => e.CardId)
                .ValueGeneratedOnAdd()
                .HasColumnName("card_id");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(20)
                .HasColumnName("card_number");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");

            entity.HasOne(d => d.Card).WithOne(p => p.MedicalCard)
                .HasForeignKey<MedicalCard>(d => d.CardId)
                .HasConstraintName("medical_card_card_id_fkey");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("medication_pkey");

            entity.ToTable("medication");

            entity.Property(e => e.MedicationId).HasColumnName("medication_id");
            entity.Property(e => e.MedicationName)
                .HasMaxLength(100)
                .HasColumnName("medication_name");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicines_pkey");

            entity.ToTable("medicines");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .HasColumnName("image");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stockquantity).HasColumnName("stockquantity");
            entity.Property(e => e.Tradename)
                .HasMaxLength(50)
                .HasColumnName("tradename");
            entity.Property(e => e.Warehouseid).HasColumnName("warehouseid");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.Warehouseid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicines_warehouseid_fkey");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("patients_pkey");

            entity.ToTable("patients");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LastVisitDate).HasColumnName("last_visit_date");
            entity.Property(e => e.MedicalHistory).HasColumnName("medical_history");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.NextVisitDate).HasColumnName("next_visit_date");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(6)
                .HasColumnName("passport_number");
            entity.Property(e => e.PassportSeries)
                .HasMaxLength(4)
                .HasColumnName("passport_series");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnName("photo");
            entity.Property(e => e.Workplace)
                .HasMaxLength(100)
                .HasColumnName("workplace");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("prescription_pkey");

            entity.ToTable("prescription");

            entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");
            entity.Property(e => e.AdministrationFormat)
                .HasMaxLength(50)
                .HasColumnName("administration_format");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .HasColumnName("dosage");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.MedicationId).HasColumnName("medication_id");

            entity.HasOne(d => d.Event).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("prescription_event_id_fkey");

            entity.HasOne(d => d.Medication).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.MedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescription_medication_id_fkey");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("result_pkey");

            entity.ToTable("result");

            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.ResultName)
                .HasMaxLength(100)
                .HasColumnName("result_name");
        });

        modelBuilder.Entity<StatusName>(entity =>
        {
            entity.HasKey(e => e.StatusNameId).HasName("status_name_pkey");

            entity.ToTable("status_name");

            entity.Property(e => e.StatusNameId).HasColumnName("status_name_id");
            entity.Property(e => e.StatusName1)
                .HasMaxLength(100)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("type_pkey");

            entity.ToTable("type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("warehouses_pkey");

            entity.ToTable("warehouses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
