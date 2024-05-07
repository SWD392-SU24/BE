namespace Backend.BO.Payloads.Responses
{
    public class AuthResponse
    {
        public string? Token { get; set; }

        public string? RefreshToken { get; set; }

        public required string Message { get; set; }

        public DateTime ExpiredAt { get; set; }
    }
}
