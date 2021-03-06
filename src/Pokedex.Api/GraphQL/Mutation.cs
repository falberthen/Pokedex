using AutoMapper;
using HotChocolate.Subscriptions;

namespace Pokedex.Api.GraphQL;

public class Mutation
{
    private readonly IMapper _mapper;

    public Mutation(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<PokemonDto> InsertPokemon(PokemonData input, [Service] IEvolutionChecker checker,
        [Service]IPokemon pokemonRepository, [Service]ITopicEventSender eventSender)
    {
        var pokemon = await Pokemon.CatalogNew(checker, input);

        await pokemonRepository
            .InsertPokemon(pokemon);

        var dto = _mapper.Map<PokemonDto>(pokemon);

        await eventSender
            .SendAsync("PokemonInserted", dto);

        return dto;
    }

    public async Task<PokemonDto> UpdatePokemon(PokemonData input, [Service] IEvolutionChecker checker,
        [Service]IPokemon pokemonRepository, [Service]ITopicEventSender eventSender)
    {
        var pokemon = await pokemonRepository
            .GetPokemonByNumber(PokemonNumber.From(input.Number));

        pokemon.Change(input);

        await pokemonRepository
            .UpdatePokemon(pokemon);

        var dto = _mapper.Map<PokemonDto>(pokemon);

        await eventSender
            .SendAsync("PokemonUpdated", dto);

        return dto;
    }
}