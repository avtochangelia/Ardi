using Ardi.Application.PolicyHolderManagement.Commands.CreatePolicyHolder;
using Ardi.Application.PolicyHolderManagement.Commands.DeletePolicyHolder;
using Ardi.Application.PolicyHolderManagement.Commands.UpdatePolicyHolder;
using Ardi.Application.PolicyHolderManagement.Queries.GetPolicyHolder;
using Ardi.Application.PolicyHolderManagement.Queries.GetPolicyHolders;
using Microsoft.AspNetCore.Mvc;

namespace Ardi.Api.Controllers;

[Route("api/[controller]")]
public class PolicyHoldersController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetPolicyHoldersResponse>> GetAllasync([FromQuery] int? page, int? pageSize)
    {
        var request = new GetPolicyHoldersRequest
        {
            Page = page,
            PageSize = pageSize,
        };

        return Ok(await Mediator.Send(request));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetPolicyHolderResponse>> GetAsync([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetPolicyHolderRequest { PolicyHolderId = id }));
    }

    [HttpPost]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePolicyHolder command)
    {
        _ = await Mediator.Send(command);

        return StatusCode(201);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePolicyHolder command)
    {
        command.SetId(id);
        await Mediator.Send(command);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        _ = await Mediator.Send(new DeletePolicyHolder(id));

        return Ok();
    }
}