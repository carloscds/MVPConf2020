using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopEF.Data.Dominio;

namespace WorkshopEF.Data.EFConfiguration
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
            builder.HasMany(p => p.Produto)
                .WithOne(p => p.Grupo)
                .HasForeignKey(p => p.GrupoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
