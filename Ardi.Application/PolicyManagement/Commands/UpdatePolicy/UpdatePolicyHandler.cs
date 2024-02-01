using Ardi.Domain.PolicyHolderManagement;
using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.UpdatePolicy;

public class UpdatePolicyHandler(
    IPolicyRepository policyRepository,
    IProductRepository productRepository,
    IPolicyHolderRepository policyHolderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePolicy>
{
    private readonly IPolicyRepository _policyRepository = policyRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IPolicyHolderRepository _policyHolderRepository = policyHolderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(UpdatePolicy request, CancellationToken cancellationToken)
    {
        var policy = await _policyRepository.OfIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Policy was not found for Id: {request.Id}");

        if (request.ProductId != null)
        {
            _ = await _productRepository.OfIdAsync(request.ProductId.Value)
                ?? throw new KeyNotFoundException($"Product was not found for Id: {request.ProductId}");

            policy.ProductId = request.ProductId!.Value;
        }

        if (request.PolicyholderId != null)
        {
            _ = await _policyHolderRepository.OfIdAsync(request.PolicyholderId.Value)
                ?? throw new KeyNotFoundException($"Policy holder was not found for Id: {request.PolicyholderId}");

            policy.PolicyholderId = request.PolicyholderId!.Value;
        }

        policy.IssueDate = request.IssueDate;
        policy.ExpiryDate = request.ExpiryDate;
        policy.Amount = request.Amount;
   
        _policyRepository.Update(policy);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}