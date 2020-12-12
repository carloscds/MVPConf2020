using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopEF.Data.Dominio;

namespace WorkshopEF.Data.EFConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .HasMaxLength(100);
            builder.Property(p => p.Preco)
                .HasPrecision(18, 2);
            builder.HasOne(p => p.Grupo)
                .WithMany(p => p.Produto)
                .HasForeignKey(p => p.GrupoId);
            builder.HasIndex(p => p.GrupoId).IsUnique(false);
        }
    }
}
