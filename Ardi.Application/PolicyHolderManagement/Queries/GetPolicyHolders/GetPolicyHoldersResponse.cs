using Ardi.Application.PolicyHolderManagement.Dto;
using Ardi.Application.Shared;

namespace Ardi.Application.PolicyHolderManagement.Queries.GetPolicyHolders;

public class GetPolicyHoldersResponse : PaginationResponse
{
    public IEnumerable<PolicyHolderDtoModel>? PolicyHolders { get; set; }
}