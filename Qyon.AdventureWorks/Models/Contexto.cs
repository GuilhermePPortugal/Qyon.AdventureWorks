using Microsoft.EntityFrameworkCore;

namespace Qyon.AdventureWorks.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
           : base(options)
        {
        }
      
        public DbSet<Competidores> Competidores { get; set; }
        public DbSet<PistaCorrida> PistaCorrida { get; set; }
        public DbSet<HistoricoCorrida> HistoricoCorrida { get; set; }




    }
}
