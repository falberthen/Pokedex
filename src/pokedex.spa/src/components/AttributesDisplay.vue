<template>
  <div class="attr-display-container">
    <div class="attr-display">
      <div class="attr-row" v-if="height">
        <label>Height</label>: 
        <span class="attr-value">{{height}} cm</span>
      </div>
      <div class="attr-row" v-if="weigth">
        <label>Weigth</label>: 
        <span class="attr-value">{{weigth}} kg</span>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'PhysicalAttributesDisplay',
  props: {
    height!: Number,
    weigth!: Number
  }
})
</script>

<style scoped lang="scss">
.attr-display-container {  
  position: absolute;
  top: 29%;
  left: 8%;
  width: 13%;
  height: 15%;
  text-align: left;

  .attr-display {
    width:100%;
    height: 10px;
    float: left;
    font-weight: bold;
  
    .attr-row {      
      float: left;
      margin:1px;
    }
    .attr-value {
      font-size: 0.9em;
      font-weight: bold;
    }
  }
}

label {
	color: #1c5252;
	display: inline-block;
  font-size: 0.9em;
	text-transform: uppercase;
	font-weight: bold;
}
</style>