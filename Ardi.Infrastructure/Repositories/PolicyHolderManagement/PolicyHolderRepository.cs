using Ardi.Domain.PolicyHolderManagement;
using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.PolicyManagement;
using Ardi.Domain.ProductManagement;
using Ardi.Infrastructure.DataAccess;
using Ardi.Infrastructure.Shared.QueryBuilders;

namespace Ardi.Infrastructure.Repositories.PolicyHolderManagement;

public class PolicyHolderRepository(EFDbContext efDbContext, DapperDbContext dapperContext) 
    : BaseRepository<PolicyHolder>(efDbContext, dapperContext), IPolicyHolderRepository
{
    public async Task<IEnumerable<PolicyHolder>> GetAllWithPoliciesAndProductsAsync()
    {
        var query = PolicyHolderQueryBuilder.BuildQueryForActivePolicies();

        var result = await _dapperContext.QueryAsync<PolicyHolder, Policy, Product>(
            query,
            (policyHolder, policy, product) =>
            {
                if (policy != null)
                {
                    policyHolder.Policies ??= new List<Policy>();
                    policyHolder.Policies.Add(policy);
                    policy.Product = product;
                }
                return policyHolder;
            },
            splitOn: "Id,Id");

        return result;
    }
}