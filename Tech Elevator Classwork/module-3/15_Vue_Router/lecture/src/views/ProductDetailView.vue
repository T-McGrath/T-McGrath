<template>
    <h1>{{ product.name }}</h1>
    <p class="description">{{ product.description }}</p>
    <div class="actions">
        <a href="#">Back to Products</a>&nbsp;|
        <a href="#">Add Review</a>
    </div>
    <div class="well-display">
      <average-summary v-bind:reviews="product.reviews"/>
      <star-summary
          v-for="i in 5"
          v-bind:rating="i"
          v-bind:key="i"
          v-bind:reviews="product.reviews" />
    </div>
    <review-list v-bind:reviews="product.reviews"/>
</template>

<script>
import AverageSummary from "../components/AverageSummary.vue";
import StarSummary from "../components/StarSummary.vue";
import ReviewList from "../components/ReviewList.vue";

export default {
    components: {
        AverageSummary,
        StarSummary,
        ReviewList
    },
    computed: {
        product() {
            let productId = this.$route.params.id;
            let prod = this.$store.state.products.find( p => p.id == productId);
            return prod;
        }
    }

}
</script>

