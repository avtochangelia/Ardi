using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.DeletePolicy;

public class DeletePolicyHandler(IPolicyRepository policyRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePolicy>
{
    private readonly IPolicyRepository _policyRepository = policyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeletePolicy request, CancellationToken cancellationToken)
    {
        var policy = await _policyRepository.OfIdAsync(request.PolicyId) 
            ?? throw new KeyNotFoundException($"Policy was not found for Id: {request.PolicyId}");

        _policyRepository.Delete(policy);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}