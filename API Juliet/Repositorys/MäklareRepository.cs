using API_Juliet.Data;
using API_Juliet.Repositorys.Contracts;
using API_Juliet.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Juliet.Repositorys
{
    public class MäklareRepository : IMäklare
    {
        private readonly DataContext _context;

        public MäklareRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mäklare>> GetAllAsync()
        {
            return await _context.Mäklare.OrderBy(m => m.Id).ToListAsync();
        }

        public async Task<Mäklare> GetByIdAsync(int id)
        {
            return await _context.Mäklare.FindAsync(id);
        }

        public async Task AddAsync(Mäklare mäklare)
        {
            _context.Mäklare.Add(mäklare);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mäklare mäklare)
        {
            _context.Entry(mäklare).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Mäklare mäklare)
        {
            _context.Mäklare.Remove(mäklare);
            await _context.SaveChangesAsync();
        }
    }
}
