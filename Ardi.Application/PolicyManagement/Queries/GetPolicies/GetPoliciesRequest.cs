using Ardi.Application.Shared;
using Ardi.Domain.PolicyManagement.Enums;
using MediatR;

namespace Ardi.Application.PolicyManagement.Queries.GetPolicies;

public class GetPoliciesRequest : PaginationRequest, IRequest<GetPoliciesResponse>
{
    public PolicyStatus? Status { get; set; }
}