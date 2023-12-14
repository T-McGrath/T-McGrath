<template>
    <book-details v-bind:isbn="bookIsbn"/>
</template>


<script>
import BookDetails from "../components/BookDetails.vue";

export default {
    components: {
        BookDetails
    },
    computed: {
        bookIsbn() {
            return this.$route.params.isbn;
        }
    }
}
</script>