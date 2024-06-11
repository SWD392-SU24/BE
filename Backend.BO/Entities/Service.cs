using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("service")]
    public class Service : IBaseEntity
    {
        [Column("service_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("service_name")]
        [MaxLength(200)]
        public required string ServiceName { get; set; }

        [Column("description")]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Column("service_price", TypeName = "double(10, 2)")]
        public double Price { get; set; }

        [Column("clinic_id")]
        public int ClinicId { get; set; }

        public IList<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();

        public IList<ComboService> ComboServices { get; set; } = new List<ComboService>();

        public Clinic Clinic { get; set; } = null!;
    }
}
