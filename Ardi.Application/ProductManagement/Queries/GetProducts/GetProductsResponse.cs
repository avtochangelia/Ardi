using Ardi.Application.ProductManagement.Dto;
using Ardi.Application.Shared;

namespace Ardi.Application.ProductManagement.Queries.GetProducts;

public class GetProductsResponse : PaginationResponse
{
    public IEnumerable<ProductBaseDtoModel>? Products { get; set; }
}