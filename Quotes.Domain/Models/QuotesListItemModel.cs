namespace Quotes.Domain.Models
{
	public class QuotesListItemModel
	{
		public QuotesListItemModel(int id, string quoteText, string author)
		{
			Id = id;
			QuoteText = quoteText;
			Author = author;
		}

		public int Id { get; set; }
		public string QuoteText { get; set; }
		public string Author { get; set; }
	}
}
