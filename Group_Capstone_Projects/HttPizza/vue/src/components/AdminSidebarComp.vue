<template>
  <div class="AdminSidebar">
    <aside>
            <h3>Main Menu</h3>
            <router-link v-bind:to="{name: 'stock'}"><p>Stock</p></router-link>
            <!-- <router-link v-bind:to="{name: 'AdminHome'}"><p>Home</p></router-link> -->
            <router-link v-bind:to="{name: 'AdminPending'}"><p>Pending Order's</p></router-link>
            <router-link v-bind:to="{name: 'AdminRecipe'}"><p>Prebuilt Pizza</p></router-link>
        </aside>
  </div>
</template>

<script>
export default{};
</script>

<style scoped>
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
</style>