<template>
  <div class="book-container">
    <book-card v-for="aBook in getAllBooks" v-bind:key="aBook.isbn" v-bind:book="aBook"/>
  </div>
</template>

<script>

import BookCard from "./BookCard.vue";
export default {
  components: {
    BookCard
  },
  computed: {
    getAllBooks() {
      const allBooks = this.$store.state.books;
      return allBooks;
    }
  }
}
</script>

<style>
.book-container {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
}
</style>