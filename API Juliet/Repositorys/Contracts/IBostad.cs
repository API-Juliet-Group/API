using BaseLibrary.DTO;
using API_Juliet.Models;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IBostad
    {
        //BostadDTO
        Task<BostadDto> GetBostad(int id);
        Task<IEnumerable<BostadDto>> GetAllBostadDtosAsync();
        Task<Bostad> AddBostadDtoAsync(BostadDto bostadDto);
        Task DeleteBostadAsync(int id);
        Task UpdateBostad(BostadDto bostadDto);
    }
}
