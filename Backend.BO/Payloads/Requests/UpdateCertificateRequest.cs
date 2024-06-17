namespace Backend.BO.Payloads.Requests
{
    public class UpdateCertificateRequest
    {
        public DateTime? IssuedDate { get; set; }

        public DateTime? ExpiredDate { get; set; }
        
        public string? CertificateImage { get; set; }

        public Guid DentistId { get; set; }
    }
}
