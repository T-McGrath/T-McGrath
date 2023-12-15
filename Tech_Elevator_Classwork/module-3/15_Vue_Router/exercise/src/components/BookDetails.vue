<template>
    <div class="deets">
        <h1>{{ desiredBook.title }}</h1>
        <h1>{{ desiredBook.author }}</h1>
        <img v-if="desiredBook.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + desiredBook.isbn + '-M.jpg'" />
        <p>Number of pages: {{ desiredBook.numPages }}</p>
        <a v-bind:href="desiredBook.moreInfoLink" target="_blank">More Information</a>
        <p>{{ haveRead }}</p>

    </div>
</template>


<script>
export default {
    props: ['isbn'],
    computed: {
        desiredBook() {
        return this.$store.state.books.find(book => book.isbn == this.isbn);
        },

        haveRead() {
            if (this.desiredBook.read) {
                return "I have read this book."
            }
            return "I have NOT read this book."
        }
    }
}

</script>