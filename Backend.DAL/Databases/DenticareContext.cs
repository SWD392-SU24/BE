﻿using Backend.BO.Commons;
using Backend.BO.Entities;
using Backend.DAL.Databases.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Backend.DAL.Databases
{
    public partial class DenticareContext : DbContext
    {
        public DenticareContext()
        {
        }

        public DenticareContext(DbContextOptions<DenticareContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
                
        public virtual DbSet<Appointment> Appointments { get; set; }
        
        public virtual DbSet<AppointmentService> AppointmentServices { get; set; }
        
        public virtual DbSet<Certificate> Certificates { get; set; }
        
        public virtual DbSet<Clinic> Clinics { get; set; }
        
        public virtual DbSet<Combo> Combos { get; set; }
        
        public virtual DbSet<ComboService> ComboServices { get; set; }
        
        public virtual DbSet<DoctorWorkingHours> DoctorSchedules { get; set; }
        
        public virtual DbSet<DoctorWorkingHours> DoctorWorkingHours { get; set; }
        
        public virtual DbSet<Service> Services { get; set; }
        
        public virtual DbSet<TreatmentDetail> TreatmentDetails { get; set; }

        public virtual DbSet<ClinicDoctor> ClinicDoctors { get; set; }

        public virtual DbSet<ClinicFeedback> ClinicFeedbacks { get; set; }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetConnectionString(), serverVersion: ServerVersion.AutoDetect(GetConnectionString()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region
            // Applying relationship configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentServiceTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CertificateTypeConfiguration).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDoctorTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicTypeConfiguration).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComboServiceTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorScheduleTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorWorkingHoursTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceTypeConfiguration).Assembly);
            #endregion

            modelBuilder.Seed();
        }
    }
}
