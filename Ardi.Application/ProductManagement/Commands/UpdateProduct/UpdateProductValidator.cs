using FluentValidation;

namespace Ardi.Application.ProductManagement.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProduct>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Amount).NotNull();
        RuleFor(x => x.Type).IsInEnum()
                            .WithMessage("Invalid product type specified.");
    }
}