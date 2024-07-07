namespace Backend.BO.Payloads.Requests
{
    public class UpdateUserRequest
    {
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public short Sex { get; set; }

        public required string Role { get; set; }
    }

    public class UpdateCustomerRequest
    {
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public short Sex { get; set; }
    }
}
