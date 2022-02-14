namespace Pokedex.Domain.Pokemon
{
    public interface IEvolutionChecker
    {
        Task<bool> CanEvolveTo(PokemonNumber number);
    }
}