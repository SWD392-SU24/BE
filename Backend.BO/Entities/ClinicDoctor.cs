using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("clinic_doctors")]
    public class ClinicDoctor : IBaseEntity
    {
        [Column("cd_no")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("clinic_id")]
        public int ClinicId { get; set; }

        [Column("doctor_id")]
        public Guid DoctorId { get; set; }
    }
}
