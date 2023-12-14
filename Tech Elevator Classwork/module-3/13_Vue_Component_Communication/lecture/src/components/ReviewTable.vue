<template>
  <table>
    <tr>
      <th>Title</th>
      <th>Reviewer</th>
      <th>Review</th>
      <th>Rating</th>
      <th>Favorited</th>
    </tr>
    <review-table-row v-for="review in filteredReviews" v-bind:key="review.id" v-bind:review = "review"/>
  </table>
</template>

<script>
import ReviewTableRow from "./ReviewTableRow.vue"
export default {
  components: {
    ReviewTableRow
  },
  computed: {
    filteredReviews() {
      const reviewsFilter = this.$store.state.filter;
      const filteredList = this.$store.state.reviews.filter((rev) => {
        return rev.rating === reviewsFilter || reviewsFilter === 0;
      });
      return filteredList;
    }
  } 
}
</script>

<style scoped>
th {
  text-align: left;
}
</style>
