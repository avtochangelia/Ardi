using Ardi.Application.ProductManagement.Commands.CreateProduct;
using Ardi.Application.ProductManagement.Commands.DeleteProduct;
using Ardi.Application.ProductManagement.Commands.UpdateProduct;
using Ardi.Application.ProductManagement.Queries.GetProduct;
using Ardi.Application.ProductManagement.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Ardi.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProductsResponse>> GetAllasync([FromQuery] int? page, int? pageSize)
        {
            var request = new GetProductsRequest
            {
                Page = page,
                PageSize = pageSize,
            };

            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProductResponse>> GetAsync([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetProductRequest { ProductId = id }));
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProduct command)
        {
            _ = await Mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProduct command)
        {
            command.SetId(id);
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            _ = await Mediator.Send(new DeleteProduct(id));

            return Ok();
        }
    }
}