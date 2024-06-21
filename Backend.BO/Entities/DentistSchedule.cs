using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("dentist_schedule")]
    public class DentistSchedule
    {
        [Column("schedule_id")]
        public Guid ScheduleId { get; set; }

        [Column("doctor_id")]
        public Guid DentistId { get; set; }
        
        [Column("working_date")]
        [DataType(DataType.Date)]
        public DateOnly? WorkingDate { get; set; }

        [Column("working_start_time")]
        [DataType(DataType.Time)]
        public TimeOnly WorkingStartTime { get; set; }

        [Column("working_end_time")]
        [DataType(DataType.Time)]
        public TimeOnly WorkingEndTime { get; set; }

        public Dentist Dentist { get; set; } = null!;
    }
}
