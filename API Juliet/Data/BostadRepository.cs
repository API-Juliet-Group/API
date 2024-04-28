using BaseLibrary.DTO;
using BaseLibrary.Models;
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


        //BostadDto

        public async Task<IEnumerable<BostadDto>> GetAllBostadDtosAsync()
        {
            return await _context.Bostäder
                .Include(b => b.BostadKategori)
                .Include(b => b.Kommun)
                .Include(b => b.Mäklare)
                .Select(b => new BostadDto
                {
                    Id = b.Id,
                    Utgångspris = b.Utgångspris,
                    Boarea = b.Boarea,
                    Biarea = b.Biarea,
                    Tomtarea = b.Tomtarea,
                    Antalrum = b.Antalrum,
                    Månadsavgift = b.Månadsavgift,
                    Driftkonstnad = b.Driftkonstnad,
                    Byggår = b.Byggår,
                    Adress = b.Adress,
                    Objektbeskrivning = b.Objektbeskrivning,
                    Kategori = b.BostadKategori.Namn,
                    Kommun = b.Kommun.Namn,
                    Mäklare = b.Mäklare.Förnamn +" "+ b.Mäklare.Förnamn
                })
                .ToListAsync();
        }

        public async Task AddBostadDtoAsync(BostadDto bostadDto)
        {
            Bostad bostad = new Bostad()
            {
                Id = bostadDto.Id,
                Utgångspris = bostadDto.Utgångspris,
                Boarea = bostadDto.Boarea,
                Biarea = bostadDto.Biarea,
                Tomtarea = bostadDto.Tomtarea,
                Antalrum = bostadDto.Antalrum,
                Månadsavgift = bostadDto.Månadsavgift,
                Driftkonstnad = bostadDto.Driftkonstnad,
                Byggår = bostadDto.Byggår,
                Adress = bostadDto.Adress,
                Objektbeskrivning = bostadDto.Objektbeskrivning

            };
            _context.Bostäder.Add(bostad);
            await _context.SaveChangesAsync();
        }

    }
}
