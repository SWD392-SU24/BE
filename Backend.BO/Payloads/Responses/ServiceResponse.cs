using System.Text.Json.Serialization;

namespace Backend.BO.Payloads.Responses
{
    public class ServiceResponse
    {
        [JsonPropertyName("serviceId")]
        public int Id { get; set; }

        public required string ServiceName { get; set; }

        [JsonPropertyName("serviceDescription")]
        public string? Description { get; set; }

        public double Price { get; set; }
    }
}
