export default interface PokemonDto {
	name: string;
	avatar: string;
	baseStats: BaseStatsDto;
	catchRate: number;
	evolvesFrom: PokemonDto[];
	evolvesTo: PokemonDto;
	genderRatio: GenderRatioDto;
	isLegendary: boolean;
	number: number;
	physicalAttributes:PhysicalAttributesDto;
	primaryType: string;
	secondaryType: string;
}

export interface BaseStatsDto {
	hP: number;
	attack: number;
	defense: number;
	specialAttack: number;
}

export interface GenderRatioDto {
	femaleRatio: number;
	maleRatio: number;
}

export interface PhysicalAttributesDto {
	height: number;
	weigth: number;
}