using Ardi.Domain.ProductManagement.Enums;
using MediatR;

namespace Ardi.Application.ProductManagement.Commands.CreateProduct;

public record CreateProduct(string Name, string Description, string? CoverageDetails, decimal Amount, ProductType Type) : IRequest;