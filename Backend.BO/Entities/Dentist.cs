using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.BO.Entities
{
    [Table("dentist")]
    public class Dentist : UserEntity
    {
        [Column("first_name")]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(150)]
        public required string LastName { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Column("password")]
        [MaxLength(75)]
        public required string Password { get; set; }

        [Column("phone_number")]
        [MaxLength(10)]
        public required string PhoneNumber { get; set; }

        [Column("citizen_id")]
        [MaxLength(12)]
        public string? CitizenId { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Column("sex")]
        public short Sex { get; set; }
        
        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
        
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();

        public IList<Certificate> Certificates { get; set; } = new List<Certificate>();

        public IList<ClinicDentist> ClinicDentists { get; set; } = new List<ClinicDentist>();

        public IList<DentistSchedule> DentistSchedules { get; set; } = new List<DentistSchedule>();
    }
}
