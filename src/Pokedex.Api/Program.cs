global using Pokedex.Domain.Pokemon;
global using Microsoft.EntityFrameworkCore;
global using Pokedex.Api.Dtos;
using Pokedex.Api.GraphQL;
using Pokedex.Api.Automapper;
using Pokedex.Api.DomainServices;
using Pokedex.Infrastructure.Persistence.Context;
using Pokedex.Infrastructure.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokedexDbContext>(options =>
    options.UseSqlite(builder.Configuration
    .GetConnectionString("DefaultConnection")));

// Services
builder.Services.
    AddTransient<IEvolutionChecker, EvolutionChecker>();
builder.Services
    .AddScoped<IPokemon, PokemonRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

builder.Services.AddAutoMapperSetup();
builder.Services.AddInMemorySubscriptions();
builder.Services.AddCors();

// App
var app = builder.Build();

app.UseRouting();
app.UseWebSockets();
app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseHttpsRedirection();
app.Run();