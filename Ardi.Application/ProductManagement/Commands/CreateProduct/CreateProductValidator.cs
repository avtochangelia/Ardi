using FluentValidation;

namespace Ardi.Application.ProductManagement.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Amount).NotNull();
        RuleFor(x => x.Type).IsInEnum()
                            .WithMessage("Invalid product type specified.");
    }
}