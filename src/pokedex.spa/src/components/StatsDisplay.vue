<template>
	<div class="stats-container" v-if="pokemon">
    <span class="pokemon-name">Nº{{pokemon.number}} - {{pokemon.name}}</span>
		<div class="stats-info">
			<div class="rTable">
				<div class="rTableRow">
          <div class="rTableHead"><span class="column-title">HP</span></div>
          <div class="rTableHead"><span class="column-title">Attack</span></div>
          <div class="rTableHead"><span class="column-title">Defense</span></div>
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
          <div class="rTableHead"><span class="column-title">Sp. Atk</span></div>
          <div class="rTableHead"><span class="column-title">Sp. Def</span></div>
          <div class="rTableHead"><span class="column-title">Speed</span></div>
				</div>
				<div class="rTableRow">
          <div class="rTableCell">{{pokemon.baseStats.specialAttack}}</div>
          <div class="rTableCell">{{pokemon.baseStats.specialDefense}}</div>
          <div class="rTableCell">{{pokemon.baseStats.speed}}</div>
				</div>
			</div>
      <br>
      <div class="rTable">
				<div class="rTableRow">
          <div class="rTableHead"><span class="column-title">Total</span></div>
				</div>
				<div class="rTableRow">
          <div class="rTableCell">{{total}}</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import PokemonDto from '@/models/PokemonDto';

export default defineComponent({
  name: 'StatsDisplay',
  props: {
    pokemon!: Object as () => PokemonDto
  },
  computed: {
    total(): number {
      let total = 0;
      const stats = this.pokemon?.baseStats;
      if(stats){
        Object.entries(stats).forEach(([key, value]) => {
          if(key !== "__typename") {
            total += value;
          }
        });                          
      }
      return total;
    }
  }
})
</script>

<style scoped lang="scss">
.stats-container {
  position: absolute;
  top: 28%;
  right:37px;
  width:39%;
  height: 44%;

  .pokemon-name {
    top: 20px;
    font-weight: bold;
    color:black;
    font-size: 1.5em;
    position: relative;
  }
  .stats-info {
    top: 35px;
    padding-left: 15px;
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
  font-size: 0.8em;
}
.rTable:after {
  visibility: hidden;
  display: block;
  content: " ";
  clear: both;
  height: 0;
}
.column-title {
  font-weight: bold;
}
</style>