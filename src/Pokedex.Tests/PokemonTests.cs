using Xunit;
using FluentAssertions;
using Pokedex.Domain.Pokemon;
using NSubstitute;
using Pokedex.Api.DomainServices;

namespace Pokedex.Tests;

public class PokemonTests
{
    [Fact]
    public void Entities_arent_equal_with_different_ids()
    {
        var pokemonNumber = PokemonNumber.From(25);

        var evolutionChecker = Substitute.For<IEvolutionChecker>();
        evolutionChecker.CanEvolveTo(pokemonNumber)
            .Returns(true);

        var pokemonData = new PokemonData(pokemonNumber.Value, "Pikachu", "Electric");
        var pokemon1 = Pokemon.CatalogNew(evolutionChecker, pokemonData);
        var pokemon2 = Pokemon.CatalogNew(evolutionChecker, pokemonData);

        (pokemon1.GetHashCode() == pokemon2.GetHashCode()).Should().BeFalse();
        pokemon1.Equals(pokemon2).Should().BeFalse();
    }

    [Fact]
    public async Task Pokemon_can_evolve()
    {
        var pikachuNumber = PokemonNumber.From(25);
        var raichuNumber = PokemonNumber.From(26);

        var raichu = await Pokemon.CatalogNew(Substitute.For<IEvolutionChecker>(),
            new PokemonData(raichuNumber.Value, "Raichu", "Electric"));

        var repositorySubstitute = Substitute.For<IPokemon>();
        repositorySubstitute.GetPokemonByNumber(raichuNumber)
                .Returns(raichu);

        var evolutionChecker = new EvolutionChecker(repositorySubstitute);

        var pikachu = await Pokemon.CatalogNew(evolutionChecker,
            new PokemonData(pikachuNumber.Value, "Pikachu", "Electric")
            { EvolvesToNumber = raichu.Number.Value });

        Assert.NotNull(pikachu);

        pikachu.EvolvesToNumber.Should().Be(raichuNumber);
    }
}