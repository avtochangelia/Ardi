using Ardi.Domain.PolicyManagement;
using Ardi.Domain.Shared;

namespace Ardi.Domain.PolicyHolderManagement;

public class PolicyHolder : BaseEntity<Guid>
{
    public override Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PersonalNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string ContactNumber { get; set; }
    public string? EmailAddress { get; set; }

    public ICollection<Policy>? Policies { get; set; }
}