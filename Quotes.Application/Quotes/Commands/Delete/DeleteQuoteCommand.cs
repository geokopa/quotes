using MediatR;

namespace Quotes.Application.Quotes.Commands.Delete
{
	public class DeleteQuoteCommand : IRequest
	{
		public DeleteQuoteCommand(int id)
		{
			ID = id;
		}

		public int ID { get; init; }
	}
}
