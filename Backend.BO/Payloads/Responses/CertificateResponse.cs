namespace Backend.BO.Payloads.Responses
{
    public class CertificateResponse
    {
        public int Id { get; set; }

        public required string CertificateName { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public string? CertificateImage { get; set; }
    }
}
