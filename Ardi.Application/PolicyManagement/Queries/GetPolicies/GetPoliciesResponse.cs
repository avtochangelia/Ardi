using Ardi.Application.PolicyManagement.Dto;
using Ardi.Application.Shared;

namespace Ardi.Application.PolicyManagement.Queries.GetPolicies;

public class GetPoliciesResponse : PaginationResponse
{
    public IEnumerable<PolicyBaseDtoModel>? Policies { get; set; }
}