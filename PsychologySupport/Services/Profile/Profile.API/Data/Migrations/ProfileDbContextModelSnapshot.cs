﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Profile.API.Data;

#nullable disable

namespace Profile.API.Data.Migrations
{
    [DbContext(typeof(ProfileDbContext))]
    partial class ProfileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DoctorProfileSpecialty", b =>
                {
                    b.Property<Guid>("DoctorProfilesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpecialtiesId")
                        .HasColumnType("uuid");

                    b.HasKey("DoctorProfilesId", "SpecialtiesId");

                    b.HasIndex("SpecialtiesId");

                    b.ToTable("DoctorProfileSpecialty", "public");
                });

            modelBuilder.Entity("MedicalHistoryPhysicalSymptom", b =>
                {
                    b.Property<Guid>("MedicalHistoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PhysicalSymptomsId")
                        .HasColumnType("uuid");

                    b.HasKey("MedicalHistoriesId", "PhysicalSymptomsId");

                    b.HasIndex("PhysicalSymptomsId");

                    b.ToTable("MedicalHistoryPhysicalSymptom", "public");
                });

            modelBuilder.Entity("MedicalHistorySpecificMentalDisorder", b =>
                {
                    b.Property<Guid>("MedicalHistoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpecificMentalDisordersId")
                        .HasColumnType("uuid");

                    b.HasKey("MedicalHistoriesId", "SpecificMentalDisordersId");

                    b.HasIndex("SpecificMentalDisordersId");

                    b.ToTable("MedicalHistorySpecificMentalDisorder", "public");
                });

            modelBuilder.Entity("MedicalRecordSpecificMentalDisorder", b =>
                {
                    b.Property<Guid>("MedicalRecordsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpecificMentalDisordersId")
                        .HasColumnType("uuid");

                    b.HasKey("MedicalRecordsId", "SpecificMentalDisordersId");

                    b.HasIndex("SpecificMentalDisordersId");

                    b.ToTable("MedicalRecordSpecificMentalDisorder", "public");
                });

            modelBuilder.Entity("Profile.API.DoctorProfiles.Models.DoctorProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("Gender");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Qualifications")
                        .HasColumnType("text");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("TotalReviews")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("integer");

                    b.ComplexProperty<Dictionary<string, object>>("ContactInfo", "Profile.API.DoctorProfiles.Models.DoctorProfile.ContactInfo#ContactInfo", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Address");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");
                        });

                    b.HasKey("Id");

                    b.ToTable("DoctorProfiles", "public");
                });

            modelBuilder.Entity("Profile.API.DoctorProfiles.Models.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialties", "public");
                });

            modelBuilder.Entity("Profile.API.MentalDisorders.Models.MentalDisorder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MentalDisorders", "public");
                });

            modelBuilder.Entity("Profile.API.MentalDisorders.Models.SpecificMentalDisorder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MentalDisorderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MentalDisorderId");

                    b.ToTable("SpecificMentalDisorders", "public");
                });

            modelBuilder.Entity("Profile.API.PatientProfiles.Models.MedicalHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DiagnosedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalHistories", "public");
                });

            modelBuilder.Entity("Profile.API.PatientProfiles.Models.MedicalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("DoctorProfileId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PatientProfileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorProfileId");

                    b.HasIndex("MedicalHistoryId");

                    b.HasIndex("PatientProfileId");

                    b.ToTable("MedicalRecords", "public");
                });

            modelBuilder.Entity("Profile.API.PatientProfiles.Models.PatientProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Allergies")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Gender");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("PersonalityTraits")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PersonalityTraits");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("ContactInfo", "Profile.API.PatientProfiles.Models.PatientProfile.ContactInfo#ContactInfo", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Address");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");
                        });

                    b.HasKey("Id");

                    b.ToTable("PatientProfiles", "public");
                });

            modelBuilder.Entity("Profile.API.PatientProfiles.Models.PhysicalSymptom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PhysicalSymptoms", "public");
                });

            modelBuilder.Entity("DoctorProfileSpecialty", b =>
                {
                    b.HasOne("Profile.API.DoctorProfiles.Models.DoctorProfile", null)
                        .WithMany()
                        .HasForeignKey("DoctorProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Profile.API.DoctorProfiles.Models.Specialty", null)
                        .WithMany()
                        .HasForeignKey("SpecialtiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalHistoryPhysicalSymptom", b =>
                {
                    b.HasOne("Profile.API.PatientProfiles.Models.MedicalHistory", null)
                        .WithMany()
                        .HasForeignKey("MedicalHistoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Profile.API.PatientProfiles.Models.PhysicalSymptom", null)
                        .WithMany()
                        .HasForeignKey("PhysicalSymptomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalHistorySpecificMentalDisorder", b =>
                {
                    b.HasOne("Profile.API.PatientProfiles.Models.MedicalHistory", null)
                        .WithMany()
                        .HasForeignKey("MedicalHistoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Profile.API.MentalDisorders.Models.SpecificMentalDisorder", null)
                        .WithMany()
                        .HasForeignKey("SpecificMentalDisordersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalRecordSpecificMentalDisorder", b =>
                {
                    b.HasOne("Profile.API.PatientProfiles.Models.MedicalRecord", null)
                        .WithMany()
                        .HasForeignKey("MedicalRecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Profile.API.MentalDisorders.Models.SpecificMentalDisorder", null)
                        .WithMany()
                        .HasForeignKey("SpecificMentalDisordersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Profile.API.MentalDisorders.Models.SpecificMentalDisorder", b =>
                {
                    b.HasOne("Profile.API.MentalDisorders.Models.MentalDisorder", "MentalDisorder")
                        .WithMany("SpecificMentalDisorders")
                        .HasForeignKey("MentalDisorderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MentalDisorder");
                });

            modelBuilder.Entity("Profile.API.PatientProfiles.Models.MedicalHistory", b =>
                {
                    b.HasOne("Profile.API.PatientProfiles.Models.PatientProfile", null)
                        .WithOne("MedicalHistory")
                        .HasForeignKey("Profile.API.PatientProfiles.Models.MedicalHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Profile.API.PatientProfiles.Models.MedicalRecord", b =>
                {
                    b.HasOne("Profile.API.DoctorProfiles.Models.DoctorProfile", "DoctorProfile")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("DoctorProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Profile.API.PatientProfiles.Models.MedicalHistory", "MedicalHistory")
                        .WithMany()
                        .HasForeignKey("MedicalHistoryId");

                    b.HasOne("Profile.API.PatientProfiles.Models.PatientProfile", "PatientProfile")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("PatientProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorProfile");

                    b.Navigation("MedicalHistory");

                    b.Navigation("PatientProfile");
                });

            modelBuilder.Entity("Profile.API.DoctorProfiles.Models.DoctorProfile", b =>
                {
                    b.Navigation("MedicalRecords");
                });

            modelBuilder.Entity("Profile.API.MentalDisorders.Models.MentalDisorder", b =>
                {
                    b.Navigation("SpecificMentalDisorders");
                });

            modelBuilder.Entity("Profile.API.PatientProfiles.Models.PatientProfile", b =>
                {
                    b.Navigation("MedicalHistory");

                    b.Navigation("MedicalRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
