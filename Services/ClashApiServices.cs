using ClashRoyaleApi.Dtos;
using ClashRoyaleApi.Interfaces;

namespace ClashRoyaleApi.Services
{
    public class ClashApiServices : IClashApiInterfaces
    {
        private readonly HttpClient _httpClient;
        public ClashApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InfoPlayerDto> GetInfoUser(string tag)
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException("O HttpClient injetado está nulo.");
            }

            if (_httpClient.BaseAddress == null)
            {
                throw new InvalidOperationException("A URL base (BaseAddress) do HttpClient não foi configurada.");
            }

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentException("A tag do jogador não pode ser nula ou vazia.", nameof(tag));
            }

            try
            {
                var response = await _httpClient.GetAsync($"players/%23{tag.Replace("#","")}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<InfoPlayerDto>();
                if(result == null)
                {
                    result = new InfoPlayerDto
                    {
                        NameUser = "Não encontrado",
                        LevelUser = 0,
                        TrophiesUser = 0,
                        Cards = new List<CardDto>()
                    };
                }
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar informações do jogador: {ex.Message}");
            }
        }
    }
}