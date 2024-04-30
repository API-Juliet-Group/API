using API_Juliet.Models;
using BaseLibrary.DTO;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IKommun
    {
        Task<Kommun> GetByIdAsync(int id);
        Task<IEnumerable<Kommun>> GetAllAsync();
        Task AddAsync(Kommun kommun);
        Task UpdateAsync(Kommun kommun);
        Task DeleteAsync(Kommun kommun);


        Task<IEnumerable<KommunDto>> GetAllKommunDtosAsync();
    }
}
