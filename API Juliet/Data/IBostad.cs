using API_Juliet.Models;

namespace API_Juliet.Data
{
    public interface IBostad
    {
        Task<Bostad> GetByIdAsync(int id);
        Task<IEnumerable<Bostad>> GetAllAsync();
        Task AddAsync(Bostad bostad);
        Task UpdateAsync(Bostad bostad);
        Task DeleteAsync(Bostad bostad);
    }
}
