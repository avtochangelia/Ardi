using Ardi.Application.PolicyHolderManagement.Dto;
using Ardi.Domain.PolicyHolderManagement.Repositories;
using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Queries.GetPolicyHolder;

public class GetPolicyHolderHandler(IPolicyHolderRepository policyHolderRepository) : IRequestHandler<GetPolicyHolderRequest, GetPolicyHolderResponse>
{
    private readonly IPolicyHolderRepository _policyHolderRepository = policyHolderRepository;

    public async Task<GetPolicyHolderResponse> Handle(GetPolicyHolderRequest request, CancellationToken cancellationToken)
    {
        var policyHolder = await _policyHolderRepository.OfIdAsync(request.PolicyHolderId)
            ?? throw new KeyNotFoundException($"Policy holder was not found for Id: {request.PolicyHolderId}");

        return new GetPolicyHolderResponse
        {
            PolicyHolder = new PolicyHolderBaseDtoModel
            {
                Id = policyHolder.Id,
                FirstName = policyHolder.FirstName,
                LastName = policyHolder.LastName,
                PersonalNumber = policyHolder.PersonalNumber,
                DateOfBirth = policyHolder.DateOfBirth,
                ContactNumber = policyHolder.ContactNumber,
                EmailAddress = policyHolder.EmailAddress,
            },
        };
    }
}