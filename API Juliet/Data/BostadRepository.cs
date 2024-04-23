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
        public async Task AddAsync(Bostad bostad)
        {
            _context.Bostäder.Add(bostad);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Bostad bostad)
        {
            _context.Bostäder.Update(bostad);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Bostad bostad)
        {
            _context.Bostäder.Remove(bostad);
            await _context.SaveChangesAsync();
        }

    }
}
