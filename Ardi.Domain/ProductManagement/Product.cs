using Ardi.Domain.ProductManagement.Enums;
using Ardi.Domain.PolicyManagement;
using Ardi.Domain.Shared;

namespace Ardi.Domain.ProductManagement;

public class Product : BaseEntity<Guid>
{
    public override Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? CoverageDetails { get; set; }
    public required decimal Amount { get; set; }
    public required ProductType Type { get; set; }

    public ICollection<Policy>? Policies { get; set; }
}