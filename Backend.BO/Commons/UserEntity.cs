using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Commons
{
    public abstract class UserEntity
    {
        [Key]
        [Column("user_id")]
        public Guid Id { get; set; }
    }
}
