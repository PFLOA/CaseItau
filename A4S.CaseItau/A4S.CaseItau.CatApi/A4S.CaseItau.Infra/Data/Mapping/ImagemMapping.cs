using Microsoft.EntityFrameworkCore.Metadata.Builders;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A4S.CaseItau.Infra.Data.Mapping
{
    public class ImagemMapping : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.ToTable("imagens");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.Altura).HasColumnName("altura");
            builder.Property(p => p.Largura).HasColumnName("largura");
            builder.Property(p => p.Url).HasColumnName("url");
            builder.Property(p => p.IdImage).HasColumnName("id_imagem");
            builder.Property(p => p.IdRaca).HasColumnName("id_raca");
            builder.Property(p => p.Categoria).HasColumnName("categoria");

            builder.HasOne(p => p.Raca).WithMany(p => p.Imagens).HasForeignKey(p => p.IdRaca);
        }
    }
}
