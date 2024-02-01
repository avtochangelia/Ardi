#nullable disable

using Ardi.Shared.Interfaces;

namespace Ardi.Application.Shared;

public abstract class PaginationResponse : IPaginationResponse
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public int Total { get; set; }
}