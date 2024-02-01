using Ardi.Domain.PolicyManagement.Enums;
using Ardi.Domain.Shared;

namespace Ardi.Domain.PolicyManagement;

public class Policy : BaseEntity<Guid>
{
    public override Guid Id { get; set; }
    public required DateTime IssueDate { get; set; }
    public required DateTime ExpiryDate { get; set; }
    public required decimal Amount { get; set; }
    public required PolicyStatus Status { get; set; }

    public Guid? PolicyholderId { get; set; }
    public PolicyHolderManagement.PolicyHolder? PolicyHolder { get; set; }

    public Guid? ProductId { get; set; }
    public ProductManagement.Product? Product { get; set; }
}