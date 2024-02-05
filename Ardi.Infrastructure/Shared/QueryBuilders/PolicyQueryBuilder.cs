using Ardi.Domain.PolicyManagement.Enums;
using Ardi.Domain.PolicyManagement;
using Ardi.Shared.Utilities;

namespace Ardi.Infrastructure.Shared.QueryBuilders;

internal static class PolicyQueryBuilder
{
    internal static string BuildQueryByStatus()
    {
        return $"SELECT * FROM {Pluralizer<Policy>.PluralizedTypeName} WHERE Status = @Status";
    }
}