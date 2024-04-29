using API_Juliet.Models;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IMäklarbyrå
    {
        Task<Mäklarbyrå> GetByIdAsync(int id);
        Task<IEnumerable<Mäklarbyrå>> GetAllAsync();
        Task AddAsync(Mäklarbyrå mäklarbyrå);
        Task UpdateAsync(Mäklarbyrå mäklarbyrå);
        Task DeleteAsync(Mäklarbyrå mäklarbyrå);
    }
}
