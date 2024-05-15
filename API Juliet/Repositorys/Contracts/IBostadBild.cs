using API_Juliet.Models;
using BaseLibrary.DTO;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IBostadBild
    {
        //DTO
        Task AddBostadsBilderDtosAsync(IEnumerable<BostadBildDto> bostadBilder);
        Task AddBostadBildAsync(BostadBildDto bostadBildDto);
        Task<IEnumerable<BostadBildDto>> GetBostadsBilderDtosAsync();
        Task<IEnumerable<BostadBildDto>> GetBostadensBilderDtosAsync(int bostadsId);
        Task DeleteBostadsBild(int id);
    }
}
