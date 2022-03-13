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
    isLegendary!: Boolean
  },
  computed:{
    legendary(): string {
      return this.isLegendary 
        ? "Legendary!" : "";
    }
  }
})
</script>

<style scoped lang="scss">
.legendary-container {  
  position: absolute;
  top: 25%;
  left: 22%;
  width:20%;

  .is-legendary-display {
    color:green;
    font-weight: bolder;
  }
}
</style>