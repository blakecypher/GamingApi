using System.Text.Json.Serialization;

namespace GamingApi.Model
{
    public class GameSummary
    {
        public GameItem[]? Items { get; set; }
        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }
    }
}
