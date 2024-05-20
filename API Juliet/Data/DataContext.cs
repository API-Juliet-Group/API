﻿using API_Juliet.Models;
using API_Juliet.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace API_Juliet.Data
{
    public class DataContext : IdentityDbContext<Mäklare>
    {
        public DbSet<Bostad> Bostäder {  get; set; }
        public DbSet<BostadBild> BostadsBilder { get; set; }
        public DbSet<BostadKategori> BostadKategorier { get; set; }
        public DbSet<Kommun> Kommuner { get; set; }
        public DbSet<Mäklarbyrå> Mäklarbyråer { get; set; }
        public DbSet<Mäklare> Mäklare {  get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = ApiRoles.SuperAdmin,
                    NormalizedName = ApiRoles.SuperAdmin.ToUpper(),
                    Id = ApiRoles.SuperAdminId
                },
                new IdentityRole
                {
                    Name = ApiRoles.Mäklare,
                    NormalizedName = ApiRoles.Mäklare.ToUpper(),
                    Id = ApiRoles.MäklareId
                }
            );
            var hasher = new PasswordHasher<Mäklare>();
            builder.Entity<Mäklare>().HasData(
                new Mäklare
                {
                    Id = "62e8b88c-364b-4731-929d-d477c855302f",
                    Email = "admin@bostäder.se",
                    NormalizedEmail = "admin@bostäder.se".ToUpper(),
                    UserName = "admin@bostäder.se",
                    NormalizedUserName = "admin@bostäder.se".ToUpper(),
                    Förnamn = "Admin",
                    Efternamn = "Bostäder.se",
                    PasswordHash = hasher.HashPassword(null, "Pass123"),
                    EmailConfirmed = true
                },
                new Mäklare
                {
                    Id = "2a2b8c8e-d2db-4fb8-b3f0-869975afb523",
                    Email = "mäklare@bostäder.se",
                    NormalizedEmail = "mäklare@bostäder.se".ToUpper(),
                    UserName = "mäklare@bostäder.se",
                    NormalizedUserName = "mäklare@bostäder.se".ToUpper(),
                    Förnamn = "Mäklare",
                    Efternamn = "Bostäder.se",
                    PasswordHash = hasher.HashPassword(null, "Pass123"),
                    EmailConfirmed = true
                }
            );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ApiRoles.SuperAdminId,
                    UserId = "62e8b88c-364b-4731-929d-d477c855302f"
                },
                new IdentityUserRole<string>
                {
                    RoleId = ApiRoles.MäklareId,
                    UserId = "2a2b8c8e-d2db-4fb8-b3f0-869975afb523"
                }
            );
        }
    }
}
