using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("combo")]
    public class Combo : IBaseEntity
    {
        [Column("combo_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("combo_name")]
        [MaxLength(250)]
        public required string ComboName { get; set; }

        [Column("combo_description")]
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
