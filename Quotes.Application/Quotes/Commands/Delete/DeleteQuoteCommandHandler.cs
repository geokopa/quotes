using MediatR;
using Quotes.Infrastructure.DataContext;

namespace Quotes.Application.Quotes.Commands.Delete
{
	public class DeleteQuoteCommandHandler : IRequestHandler<DeleteQuoteCommand, Unit>
	{
		private readonly QuotesDbContext _context;

		public DeleteQuoteCommandHandler(QuotesDbContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
		{
			var quoteToDelete = await _context.Quotes.FindAsync(request.ID);

			if (quoteToDelete != null)
			{
				_context.Quotes.Remove(quoteToDelete);
				await _context.SaveChangesAsync();
			}
			return Unit.Value;
		}
	}
}
