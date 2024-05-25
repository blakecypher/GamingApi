using System.Text.Json.Serialization;

namespace GamingApi.Model
{
    public class GameItem
    {
        public GameItem() { } // Parameterless constructor}
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonPropertyName("shortDescription")]
        public string? ShortDescription { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public List<string>? Categories { get; set; }
        public Platforms? Platforms { get; set; }
        [JsonPropertyName("releaseDate")]
        public string? ReleaseDate { get; set; }
        [JsonPropertyName("requiredAge")]
        public int RequiredAge { get; set; }
    }
}
