using API_Juliet.Data;
using API_Juliet.Repositorys.Contracts;
using API_Juliet.Models;
using Microsoft.EntityFrameworkCore;
using BaseLibrary.DTO;

namespace API_Juliet.Repositorys
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



        //DTO


        public async Task<IEnumerable<BostadBildDto>> GetBostadsBilderDtosAsync()
        {
            return await _context.BostadsBilder
                .Select(b => new BostadBildDto
                {
                    Id = b.Id,
                    BildURL = b.BildURL,
                    BostadId = b.BostadId,
                })
                .ToListAsync();
        }
    }
}
