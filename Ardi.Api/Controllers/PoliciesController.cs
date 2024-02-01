using Ardi.Application.PolicyManagement.Commands.ChangePolicyStatus;
using Ardi.Application.PolicyManagement.Commands.CreatePolicy;
using Ardi.Application.PolicyManagement.Commands.DeletePolicy;
using Ardi.Application.PolicyManagement.Commands.UpdatePolicy;
using Ardi.Application.PolicyManagement.Queries.GetPolicies;
using Ardi.Application.PolicyManagement.Queries.GetPolicy;
using Ardi.Domain.PolicyManagement.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ardi.Api.Controllers
{
    [Route("api/[controller]")]
    public class PoliciesController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPoliciesResponse>> GetAllasync([FromQuery] int? page, int? pageSize, PolicyStatus? status)
        {
            var request = new GetPoliciesRequest
            {
                Page = page,
                PageSize = pageSize,
                Status = status
            };

            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPolicyResponse>> GetAsync([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetPolicyRequest { PolicyId = id }));
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePolicy command)
        {
            _ = await Mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePolicy command)
        {
            command.SetId(id);
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            _ = await Mediator.Send(new DeletePolicy(id));

            return Ok();
        }

        [HttpPatch("{id}/change-status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> ChangeStatusAsync([FromRoute] Guid id, [FromBody] ChangePolicyStatus command)
        {
            command.SetId(id);
            _ = await Mediator.Send(command);

            return Ok();
        }
    }
}