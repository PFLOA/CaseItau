using A4S.CaseItau.Infra.Data.Mapping;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A4S.CaseItau.Infra.Data
{
    public class CaseItauTwitterContext : DbContext
    {
        public DbSet<Postagem> Postagem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public CaseItauTwitterContext() { }
        public CaseItauTwitterContext(DbContextOptions<CaseItauTwitterContext> options) : base(options) { }

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostagemMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
