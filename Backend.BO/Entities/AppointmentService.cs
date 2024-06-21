using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("appointment_service")]
    public class AppointmentService : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("appointment_service_id")]
        public int Id { get; set; }

        [Column("appointment_id")]
        public Guid AppointmentId { get; set; }

        [Column("service_id")]
        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;

        public Appointment Appointment { get; set; } = null!;
    }
}
