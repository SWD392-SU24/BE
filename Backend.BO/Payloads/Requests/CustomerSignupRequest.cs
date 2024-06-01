using Backend.BO.Constants;

namespace Backend.BO.Payloads.Requests
{
    public class CustomerSignupRequest
    {
        public required string Email { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Password { get; set; }

        public required string ConfirmedPassword { get; set; }

        public string Role { get; } = UserRole.Customer;
    }
}
