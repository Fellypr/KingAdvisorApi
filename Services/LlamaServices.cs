using ClashRoyaleApi.Interfaces;
using ClashRoyaleApi.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net;

namespace ClashRoyaleApi.Services
{
    public class LlamaServices : ILlamaInterfaces
    {   
        private readonly HttpClient _httpclient;

        public LlamaServices(HttpClient httpClient)
        {
            _httpclient = httpClient;
        } 



        public async Task<string> GetInformationPlayer(object prompt,string apiKey,CancellationToken cancellationToken)
        {
            if(string.IsNullOrWhiteSpace(apiKey))
            {
                Console.WriteLine("Erro com a chave api da groq");
            }
           try
           {
                using var request = new HttpRequestMessage(HttpMethod.Post, "openai/v1/chat/completions")
                {
                    Content = new StringContent(JsonSerializer.Serialize(prompt),Encoding.UTF8,"application/json")
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",apiKey);

                using var response = await _httpclient.SendAsync(request,cancellationToken);

                var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        $"Error na Groq ({(int)response.StatusCode}: {responseContent})",
                        null,
                        response.StatusCode
                    );
                }

                using var doc = JsonDocument.Parse(responseContent);

                var generatedText = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                if (string.IsNullOrWhiteSpace(generatedText))
                {
                    Console.WriteLine("Groq retornou uma resposta vazia => Erro no 'generatedText'");
                    throw new InvalidOperationException("Groq retornou uma resposta vazia");
                }
                return generatedText.Replace("```json", string.Empty).Replace("```", string.Empty).Trim();
            
           }
           catch (Exception ex)
           {
            Console.WriteLine("Erro De Api aqui:" + ex);
            throw new Exception ("Error ao configurar a api");
           } 
        }
    }
}