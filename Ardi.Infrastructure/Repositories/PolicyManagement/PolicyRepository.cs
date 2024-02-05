using Ardi.Domain.PolicyManagement;
using Ardi.Domain.PolicyManagement.Enums;
using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Infrastructure.DataAccess;
using Ardi.Infrastructure.Shared.QueryBuilders;

namespace Ardi.Infrastructure.Repositories.PolicyManagement;

public class PolicyRepository(EFDbContext efDbContext, DapperDbContext dapperContext) 
    : BaseRepository<Policy>(efDbContext, dapperContext), IPolicyRepository
{
    public async Task<IEnumerable<Policy>> GetAllByStatus(PolicyStatus? status)
    {
        var query = PolicyQueryBuilder.BuildQueryByStatus();

        if (status == null)
        {
            return await QueryAsync();
        }

        var result = await _dapperContext.QueryAsync<Policy>(query, new { Status = status });

        return result ?? Enumerable.Empty<Policy>();
    }
}