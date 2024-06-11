namespace Backend.BO.Payloads.Responses
{
    /// <summary>
    /// Response model for clinic feedback
    /// </summary>
    public class ClinicFeedbackResponse
    {
        public int ClinicId { get; set; }

        public string ClinicName { get; set; } = null!;
        
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;    

        public short Rating { get; set; }

        public string? FeedbackDescription { get; set; }

        public DateTime FeedbackDate { get; set; }
    }
}
