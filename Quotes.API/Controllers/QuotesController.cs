using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quotes.Application.Quotes.Commands.Create;
using Quotes.Application.Quotes.Commands.Delete;
using Quotes.Application.Quotes.Commands.Update;
using Quotes.Application.Quotes.Queries.GetList;
using Quotes.Application.Quotes.Queries.GetRandom;
using Quotes.Domain.Models;

namespace Quotes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuotesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public QuotesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _mediator.Send(new GetQuotesListQuery()));
		}

		[HttpGet("Random")]
		public async Task<IActionResult> Random()
		{
			var quote = await _mediator.Send(new GetRandomQuoteQuery());

			if (quote == null)
				return NotFound();

			return Ok(quote);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] QuoteItemModel quote)
		{
			return Ok(await _mediator.Send(new CreateQuoteCommand(quote.QuoteText, quote.Author)));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] QuoteItemModel quote)
		{
			return Ok(await _mediator.Send(new UpdateQuoteCommand(id, quote.QuoteText, quote.Author)));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await _mediator.Send(new DeleteQuoteCommand(id)));
		}
	}
}
