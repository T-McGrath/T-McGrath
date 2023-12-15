<template>
    <div class="sidebar">
        <aside>
            
            <div class="customer">
                <router-link v-bind:to="{name: 'home' }">Home</router-link>
                <router-link v-bind:to="{name: 'specialty'}"><p>Specials</p></router-link>
                <router-link v-bind:to="{name: 'createYourOwn'}"><p>Create Your Own</p></router-link>
                <!-- <router-link v-bind:to="{name: 'customerInfo'}" v-show="$store.state.token !== ''"><p>Account Info</p></router-link> -->
            </div>
            <div class="admin" v-show="$store.state.user.role === 'admin'">
                <!-- <router-link v-bind:to="{ name: 'AdminHome' }"><p>Admin Home</p></router-link> -->
                <router-link v-bind:to="{ name: 'stock' }"><p>Stock</p></router-link>
                <router-link v-bind:to="{ name: 'AdminRecipe' }"><p>Specialty Recipe</p></router-link>
                <router-link v-bind:to="{ name: 'AdminPending' }"><p>AdminPending</p></router-link>
            </div>
            <div class="highlighted-section">
            <div class="cart">
                <router-link v-bind:to="{ name: 'cart' }">
                  <img src="../../images/pbox.jpg" alt="Cart Image"/>
                </router-link> 
                <p class="cart-text">Your Cart</p>
            </div>
            <div class="login">
                <router-link v-bind:to="{ name: 'login' }" v-show="$store.state.token === ''">Login</router-link> 
                <router-link v-bind:to="{ name: 'logout' }" v-show="$store.state.token !== ''">Logout</router-link> 
            </div>
          </div>
        </aside>
        
    </div>
</template>


<script>
export default{
}
</script>


<style scoped>
.sidebar {
  display: flex;
  flex-direction: column;
  height: 100%;
  width: 15%;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: #485D17;
  color: black;
  box-sizing: border-box;
  float: left;
  border: 2px solid beige;
  font-family: 'Comic Sans MS', cursive;
  font-size: 18px;
  font-weight: bold;
}

.sidebar a {
  display: flex;
  flex-direction: column;
  color: beige;
  padding: 4px;
  text-decoration: none;
}

.customer,
.admin,
.cart,
.login {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.cart,
.login {
  margin-top: auto;
}
.sidebar a:hover:not(.active) {
  background-color: #9c2913;
  color: white;
  border-radius: 30%;
}

.sidebar a.active {
  background-color: #9c2913;
  color: white;
}
div.cart {
  margin: 10px auto; /* Center the cart div */
  width: 180px;
  text-align: center; /* Center-align the content */
}

div.cart img {
  width: 80px;
  height: 80px;
  border-radius: 50%;
  border: 4px solid rgb(10, 10, 10);
}

.cart-text {
  font-family: 'Fredoka One', sans-serif; 
  color: beige; 
  margin-top: 10px;
  margin-bottom: 20px;
}
.highlighted-section {
  background-color: #d4c526; 
  padding: 10px; 
  -webkit-text-stroke: 1px black;
  -webkit-text-fill-color: beige;
}
</style>