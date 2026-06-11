using System.Text.Json;
using System.Text.Json.Serialization;
namespace ClashRoyaleApi.Dtos
{
    public class InfoPlayerDto
    {
        [JsonPropertyName("name")]
        public string NameUser { get; set; }
        [JsonPropertyName("expLevel")]
        public int LevelUser { get; set; }
        [JsonPropertyName("trophies")]
        public int TrophiesUser { get; set; }
        [JsonPropertyName("cards")]
        public List<CardDto> Cards { get; set; } = new List<CardDto>();
    }
}