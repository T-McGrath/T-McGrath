<template>
  <div style="margin-left:15%">
    <!-- <h1>Ingredients</h1> -->
  </div>
  <div class="main">
    <admin-stock-comp v-bind:allIngredients="allIngredients"/>
  </div>  
</template>
  
<script>
import RIService from '../services/RIService.js';
import IngredientService from '../services/IngredientService.js'
import AdminStockComp from '../components/AdminStockComp.vue'


export default {
  data() {
    return {
      //markedOutOfStock: false,
      allIngredients: [],
    };
  },
  components: {
    AdminStockComp
  },
  methods: {
    // outOfStock() {
    //   this.markedOutOfStock = true;
    // },
    // inStock() {
    //   this.markedOutOfStock = false;
    // },
    getIngredients() {
      IngredientService.getAllIngredients()
      .then(response =>{
        this.allIngredients = response.data;
      })
    },
  },
  created(){
    this.getIngredients();
  }
};
</script>


<style>
.addToCart {
    background-color: beige;
    color: black;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 20px;
}

.outOfStock {
    background-color: beige;
    color: black;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 20px;
}
.inStock {
    background-color: beige;
    color: black;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 20px;
}
.Crust,
.Sauce,
.Cheese,
.Meat,
.Veggie {
  flex: 1 1 20%; 
  margin: 10px;
}
@media screen and (max-width: 768px) {
  .Crust,
  .Sauce,
  .Cheese,
  .Meat,
  .Veggie {
    flex: 1 1 40%;
  }
}
form {
  margin-top: 20px;
  width: 70%; 
  margin-left: auto;
  margin-right: auto;
}
</style>