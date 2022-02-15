using AutoMapper;
using HotChocolate.Subscriptions;

namespace Pokedex.Api.GraphQL;

public class Query
{
    private readonly IMapper _mapper;

    public Query(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<PokemonDto>> ListPokemon(
        [Service]IPokemon pokemonRepository, [Service]ITopicEventSender eventSender)
    {
        var pokemonList = await pokemonRepository
            .ListPokemon();

        await eventSender
            .SendAsync("PokemonListReturned", pokemonList.Count());

        return pokemonList
            .Select(p => _mapper.Map<PokemonDto>(p));        
    }

    public async Task<PokemonDto> GetPokemonByNumber(int number, 
        [Service]IPokemon pokemonRepository)
    {
        var pokemon = await pokemonRepository
            .GetPokemonByNumber(PokemonNumber.From(number));

        return _mapper.Map<PokemonDto>(pokemon);
    }
}