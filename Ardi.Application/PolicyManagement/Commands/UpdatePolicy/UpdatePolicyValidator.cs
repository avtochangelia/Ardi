using FluentValidation;

namespace Ardi.Application.PolicyManagement.Commands.UpdatePolicy;

public class UpdatePolicyValidator : AbstractValidator<UpdatePolicy>
{
    public UpdatePolicyValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.IssueDate).NotNull();
        RuleFor(x => x.ExpiryDate).NotNull();
    }
}