using Microsoft.EntityFrameworkCore;
using L01P02_2019TM602.Models;
namespace L01P02_2019TM602.Models
{
    public class equiposDbContext:DbContext
    {
        public equiposDbContext(DbContextOptions options)  : base(options)
        {
        
        }
        public DbSet<datos> datos { get; set; }
        public DbSet<datos> materias { get; set; }
        public DbSet<datos> departamentos { get; set; }
        public DbSet<datos> alumnos { get; set; }
        public DbSet<L01P02_2019TM602.Models.alumnos>? alumnos_1 { get; set; }
        public DbSet<L01P02_2019TM602.Models.departamentos>? departamentos_1 { get; set; }
        public DbSet<L01P02_2019TM602.Models.materias>? materias_1 { get; set; }
    }
}
