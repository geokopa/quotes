using Quotes.Domain.Entities;
using Quotes.Infrastructure.DataContext;

namespace Quotes.API.Init
{
	public static class DatabaseInitializer
	{
		private const string DB_NAME = "QuotesDatabase.db";

		public static void EnsureDatabaseFile(WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<QuotesDbContext>();

					if (File.Exists(DB_NAME))
					{
						File.Delete(DB_NAME);
					}

					using (context)
					{
						context.Database.EnsureCreated();
						Initialize(context);
					}
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred creating the DB.");
				}
			}
		}

		private static void Initialize(QuotesDbContext context)
		{
			context.Authors.Add(new Author { Name = "Anonymous" });

			context.Quotes.Add(new Quote
			{
				Text = "If you want to take the fucking island, you gotta burn your fucking boats and you will take the island.",
				Author = new Author
				{
					Name = "Tony Robbins"
				}
			});

			context.SaveChanges();
		}
	}
}
