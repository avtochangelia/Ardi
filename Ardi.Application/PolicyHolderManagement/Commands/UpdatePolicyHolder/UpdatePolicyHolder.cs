using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Commands.UpdatePolicyHolder;

public record UpdatePolicyHolder(string FirstName, string LastName, string PersonalNumber, DateTime DateOfBirth, 
                                 string ContactNumber, string? EmailAddress) : IRequest
{
    public Guid Id { get; private set; }

    public void SetId(Guid id)
    {
        Id = id;
    }
}