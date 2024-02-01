using Ardi.Domain.PolicyManagement;
using Ardi.Shared.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ardi.Infrastructure.TypeConfigurations;

public class PolicyTypeConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.ToTable(Pluralizer<Policy>.PluralizedTypeName);

        builder.Property(p => p.Amount)
               .HasPrecision(18, 2);

        builder.HasOne(p => p.PolicyHolder)
               .WithMany(ph => ph.Policies)
               .HasForeignKey(p => p.PolicyholderId);

        builder.HasOne(p => p.Product)
               .WithMany(ip => ip.Policies)
               .HasForeignKey(p => p.ProductId);
    }
}