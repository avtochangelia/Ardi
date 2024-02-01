using MediatR;

namespace Ardi.Application.PolicyManagement.Queries.GetPolicy;

public class GetPolicyRequest : IRequest<GetPolicyResponse>
{
    public Guid PolicyId { get; set; }
}