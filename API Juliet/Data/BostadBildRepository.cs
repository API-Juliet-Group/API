using BaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Juliet.Data
{
    public class BostadBildRepository : IBostadBild
    {
        private readonly DataContext _context;

        public BostadBildRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BostadBild>> GetAllAsync()
        {
            return await _context.BostadsBilder.OrderBy(b => b.Id).ToListAsync();
        }

        public async Task<BostadBild> GetByIdAsync(int id)
        {
            return await _context.BostadsBilder.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(BostadBild bostadBild)
        {
            _context.BostadsBilder.Add(bostadBild);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BostadBild bostadBild)
        {
            _context.BostadsBilder.Update(bostadBild);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BostadBild bostadBild)
        {
            _context.BostadsBilder.Remove(bostadBild);
            await _context.SaveChangesAsync();
        }
    }
}
