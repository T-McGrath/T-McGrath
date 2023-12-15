<template>
  <div class="page-name" style="margin-left:15%">
  <div class="home">
    <h1>Home</h1>
    <Home/>
  </div>
</div>
</template>

<script>
import Home from '../components/HomeComp.vue'

export default {
  components: {
    Home
  },
};
</script>

<style scoped>
.home{
  display: center;
}
</style>
