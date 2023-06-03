using HandGame.Application.Boundaries.Choice;
using HandGame.Application.Interfaces.Choice.Queries;
using HandGame.Application.Interfaces.Player.Commands;
using HandGame.Application.Queries.Choice;
using HandGame.Application.UseCases.Player;
using HandGame.Persistance.Services.Choice;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IChoiceService, ChoiceService>();
builder.Services.AddScoped<IGetAllChoicesQuery, GetAllChoicesQuery>();
builder.Services.AddScoped<IGetRandomChoiceQuery, GetRandomChoiceQuery>();
builder.Services.AddScoped<IPlayerPlayCommand, PlayerPlayCommand>();
builder.Services.AddHttpClient();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
