#nullable disable

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ardi.Api.Controllers;

[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}