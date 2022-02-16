using Xunit;
using FluentAssertions;
using Pokedex.Domain.SeedWork;
using Pokedex.Domain.Pokemon;

namespace Pokedex.Tests;

public class PokemonNumberTests
{
    [Fact]
    public void Pokemon_number_cannot_be_zero()
    {
        var ex = Assert.Throws<DomainException>(() => PokemonNumber.From(0));
        ex.GetType().Should().Be(typeof(DomainException));
    }

    [Fact]
    public void Pokemon_number_cannot_be_negative()
    {
        var ex = Assert.Throws<DomainException>(() => PokemonNumber.From(-1));
        ex.GetType().Should().Be(typeof(DomainException));
    }

    [Fact]
    public void Two_numbers_with_same_value_are_equal()
    {
        var pokemonNumber1 = PokemonNumber.From(10);
        var pokemonNumber12 = PokemonNumber.From(10);

        var areEqual = pokemonNumber1 == pokemonNumber12;

        areEqual.Should().BeTrue();
        pokemonNumber1.Should().Be(pokemonNumber12);
    }
}