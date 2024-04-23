using BaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Juliet.Data
{
    public class KommunRepository : IKommunRepository
    {
        private readonly DataContext _context;

        public KommunRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kommun>> GetAllAsync()
        {
            return await _context.Kommuner.OrderBy(k => k.Id).ToListAsync();
        }

        public async Task<Kommun> GetByIdAsync(int id)
        {
            return await _context.Kommuner.FindAsync(id);
        }

        public async Task AddAsync(Kommun kommun)
        {
            _context.Kommuner.Add(kommun);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kommun kommun)
        {
            _context.Entry(kommun).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Kommun kommun)
        {
            _context.Kommuner.Remove(kommun);
            await _context.SaveChangesAsync();
        }
    }
}
