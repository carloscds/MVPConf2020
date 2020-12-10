using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopEF.Dominio;

namespace WorkshopEF.EFConfiguration
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .HasMaxLength(100);
            builder.HasIndex(p => p.Key);
            builder.HasMany(p => p.Produto)
                .WithOne(p => p.Grupo)
                .HasForeignKey(p => p.GrupoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
