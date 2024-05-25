using System.Text.Json.Serialization;

namespace GamingApi.Model
{
    public class GameInfo
    {
        public GameInfo() { } // Parameterless constructor
        [JsonPropertyName("appid")]
        public int AppId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("short_description")]
        public string? ShortDescription { get; set; }

        [JsonPropertyName("developer")]
        public string? Developer { get; set; }

        [JsonPropertyName("publisher")]
        public string? Publisher { get; set; }

        [JsonPropertyName("genre")]
        public string? Genre { get; set; }

        [JsonPropertyName("tags")]
        public Dictionary<string, int>? Tags { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("categories")]
        public List<string>? Categories { get; set; } = new();

        [JsonPropertyName("owners")]
        public string? Owners { get; set; }

        [JsonPropertyName("positive")]
        public int Positive { get; set; }

        [JsonPropertyName("negative")]
        public int Negative { get; set; }

        [JsonPropertyName("price")]
        public string? Price { get; set; }

        [JsonPropertyName("initialprice")]
        public string? InitialPrice { get; set; }

        [JsonPropertyName("discount")]
        public string? Discount { get; set; }

        [JsonPropertyName("ccu")]
        public int Ccu { get; set; }

        [JsonPropertyName("languages")]
        public string? Languages { get; set; }

        [JsonPropertyName("platforms")]
        public Platforms? Platforms { get; set; } = new();

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("required_age")]
        public int RequiredAge { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }

        [JsonPropertyName("header_image")]
        public string? HeaderImage { get; set; }
    }
}
