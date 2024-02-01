using Ardi.Application.Shared;
using MediatR;

namespace Ardi.Application.ProductManagement.Queries.GetProducts;

public class GetProductsRequest : PaginationRequest, IRequest<GetProductsResponse>
{
}