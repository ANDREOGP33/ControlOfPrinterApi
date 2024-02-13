using Microsoft.EntityFrameworkCore.Sqlite;
using ControlOfPrinterApi.Data;
using Microsoft.EntityFrameworkCore;
using ControlOfPrinterApi.Repositories.Interfaces;
using ControlOfPrinterApi.Repositories;

namespace ControlOfPrinterApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<PrinterContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IPrinterRepository, PrinterRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
