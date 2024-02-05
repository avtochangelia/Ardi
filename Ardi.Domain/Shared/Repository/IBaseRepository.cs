using System.Linq.Expressions;

namespace Ardi.Domain.Shared.Repository;

public interface IBaseRepository<TAggregateRoot> where TAggregateRoot : class
{
    Task<TAggregateRoot?> OfIdAsync(Guid id);
    Task<IEnumerable<TAggregateRoot>> QueryAsync();
    Task InsertAsync(TAggregateRoot aggregateRoot);
    void Update(TAggregateRoot aggregateRoot);
    void Delete(TAggregateRoot aggregateRoot);
}