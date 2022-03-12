<template>
  <div class="type-display">
    <div v-if="primaryType && secondaryType">
      <div class="type-container" :style="{ 'background-color': getTypeColor(primaryType)}">
        {{primaryType}}
      </div>
      <div v-if="secondaryType != 'None'" 
        class="type-container" :style="{ 'background-color': getTypeColor(secondaryType)}">
        {{secondaryType}}
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { PokemonTypes } from '@/models/PokemonTypes';
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'TypeDisplay',
  props: {
    primaryType!: String,
    secondaryType!: String
  },
  methods: {
    getTypeColor(type:string) {
      let color : PokemonTypes = (<never>PokemonTypes)[type];
      return color;
    }
  }
})
</script>

<style scoped lang="scss">
.type-display {
  position: absolute;
  top: 61%;
  left: 225px;
  width:20%;
  height: 45px;

  .type-container {
    width:48%;
    height: 35px;
    float: left;
    line-height: 35px;
    border-radius: 15px;
    margin:2px;
    color:white;
    font-weight: bold;
    font-size:0.9em;
  }
}
</style>