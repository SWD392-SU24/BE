using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("clinic_dentist")]
    public class ClinicDentist : IBaseEntity
    {
        [Column("cd_no")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("clinic_id")]
        public int ClinicId { get; set; }

        [Column("dentist_id")]
        public Guid DentistId { get; set; }

        public Dentist Dentist { get; set; } = null!;

        public Clinic Clinic { get; set; } = null!;

        // TODO: Add more fields relating to date
    }
}
