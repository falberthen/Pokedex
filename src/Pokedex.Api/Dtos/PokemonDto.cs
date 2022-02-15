namespace Pokedex.Api.Dtos;

public record class PokemonDto
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string PrimaryType { get; set; }
    public string? SecondaryType { get; set; }
    public float CatchRate { get; set; }
    public bool IsLegendary { get; set; }
    public string? Avatar { get; set; }
    public PhysicalAttributesDto PhysicalAttributes { get; set; }
    public GenderRatioDto GenderRatio { get; set; }  
    public BaseStatsDto? BaseStats { get; set; }
    public PokemonDto? EvolvesTo { get; set; }
    public IEnumerable<PokemonDto>? EvolvesFrom { get; set; }

}
