using Ardi.Domain.PolicyManagement.Enums;
using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.ChangePolicyStatus;

public record ChangePolicyStatus(PolicyStatus Status) : IRequest
{
    public Guid PolicyId { get; private set; }

    public void SetId(Guid id)
    {
        PolicyId = id;
    }
}