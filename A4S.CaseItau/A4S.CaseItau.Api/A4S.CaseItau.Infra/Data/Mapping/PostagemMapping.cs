using Microsoft.EntityFrameworkCore.Metadata.Builders;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace A4S.CaseItau.Infra.Data.Mapping
{
    public class PostagemMapping : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.ToTable("postagens");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.DataPostagem).HasColumnName("data_postagem");
            builder.Property(p => p.IdAuthor).HasColumnName("id_author");
            builder.Property(p => p.Text).HasColumnName("text");
            builder.Property(p => p.Idioma).HasColumnName("idioma");

            builder.HasOne(p => p.Usuario).WithMany(p => p.Postagens).HasForeignKey(p => p.IdAuthor);
        }
    }
}
