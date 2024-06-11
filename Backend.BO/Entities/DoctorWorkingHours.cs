using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("doctor_working_hours")]
    public class DoctorWorkingHours : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("working_hour_id")]
        public int Id { get; set; }

        [Column("schedule_id")]
        [MaxLength(25)]
        public required string ScheduleId { get; set; }

        [Column("start_time")]
        public TimeOnly StartTime { get; set; }

        [Column("end_time")]
        public TimeOnly EndTime { get; set; }

        public DoctorSchedule DoctorSchedule { get; set; } = null!;
    }
}
