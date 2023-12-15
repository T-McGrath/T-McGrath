<template>
  <div class="homeMain">
  <div class="gallery1">
    <router-link v-bind:to="{name: 'specialty'}">
      <img src="../../images/Craig'sPizza.jpg" />
    </router-link>
    <div class="desc">Craig's Pizza</div>
  </div>

  <div class="gallery1">
    <router-link v-bind:to="{name: 'specialty'}">
      <img src="../../images/Lusia'sPizza.jpg" /> 
    </router-link>
    <div class="desc">Lusia's Pizza</div>
  </div>

  <div class="gallery1">
    <router-link v-bind:to="{name: 'specialty'}">
      <img src="../../images/PrestonPizza.avif">
    </router-link>
    <div class="desc">Preston's Pizza</div>
  </div>
</div>
</template>

<script>
export default{};
</script>

<style scoped>

.homeMain {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

.gallery1 {
  margin: 5px;
  width: 300px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.gallery1:hover {
  border: 1px solid #777;
}

.gallery1 img {
  width: 280px;
  height: 280px;
  border-radius: 10px;
  border: 5px solid beige;
  box-shadow: 0 10px 16px rgba(0, 0, 0, 0.5);
}

.desc {
  padding: 15px;
  text-align: center;
}
</style>