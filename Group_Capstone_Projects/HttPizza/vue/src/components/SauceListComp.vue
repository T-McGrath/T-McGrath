<template>
    <div class="gallery">
      <img src="../../images/RegularSauce.jpg" />
      <h3>{{filteredIngredients[0].ingredientType}}s:</h3>
      <ul>
        <li v-for="ingredient in filteredIngredients" v-bind:key="ingredient.ingredientId"><input type="checkbox" v-bind:value="ingredient" :checked="ingredient" v-model="selectedSauces"/>
          {{ ingredient.ingredientName }}
        </li>
      </ul>
      <!-- <h4>Sauces: </h4>
      <label>
            <p>BBQSauce</p>
            <input type="checkbox" name="sauce" value="BBQSauce">
            <img src="../../images/BBQSauce.webp" />
        </label>
        <label>
            <p>RegularSauce</p>
            <input type="checkbox" name="sauce" value="RegularSauce">
            <img src="../../images/RegularSauce.jpg" />
        </label>
        <label>
            <p>Ranch</p>
            <input type="checkbox" name="sauce" value="Ranch">
            <img src="../../images/Ranch.jpg" />
        </label> -->
        <!-- <ul>
            <li v-for="">
                {{  }}
            </li>
        </ul> -->
    </div>
</template>

<script>
export default{
      data() {
        return{
          selectedSauces: []
        }
      },
      computed: {
          filteredIngredients() {
              return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Sauce'});
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