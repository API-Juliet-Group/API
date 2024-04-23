using API_Juliet.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Juliet.Data
{
    public class BostadRepository : IBostad
    {
        private readonly DataContext _context;
        public BostadRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Bostad>> GetAllAsync()
        {
            return await _context.Bostäder.OrderBy(s => s.Id).ToListAsync();
        }
        public async Task<Bostad> GetByIdAsync(int id)
        {
            return await _context.Bostäder.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddAsync(Bostad order)
        {
            _context.Bostäder.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Bostad order)
        {
            _context.Bostäder.Update(order);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Bostad order)
        {
            _context.Bostäder.Remove(order);
            await _context.SaveChangesAsync();
        }

    }
}
