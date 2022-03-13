<template>
  <div class="header-logo"><img src="./assets/pokedex-logo.png" /></div>  
  <SearchBox 
    :currentPokemonNumber="currentPokemonNumber"
    @setPokemonByNumber="setPokemonByNumber"/>

  <MainDevice 
    :pokemon="pokemonByNumberResult" 
    @goUp="goUp" 
    @goLeft="goLeft" 
    @goRight="goRight" 
    @goDown="goDown"/>
  
  <SubscriptionListener    
    :onInsertPokemonResult="onInsertPokemonResult" 
    :onUpdatePokemonResult="onUpdatePokemonResult" 
    :onListPokemonResult="onListPokemonResult" 
    @setPokemonByNumber="setPokemonByNumber"/>  
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import { useQuery, useResult, useSubscription } from '@vue/apollo-composable'
import { pokemonByNumber } from './graphql/queries';
import { onInsertPokemon, onUpdatePokemon, onListPokemon } from './graphql/subscriptions';
import PokemonDto from '@/models/PokemonDto';
import MainDevice from './components/MainDevice.vue';
import SubscriptionListener from './components/SubscriptionListener.vue';
import SearchBox from './components/SearchBox.vue';

const variables = reactive({
  number: 1,
})

export default defineComponent({
  name: 'App',
  components: {
    MainDevice,
    SubscriptionListener,
    SearchBox
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
    setPokemonByNumber(pokemonNumber: number) {      
      variables.number = pokemonNumber;
    }
  },
  computed: {
    currentPokemonNumber(): number {
      return variables.number;
    }
  },
  watch: {
    error: function (errorValue: unknown) {
      console.log(errorValue);
      variables.number = 1;
    },
  },
  setup() {
    const { result, loading, error } = 
      useQuery(pokemonByNumber, variables);

    //Subscriptions
    const useOnInsertPokemon = 
      useSubscription(onInsertPokemon);
    const useOnUpdatePokemon = 
      useSubscription(onUpdatePokemon);
    const useOnListPokemon = 
      useSubscription(onListPokemon);

    const pokemonByNumberResult = useResult(result, null, (data) => {
      return data.pokemonByNumber;
    });

    const onListPokemonResult = useResult(useOnListPokemon.result, null, (data) => {
      return data.onListPokemon;
    });

    const onInsertPokemonResult = useResult(useOnInsertPokemon.result, null, (data) => {
      return data.onInsertPokemon;
    });

    const onUpdatePokemonResult = useResult(useOnUpdatePokemon.result, null, (data) => {      
      return data.onUpdatePokemon;
    });

    return {      
      loading, 
      error,
      pokemonByNumberResult,
      onListPokemonResult,
      onInsertPokemonResult,
      onUpdatePokemonResult
    }
  }
});
</script>

<style lang="scss">
#app {
  font-family: 'Lucida Sans Unicode';
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