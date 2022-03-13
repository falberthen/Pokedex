using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Pokedex.Api.GraphQL;

public class Subscription
{
    [SubscribeAndResolve]
    public async ValueTask<ISourceStream<int>> OnListPokemon([Service]ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver
            .SubscribeAsync<string, int>("PokemonListReturned", cancellationToken);
    }

    [SubscribeAndResolve]
    public async ValueTask<ISourceStream<PokemonDto>> OnInsertPokemon([Service]ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver
            .SubscribeAsync<string, PokemonDto>("PokemonInserted", cancellationToken);
    }

    [SubscribeAndResolve]
    public async ValueTask<ISourceStream<PokemonDto>> OnUpdatePokemon([Service]ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver
            .SubscribeAsync<string, PokemonDto>("PokemonUpdated", cancellationToken);
    }
}