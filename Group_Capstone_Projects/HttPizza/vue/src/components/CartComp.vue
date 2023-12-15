<template>
  <div>
    <!-- <div class="cart">
      <router-link v-bind:to="{name: 'cart'}">
        <img src="../../images/pbox.jpg" alt="Cart Image"/>
      </router-link> 
      <p class="cart-text">Your Cart</p>
    </div>
    <div class="login">
      <router-link v-bind:to="{ name: 'login' }" v-show="$store.state.token === ''">Login</router-link> 
      <router-link v-bind:to="{ name: 'logout' }" v-show="$store.state.token !== ''">Logout</router-link> 
    </div> -->
  </div>
</template>

<script>
export default{
};
</script>

<style scoped>
div.cart {
  margin: 10px auto; /* Center the cart div */
  width: 180px;
  text-align: center; /* Center-align the content */
}

div.cart img {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  border: 4px solid rgb(10, 10, 10);
}

.cart-text {
  font-family: 'Fredoka One', sans-serif; 
  color: beige; 
  margin-top: 10px;
}

.rightSidebar {
  height: 50%;
  width: 10%;
  position: fixed;
  z-index: 1;
  top: 30;
  right: 0;
  background-color: #485D17;
  color: black;
  box-sizing: border-box;
  float: left;
  border: 2px solid beige;
}
</style>