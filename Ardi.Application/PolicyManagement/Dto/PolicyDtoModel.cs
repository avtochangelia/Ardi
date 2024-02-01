using Ardi.Application.PolicyHolderManagement.Dto;
using Ardi.Application.ProductManagement.Dto;
using Ardi.Domain.PolicyManagement;

namespace Ardi.Application.PolicyManagement.Dto;

public class PolicyDtoModel : PolicyBaseDtoModel
{
    public ProductBaseDtoModel? Product { get; set; }

    public static PolicyDtoModel MapToDto(Policy policy, bool includeNavProperties = true)
    {
        var model = new PolicyDtoModel()
        {
            Id = policy.Id,
            IssueDate = policy.IssueDate,
            ExpiryDate = policy.ExpiryDate,
            Amount = policy.Amount,
            Status = policy.Status,
        };

        if (includeNavProperties)
        {
            model.Product = policy.Product != null ? ProductBaseDtoModel.MapToDto(policy.Product) : null;
        }

        return model;
    }
}