﻿using Microsoft.EntityFrameworkCore;
using Profilee.API.Models;

namespace Profilee.API.Data
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {

        }

        //public DbSet<PatientProfile> PatientProfiles => Set<PatientProfile>();
        public DbSet<DoctorProfile> DoctorProfiles => Set<DoctorProfile>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");

            base.OnModelCreating(builder);
        }
    }
}
