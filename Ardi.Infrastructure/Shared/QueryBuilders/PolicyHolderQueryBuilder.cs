using Ardi.Domain.PolicyHolderManagement;
using Ardi.Domain.PolicyManagement;
using Ardi.Domain.ProductManagement;
using Ardi.Shared.Utilities;

namespace Ardi.Infrastructure.Shared.QueryBuilders;

internal static class PolicyHolderQueryBuilder
{
    internal static string BuildQueryForActivePolicies()
    {
        return $@"SELECT ph.*, p.*, pr.*
                  FROM {Pluralizer<PolicyHolder>.PluralizedTypeName} ph
                  LEFT JOIN {Pluralizer<Policy>.PluralizedTypeName} p ON ph.Id = p.PolicyholderId
                  LEFT JOIN {Pluralizer<Product>.PluralizedTypeName} pr ON p.ProductId = pr.Id";
    }
}