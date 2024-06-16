namespace Backend.BO.Payloads.Responses
{
    public class UserDashboardReponse
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required string Address { get; set; }

        public required short Sex { get; set; }

    }
}
