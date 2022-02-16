using Xunit;
using FluentAssertions;
using Pokedex.Domain.SeedWork;
using Pokedex.Domain.Pokemon;

namespace Pokedex.Tests;

public class BaseStatsTests
{
    [Fact]
    public void BaseStats_cannot_have_negative_values()
    {
        var pokemonData = new PokemonData(1, "Missigno", "Ghost") { HP = -1 };
        var ex = Assert.Throws<DomainException>(() => BaseStats.From(pokemonData));
        ex.GetType().Should().Be(typeof(DomainException));
    }

    [Fact]
    public void Two_BaseStats_with_same_values_are_equal()
    {
        var pokemonData1 = new PokemonData(25, "Pikachu", "Electric") { HP = 100 };
        var pokemonData2 = new PokemonData(25, "Pikachu", "Electric") { HP = 100 };

        var baseStats1 = BaseStats.From(pokemonData1);
        var baseStats2 = BaseStats.From(pokemonData2);

        var areEqual = baseStats1 == baseStats2;

        areEqual.Should().BeTrue();
        baseStats1.Should().Be(baseStats2);
    }
}