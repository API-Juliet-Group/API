using API_Juliet.Data;
using API_Juliet.Repositorys.Contracts;
using API_Juliet.Models;
using Microsoft.EntityFrameworkCore;
using BaseLibrary.DTO;

namespace API_Juliet.Repositorys
{
    public class KommunRepository : IKommun
    {
        private readonly DataContext _context;

        public KommunRepository(DataContext context)
        {
            _context = context;
        }

        //DTO
        public async Task<IEnumerable<KommunDto>> GetAllKommunDtosAsync()
        {
            return await _context.Kommuner
                .Select(k => new KommunDto
                {
                    Id = k.Id,
                    Namn = k.Namn,
                })
                .ToListAsync();
        }
    }
}
