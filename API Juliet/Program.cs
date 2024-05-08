
using API_Juliet.Data;
using API_Juliet.Repositorys;
using API_Juliet.Repositorys.Contracts;
using API_Juliet.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace API_Juliet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DataDbContext") ?? throw new InvalidOperationException("Connection string 'DataDbContext' not found.")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors( options =>
            {
                options.AddPolicy("AllowAll",
                    b => b.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    );
            });
            builder.Services.AddTransient<IBostad, BostadRepository>();
            builder.Services.AddTransient<IBostadBild, BostadBildRepository>();
            builder.Services.AddTransient<IKommun, KommunRepository>();
            builder.Services.AddTransient<IMäklarbyrå, MäklarbyråRepository>();
            builder.Services.AddTransient<IMäklare, MäklareRepository>();
            builder.Services.AddTransient<IBostadKategori, BostadKategoriRepository>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policy =>
                policy.WithOrigins("http://localhost:7109", "https://localhost:7109")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType)
            );

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Seed();

            app.Run();
        }
    }
}
