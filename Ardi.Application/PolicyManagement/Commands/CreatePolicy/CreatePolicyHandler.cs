using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.PolicyManagement;
using Ardi.Domain.PolicyManagement.Enums;
using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.CreatePolicy;

public class CreatePolicyHandler(
    IPolicyRepository policyRepository,
    IProductRepository productRepository,
    IPolicyHolderRepository policyHolderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePolicy>
{
    private readonly IPolicyRepository _policyRepository = policyRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IPolicyHolderRepository _policyHolderRepository = policyHolderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(CreatePolicy request, CancellationToken cancellationToken)
    {
        _ = await _productRepository.OfIdAsync(request.ProductId)
            ?? throw new KeyNotFoundException($"Product was not found for Id: {request.ProductId}");
        
        _ = await _policyHolderRepository.OfIdAsync(request.PolicyholderId)
            ?? throw new KeyNotFoundException($"Policy holder was not found for Id: {request.PolicyholderId}");

        var policy = new Policy()
        {
            IssueDate = request.IssueDate,
            ExpiryDate = request.ExpiryDate,
            Amount = request.Amount,
            Status = PolicyStatus.Active,
            ProductId = request.ProductId,
            PolicyholderId = request.PolicyholderId
        };

        await _policyRepository.InsertAsync(policy);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}