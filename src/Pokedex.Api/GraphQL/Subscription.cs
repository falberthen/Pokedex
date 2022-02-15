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
    public async ValueTask<ISourceStream<Pokemon>> OnInsertPokemon([Service]ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver
            .SubscribeAsync<string, Pokemon>("PokemonInserted", cancellationToken);
    }

    [SubscribeAndResolve]
    public async ValueTask<ISourceStream<Pokemon>> OnUpdatePokemon([Service]ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver
            .SubscribeAsync<string, Pokemon>("PokemonUpdated", cancellationToken);
    }
}