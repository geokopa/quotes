using Microsoft.EntityFrameworkCore;
using Quotes.Domain.Entities;

namespace Quotes.Infrastructure.DataContext
{
	public class QuotesDbContext : DbContext
	{
		public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
		{
		}

		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Author>().ToTable("Authors");
			modelBuilder.Entity<Author>(entity =>
			{
				entity.HasKey(e => e.ID);
				entity.HasIndex(e => e.Name).IsUnique();
				entity.Property(e => e.Name).IsRequired().HasMaxLength(500);
				entity.HasMany(x => x.Quotes);
			});

			modelBuilder.Entity<Quote>().ToTable("Quotes");
			modelBuilder.Entity<Quote>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.HasIndex(e => e.Text).IsUnique();
				entity.Property(e => e.Text).IsRequired();
				entity.HasOne(e => e.Author);
			});


			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
