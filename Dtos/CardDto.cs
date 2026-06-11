using System.Text.Json.Serialization;
namespace ClashRoyaleApi.Dtos
{
    public class CardDto
    {
        [JsonPropertyName("id")]
        public int IdCard { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("elixirCost")]
        public int ElixirCard { get; set; }
        [JsonPropertyName("iconUrls")]
        public IconsCardDto IconUrls { get; set; }
    }
}