using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Commands.UpdatePolicyHolder;

public class UpdatePolicyHolderHandler(IPolicyHolderRepository policyHolderRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePolicyHolder>
{
    private readonly IPolicyHolderRepository _policyHolderRepository = policyHolderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(UpdatePolicyHolder request, CancellationToken cancellationToken)
    {
        var policyHolder = await _policyHolderRepository.OfIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Policy holder was not found for Id: {request.Id}");

        policyHolder.FirstName = request.FirstName;
        policyHolder.LastName = request.LastName;
        policyHolder.PersonalNumber = request.PersonalNumber;
        policyHolder.DateOfBirth = request.DateOfBirth;
        policyHolder.ContactNumber = request.ContactNumber;
        policyHolder.EmailAddress = request.EmailAddress;
        
        _policyHolderRepository.Update(policyHolder);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}