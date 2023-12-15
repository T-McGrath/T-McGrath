<template>
  <div class="main">
    <div>
        <transition>
          <button v-show="Object.keys(selectedRecipe).length > 0" @click="goToCustomizePage" class="addToCart">Customize Pizza</button>
        </transition>
        <!-- <button v-show="Object.keys(selectedRecipe).length > 0" @click="addToCart" class="addToCart">Add to Cart</button>
        <p v-show="addedToCartText">Item added to cart!</p> -->
    </div>
    <div class="specialPics">
      <img src="../../images/Craig'sPizza.jpg" />
      <img src="../../images/WillBougieVeggieDelightPizza.jpg" />
      <img src="../../images/Lusia'sPizza.jpg" />
      <img src="../../images/PrestonPizza.avif" />
      <img src="../../images/Trevor'sPizza.jpg" />
    </div>
    <div class = "flex-container">
      <div v-for="recipe in SpecialtiesFilter" v-bind:key="recipe.recipeId">
        <input type="radio" v-bind:id="recipe.recipeName" v-bind:value="recipe" v-model="selectedRecipe"/>
        <label v-bind:for="recipe.recipeName"><h3 id="recipe-name">{{ recipe.recipeName }}</h3><span id="price"> [${{ recipe.recipePrice }}]</span></label>
        <!-- <h3>{{ recipe.recipeName }} </h3> -->
        <ul>
          <li v-for="ingredient in recipe.ings" v-bind:key="ingredient.ingredientId">
            <p>{{ingredient.ingredientName}}</p>
          </li>
        </ul>
      </div>
    </div>
<!-- <div class="gallery">
    <a  href="../customizePizza">
      <img src="../../images/Craig'sPizza.jpg" />
    </a>
    <div class="desc">Craig's Pizza</div>
  </div>

<div class="gallery">
    <a target="_blank" href="../customizePizza">
      <img src="../../images/Lusia'sPizza.jpg" /> 
    </a>
    <div class="desc">Lusia's Pizza</div>
  </div>

<div class="gallery">
    <a target="_blank" href="../customizePizza">
      <img src="../../images/PrestonPizza.avif">
    </a>
    <div class="desc">Preston's Pizza</div>
</div>

<div class="gallery">
    <a target="_blank" href="../customizePizza">
      <img src="../../images/WillBougieVeggieDelightPizza.jpg">
    </a>
    <div class="desc">Will's Pizza</div>
</div>

<div class="gallery">
    <a target="_blank" href="../customizePizza">
      <img src="../../images/Trevor'sPizza.jpg">
    </a>
    <div class="desc">Trevor's Pizza</div>
</div> -->
</div>
</template>

<script>
import { createNamespacedHelpers } from 'vuex';
import { ref } from 'vue';

export default{
  data() {
    return {
      isPizzaSelected: false,
      addedToCartText: ref(false),
      selectedRecipe: {}
    }
  },
  props:['recipes'],
  methods: {
    // Method not currently in use.
    hitAddedToCartButton() {
      this.addedToCartText = true;
      setTimeout(() => {
      this.addedToCartText = false}, 2000)
    },
    // Method not currently in use.
    addToCart() {
      // Need to implement the rest of this method...copy from other component?
      this.hitAddedToCartButton();
      // Maybe do this, too? this.selectedRecipe = {};
    },
    goToCustomizePage() {
      this.$store.commit('ADD_RECIPE', this.selectedRecipe);
      this.selectedRecipe = {};
      this.$router.push({name: "createYourOwn"});
    }
  },
  computed: {
    getRecipes(){
      return this.recipes;
    },
    SpecialtiesFilter() {
      return this.recipes.filter(recipe => {return recipe.isAvailable && recipe.recipeId !== 6})
    }
  }
};
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
  margin-top: 15px
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

.v-enter-from, .v-leave-to {
  opacity: 0;
}

.v-enter-active, .v-leave-active {
  transition: opacity 750ms
}
</style>