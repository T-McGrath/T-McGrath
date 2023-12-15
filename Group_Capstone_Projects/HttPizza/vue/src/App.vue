<template>
  <div id="capstone-app">
   <div class="header">
    <div class="title">
      <h1>HttPizza</h1>
      <img src="../../images/cpizza.webp" class="header-image">
    </div>
    </div> 
    
    <div id="nav">
      <side-bar-comp/>
    </div>
    <div id="login-and-cart">
      <cart-comp/>
    </div>
    <router-view />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Fredoka+One&display=swap" rel="stylesheet">
  </div> 

</template>

<script>
import { RouterLink } from 'vue-router';
import sideBarComp from "./components/SidebarComp.vue";
import CartComp from './components/CartComp.vue';
import authService from './services/AuthService.js';


export default { 
  components: {
    sideBarComp,
    CartComp
  },
  methods: {
    getUser() {
      authService.getUserByUsername(this.$store.state.user);
    }
  }
 };
</script>

<style>
body {
  background-color: #1D2833;
  color: #E9c590;
  margin: 0;
  padding: 0;
  display: grid;
  gap: 15px;
}

.header {
  background: linear-gradient(to right, #9c2913, #ca4527);
  position: relative;
}

.title {
  text-align: center;
  position: relative;
  color: beige;
  font-size: 30px;
  border: 2px solid beige;
  box-shadow: 0 6px 10px rgba(0, 0, 0, 6);
  font-family: 'Fredoka One', sans-serif;
  -webkit-text-stroke: 1px black;
  -webkit-text-fill-color: beige;
}

.header-image {
  position: absolute;
  width: 165px;
  height: 165px;
  top: 50%; 
  left: 68%; 
  transform: translate(-50%, -50%);

}

div.desc {
  padding: 15px;
  text-align: left;
}
.page-name {
  font-family: 'Comic Sans MS', cursive;
}

.invisible{
  visibility: hidden;
}

@media only screen and (min-width: 768px) {
  .sidebar,
  
  .rightSidebar {
    width: 15%;
  }
}


@media (max-width: 767px) {
  .sidebar{
    flex-direction: row;
  }
}


@media only screen and (max-width: 480px) {
  .sidebar{
    flex-direction: row;
  }
}
</style>
