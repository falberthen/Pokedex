global using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Pokemon;

namespace Pokedex.Infrastructure.Persistence.Context;

public sealed class PokedexDbContext : DbContext
{
    public DbSet<Pokemon> Pokemon { get; set; }

    public PokedexDbContext(DbContextOptions<PokedexDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokedexDbContext).Assembly);
    }
}