namespace Backend.BO.Payloads.Requests
{
    public class DentistScheduleRequest
    {
        public Guid DentistId { get; set; }

        public DateOnly WorkingDate { get; set; }

        public TimeOnly WorkingStartTime { get; set; }

        public TimeOnly WorkingEndTime { get; set; }
    }

    public class UpdateScheduleWorkingTimeRequest
    {
        public Guid DentistId { get; set; }

        public TimeOnly WorkingStartTime { get; set; }

        public TimeOnly WorkingEndTime { get; set; }
    }
}
