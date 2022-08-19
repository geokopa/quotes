using MediatR;

namespace Quotes.Application.Quotes.Commands.Create
{
	public class CreateQuoteCommand : IRequest
	{
		public CreateQuoteCommand(string text, string author)
		{
			Text = text;
			Author = author;
		}

		public string Text { get; init; }
		public string Author { get; init; }
	}
}
