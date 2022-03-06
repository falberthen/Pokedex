<template>
	<div class="stats-container">
		<span class="pokemon-name">Nº {{pokemon.number}} {{pokemon.name}}</span>
		<div class="stats-info">
			<div class="rTable">
				<div class="rTableRow">
				<div class="rTableHead"><span style="font-weight: bold;">HP</span></div>
				<div class="rTableHead"><span style="font-weight: bold;">Attk</span></div>
				<div class="rTableHead"><span style="font-weight: bold;">Def</span></div>
				</div>
				<div class="rTableRow">
				<div class="rTableCell">{{pokemon.baseStats.hP}}</div>
				<div class="rTableCell">{{pokemon.baseStats.attack}}</div>
				<div class="rTableCell">{{pokemon.baseStats.defense}}</div>
				</div>
			</div>
			<br>
			<div class="rTable">
				<div class="rTableRow">
				<div class="rTableHead"><span style="font-weight: bold;">Sp Attk</span></div>
				<div class="rTableHead"><span style="font-weight: bold;">Sp Def</span></div>
				<div class="rTableHead"><span style="font-weight: bold;">Speed</span></div>
				</div>
				<div class="rTableRow">
				<div class="rTableCell">{{pokemon.baseStats.specialAttack}}</div>
				<div class="rTableCell">{{pokemon.baseStats.specialDefense}}</div>
				<div class="rTableCell">{{pokemon.baseStats.speed}}</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import { defineComponent } from 'vue';
import PokemonDto from '@/models/pokemon';

export default defineComponent({
  name: 'StatsDisplay',
  props: {
    pokemon: PokemonDto
  }
})
</script>

<style scoped lang="scss">
.stats-container {
  position: absolute;
  top: 210px;
  right:37px;
  width:39%;
  height: 44%;

  .pokemon-name {
    top: 25px;
    font-weight: bold;
    color:black;
    font-size: 1.5em;
    position: relative;
  }
  .stats-info {
    top: 60px;
    left: 25px;
    color:black;
    font-size: 1.5em;
    position: relative;    
  }
}

.rTable {
  display: block;
  width: 100%;
}
.rTableHeading, .rTableBody, .rTableFoot, .rTableRow{
  clear: both;
}
.rTableHead, .rTableFoot{
  font-weight: bold;
}
.rTableCell, .rTableHead {
  float: left;
  text-align: left;
  height: 20px;
  overflow: hidden;
  padding: 3px 1.8%;
  width: 28%;
}
.rTable:after {
  visibility: hidden;
  display: block;
  font-size: 0;
  content: " ";
  clear: both;
  height: 0;
}
</style>