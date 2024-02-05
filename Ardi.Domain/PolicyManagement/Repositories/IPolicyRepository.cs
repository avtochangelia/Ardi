using Ardi.Domain.PolicyManagement.Enums;
using Ardi.Domain.Shared.Repository;

namespace Ardi.Domain.PolicyManagement.Repositories;

public interface IPolicyRepository : IBaseRepository<Policy>
{
    Task<IEnumerable<Policy>> GetAllByStatus(PolicyStatus? status);
}