using Ardi.Domain.PolicyManagement;
using Ardi.Domain.PolicyManagement.Enums;
using Ardi.Shared.Utilities;

namespace Ardi.Application.Shared.QueryBuilders;

internal static class PolicyQueryBuilder
{
    internal static string BuildQueryByStatus(PolicyStatus? status)
    {
        var query = $"SELECT * FROM {Pluralizer<Policy>.PluralizedTypeName}";

        if (status != null)
        {
            query += $" WHERE Status = {(int)status.Value}";
        }

        return query;
    }
}