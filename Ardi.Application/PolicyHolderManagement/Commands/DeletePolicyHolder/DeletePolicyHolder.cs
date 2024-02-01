using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Commands.DeletePolicyHolder;

public record DeletePolicyHolder(Guid PolicyHolderId) : IRequest;