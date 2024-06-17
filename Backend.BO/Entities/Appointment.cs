using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("appointment")]
    public class Appointment
    {
        [Key]
        [Column("appointment_id")]
        [MaxLength(50)]
        public required string AppointmentId { get; set; }

        [Column("appointment_date")]
        public DateOnly AppointmentDate { get; set; }

        [Column("start_time")]
        public TimeOnly StartTime { get; set; }

        [Column("end_time")]
        public TimeOnly EndTime { get; set; }

        /// <summary>
        /// 2 types: 1 - đăng kí khám bệnh; 2: điều trị
        /// </summary>
        [Column("appointment_type")]
        public int AppointmentType { get; set; }

        /// <summary>
        /// 3 states: 1 - booking; 2 - completed; 3 - cancelled
        /// </summary>
        [Column("appointment_status")]
        public short AppointmentStatus { get; set; }

        [Column("clinic_id")]
        public int ClinicId { get; set; }
        
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        [Column("dentist_id")]
        public Guid DentistId { get; set; }

        public Clinic Clinic { get; set; } = null!;

        public User Customer { get; set; } = null!;

        public Dentist Dentist { get; set; } = null!;

        public TreatmentDetail TreatmentDetail { get; set; } = null!;

        public IList<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
    }
}
