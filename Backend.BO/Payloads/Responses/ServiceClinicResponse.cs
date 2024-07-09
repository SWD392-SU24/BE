using System.Text.Json.Serialization;

namespace Backend.BO.Payloads.Responses
{
    public class ServiceClinicResponse
    {
        [JsonPropertyName("serviceId")]
        public int Id { get; set; }

        public required string ServiceName { get; set; }
    }
}
