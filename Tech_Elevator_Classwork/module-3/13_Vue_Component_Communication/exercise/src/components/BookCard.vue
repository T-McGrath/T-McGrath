<template>
  <div v-bind:class="toggleCardReadClass">
  <!--<div class="card" v-bind:class="{read: isBookRead}">--> 
    <h2 class="book-title">{{ book.title }}</h2>
    <h3 class="book-author">{{ book.author }}</h3>
    <img class="book-image" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'"/>
    <!--I had this button within a p tag and that's why the Step 3 tests were failing >:(-->
    <button type="button" v-bind:class="toggleButtonClass" v-on:click="toggleBookRead">{{ toggleButtonText }}</button>
    <!--<button type="button" v-bind:class="{'mark-read': !isBookRead, 'mark-unread': isBookRead}" v-on:click="toggleBookRead">{{ toggleButtonText }}</button>-->
  </div>
</template>

<script>
export default {
  props: ["book"],
  methods: {
    toggleBookRead() {
      this.$store.commit("TOGGLE_BOOK_READ", this.book);
    }
  },
  computed: {
    toggleCardReadClass() {
      if(this.isBookRead) {
        return "card read";
      }
      return "card";
    },
    
    toggleButtonClass() {
      if (this.isBookRead) {
        return "mark-unread";
      }
      return "mark-read";
    },

    toggleButtonText() {
      if(this.isBookRead) {
        return "Mark Unread";
      }
      return "Mark Read";
    },

    isBookRead() {
      return this.book.read;
    }
  }
}
</script>

<style>
.card {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  height: 550px;
  margin: 20px;
  position: relative;
}

.card.read {
  background-color: lightgray;
}

.card .book-title {
  font-size: 1.5rem;
}

.card .book-author {
  font-size: 1rem;
}

.book-image {
  width: 80%;
}

.mark-read, .mark-unread {
  display: block;
  position: absolute;
  bottom: 40px;
  width: 80%;
  left: 10%;
  font-size: 1rem;
}
</style>