using API_Juliet.Data;
using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
using Microsoft.EntityFrameworkCore;

namespace API_Juliet.Repositorys
{
    public class BostadKategoriRepository : IBostadKategori
    {
        private readonly DataContext _context;

        public BostadKategoriRepository(DataContext context)
        {
            _context = context;
        }

        //DTO


        public async Task<IEnumerable<BostadKategoriDto>> GetAllBostadKategoriDtosAsync()
        {
            return await _context.BostadKategorier
                .Select(k => new BostadKategoriDto
                {
                    Id = k.Id,
                    Namn = k.Namn,
                })
                .ToListAsync();
        }
    }
}
