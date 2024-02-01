using Ardi.Application.PolicyManagement.Dto;
using Ardi.Application.ProductManagement.Dto;

namespace Ardi.Application.PolicyManagement.Queries.GetPolicy;

public class GetPolicyResponse
{
    public PolicyBaseDtoModel? Policy { get; set; }
}