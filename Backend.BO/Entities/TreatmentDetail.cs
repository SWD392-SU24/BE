using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("treatment_detail")]
    public class TreatmentDetail : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("treatment_detail_id")]
        public int Id { get; set; }

        [Column("appointment_id")]
        public required string AppointmentId { get; set; }

        [Column("details", TypeName = "text")]
        public string? Details { get; set; }

        //public Appointment Appointment { get; set; } = null!;
    }
}
