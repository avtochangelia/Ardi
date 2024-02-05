using Ardi.Application.PolicyManagement.Dto;
using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Shared.Extensions;
using MediatR;

namespace Ardi.Application.PolicyManagement.Queries.GetPolicies;

public class GetPoliciesHandler(IPolicyRepository policyRepository) : IRequestHandler<GetPoliciesRequest, GetPoliciesResponse>
{
    private readonly IPolicyRepository _policyRepository = policyRepository;

    public async Task<GetPoliciesResponse> Handle(GetPoliciesRequest request, CancellationToken cancellationToken)
    {
        var policies = await _policyRepository.GetAllByStatus(request.Status);

        var total = policies.Count();

        var paginatedPolicies = policies.Pagination(request);

        var response = new GetPoliciesResponse
        {
            Policies = paginatedPolicies.Select(PolicyBaseDtoModel.MapToDto),
            Page = request.Page,
            PageSize = request.PageSize,
            Total = total,
        };

        return response;
    }
}