using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Commons
{
    [Table("users")]
    public class User : UserEntity
    {
        [Column("first_name")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

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
        public int Role { get; set; }
    }

}
