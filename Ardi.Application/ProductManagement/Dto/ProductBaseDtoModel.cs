using Ardi.Domain.ProductManagement;
using Ardi.Domain.ProductManagement.Enums;

namespace Ardi.Application.ProductManagement.Dto;

public class ProductBaseDtoModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? CoverageDetails { get; set; }
    public required decimal Amount { get; set; }
    public required ProductType Type { get; set; }

    public static ProductBaseDtoModel MapToDto(Product product)
    {
        return ProductDtoModel.MapToDto(product, false);
    }
}