﻿using System.Text.Json.Serialization;
using BuildingBlocks.DDD;
using Profile.API.DoctorProfiles.Models;
using Profile.API.MentalDisorders.Models;
using Profile.API.PatientProfiles.ValueObjects;

namespace Profile.API.PatientProfiles.Models;

public class MedicalRecord : Entity<Guid>
{
    [JsonIgnore]
    public Guid PatientProfileId { get; set; }

    [JsonIgnore]
    public Guid DoctorProfileId { get; set; }

    [JsonIgnore]
    public Guid? MedicalHistoryId { get; set; }

    public string Notes { get; set; } = default!;

    public MedicalRecordStatus Status { get; set; }
    
    [JsonIgnore]
    public MedicalHistory? MedicalHistory { get; set; }

    [JsonIgnore]
    public virtual PatientProfile PatientProfile { get; set; }
    
    [JsonIgnore]
    public virtual DoctorProfile DoctorProfile { get; set; }
    
    [JsonIgnore]
    private readonly List<SpecificMentalDisorder> _specificMentalDisorders = [];

    public IReadOnlyList<SpecificMentalDisorder> SpecificMentalDisorders => _specificMentalDisorders.AsReadOnly();

    public MedicalRecord()
    {
    }

    private MedicalRecord(Guid id, Guid patientId, Guid doctorId, Guid? medicalHistoryId,
        string notes, MedicalRecordStatus status, List<SpecificMentalDisorder> disorders)
    {
        Id = id;
        PatientProfileId = patientId;
        DoctorProfileId = doctorId;
        MedicalHistoryId = medicalHistoryId;
        Notes = notes;
        Status = status;
        _specificMentalDisorders = disorders;
    }

    internal static MedicalRecord Create(Guid patientId, Guid doctorId, Guid? medicalHistoryId,
        string notes, MedicalRecordStatus status,
        List<SpecificMentalDisorder> disorders)
    {
        if (patientId == Guid.Empty)
            throw new ArgumentException("Patient ID cannot be empty.", nameof(patientId));

        if (doctorId == Guid.Empty)
            throw new ArgumentException("Doctor ID cannot be empty.", nameof(doctorId));

        if (medicalHistoryId == Guid.Empty)
            throw new ArgumentException("Medical history ID cannot be empty.", nameof(medicalHistoryId));

        if (string.IsNullOrWhiteSpace(notes))
            throw new ArgumentException("Notes cannot be empty.", nameof(notes));

        return new MedicalRecord(Guid.NewGuid(), patientId, doctorId, medicalHistoryId, notes, status, disorders);
    }
}