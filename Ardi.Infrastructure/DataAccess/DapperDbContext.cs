using Dapper;
using System.Data;

namespace Ardi.Infrastructure.DataAccess;

public class DapperDbContext : IDisposable
{
    private readonly IDbConnection _connection;

    public DapperDbContext(IDbConnection connection)
    {
        _connection = connection;
        _connection.Open();
    }

    public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null)
    {
        return await _connection.QueryFirstOrDefaultAsync<T>(sql, param);
    }

    public async Task<IEnumerable<T>?> QueryAsync<T>(string sql, object? param = null)
    {
        return await _connection.QueryAsync<T>(sql, param);
    }

    public async Task<IEnumerable<T>> QueryAsync<T, TFirst, TSecond>(
        string sql,
        Func<T, TFirst, TSecond, T> map,
        string splitOn)
    {
        return await _connection.QueryAsync(sql, map, splitOn: splitOn);
    }

    public void Dispose()
    {
        _connection.Close();
        _connection.Dispose();
        GC.SuppressFinalize(this);
    }
}