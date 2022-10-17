using A4S.CaseItau.Infra.Data.Mapping;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A4S.CaseItau.Infra.Data
{
    public class CaseItauCatApiContext : DbContext
    {
        public DbSet<Raca> Raca { get; set; }
        public DbSet<Imagem> Imagem { get; set; }

        public CaseItauCatApiContext() { }
        public CaseItauCatApiContext(DbContextOptions<CaseItauCatApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RacaMapping());
            modelBuilder.ApplyConfiguration(new ImagemMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
