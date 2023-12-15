<template>
  <div class="main">
    <div class="gallery">
      <img src="../../images/ItalianSausage.jpg" />
      <h3>{{filteredIngredients[0].ingredientType}}s:</h3>
      <ul>
        <li v-for="ingredient in filteredIngredients" v-bind:key="ingredient.ingredientId"><input type="checkbox" v-bind:value="ingredient" :checked="ingredient" v-model="selectedMeats"/>
          {{ ingredient.ingredientName }}
        </li>
      </ul>
      <!-- <h4>Meats: </h4>
        <label>
            <p>Bacon</p>
            <input type="checkbox" name="meat" value="Bacon">
            <img src="../../images/Bacon.jpg" />
        </label>
        <label>
            <p>GrilledChicken</p>
            <input type="checkbox" name="meat" value="GrilledChicken">
            <img src="../../images/GrilledChicken.jpg" />
        </label>
        <label>
            <p>Ham</p>
            <input type="checkbox" name="meat" value="Ham">
            <img src="../../images/Ham.jpg" />
        </label>
        <label>
            <p>ItalianSausage</p>
            <input type="checkbox" name="meat" value="ItalianSausage">
            <img src="../../images/ItalianSausage.jpg" />
        </label>
        <label>
            <p>MeatBalls</p>
            <input type="checkbox" name="meat" value="MeatBalls">
            <img src="../../images/MeatBalls.jpg" />
        </label>
        <label>
            <p>Pepperoni</p>
            <input type="checkbox" name="meat" value="Pepperoni">
            <img src="../../images/Pepperoni.jpg" />
        </label> -->
        <!-- <ul>
            <li v-for="()">
                {{  }}
            </li>
        </ul> -->
    </div>
  </div>
</template>

<script>
export default{
      data() {
        return {
          selectedMeats: []
        }
      },
      computed: {
          filteredIngredients() {
              return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Meat'});
          },
      },
    props:{
    allIngredients: {
      type: Array,
      required: true
    }
  }
};
</script>

<style scoped>
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
</style>