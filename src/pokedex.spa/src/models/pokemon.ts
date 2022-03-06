export default class PokemonDto {
	name!: string;
	avatar!: string;
	baseStats!: BaseStatsDto;
	catchRate!: number;
	evolvesFrom!: PokemonDto[];
	evolvesTo!: PokemonDto;
	genderRatio!: GenderRatioDto;
	isLegendary!: boolean;
	number!: number;
	physicalAttributes!:PhysicalAttributesDto;
	primaryType!: string;
	secondaryType!: string;
}

export class BaseStatsDto {
	hP!: number;
	attack!: number;
	defense!: number;
	specialAttack!: number;
}

export class GenderRatioDto {
	femaleRatio!: number;
	maleRatio!: number;
}

export class PhysicalAttributesDto {
	height!: number;
	weigth!: number;
}