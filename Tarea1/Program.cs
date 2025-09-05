using Microsoft.EntityFrameworkCore;
using System;

namespace Tarea1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            var connectionString =
                builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
