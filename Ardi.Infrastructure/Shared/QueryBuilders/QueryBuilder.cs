using Ardi.Shared.Utilities;

namespace Ardi.Infrastructure.Shared.QueryBuilders;

internal static class QueryBuilder<TAggregateRoot> where TAggregateRoot : class
{
    internal static string GetByIdQuery()
    {
        return $"SELECT * FROM {Pluralizer<TAggregateRoot>.PluralizedTypeName} WHERE Id = @Id";
    }

    internal static string GetAllQuery()
    {
        return $"SELECT * FROM {Pluralizer<TAggregateRoot>.PluralizedTypeName}";
    }
}