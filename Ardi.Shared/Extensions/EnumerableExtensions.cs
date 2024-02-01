using Ardi.Shared.Interfaces;

namespace Ardi.Shared.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Pagination<T>(this IEnumerable<T> source, IPaginationRequest request)
    {
        if (request == null)
        {
            return source;
        }

        request.PageSize ??= 10;
        request.Page ??= 1;

        return source.Skip(request.PageSize.Value * (request.Page.Value - 1)).Take(request.PageSize.Value);
    }
}