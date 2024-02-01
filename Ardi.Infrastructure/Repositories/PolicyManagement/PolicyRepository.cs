using Ardi.Domain.PolicyManagement;
using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Infrastructure.DataAccess;

namespace Ardi.Infrastructure.Repositories.PolicyManagement;

public class PolicyRepository(EFDbContext efDbContext, DapperDbContext dapperContext) 
    : BaseRepository<Policy>(efDbContext, dapperContext), IPolicyRepository
{
}