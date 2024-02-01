using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.ProductManagement.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<UpdateProduct>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.OfIdAsync(request.Id) 
            ?? throw new KeyNotFoundException($"Product was not found for Id: {request.Id}");

        product.Name = request.Name;
        product.Description = request.Description;
        product.CoverageDetails = request.CoverageDetails;
        product.Amount = request.Amount;
        product.Type = request.Type;

        _productRepository.Update(product);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}