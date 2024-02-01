using Ardi.Application.ProductManagement.Commands.CreateProduct;
using FluentValidation;

namespace Ardi.Application.PolicyManagement.Commands.CreatePolicy;

public class CreatePolicyValidator : AbstractValidator<CreatePolicy>
{
    public CreatePolicyValidator()
    {
        RuleFor(x => x.IssueDate).NotNull();
        RuleFor(x => x.ExpiryDate).NotNull();
        RuleFor(x => x.ProductId).NotNull();
        RuleFor(x => x.PolicyholderId).NotNull();
    }
}