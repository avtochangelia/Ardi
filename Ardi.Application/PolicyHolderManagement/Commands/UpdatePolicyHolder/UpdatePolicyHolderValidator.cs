using FluentValidation;

namespace Ardi.Application.PolicyHolderManagement.Commands.UpdatePolicyHolder;

public class UpdatePolicyHolderValidator : AbstractValidator<UpdatePolicyHolder>
{
    public UpdatePolicyHolderValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.FirstName).NotNull().NotEmpty();
        RuleFor(x => x.LastName).NotNull().NotEmpty();
        RuleFor(x => x.PersonalNumber).NotNull().NotEmpty();
        RuleFor(x => x.DateOfBirth).NotNull();
        RuleFor(x => x.ContactNumber).NotNull();
        RuleFor(x => x.EmailAddress).EmailAddress();
    }
}