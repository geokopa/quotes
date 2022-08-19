using MediatR;
using Quotes.Infrastructure.DataContext;

namespace Quotes.Application.Quotes.Commands.Create
{
	public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, Unit>
	{
		private readonly QuotesDbContext _context;

		public CreateQuoteCommandHandler(QuotesDbContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
		{
			var author = _context.Authors.FirstOrDefault(x => x.Name.ToLower() == request.Author.ToLower());

			await _context.Quotes.AddAsync(new Domain.Entities.Quote { Text = request.Text, Author = author ?? new Domain.Entities.Author { Name = request.Author } }, cancellationToken);
			await _context.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
