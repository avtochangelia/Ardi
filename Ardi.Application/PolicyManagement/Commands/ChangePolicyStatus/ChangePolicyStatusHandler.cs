using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.PolicyManagement.Commands.ChangePolicyStatus;

public class ChangePolicyStatusHandler(
    IPolicyRepository policyRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ChangePolicyStatus>
{
    private readonly IPolicyRepository _policyRepository = policyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(ChangePolicyStatus request, CancellationToken cancellationToken)
    {
        var policy = await _policyRepository.OfIdAsync(request.PolicyId)
            ?? throw new KeyNotFoundException($"Policy was not found for Id: {request.PolicyId}");

        policy.Status = request.Status;

        _policyRepository.Update(policy);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}