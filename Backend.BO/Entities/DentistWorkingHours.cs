using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("dentist_working_hours")]
    public class DentistWorkingHours : IBaseEntity
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

        public DentistSchedule DentistSchedule { get; set; } = null!;
    }
}
