using Backend.BO.Commons;
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
        
        public virtual DbSet<Service> Services { get; set; }
        
        public virtual DbSet<TreatmentDetail> TreatmentDetails { get; set; }

        public virtual DbSet<ClinicDentist> ClinicDentists { get; set; }

        public virtual DbSet<ClinicFeedback> ClinicFeedbacks { get; set; }

        public virtual DbSet<Dentist> Dentists { get; set; }

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
            #region Relationship configuration
            // Applying relationship configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentServiceTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CertificateTypeConfiguration).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDoctorTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicTypeConfiguration).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DentistScheduleTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceTypeConfiguration).Assembly);
            #endregion
            
            modelBuilder.Seed();
        }
    }
}
