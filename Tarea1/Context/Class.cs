using Microsoft.EntityFrameworkCore;
using Tarea1.Modulos;

namespace Tarea1.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Personas { get; set; }   ///con el get set llamo los atributos que definimos
    }
}

