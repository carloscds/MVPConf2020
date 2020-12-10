using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopEF.Dominio;

namespace WorkshopEF.EFConfiguration
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .HasMaxLength(100);
        }
    }
}
