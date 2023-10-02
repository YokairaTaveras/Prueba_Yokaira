using Microsoft.EntityFrameworkCore;
using Prueba_Yokaira.Models;

namespace Prueba_Yokaira.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Ingresos> ingreso { get; set; }
    }
}
