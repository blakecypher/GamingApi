using System.Text.Json.Serialization;

namespace GamingApi.Model
{
    public class Platforms
    {
        public Platforms() { }
        [JsonPropertyName("windows")]
        public bool Windows { get; set; }

        [JsonPropertyName("mac")]
        public bool Mac { get; set; }

        [JsonPropertyName("linux")]
        public bool Linux { get; set; }
    }
}
