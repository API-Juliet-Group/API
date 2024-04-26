using BaseLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Juliet.Data
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
