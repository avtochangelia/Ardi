using Ardi.Application.Shared;
using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Queries.GetPolicyHolders;

public class GetPolicyHoldersRequest : PaginationRequest, IRequest<GetPolicyHoldersResponse>
{
}