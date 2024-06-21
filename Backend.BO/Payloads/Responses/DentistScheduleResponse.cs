namespace Backend.BO.Payloads.Responses
{
    public class DentistScheduleResponse
    {
        public Guid ScheduleId { get; set; }

        public DateOnly? WorkingDate { get; set; }

        public TimeOnly WorkingStartTime { get; set; }

        public TimeOnly WorkingEndTime { get; set; }
    }
}
