<template>
  <div style="margin-left:15%">
    <h1>Ingredients</h1>
  </div>
  <div class="main">  
    <div style="margin-left: 15%">
        <div class="save">
          <button @click="saveIngredientAvailability" class="save-stock">Save Ingredient Availability</button>
          <span id="done" v-show="textVisible">Done!</span>
        </div>
        <div class="ingForm">
          <button @click="showForm = true" v-show="!showForm" class="newForm">Add Ingredient</button>
    <form v-if="showForm" @submit.prevent="addNewIngredient" style="margin-left: 15%;">
      <label for="ingredientName">Ingredient Name:</label>
      <input type="text" id="ingredientName" v-model="newIngredient.ingredientName">
    
      <label for="ingredientType">Ingredient Type:</label>
      <select id="ingredientType" v-model="newIngredient.ingredientType">
        <option value="Crust">Crust</option>
        <option value="Cheese">Cheese</option>
        <option value="Sauce">Sauce</option>
        <option value="Meat">Meat</option>
        <option value="Vegetable">Vegetable</option>
        <option value="Premium">Premium</option>
      </select>

      <button type="submit">Add Ingredient</button>
      <span id="added" v-show="addedText">Ingredient added!</span>
    </form>
        </div>
      <div class="gallery">
        <img src="../../images/Crust.jpg" />
        <h3>{{CrustFilter[0].ingredientType}}s:</h3>
        <ul id="crusts">
            <li v-for="crust in CrustFilter" v-bind:key="crust.ingredientId">
                <input type="checkbox" v-model="crust.isAvailable"/>
                {{ crust.ingredientName }}
            </li>
        </ul>
      </div>
      <div class="gallery">
        <img src="../../images/RegularSauce.jpg" />
        <h3>{{SauceFilter[0].ingredientType}}s:</h3>
        <ul id="sauces">
            <li v-for="sauce in SauceFilter" v-bind:key="sauce.ingredientId">
                <input type="checkbox" v-model="sauce.isAvailable"/>
                {{ sauce.ingredientName }}
            </li>
        </ul>
      </div>
      <div class="gallery">
        <img src="../../images/Mozzarella.jpg" />
        <h3>{{CheeseFilter[0].ingredientType}}s:</h3>
        <ul id="cheeses">
            <li v-for="cheese in CheeseFilter" v-bind:key="cheese.ingredientId">
                <input type="checkbox" v-model="cheese.isAvailable"/>
                {{ cheese.ingredientName }}
            </li>
        </ul>
      </div>
      <div class="gallery">
        <img src="../../images/ItalianSausage.jpg" />
        <h3>{{MeatFilter[0].ingredientType}}s:</h3>
        <ul id="meats">
            <li v-for="meat in MeatFilter" v-bind:key="meat.ingredientId">
                <input type="checkbox" v-model="meat.isAvailable"/>
                {{ meat.ingredientName }}
            </li>
        </ul>
      </div>
      <div class="gallery">
        <img src="../../images/RedOnions.jpg" />
        <h3>{{VeggieFilter[0].ingredientType}}s:</h3>
        <ul id="veggies">
            <li v-for="veggie in VeggieFilter" v-bind:key="veggie.ingredientId">
                <input type="checkbox" v-model="veggie.isAvailable"/>
                {{ veggie.ingredientName }}
            </li>
        </ul>
      </div>
      <div class="gallery">
        <img src="../../images/pineapple.webp" />
        <h3>{{PremiumFilter[0].ingredientType}}:</h3>
        <ul id="premium">
            <li v-for="prem in PremiumFilter" v-bind:key="prem.ingredientId">
                <input type="checkbox" v-model="prem.isAvailable"/>
                {{ prem.ingredientName }}
            </li>
        </ul>
      </div>
    </div>
  </div>
</template>


<script>

import { ref } from 'vue';
import IngredientService from "../services/IngredientService.js";

export default{
  data() {
    return {
      textVisible: ref(false),
      addedText: ref(false),
      showForm: false,
      //selectedIngredients: [],
      newIngredient: {
        ingredientName: '',
        ingredientType: '', 
        isAvailable: true
      },
      updatedIngredients: this.allIngredients // I believe we need this updatedIngredient list to make the newly added ings show up on page.
    }
  },
  props: ["allIngredients"],
  computed:{
    CrustFilter() {
      return this.updatedIngredients.filter(ingredient => {return ingredient.ingredientType === 'Crust'});
    },
    SauceFilter(){
      return this.updatedIngredients.filter(ingredient => {return ingredient.ingredientType === 'Sauce'});
    },
    CheeseFilter(){
      return this.updatedIngredients.filter(ingredient => {return ingredient.ingredientType === 'Cheese'});
    },
    MeatFilter() {
      return this.updatedIngredients.filter(ingredient => {return ingredient.ingredientType === 'Meat'});
    },
    VeggieFilter() {
      return this.updatedIngredients.filter(ingredient => {return ingredient.ingredientType === 'Vegetable'});
    },
    PremiumFilter() {
      return this.updatedIngredients.filter(ingredient => {return ingredient.ingredientType === 'Premium'});
    }
  },
  methods: {
    // When method called, shows 'Done!' for 2 seconds.
    hitAddNewIngredientButton() {
      this.addedText = true;
      setTimeout(() => {
      this.addedText = false}, 2000)
    },
    hitStockButton() {
      this.textVisible = true;
      setTimeout(() => {
      this.textVisible = false}, 2000)
    },
    addNewIngredient() {
      IngredientService.createIngredient(this.newIngredient).then(response => {
        this.hitAddNewIngredientButton();
        this.showForm = false;
        IngredientService.getAllIngredients().then(resp => {
          this.updatedIngredients = resp.data;
          this.newIngredient = {
            ingredientName: '',
            ingredientType: '',
            isAvailable: true
          };
        });
      });
    },
    saveIngredientAvailability() {
      this.updatedIngredients.forEach(ingredient => {
        IngredientService.updateIngredient(ingredient.ingredientId, ingredient).then(response => {
          this.hitStockButton();
        });
      });
    },
  }
};
</script>

<style scoped>
  div.gallery {
    margin: 5px;
    float: left;
    width: 180px;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  div.gallery:hover {
    border: 1px solid #777;
  }

  div.gallery img {
      width:  165px;
      height: 165px;
      border-radius: 10px;
      border: 5px solid beige;
      box-shadow: 0 10px 16px rgba(0, 0, 0, 50);
  }
  div.desc {
    padding: 15px;
    text-align: center;
  }
  li{
    list-style-type: none;
    
  }
  .save-stock {
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
  margin-left: 15%;
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