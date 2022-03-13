<template>
<div class="listener-container">
  <div>
    <div v-if="onInsertPokemonResult" class="subscription-message clickable">
      <span @click="setPokemonByNumber(onInsertPokemonResult.number)">
        A new Pokemon was discovered!
      </span>
    </div>
    <div v-if="onUpdatePokemonResult" class="subscription-message clickable">
      <span @click="setPokemonByNumber(onUpdatePokemonResult.number)">
        Pokemon Nº{{onUpdatePokemonResult.number}} was updated!
      </span>
    </div>
    <div v-if="onListPokemonResult" class="subscription-message">
      There are {{onListPokemonResult}} Pokemon discovered!
    </div>
  </div>
</div>
</template>

<script lang="ts">
import PokemonDto from '@/models/PokemonDto';
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'SubscriptionListener',
  emits: ['setPokemonByNumber'],
  props: {    
    onInsertPokemonResult!: Object as () => PokemonDto,
    onUpdatePokemonResult!: Object as () => PokemonDto,
    onListPokemonResult!: Number
  },
  methods: {
    setPokemonByNumber(pokemonNumber: number){
      this.$emit("setPokemonByNumber", pokemonNumber);
    }
  },
})
</script>

<style scoped lang="scss">
.listener-container {  
  position: relative;
  margin-top: 1%;

  .subscription-message {
    font-size: 1.5em;
    font-weight: bolder;
  }
  .clickable {
    cursor: pointer;
  }
}
</style>