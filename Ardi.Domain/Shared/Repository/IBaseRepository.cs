using System.Linq.Expressions;

namespace Ardi.Domain.Shared.Repository;

public interface IBaseRepository<TAggregateRoot> where TAggregateRoot : class
{
    Task<TAggregateRoot?> OfIdAsync(Guid id);
    Task<IEnumerable<TAggregateRoot>> QueryAsync(string? query = null);
    Task InsertAsync(TAggregateRoot aggregateRoot);
    void Update(TAggregateRoot aggregateRoot);
    void Delete(TAggregateRoot aggregateRoot);
    Task<IEnumerable<TAggregateRoot>> QueryAsync<T, TFirst, TSecond>(string query, Func<TAggregateRoot, TFirst, TSecond, TAggregateRoot> map, string splitOn);
}