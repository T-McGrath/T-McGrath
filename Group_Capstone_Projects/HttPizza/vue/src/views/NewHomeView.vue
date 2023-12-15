<template>
    <div id="capstone-app">
      <!-- <div class="header">
        <h1>HttPizza</h1>
      </div> -->
      <div id="nav">
        <div class="sidebar" style="width:15%">
          <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;&nbsp;
          <router-link v-bind:to="{ name: 'specialty' }">Specialty Pizzas</router-link>&nbsp;&nbsp;
          <router-link v-bind:to="{ name: 'createYourOwn' }">Create Your Own Pizza</router-link>&nbsp;&nbsp;
          <!--<router-link v-bind:to="{ name: 'customerInfo' }" v-if="$store.state.token">Account Info</router-link>-->
          <!--!v-if="$store.state.token != ''-->
        <!--Do we need 'this.' before $store??-->
      </div>
      <Home></Home>
      <div class="rightSidebar" style="margin-left:10%">
        <div class="cart">
          <!--<a target="_blank" href="../CartView">-->
            <router-link v-bind:to="{name: 'cart'}">
            <img src="../../images/cart.png" />
          </router-link>
          <!--</a>-->
            <div class="desc">Your Cart</div>
      
        
      </div>
      <div class = "login">
        <router-link v-bind:to="{ name: 'login' }" >Login</router-link>&nbsp;
        <!--!v-if="$store.state.token != ''-->
        <router-link v-bind:to="{ name: 'logout' }" >Logout</router-link>
        <!--!v-if="$store.state.token != ''-->
        
      </div>
      <div class="AdminSidebar" style="width:15%">
          <router-link v-bind:to="{ name: 'AdminHome' }">Admin Home</router-link>&nbsp;&nbsp;
          <router-link v-bind:to="{ name: 'stock' }">Stock</router-link>&nbsp;&nbsp;
          <router-link v-bind:to="{ name: 'AdminRecipe' }">Specialty Recipe</router-link>&nbsp;&nbsp;
          <router-link v-bind:to="{ name: 'AdminPending' }">AdminPending</router-link>
          <!--!v-if="$store.state.token != ''-->
        <!--Do we need 'this.' before $store??-->
      </div>
      </div>
      <router-view />
    </div>
    </div>
  
  </template>
  
  <script>
  import { RouterLink } from 'vue-router';
  import Home from '../components/HomeComp.vue'
  
  export default { components: { RouterLink } };
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
    text-align: center;
    background: #9c2913;
    color: beige;
    font-size: 25px;
    border: 2px solid beige;
  }
  .sidebar {
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
  }
  
  .sidebar a {
    display: block;
    color: beige;
    padding: 16px;
    text-decoration: none;
  }
  
  .sidebar a:hover:not(.active) {
    background-color: #9c2913;
    color: white;
  }
  
  .AdminSidebar {
    height: 50%;
    width: 15%;
    position: fixed;
    z-index: 1;
    top: 50%;
    left: 0;
    background-color: #d8c624;
    color: black;
    box-sizing: border-box;
    float: left;
    border: 2px solid beige;
  }
  
  .AdminSidebar a {
    display: block;
    color: beige;
    padding: 16px;
    text-decoration: none;
  }
  
  .AdminSidebar a:hover:not(.active) {
    background-color: #9c2913;
    color: white;
  }
  
  div.cart {
    margin: 10px;
    float: center;
    width: 180px;
  }
  
  
  div.cart img {
      width:  100px;
      height: 100px;
  }
  
  div.desc {
    padding: 15px;
    text-align: left;
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
  .invisible{
    visibility: hidden;
  }
  </style>
  