<template>
  <div class="legendary-container">
    <span class="is-legendary-display">{{legendary}}</span>
  </div>  
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'LegendaryDisplay',
  props: {
    isLegendary: Boolean
  },
  computed:{
    legendary(): string {
      return this.isLegendary 
        ? "Legendary" : "";
    }
  }
})
</script>

<style scoped lang="scss">
.legendary-container {  
  position: absolute;
  top: 26%;
  left: 28%;
  width:20%;
  height: 30px;

  .is-legendary-display {
    color:rgb(195, 186, 52);
    font-weight: bolder;
  }
}
</style>