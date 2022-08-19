using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.Infrastructure.DataContext;

namespace Quotes.Application.Quotes.Commands.Update
{
	public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommand, Unit>
	{
		private readonly QuotesDbContext _context;

		public UpdateQuoteCommandHandler(QuotesDbContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateQuoteCommand request, CancellationToken cancellationToken)
		{
			var quoteToUpdate = await _context.Quotes.Include(x=>x.Author).Where(x => x.Id == request.ID).AsNoTracking().FirstOrDefaultAsync();

			if (quoteToUpdate != null)
			{
				quoteToUpdate.Text = request.Text;
				quoteToUpdate.Author.Name = request.Author;

				_context.Quotes.Update(quoteToUpdate);
				await _context.SaveChangesAsync();
			}

			return Unit.Value;
		}
	}
}
