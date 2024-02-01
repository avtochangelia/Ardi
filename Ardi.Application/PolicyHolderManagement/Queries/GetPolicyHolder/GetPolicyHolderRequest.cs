using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Queries.GetPolicyHolder;

public class GetPolicyHolderRequest : IRequest<GetPolicyHolderResponse>
{
    public Guid PolicyHolderId { get; set; }
}