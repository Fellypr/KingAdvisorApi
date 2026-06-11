using ClashRoyaleApi.Dtos;

namespace ClashRoyaleApi.Interfaces
{
    public interface IClashApiInterfaces
    {
        public Task<InfoPlayerDto> GetInfoUser(string tag);
    }
}