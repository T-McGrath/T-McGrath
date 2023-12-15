<template>
    <tr>
        <td>{{review.title}}</td>
        <td>{{review.reviewer}}</td>
        <td>{{review.review}}</td>
        <td class='stars'><img class='star' src="../assets/star.png" v-for="num in review.rating" v-bind:key="num" v-bind:title="review.rating + ' Star Review'"/></td>
        <td><input type="checkbox" v-bind:checked="review.favorited" @change="onFavoritedChange"/></td>
    </tr>
</template>

<script>
export default {
    props: ['review'],
    methods: {
        onFavoritedChange() {
            this.$store.commit('FLIP_FAVORITED', this.review);
        }
    }
}
</script>

<style>
.stars {
  display: flex;
}
.star {
  width: 20px;
}
tr:nth-child(even) {
  background-color: rgb(238, 238, 238);
}
</style>