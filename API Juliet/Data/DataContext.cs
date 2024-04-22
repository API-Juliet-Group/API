using Microsoft.EntityFrameworkCore;
using API_Juliet.Models;

namespace API_Juliet.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Bostad> Bostäder {  get; set; }
        public DbSet<BostadKategori> BostadKategori { get; set; }
        public DbSet<Kommun> Kommuner { get; set; }
        public DbSet<Mäklarbyrå> Mäklarbyråer { get; set; }
        public DbSet<Mäklare> Mäklare {  get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }
    }
}
