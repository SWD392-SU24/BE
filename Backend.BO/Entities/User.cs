using Backend.BO.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Commons
{
    [Table("user")]
    public class User : UserEntity
    {
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("first_name")]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(150)]
        public string? LastName { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Column("password")]
        [MaxLength(75)]
        public required string Password { get; set; }

        [Column("phone_number")]
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [Column("citizen_id")]
        [MaxLength(12)]
        public string? CitizenId { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("sex")]
        public short Sex { get; set; }

        [Column("role", TypeName = "char(4)")]
        public required string Role { get; set; }

        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }

        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        
        public IList<ClinicFeedback> ClinicFeedbacks { get; set; } = new List<ClinicFeedback>();
    }
}
