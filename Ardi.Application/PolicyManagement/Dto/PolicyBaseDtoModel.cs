using Ardi.Domain.PolicyManagement;
using Ardi.Domain.PolicyManagement.Enums;

namespace Ardi.Application.PolicyManagement.Dto;

public class PolicyBaseDtoModel
{
    public Guid Id { get; set; }
    public required DateTime IssueDate { get; set; }
    public required DateTime ExpiryDate { get; set; }
    public required decimal Amount { get; set; }
    public required PolicyStatus Status { get; set; }

    public static PolicyBaseDtoModel MapToDto(Policy policy)
    {
        return PolicyDtoModel.MapToDto(policy, false);
    }
}