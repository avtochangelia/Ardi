using Ardi.Domain.PolicyManagement;
using Ardi.Domain.ProductManagement.Enums;
using MediatR;

namespace Ardi.Application.ProductManagement.Commands.UpdateProduct;

public record UpdateProduct(string Name, string Description, string? CoverageDetails,
                            decimal Amount, ProductType Type) : IRequest
{
    public Guid Id { get; private set; }

    public void SetId(Guid id)
    {
        Id = id;
    }
}