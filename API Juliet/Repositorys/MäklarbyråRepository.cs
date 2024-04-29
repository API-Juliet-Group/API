using API_Juliet.Data;
using API_Juliet.Repositorys.Contracts;
using API_Juliet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Juliet.Repositorys
{
    public class MäklarbyråRepository : IMäklarbyrå
    {
        private readonly DataContext _context;

        public MäklarbyråRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mäklarbyrå>> GetAllAsync()
        {
            return await _context.Mäklarbyråer.OrderBy(mb => mb.Id).ToListAsync();
        }

        public async Task<Mäklarbyrå> GetByIdAsync(int id)
        {
            return await _context.Mäklarbyråer.FindAsync(id);
        }

        public async Task AddAsync(Mäklarbyrå mäklarbyrå)
        {
            _context.Mäklarbyråer.Add(mäklarbyrå);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mäklarbyrå mäklarbyrå)
        {
            _context.Entry(mäklarbyrå).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Mäklarbyrå mäklarbyrå)
        {
            _context.Mäklarbyråer.Remove(mäklarbyrå);
            await _context.SaveChangesAsync();
        }
    }
}
