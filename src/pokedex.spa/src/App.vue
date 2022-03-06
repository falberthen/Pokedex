<template>
  <div class="header-logo"><img src="./assets/pokedex-logo.png" /></div>
  <div v-for="queryResult in result" :key="queryResult.number">    
    <MainDevice :pokemon="queryResult" @goUp="goUp" @goLeft="goLeft" @goRight="goRight" @goDown="goDown"/> 
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import { useQuery } from '@vue/apollo-composable'
import { pokemonByNumber } from './graphql/queries';
import PokemonDto from '@/models/pokemon';
import MainDevice from './components/MainDevice.vue';

const variables = reactive({
  number: 1,
})

export default defineComponent({
  name: 'App',
  components: {
    MainDevice
  },
  methods: {
    goUp(evolutionNumber: number) {
      variables.number = evolutionNumber;
    },
    goLeft() {
      variables.number > 1 
        ? variables.number-- : 1;
    },
    goRight() {
      variables.number++;
    },
    goDown(preEvolutions: PokemonDto[]) {  
      variables.number = preEvolutions[0].number;
    },
  },
  setup() {
    const { result, loading, error } = 
      useQuery(pokemonByNumber, variables);   
      return {
        result,
        loading, 
        error
      }
  }
});
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.header-logo {
  margin:30px;
}
</style>