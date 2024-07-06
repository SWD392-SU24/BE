namespace Backend.BO.Payloads.Requests
{
    public class AppointmentRequest
    {
        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentStartTime { get; set; }

        public TimeOnly AppointmentEndTime { get; set; }

        public int AppointmentType { get; set; }

        public short AppointmentStatus { get; set; }

        public int ClinicId { get; set; }

        public Guid DentistId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
