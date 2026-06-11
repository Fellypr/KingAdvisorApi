using System.Text.Json.Serialization;
namespace ClashRoyaleApi.Dtos
{
    public class IconsCardDto
    {
        [JsonPropertyName("medium")]
        public string Medium { get; set; }
        [JsonPropertyName("evolutionMedium")]
        public string EvolutionMedium { get; set; }
        [JsonPropertyName("heroMedium")]
        public string HeroMedium { get; set; }
    }
}