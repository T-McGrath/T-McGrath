<template>
    <form class="new-book-form" v-on:submit.prevent="createNewBook">
        <input class="title-input" type="text" placeholder="Title" v-model="newBook.title"/>
        <input class="author-input" type="text" placeholder="Author" v-model="newBook.author"/>
        <input class="isbn-input" type="text" placeholder="ISBN" v-model="newBook.isbn"/>
        <input type="submit" value="Save"/>
    </form>
</template>


<script>
export default {
    data() {
        return {
            newBook: {}
        }
    },
    methods: {
        createNewBook() {
            this.newBook.read = false;
            this.$store.commit("ADD_BOOK", this.newBook);
            this.clearBook();
        },
        clearBook() {
            this.newBook = {};
        }
    }
}
</script>


<style>
input {
    margin-right: 15px;
}
</style>