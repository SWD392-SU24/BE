using Backend.BO.Enums;
using System.Text.Json.Serialization;

namespace Backend.BO.Payloads.Requests
{
    public class AppointmentRequest
    {
        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentStartTime { get; set; }

        [JsonIgnore]
        public TimeOnly AppointmentEndTime { get; set; }

        public int AppointmentType { get; set; } = (int)AppointmentTypeEnum.Registration;

        public short AppointmentStatus { get; set; } = (int)AppointmentStatusEnum.Booking;

        public int ClinicId { get; set; }

        public Guid DentistId { get; set; }

        public Guid CustomerId { get; set; }

        public List<AppointmentServiceRequest>? Services { get; set; }
    }

    public class AppointmentServiceRequest
    {
        public int ServiceId { get; set; }

        public Guid AppointmentId { get; set; } = Guid.Empty;
    }
}
