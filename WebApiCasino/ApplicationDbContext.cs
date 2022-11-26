using Microsoft.EntityFrameworkCore;
using WebApiCasino.Entidades;

namespace WebApiCasino
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Premio> Premios { get; set; }
        public DbSet<Rifa> Rifas { get; set; }
    }
}
