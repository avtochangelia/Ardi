using MediatR;

namespace Ardi.Application.ProductManagement.Queries.GetProduct;

public class GetProductRequest : IRequest<GetProductResponse>
{
    public Guid ProductId { get; set; }
}