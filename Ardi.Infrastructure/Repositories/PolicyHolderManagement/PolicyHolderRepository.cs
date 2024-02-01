using Ardi.Domain.PolicyHolderManagement;
using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Infrastructure.DataAccess;

namespace Ardi.Infrastructure.Repositories.PolicyHolderManagement;

public class PolicyHolderRepository(EFDbContext efDbContext, DapperDbContext dapperContext) 
    : BaseRepository<PolicyHolder>(efDbContext, dapperContext), IPolicyHolderRepository
{
}