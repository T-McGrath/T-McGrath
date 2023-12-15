<template>
  <div class="main">
    <div>
    <button @click="updateRecipes" class="newForm">Update Selected Recipes</button>
    <router-link :to="{ name: 'newPizza' }" class="newForm">Add New Specialty Pizza</router-link><span v-show="confirmationText"> Recipes updated!</span>
    
  </div>
    <div class="specialPics">
      <img src="../../images/Craig'sPizza.jpg" />
      <img src="../../images/WillBougieVeggieDelightPizza.jpg" />
      <img src="../../images/Lusia'sPizza.jpg" />
      <img src="../../images/PrestonPizza.avif" />
      <img src="../../images/Trevor'sPizza.jpg" />
      <img src="../../images/widePizza.jpg" />
    </div>
    <div class = "flex-container">
      <div v-for="recipe in getRecipes" v-bind:key="recipe.recipeId">
          <input type="checkbox" v-bind:value="recipe" v-model="recipe.isAvailable">
          <h3>{{ recipe.recipeName }}</h3>
        <ul>
          <li v-for="ingredient in recipe.ings" :key="ingredient.ingredientId">
            <p>{{ ingredient.ingredientName }}</p>
          </li>
        </ul>
    </div>
    </div>
  <!-- <div class="gallery">
    <input type="checkbox" name="pizza" value="Craig'sPizza">
    <img src="../../images/Craig'sPizza.jpg" />
    <div class="desc">Craig's Pizza</div>
  </div>

  <div class="gallery">
    <input type="checkbox" name="pizza" value="Lusia'sPizza">
    <img src="../../images/Lusia'sPizza.jpg" />
    <div class="desc">Lusia's Pizza</div>
  </div>

  <div class="gallery">
    <input type="checkbox" name="pizza" value="Preston'sPizza">
    <img src="../../images/PrestonPizza.avif">
    <div class="desc">Preston's Pizza</div>
  </div>

  <div class="gallery">
    <input type="checkbox" name="pizza" value="WillBougieVeggieDelightPizza">
    <img src="../../images/WillBougieVeggieDelightPizza.jpg">
    <div class="desc">Will's Pizza</div>
  </div>

  <div class="gallery">
    <input type="checkbox" name="pizza" value="Trevor'sPizza">
    <img src="../../images/Trevor'sPizza.jpg">
    <div class="desc">Trevor's Pizza</div>
  </div> -->
  
</div>
</template>
    
<script>
import { createNamespacedHelpers } from 'vuex';
import IngredientService from '../services/IngredientService';
import RecipeService from '../services/RecipeService.js';
import { ref } from 'vue';

export default{
  props:['recipes'],
  data() {
    return {
      confirmationText: ref(false),
      markedOutOfStock: false,
      selectedRecipes: this.recipes,
      newPizza: {
        name: '',
        price: 0
      },
    };
  },
  methods: {
    hitUpdateButton() {
      this.confirmationText = true;
      setTimeout(() => {
      this.confirmationText = false}, 2000)
    },
    addNewPizza() {
      console.log('Adding new pizza:', this.newPizza);
      this.newPizza.name = '';
      this.newPizza.price = 0;
    },
    goToDifferentScreen() {
      console.log('Navigating to a different screen...');
    },
    updateRecipes() {
      this.recipes.forEach(recipe => {
        RecipeService.updateRecipe(recipe.recipeId, recipe).then(response => {
          this.hitUpdateButton();
        });
      });
      // this.$router.go(0);
    }
  },
  computed: {
    getRecipes(){
      return this.recipes;
    }
  }
  
}

</script>
    
<style scoped>

.flex-container {
  display: flex;
  flex-wrap: wrap;
  align-items: left;
}

.flex-container > div {
  width: 200px;
  margin: 10px;
  text-align: center;
  font-family: 'Comic Sans MS', cursive;
  line-height: 25px;
  font-size: 17px;
}

.specialPics {
  float: center;
  height: 200px;
  width: 200px;
  display: flex;
  flex-direction: row;
  align-items: center;
  padding-top: 1%;
}

.specialPics:hover {
  border: 1px solid #777;
}

.specialPics img {
      width:  200px;
      align-items: center;
      height: 200px;
      margin: 25px;
      border-radius: 10px;
      border: 5px solid beige;
      box-shadow: 0 10px 16px rgba(0, 0, 0, 50);
  }

div.desc {
  padding: 15px;
  text-align: center;
}

#recipe-name {
  display: inline;
}
</style>