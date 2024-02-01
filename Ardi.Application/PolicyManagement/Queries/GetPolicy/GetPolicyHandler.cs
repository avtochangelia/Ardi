using Ardi.Application.PolicyManagement.Dto;
using Ardi.Domain.PolicyManagement.Repositories;
using MediatR;

namespace Ardi.Application.PolicyManagement.Queries.GetPolicy;

public class GetPolicyHandler(IPolicyRepository policyRepository) : IRequestHandler<GetPolicyRequest, GetPolicyResponse>
{
    private readonly IPolicyRepository _policyRepository = policyRepository;

    public async Task<GetPolicyResponse> Handle(GetPolicyRequest request, CancellationToken cancellationToken)
    {
        var policy = await _policyRepository.OfIdAsync(request.PolicyId)
            ?? throw new KeyNotFoundException($"Policy was not found for Id: {request.PolicyId}");

        return new GetPolicyResponse
        {
            Policy = new PolicyBaseDtoModel
            {
                Id = policy.Id,
                IssueDate = policy.IssueDate,
                ExpiryDate = policy.ExpiryDate,
                Amount = policy.Amount,
                Status = policy.Status,
            },
        };
    }
}