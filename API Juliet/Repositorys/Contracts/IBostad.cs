using BaseLibrary.DTO;
using API_Juliet.Models;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IBostad
    {
        Task<Bostad> GetByIdAsync(int id);
        Task<IEnumerable<Bostad>> GetAllAsync();
        Task AddAsync(Bostad bostad);
        Task UpdateAsync(Bostad bostad);
        Task DeleteAsync(Bostad bostad);

        //BostadDTO
        Task<BostadDto> GetBostadDtoByIdAsync(int id);
        Task<IEnumerable<BostadDto>> GetAllBostadDtosAsync();
        Task AddBostadDtoAsync(BostadDto bostadDto);
        Task DeleteDtoAsync(int id);
    }
}
