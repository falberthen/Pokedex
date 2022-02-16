global using Pokedex.Domain.SeedWork;

namespace Pokedex.Domain.Pokemon;

public class Pokemon : Entity<PokemonNumber>, IAggregateRoot
{
    public string Name { get; private set; }
    public decimal? CatchRate { get; private set; }
    public bool IsLegendary { get; private set; }
    public string? Avatar { get; private set; }
    public PhysicalAttributes? PhysicalAttributes { get; private set; }
    public GenderRatio? GenderRatio { get; private set; }
    public PokemonType PrimaryType { get; private set; }
    public PokemonType? SecondaryType { get; private set; }
    public BaseStats BaseStats { get; private set; }
    public PokemonNumber? EvolvesToNumber { get; private set; }

    public virtual Pokemon? EvolvesTo { get; }
    public virtual IReadOnlyCollection<Pokemon>? EvolvesFrom { get; }

    private static bool _canEvolve { get; set; }

    public static async Task<Pokemon> CatalogNew(IEvolutionChecker checker, PokemonData data)
    {
        // Checks if you're assigning evolution to a cataloged Pokémon
        if (data.EvolvesToNumber != null)
            _canEvolve = await checker.CanEvolveTo(PokemonNumber.From(data.EvolvesToNumber.Value));

        return new Pokemon(data);
    }

    public void Change(PokemonData data)
    {
        SetPokemonData(data);
    }

    private void SetPokemonData(PokemonData data)
    {
        ValidatePokemonData(data);

        Name = data.Name;
        CatchRate = data.CatchRate;
        IsLegendary = data.IsLegendary;
        Avatar = data.Avatar;

        PhysicalAttributes = PhysicalAttributes
            .From(data.Height, data.Weigth);
        GenderRatio = GenderRatio
            .From(data.MaleRatio, data.FemaleRatio);
        PrimaryType = PokemonType
            .From(data.PrimaryType);
        BaseStats = BaseStats.From(data);

        if (data.SecondaryType is not null)
            SecondaryType = PokemonType.From(data.SecondaryType);        
    }

    private static void ValidatePokemonData(PokemonData data)
    {
        if (data == null)
            throw new DomainRuleException(nameof(data));

        if (data.Number <= 0)
            throw new DomainRuleException("Pokemon's number must be valid.");

        if (string.IsNullOrWhiteSpace(data.Name))
            throw new DomainRuleException("Pokemon's name cannot be null or whitespace.");
    }

    private Pokemon(PokemonData data)
    {
        Number = PokemonNumber.From(data.Number);
        SetPokemonData(data);

        if (_canEvolve)
            EvolvesToNumber = PokemonNumber.From(data.EvolvesToNumber.Value);
    }

    private Pokemon() {}
}