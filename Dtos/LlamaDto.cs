namespace ClashRoyaleApi.Dtos
{


    public record LlamaPayload(
        string Model,
        ResponseFormDto responseFormDto,
        double Temperature,
        LlamaMessge[] Messages
    );
    public record ResponseFormDto(string Type);
    public record LlamaMessge(string Role, string Content);
}