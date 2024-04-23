using BaseLibrary.Models;

namespace API_Juliet.Data
{
    public interface IMäklare
    {
        Task<Mäklare> GetByIdAsync(int id);
        Task<IEnumerable<Mäklare>> GetAllAsync();
        Task AddAsync(Mäklare mäklare);
        Task UpdateAsync(Mäklare mäklare);
        Task DeleteAsync(Mäklare mäklare);
    }
}
