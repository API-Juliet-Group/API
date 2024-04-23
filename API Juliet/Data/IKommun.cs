using API_Juliet.Models;

namespace API_Juliet.Data
{
    public interface IKommunRepository
    {
        Task<Kommun> GetByIdAsync(int id);
        Task<IEnumerable<Kommun>> GetAllAsync();
        Task AddAsync(Kommun kommun);
        Task UpdateAsync(Kommun kommun);
        Task DeleteAsync(Kommun kommun);
    }
}
