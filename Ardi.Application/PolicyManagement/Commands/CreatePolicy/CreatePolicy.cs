using Ardi.Domain.PolicyManagement.Enums;
using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.CreatePolicy;

public record CreatePolicy(DateTime IssueDate, DateTime ExpiryDate, decimal Amount,
                           Guid PolicyholderId, Guid ProductId) : IRequest;