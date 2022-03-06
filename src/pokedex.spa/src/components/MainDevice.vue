<template>
  <div class="device-container">
    <div @click="goUp" class="joystick-button goUpButton"/>
    <div @click="goLeft" class="joystick-button goLeftButton"/>
    <div @click="goRight" class="joystick-button goRightButton"/>
    <div @click="goDown" class="joystick-button goDownButton"/>
    <AvatarDisplay :pokemon="pokemon"/>
    <StatsDisplay :pokemon="pokemon" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import PokemonDto from '@/models/pokemon';
import AvatarDisplay from './AvatarDisplay.vue';
import StatsDisplay from './StatsDisplay.vue';

export default defineComponent({
  name: 'MainDevice',
  emits: ['goUp','goLeft','goRight','goDown'],
  components: {
    AvatarDisplay,
    StatsDisplay
  },
  props: {
    pokemon: PokemonDto
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
      if(this.pokemon && this.pokemon?.evolvesFrom?.length > 0) {
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
    width:50px;
    height: 50px;
    cursor: pointer;
  }
  .goUpButton {
    top: 530px;
    left: 365px;
  }
  .goLeftButton {
    top: 580px;
    left: 325px;
  }
  .goRightButton {
    top: 570px;
    left: 405px;
  }
  .goDownButton {
    top: 615px;
    left: 370px;
  }
}
</style>