<template>
  <div class="avatar-display">
    <img :src="pokemon.avatar" class="avatar-container">
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import PokemonDto from '@/models/pokemon';

export default defineComponent({
  name: 'AvatarDisplay',
  props: {
    pokemon: PokemonDto
  }
})
</script>

<style scoped lang="scss">
.avatar-display {  
  position: absolute;
  top: 210px;
  left: 80px;
  width:35%;
  height: 32%;

  .avatar-container {
    width: 230px;
    height: 230px;
    margin-top: -5px;
    margin-left: 50px;
  }
}
</style>