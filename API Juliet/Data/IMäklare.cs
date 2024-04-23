using API_Juliet.Models;

namespace API_Juliet.Data
{
    public interface IMäklareRepository
    {
        Task<Mäklare> GetByIdAsync(int id);
        Task<IEnumerable<Mäklare>> GetAllAsync();
        Task AddAsync(Mäklare mäklare);
        Task UpdateAsync(Mäklare mäklare);
        Task DeleteAsync(Mäklare mäklare);
    }
}
