using CQRSWithMediatR.Commands;
using CQRSWithMediatR.Models;
using CQRSWithMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatR.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);

        return Ok(productId);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }
}