namespace Backend.BO.Payloads.Requests
{
    public class CertificateRequest
    {
        public required string CertificateName { get; set; }

        public required string CertificateNumber { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public string? CertificateImage { get; set; }

        public Guid DentistId { get; set; }
    }
}
