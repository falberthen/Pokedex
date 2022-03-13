<template>
  <div class="device-container">
    <div @click="goUp" class="joystick-button goUpButton" title="Evolutions" alt="Evolutions"/>
    <div @click="goLeft" class="joystick-button goLeftButton" title="Go back" alt="Go back"/>
    <div @click="goRight" class="joystick-button goRightButton" title="Go forward" alt="Go forward"/>
    <div @click="goDown" class="joystick-button goDownButton" title="Pre evolutions" alt="Pre evolutions"/>
    <AvatarDisplay 
      :avatar="pokemon?.avatar" 
      :name="pokemon?.name"/>

    <LegendaryDisplay 
      :isLegendary="pokemon?.isLegendary"/>

    <TypeDisplay 
      :primaryType="pokemon?.primaryType" 
      :secondaryType="pokemon?.secondaryType"/>
      
    <StatsDisplay :pokemon="pokemon" />

    <PhysicalAttributesDisplay 
      :weigth="pokemon?.physicalAttributes?.weigth" 
      :height="pokemon?.physicalAttributes?.height"/>

    <GenderRatioDisplay 
      :maleRatio="pokemon?.genderRatio.maleRatio" 
      :femaleRatio="pokemon?.genderRatio.femaleRatio"/>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import AvatarDisplay from './AvatarDisplay.vue';
import StatsDisplay from './StatsDisplay.vue';
import TypeDisplay from './TypeDisplay.vue';
import PhysicalAttributesDisplay from './AttributesDisplay.vue';
import GenderRatioDisplay from './GenderRatioDisplay.vue';
import LegendaryDisplay from './LegendaryDisplay.vue';
import PokemonDto from '@/models/PokemonDto';

export default defineComponent({
  name: 'MainDevice',
  emits: ['goUp','goLeft','goRight','goDown'],
  components: {
    AvatarDisplay,
    StatsDisplay,
    TypeDisplay,
    PhysicalAttributesDisplay,
    GenderRatioDisplay,
    LegendaryDisplay
  },
  props: {
    pokemon!: Object as () => PokemonDto
  },
  methods: {
    goUp() {
      if(this.pokemon?.evolvesTo?.number) {
        this.$emit('goUp',        
          this.pokemon.evolvesTo.number);
      }         
    },
    goLeft() {
      this.$emit('goLeft');
    },
    goRight() {
      this.$emit('goRight');
    },
    goDown() {
      if(this.pokemon && 
      this.pokemon?.evolvesFrom?.length > 0) {
        this.$emit('goDown',        
          this.pokemon?.evolvesFrom);
      }
    },
  },
})
</script>

<style scoped lang="scss">
.device-container {  
  width: 1020px;
  height: 741px;
  background-image: url("../assets/pokedex-template.png");
  background-repeat: no-repeat, repeat;
  margin: auto;
  position: relative;
  
  .joystick-button {
    position: absolute;
    width: 50px;
    height: 50px;
    cursor: pointer;
  }
  .goUpButton {
    bottom: 20%;
    left: 36%;
  }
  .goLeftButton {
    bottom: 15%;
    left: 32%;
  }
  .goRightButton {
    bottom: 15%;
    left: 40%; 
  }
  .goDownButton {
    bottom: 10%;
    left: 36%;
  }
}
</style>