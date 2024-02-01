using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.ProductManagement.Commands.DeleteProduct;

public class DeleteProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteProduct>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.OfIdAsync(request.ProductId) 
            ?? throw new KeyNotFoundException($"Product was not found for Id: {request.ProductId}");

        _productRepository.Delete(product);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}