<template>
  <div class="product-review-app">
    <product-review></product-review>
  </div>
</template>

<script>
import ProductReview from "./components/ProductReview.vue";
export default {
  components: {
    ProductReview
  }
}
</script>

<style>
.product-review-app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: 60px auto 0 auto;
  max-width: 800px;
}
</style>
