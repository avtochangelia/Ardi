using Ardi.Application.ProductManagement.Dto;
using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Shared.Extensions;
using MediatR;

namespace Ardi.Application.ProductManagement.Queries.GetProducts;

public class GetProductsHandler(IProductRepository productRepository) : IRequestHandler<GetProductsRequest, GetProductsResponse>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.QueryAsync();

        var total = products.Count();
        
        var paginatedProducts = products.Pagination(request);

        var response = new GetProductsResponse
        {
            Products = paginatedProducts.Select(ProductBaseDtoModel.MapToDto),
            Page = request.Page,
            PageSize = request.PageSize,
            Total = total,
        };

        return response;
    }
}