using Ardi.Domain.ProductManagement;
using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.ProductManagement.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateProduct>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            CoverageDetails = request.CoverageDetails,
            Amount = request.Amount,
            Type = request.Type
        };

        await _productRepository.InsertAsync(product);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}