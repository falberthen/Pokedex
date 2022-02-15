namespace Pokedex.Api.Automapper;

public static class AutoMapperSetup
{
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services
            .AddAutoMapper(typeof(PokemonToPokemonDtoProfile));
    }
}