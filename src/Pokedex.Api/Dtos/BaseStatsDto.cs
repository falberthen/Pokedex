namespace Pokedex.Api.Dtos;

public record class BaseStatsDto
{
    public int? HP { get; set; }
    public int? Attack { get; set; }
    public int? Defense { get; set; }
    public int? SpecialAttack { get; set; }
    public int? SpecialDefense { get; set; }
    public int? Speed { get; set; }
}