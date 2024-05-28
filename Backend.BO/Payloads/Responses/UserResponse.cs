namespace Backend.BO.Payloads.Responses
{
    public class UserResponse
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public required string Email { get; set; }

        public required string Role { get; set; }
    }
}
