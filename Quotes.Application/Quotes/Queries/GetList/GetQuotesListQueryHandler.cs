using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Domain.Models;
using Quotes.Infrastructure.DataContext;

namespace Quotes.Application.Quotes.Queries.GetList
{
	public class GetQuotesListQueryHandler : IRequestHandler<GetQuotesListQuery, IEnumerable<QuotesListItemModel>>
	{
		private readonly QuotesDbContext _context;

		public GetQuotesListQueryHandler(QuotesDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<QuotesListItemModel>> Handle(GetQuotesListQuery request, CancellationToken cancellationToken)
		{
			return await _context.Quotes.AsNoTracking().Select(x => new QuotesListItemModel(x.Id, x.Text, x.Author.Name)).ToListAsync(cancellationToken: cancellationToken);
		}
	}
}
