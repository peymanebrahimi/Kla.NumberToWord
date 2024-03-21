using Kla.NumberToWord.Application;
using Kla.NumberToWord.Application.Features;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Kla.NumberToWord.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConvertToWordController: ControllerBase
{
    private readonly IMediator _mediator;

    public ConvertToWordController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{input}")]
    public async Task<IActionResult> Get(string input)
    {
        var result =await _mediator.Send(new ConvertNumberToWordQuery(input));

        return Ok(result);
    }
}