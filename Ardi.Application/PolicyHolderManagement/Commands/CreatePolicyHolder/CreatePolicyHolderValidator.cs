using FluentValidation;

namespace Ardi.Application.PolicyHolderManagement.Commands.CreatePolicyHolder;

public class CreatePolicyHolderValidator : AbstractValidator<CreatePolicyHolder>
{
    public CreatePolicyHolderValidator()
    {
        RuleFor(x => x.FirstName).NotNull().NotEmpty();
        RuleFor(x => x.LastName).NotNull().NotEmpty();
        RuleFor(x => x.PersonalNumber).NotNull().NotEmpty();
        RuleFor(x => x.DateOfBirth).NotNull();
        RuleFor(x => x.ContactNumber).NotNull();
        RuleFor(x => x.EmailAddress).EmailAddress();
    }
}