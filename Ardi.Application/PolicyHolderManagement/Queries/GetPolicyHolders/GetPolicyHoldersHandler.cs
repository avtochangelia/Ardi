using Ardi.Application.PolicyHolderManagement.Dto;
using Ardi.Domain.PolicyHolderManagement;
using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.PolicyManagement;
using Ardi.Domain.ProductManagement;
using Ardi.Shared.Extensions;
using MediatR;

namespace Ardi.Application.PolicyHolderManagement.Queries.GetPolicyHolders;

public class GetPolicyHoldersHandler(IPolicyHolderRepository policyHolderRepository) : IRequestHandler<GetPolicyHoldersRequest, GetPolicyHoldersResponse>
{
    private readonly IPolicyHolderRepository _policyHolderRepository = policyHolderRepository;

    public async Task<GetPolicyHoldersResponse> Handle(GetPolicyHoldersRequest request, CancellationToken cancellationToken)
    {
        var policyHolders = await _policyHolderRepository.GetAllWithPoliciesAndProductsAsync();

        var total = policyHolders.Count();

        var paginatedPolicyHolders = policyHolders.Pagination(request);

        var response = new GetPolicyHoldersResponse
        {
            PolicyHolders = paginatedPolicyHolders.Select(x => PolicyHolderDtoModel.MapToDto(x)),
            Page = request.Page,
            PageSize = request.PageSize,
            Total = total,
        };

        return response;
    }
}