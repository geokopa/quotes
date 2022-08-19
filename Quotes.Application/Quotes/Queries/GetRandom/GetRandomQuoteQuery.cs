using MediatR;
using Quotes.Domain.Models;

namespace Quotes.Application.Quotes.Queries.GetRandom
{
	public class GetRandomQuoteQuery : IRequest<QuoteItemModel>
	{
	}
}
