using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("treatment_detail")]
    public class TreatmentDetail : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("treatment_detail_id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column("appointment_id")]
        public Guid AppointmentId { get; set; }

        [Column("details", TypeName = "text")]
        public string? Details { get; set; }

        public Appointment Appointment { get; set; } = null!;
    }
}
