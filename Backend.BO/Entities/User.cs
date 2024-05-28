using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Commons
{
    [Table("users")]
    public class User : UserEntity
    {
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

        [Column("role")]
        [MaxLength(10)]
        public string Role { get; set; } = null!;

        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }

}
