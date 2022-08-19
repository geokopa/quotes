namespace Quotes.Domain.Entities
{
	public class Author
	{
		public Author()
		{
			Quotes = new HashSet<Quote>();
		}

		public int ID { get; set; }
		public string Name { get; set; }

		public ICollection<Quote> Quotes { get; set; }
	}
}
