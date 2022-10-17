using Microsoft.EntityFrameworkCore.Metadata.Builders;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A4S.CaseItau.Infra.Data.Mapping
{
    public class RacaMapping : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ToTable("racas");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.Origem).HasColumnName("origem");
            builder.Property(p => p.Descricao).HasColumnName("descricao");
            builder.Property(p => p.Temperamento).HasColumnName("temperamento");

            builder.HasMany(p => p.Imagens).WithOne(p => p.Raca).HasForeignKey(p => p.IdRaca);
        }
    }
}
