namespace Pokedex.Domain.Pokemon;

public sealed class PokemonNumber : StronglyTypedId<PokemonNumber>
{
    public static PokemonNumber From(int value)
    {
        return new PokemonNumber(value);
    }

    private PokemonNumber(int value) : base(value) {}
}