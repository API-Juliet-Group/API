using API_Juliet.Models;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IBostadBild
    {
        Task<BostadBild> GetByIdAsync(int id);
        Task<IEnumerable<BostadBild>> GetAllAsync();
        Task AddAsync(BostadBild bostadBild);
        Task UpdateAsync(BostadBild bostadBild);
        Task DeleteAsync(BostadBild bostadBild);
    }
}
