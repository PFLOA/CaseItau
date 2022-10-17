using Microsoft.EntityFrameworkCore.Metadata.Builders;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A4S.CaseItau.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.Seguidores).HasColumnName("seguidores");
            builder.Property(p => p.Seguindo).HasColumnName("seguindo");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.UserName).HasColumnName("username");
        }
    }
}
