using Ardi.Domain.PolicyHolderManagement;
using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.Shared;
using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Commands.CreatePolicyHolder;

public class CreatePolicyHolderHandler(IPolicyHolderRepository policyHolderRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePolicyHolder>
{
    private readonly IPolicyHolderRepository _policyHolderRepository = policyHolderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(CreatePolicyHolder request, CancellationToken cancellationToken)
    {
        var policyHolder = new PolicyHolder()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PersonalNumber = request.PersonalNumber,
            DateOfBirth = request.DateOfBirth,
            ContactNumber = request.ContactNumber,
            EmailAddress = request.EmailAddress,
        };

        await _policyHolderRepository.InsertAsync(policyHolder);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}