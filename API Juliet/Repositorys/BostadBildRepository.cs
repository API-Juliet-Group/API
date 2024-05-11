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

        //DTO

        //hämtar alla bilder
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

        //Hämtar alla bilder som tillhör en bostad
        public async Task<IEnumerable<BostadBildDto>> GetBostadensBilderDtosAsync(int bostadsId)
        {
            return await _context.BostadsBilder
                .Select(b => new BostadBildDto
                {
                    Id = b.Id,
                    BildURL = b.BildURL,
                    BostadId = b.BostadId,
                })
                .Where(b => b.BostadId == bostadsId)
                .ToListAsync();
        }

        //lägger till en list av bilder
        public async Task AddBostadsBilderDtosAsync(IEnumerable<BostadBildDto> bostadBilder)
        {
            foreach (var item in bostadBilder)
            {
                BostadBild bostadBild = new BostadBild() { BildURL = item.BildURL, BostadId = item.BostadId};
                _context.BostadsBilder.Add(bostadBild);
            }
            await _context.SaveChangesAsync();
        }

        //lägger till en bild
        public async Task AddBostadBildAsync(BostadBildDto bostadBildDto)
        {
            BostadBild bostadBild = new BostadBild() { BildURL = bostadBildDto.BildURL, BostadId = bostadBildDto.BostadId };
            _context.BostadsBilder.Add(bostadBild);

            await _context.SaveChangesAsync();
        }

        //tar bort en bild
        public async Task DeleteBostadsBild(int id)
        {
            BostadBild bild = await _context.BostadsBilder.FindAsync(id);

            if (bild != null)
            {
                _context.BostadsBilder.Remove(bild);
                await _context.SaveChangesAsync();
            }
        }

    }
}
