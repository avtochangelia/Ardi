﻿using Ardi.Shared.Interfaces;

namespace Ardi.Application.Shared;

public abstract class PaginationRequest : IPaginationRequest
{
    public int? Page { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
}