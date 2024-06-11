namespace Backend.BO.Payloads.Requests
{
    public class ClinicRequest
    {
        public required string ClinicName { get; set; }
        public required string LicenseNumber { get; set; }
        public required string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NumberOfEmployees { get; set; }
        public string? OwnerId { get; set; }
        public string? AreaId { get; set; }
    }
}
