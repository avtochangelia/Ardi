using Ardi.Domain.Shared.Repository;
using Ardi.Infrastructure.DataAccess;
using Ardi.Infrastructure.Shared.QueryBuilders;
using Microsoft.EntityFrameworkCore;

namespace Ardi.Infrastructure.Repositories;

public class BaseRepository<TAggregateRoot>(EFDbContext efDbContext, DapperDbContext dapperContext) : IBaseRepository<TAggregateRoot>
    where TAggregateRoot : class
{
    protected readonly EFDbContext _efDbContext = efDbContext;
    protected readonly DapperDbContext _dapperContext = dapperContext;

    public virtual async Task InsertAsync(TAggregateRoot aggregateRoot)
    {
        await _efDbContext.Set<TAggregateRoot>().AddAsync(aggregateRoot);
    }

    public virtual void Update(TAggregateRoot aggregateRoot)
    {
        _efDbContext.Entry(aggregateRoot).State = EntityState.Modified;
    }

    public virtual void Delete(TAggregateRoot aggregateRoot)
    {
        _efDbContext.Set<TAggregateRoot>().Remove(aggregateRoot);
    }

    public async Task<TAggregateRoot?> OfIdAsync(Guid id)
    {
        var query = QueryBuilder<TAggregateRoot>.GetByIdQuery();
        return await _dapperContext.QueryFirstOrDefaultAsync<TAggregateRoot>(query, new { Id = id });
    }

    public async Task<IEnumerable<TAggregateRoot>> QueryAsync()
    {
        var query = QueryBuilder<TAggregateRoot>.GetAllQuery();
        var result = await _dapperContext.QueryAsync<TAggregateRoot>(query);
        return result ?? Enumerable.Empty<TAggregateRoot>();
    }
}