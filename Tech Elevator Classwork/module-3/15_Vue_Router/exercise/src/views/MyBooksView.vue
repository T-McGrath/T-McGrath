<template>
    <div>
        <ReadingList />
        <router-link v-bind:to="{name: 'add-book'}">Add book to Reading List</router-link>
    </div>
</template>

<script>
import ReadingList from "../components/ReadingList.vue";

export default {
    components: {
        ReadingList
    }
}
</script>