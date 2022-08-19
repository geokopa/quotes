using MediatR;

namespace Quotes.Application.Quotes.Commands.Update
{
	public class UpdateQuoteCommand : IRequest
	{
		public UpdateQuoteCommand(int id, string text, string author)
		{
			ID = id;
			Text = text;
			Author = author;
		}

		public int ID { get; init; }
		public string Text { get; init; }
		public string Author { get; init; }
	}
}
