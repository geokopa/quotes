using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Domain.Models;
using Quotes.Infrastructure.DataContext;

namespace Quotes.Application.Quotes.Queries.GetRandom
{
	public class GetRandomQuoteQueryHandler : IRequestHandler<GetRandomQuoteQuery, QuoteItemModel>
	{
		private readonly QuotesDbContext _context;

		public GetRandomQuoteQueryHandler(QuotesDbContext context)
		{
			_context = context;
		}

		public async Task<QuoteItemModel> Handle(GetRandomQuoteQuery request, CancellationToken cancellationToken)
		{
			var count = await _context.Quotes.CountAsync();
			var randomId = new Random().Next(1, count+1);

			var quote = await _context.Quotes.Include(x=>x.Author).AsNoTracking().Where(q => q.Id == randomId).FirstOrDefaultAsync();

			if (quote != null)
			{
				return new QuoteItemModel { Author = quote.Author.Name, QuoteText = quote.Text };
			}

			return null;
		}
	}
}
