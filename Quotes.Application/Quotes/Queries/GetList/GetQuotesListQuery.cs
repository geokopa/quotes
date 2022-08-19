using MediatR;
using Quotes.Domain.Models;

namespace Quotes.Application.Quotes.Queries.GetList
{
	public class GetQuotesListQuery : IRequest<IEnumerable<QuotesListItemModel>>
	{
	}
}
