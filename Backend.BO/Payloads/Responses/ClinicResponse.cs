namespace Backend.BO.Payloads.Responses
{
    public class ClinicResponse
    {
        public int Id { get; set; }
        public required string ClinicName { get; set; }
        public required string LicenseNumber { get; set; }
        public required string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NumberOfEmployees { get; set; }
        public string? OwnerId { get; set; }
        public string? AreaId { get; set; }
    }
}
