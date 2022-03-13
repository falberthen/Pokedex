<template>
<div class="searchbox-container">
  <input type="text" 
    v-model="pokemonNumber" 
    @keyup.enter="setPokemonByNumber"
    class="search-box"/>
    <span class="search-icon" @click="setPokemonByNumber" title="Search">
      🔎
    </span>
</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'SearchBox',
  emits: ['setPokemonByNumber'],
  props: {
    currentPokemonNumber: Number
  },
  methods: {
    setPokemonByNumber(){
      this.$emit("setPokemonByNumber", Number(this.pokemonNumber));
    }
  },
  data() {
    return {
      pokemonNumber: this.currentPokemonNumber
    }
  },
  watch: { 
    currentPokemonNumber: function(newVal) { 
      this.pokemonNumber = newVal;
    }
  }
})
</script>

<style scoped lang="scss">
.searchbox-container {
  position: relative;
  margin-left:1%;  
  margin-bottom: 1%;
  z-index: 999999;
  
  .search-box {
    font-size: 30px;
    width:80px;
    height:45px;
  }
  .search-icon {
    font-size: 30px;
    cursor: pointer;    
  }
}
</style>