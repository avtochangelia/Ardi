using FluentValidation;

namespace Ardi.Application.PolicyManagement.Commands.ChangePolicyStatus;

public class ChangePolicyStatusValidator : AbstractValidator<ChangePolicyStatus>
{
    public ChangePolicyStatusValidator()
    {
        RuleFor(x => x.Status).IsInEnum()
                              .WithMessage("Invalid policy status specified.");
    }
}