
namespace ClashRoyaleApi.Interfaces
{
    public interface ILlamaInterfaces
    {
        Task<string> GetInformationPlayer(object prompt,string apiKey,CancellationToken cancellationToken);
    }

}