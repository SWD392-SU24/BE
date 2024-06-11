using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("combo_service")]
    public class ComboService : IBaseEntity
    {
        [Column("combo_service_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("service_id")]
        public int ServiceId { get; set; }

        [Column("combo_id")]
        public int ComboId { get; set; }

        public Service Service { get; set; } = null!;

        public Combo Combo { get; set; } = null!;
    }
}
