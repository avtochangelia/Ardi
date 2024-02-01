using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Commands.CreatePolicyHolder;

public record CreatePolicyHolder(string FirstName, string LastName, string PersonalNumber,
                                 DateTime DateOfBirth, string ContactNumber, string? EmailAddress) : IRequest;