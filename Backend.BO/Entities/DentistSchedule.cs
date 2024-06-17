using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("dentist_schedule")]
    public class DentistSchedule
    {
        [Key]
        [Column("schedule_id")]
        [MaxLength(25)]
        public required string ScheduleId { get; set; }

        [Column("working_date")]
        public DateOnly? WorkingDate { get; set; }

        [Column("doctor_id")]
        public Guid DentistId { get; set; }

        public IList<DentistWorkingHours> DentistWorkingHours { get; set; } = new List<DentistWorkingHours>();

        public Dentist Dentist { get; set; } = null!;
    }
}
