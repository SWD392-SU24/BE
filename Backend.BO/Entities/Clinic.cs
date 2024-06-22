using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("clinic")]
    public class Clinic : IBaseEntity
    {
        [Column("clinic_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("clinic_name")]
        [MaxLength(200)]
        public required string ClinicName { get; set; }

        [Column("license_number")]
        [MaxLength(50)]
        public required string LicenseNumber { get; set; }

        [Column("clinic_address")]
        [MaxLength(300)]
        public required string Address { get; set; }

        [Column("clinic_phone_number")]
        [MaxLength(12)]
        public string? PhoneNumber { get; set; }

        [Column("employee_size")]
        public int EmployeeSize { get; set; }

        [Column("owner_id")]
        public Guid OwnerId { get; set; }

        [Column("area_id")]
        public int AreaId { get; set; }

        public User Owner { get; set; } = null!;

        public IList<ClinicDentist> ClinicDentists { get; set; } = new List<ClinicDentist>();

        public IList<Service> Services { get; set; } = new List<Service>();

        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();

        public IList<ClinicFeedback> ClinicFeedbacks { get; set; } = new List<ClinicFeedback>();

        /// <summary>
        /// Three states: 1: pending; 2: verified; 3: disable
        /// </summary>
        [Column("clinic_state")]
        public short ClinicState { get; set; }

        public Area Area { get; set; } = null!;
    }
}
