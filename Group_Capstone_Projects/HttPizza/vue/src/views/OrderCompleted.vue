<template>
    <div>
        <h2>Thank you! Your order has been placed!</h2>
        <h3>Please check your email or call the store for updates!</h3>
       
        <!-- <img src="../../images/cpizza.webp" class="header-image"> -->
        <h4>Thank you for choosing HttPizza!</h4>

        <button @click="goHome" class="newForm">Return Home</button>
    </div>

</template>

<script>
export default {
    methods:{
        goHome(){
            this.$router.push({name: "home"})
        }
    }
}
</script>

<style scoped>
div {
text-align: center;
font-family: 'Comic Sans MS', cursive;
}


</style>