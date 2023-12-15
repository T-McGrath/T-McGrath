<template>
    <div>
        <div class="page-name" style="margin-left:15%">
            <!-- <div> -->
         <!-- <div>
            <button @click="addToCart" class="addToCart">Add to Cart</button>
        <p v-if="addedToCart">Item added to cart!</p>
      </div> -->
            <!-- </div> -->
            <h1>Create Your Own Pizza</h1>
        <customize-comp v-bind:allIngredients="allIngredients" v-bind:allSizes="allSizes" />
        <!-- <Crust v-bind:allIngredients="allIngredients" v-model:selected="selectedCrusts"/>
    <Sauce v-bind:allIngredients="allIngredients"/>
    <Cheese v-bind:allIngredients="allIngredients"/>
    <Meat v-bind:allIngredients="allIngredients"/>
    <Veggie v-bind:allIngredients="allIngredients"/> -->
        </div>
    </div>

</template>


<script>
import Crust from '../components/CrustListComp.vue'
import Sauce from '../components/SauceListComp.vue'
import Cheese from '../components/CheeseListComp.vue'
import Meat from '../components/MeatListComp.vue'
import Veggie from '../components/VeggieListComp.vue'
import RIService from '../services/RIService';
import IngredientService from '../services/IngredientService'
import CustomizeComp from '../components/CustomizeComp.vue'
import SizeService from "../services/SizeService"

export default {
    data() {
    return {
      //addedToCart: false,
      allSizes: [],
      allIngredients: [],
      selected: [] // This might not be used?
    };
},
    components: {
        // Crust,
        // Sauce,
        // Cheese,
        // Meat,
        // Veggie,
        CustomizeComp
    },
    methods: {
    // addToCart() {
    //     this.addedToCart = true;
    //     },
        getIngredients(){
                IngredientService.getAllIngredients()
                    .then(response =>{
                        this.allIngredients = response.data;
                    }
                    )},
        getSizes(){
            SizeService.getAllSizes()
                .then(response => {
                    this.allSizes = response.data;
            })
        },
    },
    created(){
        this.getIngredients();
        this.getSizes();
    }
    
};
</script>


<style>
.addToCart {
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