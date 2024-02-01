using Ardi.Domain.PolicyManagement.Enums;
using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.UpdatePolicy;

public record UpdatePolicy(DateTime IssueDate, DateTime ExpiryDate, decimal Amount,
                           Guid? PolicyholderId, Guid? ProductId) : IRequest
{
    public Guid Id { get; private set; }

    public void SetId(Guid id)
    {
        Id = id;
    }
}