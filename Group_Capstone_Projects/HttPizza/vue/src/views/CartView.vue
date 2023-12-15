<template>
    <div style="margin-left: 15%">
        <div class="cart">
          <div class="page-name">
          <h1>Your Cart</h1>
          </div>
          <div v-if="orders.length > 0">
            <table id="cartOrder">
              <thead>
                <tr>
                  <th></th>
                  <th>Recipe Name</th>
                  <th>Ingredients</th>
                  <th>Price</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(order, index) in orders" :key="index">
                  <td>
                    <input type="checkbox" v-model="selectedOrders" :value="order" :checked=true />
                  </td>
                  <td>{{ order.recipe.recipeName }}</td>
                  <td><p v-for="ingredient in order.ingredients" :key="ingredient.ingredientId">{{ ingredient.ingredientName }}</p></td>
                  <td>${{ order.recipe.recipePrice }}.00</td>
                </tr>
              </tbody>
            </table>
            
          </div>
          <div v-else>
            <p>Cart Empty</p>
          </div>
          <!-- <Cart v-if="orders.length > 0" /> -->
        </div>
        <div class="orderChoice">
        <label>
          <input type="radio" v-model="isDelivery" value="true"> Delivery
        </label>
        <label>
          <input type="radio" v-model="isDelivery" value="false"> Pickup
        </label>
      </div>
      <button @click="submitOrders" class="submitOrders">Place Order</button>
      <p v-show="textVisible">Order Submitted!</p>
      </div>
  </template>
  
  <script>
  //import Cart from '../components/CartComp.vue'
  import OrderService from '../services/OrderService';
  import RecipeService from '../services/RecipeService'
  import CustomerService from '../services/CustomerService';
  import ORSService from '../services/ORSService';
  import IngredientService from '../services/IngredientService'
  import { ref } from 'vue'

  export default {
    components: {
      //Cart
    },
    data() {
      return {
        orders: [],
        selectedOrders: [] ,
        orderType: "delivery",
        isDelivery: true,
        customerId: 0,
        textVisible: ref(false)
      };
    },
    methods: {
      getOrders(){
        CustomerService.getCustomerByUserId(this.$store.state.user.userId)
          .then(response => {
            this.customerId = response.data.customerId;

            OrderService.getOrdersByCustId(this.customerId)
              .then(response => {
                this.orders = response.data;

                this.orders.forEach(order => {
                  ORSService.getAllOrderInfoById(order.orderId)
                    .then(response => {
                      order.ors = response.data;

                      //this.order.ors.forEach(ors => {
                        RecipeService.getRecipeById(order.ors[0].recipeId)
                          .then(response => {
                            order.recipe = response.data;

                            //order.ors.forEach(or => {
                              IngredientService.getIngredientsByRecipeId(order.recipe.recipeId)
                                .then(response => {
                                  order.ingredients = response.data;
                                })
                            //})
                          })
                      //})
                   })
                })
              })
          })
      },
      hitButton(){
        this.textVisible = true;
        setTimeout(() => {
          this.textVisible = false, 5000})
          
        },
      submitOrders() {
        if(!this.isDelivery){
          this.orders.forEach(order => {
            order.isDelivery = false;
            OrderService.updateOrder(order.orderId, order)
              .then(response => {
                order = response.data;
              })
            
          })
        }
        this.$router.push({name: "orderCompleted"})
        
        //this.$router.push({name: "home"});
      },
      goHome(){
        this.$router.push({name: "orderCompleted"});
      }
      },
      created(){
      this.getOrders();
    }
      
    };
    

</script> 
    
<style>
   #cartOrder {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#cartOrder td, #cartOrder th {
  border: 3px solid beige;
  padding: 8px;
}

#cartOrder tr:nth-child(even){
  background-color: #1D2833;
}

#cartOrder tr:nth-child(even) {
  background-color: #1d2833;
}

#cartOrder th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #9c2913;
  color: beige;
} 

.submitOrders {
    background-color: beige;
    color: black;
    padding: 10px 20px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-family: 'Comic Sans MS', cursive;
    font-size: 20px;
    border: 4px solid black;
    border-radius: 30px; 
    cursor: pointer;
}
</style>