<template>
  <div class="avatar-display">
    <img :src="avatar" class="avatar-container" v-if="avatar" :title="name">
  </div>  
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'AvatarDisplay',
  props: {
    avatar!: String,
    name! : String
  }
})
</script>

<style scoped lang="scss">
.avatar-display {  
  position: absolute;
  top: 26.5%;
  left: 18%;
  width:25%;
  height: 32%;

  .avatar-container {
    width: 230px;
    height: 230px;
  }
}
</style>