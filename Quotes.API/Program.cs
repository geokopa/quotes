using MediatR;
using Microsoft.EntityFrameworkCore;
using Quotes.API.Init;
using Quotes.Application.Quotes.Commands.Create;
using Quotes.Infrastructure.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuotesDbContext>(options => options.UseSqlite("Data Source=quotes.db"));
builder.Services.AddMediatR(typeof(CreateQuoteCommand).Assembly);

var app = builder.Build();

// Initialize database file with predefined data
DatabaseInitializer.EnsureDatabaseFile(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

