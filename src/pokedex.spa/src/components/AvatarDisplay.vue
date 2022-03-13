<template>
  <div class="avatar-container">
    <img :src="avatar" class="avatar-display" :title="name" v-if="avatar">
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
.avatar-container {  
  position: absolute;
  top: 26.5%;
  left: 18%;
  width:25%;
  height: 32%;

  .avatar-display {
    width: 230px;
    height: 230px;
  }
}
</style>