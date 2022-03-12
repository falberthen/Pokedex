<template>
  <div class="gender-ratio-display-container">
    <div class="ratio-bar-display">
      <div class="male-ratio" 
        :style="{'width': getWidth(maleRatio)}" 
        :class="roundedMaleClass" 
        v-if="maleRatio > 0" 
        :title="maleRatioDescription">
        &#9794;
      </div>
      <div class="female-ratio" 
        :style="{'width': getWidth(femaleRatio)}" 
        :class="roundedFemaleClass" 
        v-if="femaleRatio > 0" 
        :title="femaleRatioDescription">
        &#9792;
      </div>      
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'GenderRatioDisplay',
  props: {
    maleRatio: Number,
    femaleRatio: Number
  },
  computed: {
    maleRatioDescription(): string {
      return this.maleRatio + "% Male"
    },
    femaleRatioDescription(): string {
      return this.femaleRatio + "% Female"
    },
    roundedMaleClass() {
      let ratioClass = 'male-ratio '
      return ratioClass += 
        this.maleRatio && this.maleRatio > 0 && this.femaleRatio == 0 
        ? this.allRundedClass : "left-radius-only";
    },
    roundedFemaleClass() {
      let ratioClass = 'female-ratio '
      return ratioClass += 
        this.femaleRatio && this.femaleRatio > 0 && this.maleRatio == 0 
        ? this.allRundedClass : "right-radius-only";
    }
  },
  data() {
    return {
      allRundedClass: 'left-radius-only right-radius-only'
    }
  },
  methods:{
    getWidth(ratio: number) : string {
      return ratio + '%';
    }
  }
})
</script>

<style scoped lang="scss">
.gender-ratio-display-container {  
  position: absolute;
  top: 56%;
  left: 8%;
  width: 12%;
  height: 25px;
  text-align: left;

  .ratio-bar-display {
    width:100%;
    float: left;

    .left-radius-only {
      border-top-left-radius: 5px;
      border-bottom-left-radius: 5px;
    }
    .right-radius-only {
      border-top-right-radius: 5px;      
      border-bottom-right-radius: 5px;
    }
    .ratio-description-container,
    .male-ratio, 
    .female-ratio {
      float: left;
      text-align: center;
      width:100%;
      height: 25px;
      color:black;
      line-height: 25px;
      font-size: 1.2em;      
    }
    .male-ratio {
      background-color: #4daceb;      
    }
    .female-ratio {
      background-color: #dca0ee;      
    }
  }
}
</style>