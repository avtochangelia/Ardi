using Ardi.Domain.ProductManagement;
using Ardi.Shared.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ardi.Infrastructure.TypeConfigurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(Pluralizer<Product>.PluralizedTypeName);

        builder.Property(p => p.Amount)
               .HasPrecision(18, 2);
    }
}