<template>
    <div class="page-name" style="margin-left:15%">
    <div>
        <h1>Admin Recipe</h1>
        
        <button @click="showForm = !showForm" class="newForm">Add New Specialty Pizza</button>

    <form v-if="showForm" @submit.prevent="addNewPizza">
      <label for="pizzaName">Pizza Name:</label>
      <input type="text" id="pizzaName" v-model="newPizza.recipeName">
      
      <label for="pizzaPrice">Price:</label>
      <input type="number" id="pizzaPrice" v-model="newPizza.recipePrice">

        <!-- <Crust v-bind:allIngredients="allIngredients"/>
        <Sauce v-bind:allIngredients="allIngredients"/>
        <Cheese v-bind:allIngredients="allIngredients"/>
        <Meat v-bind:allIngredients="allIngredients"/>
        <Veggie v-bind:allIngredients="allIngredients"/> -->
<div>
        <div class="gallery">
            <img src="../../images/Crust.jpg"/>
            <h3>{{ CrustFilter[0].ingredientType }}s:</h3>
            <ul id="crusts">
                <li v-for="crust in CrustFilter" v-bind:key="crust.ingredientId">
                    <input type="checkbox" v-bind:value="crust" v-model="selectedIngredients"/>
                    {{ crust.ingredientName }}
                </li>
            </ul>
        </div>

        <div class="gallery">
            <img src="../../images/RegularSauce.jpg"/>
            <h3>{{ SauceFilter[0].ingredientType }}s:</h3>
            <ul id="sauces">
                <li v-for="sauce in SauceFilter" v-bind:key="sauce.ingredientId">
                    <input type="checkbox" v-bind:value="sauce" v-model="selectedIngredients"/>
                    {{ sauce.ingredientName }}
                </li>
            </ul>
        </div>

        <div class="gallery">
            <img src="../../images/Mozzarella.jpg"/>
            <h3>{{ CheeseFilter[0].ingredientType }}s:</h3>
            <ul id="cheeses">
                <li v-for="cheese in CheeseFilter" v-bind:key="cheese.ingredientId">
                    <input type="checkbox" v-bind:value="cheese" v-model="selectedIngredients"/>
                    {{ cheese.ingredientName }}
                </li>
            </ul>
        </div>

        <div class="gallery">
            <img src="../../images/ItalianSausage.jpg"/>
            <h3>{{ MeatFilter[0].ingredientType }}s:</h3>
            <ul id="meats">
                <li v-for="meat in MeatFilter" v-bind:key="meat.ingredientId">
                    <input type="checkbox" v-bind:value="meat" v-model="selectedIngredients"/>
                    {{ meat.ingredientName }}
                </li>
            </ul>
        </div>

        <div class="gallery">
            <img src="../../images/RedOnions.jpg"/>
            <h3>{{ VeggieFilter[0].ingredientType }}s:</h3>
            <ul id="veggies">
                <li v-for="veggie in VeggieFilter" v-bind:key="veggie.ingredientId">
                    <input type="checkbox" v-bind:value="veggie" v-model="selectedIngredients"/>
                    {{ veggie.ingredientName }}
                </li>
            </ul>
        </div>

        <div class="gallery">
            <img src="../../images/pineapple.webp"/>
            <h3>{{ PremiumFilter[0].ingredientType }}s:</h3>
            <ul id="premiums">
                <li v-for="premium in PremiumFilter" v-bind:key="premium.ingredientId">
                    <input type="checkbox" v-bind:value="premium" v-model="selectedIngredients"/>
                    {{ premium.ingredientName }}
                </li>
            </ul>
        </div>
    </div>
      <button @click="addNewPizza" class="newForm">Create Pizza</button>
    </form>
    </div>
</div>
</template>


<script>
import RecipeService from '../services/RecipeService'
import RIService from '../services/RIService';
import IngredientService from '../services/IngredientService'
import { ref } from 'vue';
import Crust from '../components/CrustListComp.vue'
import Sauce from '../components/SauceListComp.vue'
import Cheese from '../components/CheeseListComp.vue'
import Meat from '../components/MeatListComp.vue'
import Veggie from '../components/VeggieListComp.vue'

export default {
    data(){
        return{
            selectedIngredients: [],
            recipes: [],
            allIngredients: [],
            showForm: false,
            newPizza: {
                recipeName: '',
                recipePrice: 0,
                isAvailable: true
            }
        };
    },
    components: {
        //Crust,
        //Sauce,
        //Cheese,
        //Meat,
        // Veggie
    },
    methods: {
        addNewPizza() {
            RecipeService.createRecipe(this.newPizza)
                .then(response => {
                    this.newPizza = response.data;

                    this.selectedIngredients.forEach(ingredient => {
                        let recipeIngredient = {
                            recipeId: this.newPizza.recipeId,
                            ingredientId: ingredient.ingredientId
                        }
                        RIService.linkRecipeIngredient(recipeIngredient)
                            .then(response =>{
                                this.recipeIngredient = response.data;
                                this.$router.push({name: "AdminRecipe"})
                            })
                    })
                })
        },
        getIngredients(){
            IngredientService.getAllIngredients()
                .then(response =>{
                    this.allIngredients = response.data;
                }
                )}
    },
    computed: {
        CrustFilter(){return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Crust' && ingredient.isAvailable})},
        SauceFilter(){return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Sauce' && ingredient.isAvailable})},
        CheeseFilter(){return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Cheese' && ingredient.isAvailable})},
        MeatFilter(){return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Meat' && ingredient.isAvailable})},
        VeggieFilter(){return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Vegetable' && ingredient.isAvailable})},
        PremiumFilter(){return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Premium' && ingredient.isAvailable})}
    },

    created(){
        this.getIngredients();
    }
      
};
</script>


<style>
div.gallery {
  margin: 5px;
  float: left;
  width: 180px;
  
}

div.gallery:hover {
  border: 1px solid #777;
}

div.gallery img {
    width:  150px;
    height: 150px;
}
div.desc {
  padding: 15px;
  text-align: center;
}
li{
  list-style-type: none;
  
}
.newForm {
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
form {
  margin-left: 1%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

label {
  font-family: 'Comic Sans MS', cursive;
  font-size: 18px;
  margin-bottom: 8px;
}

input[type="text"],
select {
  padding: 8px;
  margin-bottom: 12px;
  border-radius: 5px;
  border: 1px solid #ccc;
}

button[type="submit"] {
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