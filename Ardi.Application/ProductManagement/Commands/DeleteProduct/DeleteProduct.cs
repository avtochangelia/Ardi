using MediatR;

namespace Ardi.Application.ProductManagement.Commands.DeleteProduct;

public record DeleteProduct(Guid ProductId) : IRequest;