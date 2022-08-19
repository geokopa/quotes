namespace Quotes.Domain.Entities
{
	public class Quote
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public Author Author { get; set; }
		public int AuthorId { get; set; }
	}
}
