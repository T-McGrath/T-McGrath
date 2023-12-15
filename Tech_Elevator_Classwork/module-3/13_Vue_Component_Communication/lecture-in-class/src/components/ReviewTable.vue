<template>
  <table>
    <tr>
      <th>Title</th>
      <th>Reviewer</th>
      <th>Review</th>
      <th>Rating</th>
      <th>Favorited</th>
    </tr>
    <review-table-row v-for="review in filteredReviews" v-bind:key="review.id" v-bind:review="review"/>
  </table>

</template>

<script>
import ReviewTableRow from './ReviewTableRow.vue';
export default {
  components: {
    ReviewTableRow
  },
  computed: {
    filteredReviews() {
      const reviewsFilter = this.$store.state.filter;
      const filtered = this.$store.state.reviews.filter((rev) => {
        return reviewsFilter === 0 ? true : reviewsFilter === rev.rating;
      })
      return filtered;
    }
    /*  computed: {
    filteredReviews() {
      const reviewsFilter = this.$store.state.filter;
      return this.$store.state.reviews.filter(review => {
        return reviewsFilter === 0 ? true : reviewsFilter === review.rating;
      });
    }
  }*/
  } 

  
};
</script>

<style scoped>
th {
  text-align: left;
}
</style>
