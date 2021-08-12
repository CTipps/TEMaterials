<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/petInfo.png">
    <HelloWorld msg="Welcome to the PetInfo Application"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld
  }
}
</script>

<style scoped>

img {
  height: 300px;
}

</style>