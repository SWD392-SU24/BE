using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    public class Area : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("area_id")]
        public int Id { get; set; }

        [Column("area_name")]
        [MaxLength(100)]
        public required string AreaName { get; set; }
    }
}
