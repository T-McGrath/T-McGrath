<template>
  <div class="main">
    <div class="gallery">
      <img src="../../images/pineapple.webp" />
      <h3>{{filteredIngredients[0].ingredientType}}s:</h3>
      <ul>
        <li v-for="ingredient in filteredIngredients" v-bind:key="ingredient.ingredientId"><input type="checkbox" v-bind:value="ingredient" :checked="ingredient" v-model="selectedVeggies"/>
          {{ ingredient.ingredientName }}
        </li>
      </ul>
        <!-- <h4>Veggies: </h4>
        <label>
            <p>ArtichokeHearts</p>
            <input type="checkbox" name="veggie" value="ArtichokeHearts">
            <img src="../../images/ArtichokeHearts.jpg" />
        </label>
        <label>
            <p>Broccoli</p>
            <input type="checkbox" name="veggie" value="Broccoli">
            <img src="../../images/Broccoli.jpg" />
        </label>
        <label>
            <p>Mushrooms</p>
            <input type="checkbox" name="veggie" value="Mushroom">
            <img src="../../images/Mushroom.webp" />
        </label>
        <label>
            <p>Olives</p>
            <input type="checkbox" name="veggie" value="Olives">
            <img src="../../images/Olives.webp" />
        </label>
        <label>
            <p>Onions</p>
            <input type="checkbox" name="veggie" value="Onions">
            <img src="../../images/onions.jpg" />
        </label>
        <label>
            <p>Pineapples</p>
            <input type="checkbox" name="veggie" value="Pineapple">
            <img src="../../images/pineapple.webp" />
        </label>
        <label>
            <p>RedOnions</p>
            <input type="checkbox" name="veggie" value="RedOnion">
            <img src="../../images/RedOnions.jpg" />
        </label>
        <label>
            <p>Spinach</p>
            <input type="checkbox" name="veggie" value="Spinach">
            <img src="../../images/Spinach.jpg" />
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
        return{
          selectedVeggies: []
        }
      },
      computed: {
          filteredIngredients() {
              return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Vegetable'});
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