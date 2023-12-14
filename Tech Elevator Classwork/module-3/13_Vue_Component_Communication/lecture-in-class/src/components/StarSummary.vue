<template>
  <div class="well">
    <span class="amount" v-on:click="updateFilter()">{{ numberOfReviews }}</span>
    {{ hedgehog }} Star Review{{ numberOfReviews === 1 ? '' : 's' }}
  </div>
</template>

<script>
export default {
  props: ['hedgehog'],
  methods: {
    updateFilter() {
      this.$store.commit('UPDATE_FILTER', this.hedgehog)
    }
  },
  computed: {
    numberOfReviews() {
      const reviews = this.$store.state.reviews;
      const matchingReviews = reviews.filter((review) => {
        return review.rating === this.hedgehog;
      });
      return matchingReviews.length;
    }
  }
};
</script>

<style scoped>
.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  padding: 0.25rem;
}

.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

.amount:hover {
  cursor: pointer;
}

</style>
