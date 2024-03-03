using Microsoft.EntityFrameworkCore;

namespace AgenciaViagem.Models
{
    public class AgenciaDbContext:DbContext
    {
        public AgenciaDbContext(DbContextOptions<AgenciaDbContext> options) : base(options)
        { }
        public DbSet<Viagem> viagem {  get; set; }

    }
}
