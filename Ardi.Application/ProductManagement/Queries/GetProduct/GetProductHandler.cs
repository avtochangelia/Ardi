using Ardi.Application.ProductManagement.Dto;
using Ardi.Domain.ProductManagement.Repositories;
using MediatR;

namespace Ardi.Application.ProductManagement.Queries.GetProduct;

public class GetProductHandler(IProductRepository productRepository) : IRequestHandler<GetProductRequest, GetProductResponse>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.OfIdAsync(request.ProductId) 
            ?? throw new KeyNotFoundException($"Product was not found for Id: {request.ProductId}");

        return new GetProductResponse
        {
            Product = new ProductBaseDtoModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CoverageDetails = product.CoverageDetails,
                Amount = product.Amount,
                Type = product.Type,
            },
        };
    }
}