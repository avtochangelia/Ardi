using Ardi.Application.PolicyManagement.Dto;
using Ardi.Domain.ProductManagement;

namespace Ardi.Application.ProductManagement.Dto;

public class ProductDtoModel : ProductBaseDtoModel
{
    public IEnumerable<PolicyBaseDtoModel>? Policies { get; set; }

    public static ProductDtoModel MapToDto(Product product, bool includeNavProperties = true)
    {
        var model = new ProductDtoModel()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            CoverageDetails = product.CoverageDetails,
            Amount = product.Amount,
            Type = product.Type,
        };

        if (includeNavProperties)
        {
            model.Policies = product.Policies != null && product.Policies.Count != 0 ? product.Policies.Select(x => PolicyBaseDtoModel.MapToDto(x)).ToList() : default;
        }

        return model;
    }
}