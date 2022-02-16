using Xunit;
using FluentAssertions;
using Pokedex.Domain.SeedWork;
using Pokedex.Domain.Pokemon;

namespace Pokedex.Tests;

public class PokemonTypeTests
{
    [Fact]
    public void PokemonType_cannot_be_null_or_empty()
    {
        string? nullType = null;
        var ex = Assert.Throws<DomainException>(() => PokemonType.From(nullType));
        ex.GetType().Should().Be(typeof(DomainException));

        ex = Assert.Throws<DomainException>(() => PokemonType.From(String.Empty));
        ex.GetType().Should().Be(typeof(DomainException));
    }

    [Fact]
    public void PokemonType_is_supported()
    {
        string typeName = "Grass";
        var pokemonType = PokemonType.From(typeName);

        pokemonType.Should().NotBeNull();
    }

    [Fact]
    public void PokemonType_is_not_supported()
    {
        string pokemonType = "None";
        var ex = Assert.Throws<DomainException>(() => PokemonType.From(pokemonType));
        ex.GetType().Should().Be(typeof(DomainException));
    }

    [Fact]
    public void Two_BaseStats_with_same_values_are_equal()
    {
        string typeName = "Grass";
        var pokemonType1 = PokemonType.From(typeName);
        var pokemonType2 = PokemonType.From(typeName);

        var areEqual = pokemonType1 == pokemonType2;

        areEqual.Should().BeTrue();
        pokemonType1.Should().Be(pokemonType2);
    }
}