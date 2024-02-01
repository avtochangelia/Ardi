using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.DeletePolicy;

public record DeletePolicy(Guid PolicyId) : IRequest;