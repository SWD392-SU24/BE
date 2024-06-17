namespace Backend.BO.Payloads.Requests
{
    public class UserRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string PhoneNumber { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required string Address { get; set; }

        public required short Sex { get; set; }

        public required string Role { get; set; }
    }
}
