using Microsoft.EntityFrameworkCore;
using BaseLibrary.Models;
using API_Juliet.SeedData;

namespace API_Juliet.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Bostad> Bostäder {  get; set; }
        public DbSet<BostadBild> BostadsBilder { get; set; }
        public DbSet<BostadKategori> BostadKategorier { get; set; }
        public DbSet<Kommun> Kommuner { get; set; }
        public DbSet<Mäklarbyrå> Mäklarbyråer { get; set; }
        public DbSet<Mäklare> Mäklare {  get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
