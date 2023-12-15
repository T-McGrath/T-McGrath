<template>
  <div class="main">
    <img id="hedgehog-pic" alt="Lego hedgehog" src="https://www.lego.com/cdn/cs/set/assets/bltbfde534d2f7588d6/40627.png?format=webply&fit=bounds&quality=70&width=800&height=800&dpr=1.5" />
    <product-review />
  </div>
</template>

<script>
import ProductReview from './components/ProductReview.vue';

export default {
  components: {
    ProductReview
  }
};
</script>

<style>
.main {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  max-width: 800px;
  margin: 60px auto 0 auto;
}
img#hedgehog-pic {
    width: 200px;
  }
</style>
