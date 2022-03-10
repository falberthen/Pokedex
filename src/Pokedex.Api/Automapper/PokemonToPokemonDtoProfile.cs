using AutoMapper;

namespace Pokedex.Api.Automapper;

public class PokemonToPokemonDtoProfile : Profile
{
    public PokemonToPokemonDtoProfile()
    {
        CreateMap<Pokemon, PokemonDto>()
            .ForMember(t => t.Number,
                g => g.MapFrom(src => src.Number.Value))
            .ForMember(t => t.PrimaryType,
                g => g.MapFrom(src => src.PrimaryType.Name))
            .ForMember(t => t.SecondaryType,
                g => g.MapFrom(src => src.SecondaryType == null 
                    ? "None" : src.SecondaryType.Name));

        CreateMap<PhysicalAttributes, PhysicalAttributesDto>();
        CreateMap<GenderRatio, GenderRatioDto>();
        CreateMap<BaseStats, BaseStatsDto>();
    }
}