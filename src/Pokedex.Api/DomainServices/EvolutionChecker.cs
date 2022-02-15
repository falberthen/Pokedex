using Pokedex.Domain.SeedWork;

namespace Pokedex.Api.DomainServices
{
    public class EvolutionChecker : IEvolutionChecker
    {
        private readonly IPokemon _repository;

        public EvolutionChecker(IPokemon repository)
        {
            _repository = repository;
        }

        public async Task<bool> CanEvolveTo(PokemonNumber number)
        {
            var result = await _repository
                .GetPokemonByNumber(number);

            if (result.EvolvesFrom is not null && 
                result.EvolvesFrom.Count > 0)
                throw new DomainException($"{result} already has a pre-evolution.");

            return true;
        }
    }
}