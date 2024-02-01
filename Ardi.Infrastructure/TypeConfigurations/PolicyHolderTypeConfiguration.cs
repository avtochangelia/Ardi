using Ardi.Domain.PolicyHolderManagement;
using Ardi.Shared.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ardi.Infrastructure.TypeConfigurations;

public class PolicyHolderTypeConfiguration : IEntityTypeConfiguration<PolicyHolder>
{
    public void Configure(EntityTypeBuilder<PolicyHolder> builder)
    {
        builder.ToTable(Pluralizer<PolicyHolder>.PluralizedTypeName);
    }
}