using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("doctor_schedule")]
    public class DoctorSchedule
    {
        [Key]
        [Column("schedule_id")]
        [MaxLength(25)]
        public required string ScheduleId { get; set; }

        [Column("working_date")]
        public DateOnly? WorkingDate { get; set; }

        [Column("doctor_id")]
        public Guid DoctorId { get; set; }

        public IList<DoctorWorkingHours> DoctorWorkingHours { get; set; } = new List<DoctorWorkingHours>();

        public User Doctor { get; set; } = null!;
    }
}
