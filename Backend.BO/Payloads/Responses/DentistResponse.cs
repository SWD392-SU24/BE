using System.Text.Json.Serialization;

namespace Backend.BO.Payloads.Responses
{
    public class DentistResponse
    {
        /// <summary>
        /// Dentist's id
        /// </summary>
        [JsonPropertyName("dentistId")]
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? FullName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
