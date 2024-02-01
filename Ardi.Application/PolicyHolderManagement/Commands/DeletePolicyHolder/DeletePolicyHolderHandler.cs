using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Commands.DeletePolicyHolder;

public class DeletePolicyHolderHandler(IPolicyHolderRepository policyHolderRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePolicyHolder>
{
    private readonly IPolicyHolderRepository _policyHolderRepository = policyHolderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeletePolicyHolder request, CancellationToken cancellationToken)
    {
        var policyHolder = await _policyHolderRepository.OfIdAsync(request.PolicyHolderId)
            ?? throw new KeyNotFoundException($"Policy holder was not found for Id: {request.PolicyHolderId}");

        _policyHolderRepository.Delete(policyHolder);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}