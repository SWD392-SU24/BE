﻿namespace Backend.BO.Payloads.Responses
{
    public class AuthResponse
    {
        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime ExpiredAt { get; set; }
    }
}
