using System.Text.Json.Serialization;

namespace CarApp.Models
{
    public class VehicleType
    {
        [JsonPropertyName("VehicleTypeId")]
        public int Id { get; set; }
        [JsonPropertyName("VehicleTypeName")]
        public string Name { get; set; }
    }
}

