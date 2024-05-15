using API_Juliet.Data;
using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
using API_Juliet.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Juliet.Repositorys
{
    public class BostadRepository : IBostad
    {
        private readonly DataContext _context;
        public BostadRepository(DataContext context)
        {
            _context = context;
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
                    Gatuadress = b.Gatuadress,
                    Ort = b.Ort,
                    Objektbeskrivning = b.Objektbeskrivning,
                    KategoriId = b.KategoriId,
                    Kategori = b.BostadKategori.Namn,
                    KommunId = b.KommunId,
                    Kommun = b.Kommun.Namn,
                    MäklarId = b.MäklareId,
                    Mäklare = b.Mäklare.Förnamn + " " + b.Mäklare.Efternamn
                })
                .ToListAsync();
        }

        public async Task<BostadDto> GetBostad(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
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
                    Gatuadress = b.Gatuadress,
                    Ort = b.Ort,
                    Objektbeskrivning = b.Objektbeskrivning,
                    KategoriId = b.KategoriId,
                    Kategori = b.BostadKategori.Namn,
                    KommunId = b.KommunId,
                    Kommun = b.Kommun.Namn,
                    MäklarId = b.MäklareId,
                    Mäklare = b.Mäklare.Förnamn + " " + b.Mäklare.Efternamn
                })
                .SingleOrDefaultAsync(c => c.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Bostad> AddBostadDtoAsync(BostadDto bostadDto)
        {
            Bostad bostad = new Bostad()
            {
                Utgångspris = bostadDto.Utgångspris,
                Boarea = bostadDto.Boarea,
                Biarea = bostadDto.Biarea,
                Tomtarea = bostadDto.Tomtarea,
                Antalrum = bostadDto.Antalrum,
                Månadsavgift = bostadDto.Månadsavgift,
                Driftkonstnad = bostadDto.Driftkonstnad,
                Byggår = bostadDto.Byggår,
                Gatuadress = bostadDto.Gatuadress,
                Ort = bostadDto.Ort,
                Objektbeskrivning = bostadDto.Objektbeskrivning,
                KategoriId = bostadDto.KategoriId,
                KommunId = bostadDto.KommunId,
                MäklareId = bostadDto.MäklarId
            };
            var result = await _context.Bostäder.AddAsync(bostad);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteBostadAsync(int id)
        {
            Bostad bostad = await _context.Bostäder.FindAsync(id);

            if (bostad != null)
            {
                _context.Bostäder.Remove(bostad);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBostad(BostadDto bostadDto)
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
                Gatuadress = bostadDto.Gatuadress,
                Ort = bostadDto.Ort,
                Objektbeskrivning = bostadDto.Objektbeskrivning,
                KategoriId = bostadDto.KategoriId,
                KommunId = bostadDto.KommunId,
                MäklareId = bostadDto.MäklarId
            };
            _context.Update(bostad);

            await _context.SaveChangesAsync();
        }


    }
}
