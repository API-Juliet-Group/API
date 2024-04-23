using BaseLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Juliet.Data
{
    public interface IMäklarbyråRepository
    {
        Task<Mäklarbyrå> GetByIdAsync(int id);
        Task<IEnumerable<Mäklarbyrå>> GetAllAsync();
        Task AddAsync(Mäklarbyrå mäklarbyrå);
        Task UpdateAsync(Mäklarbyrå mäklarbyrå);
        Task DeleteAsync(Mäklarbyrå mäklarbyrå);
    }
}
