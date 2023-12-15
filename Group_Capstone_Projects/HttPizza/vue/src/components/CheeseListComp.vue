<template>
    <div class="gallery">
      <img src="../../images/Mozzarella.jpg" />
      <h3>{{filteredIngredients[0].ingredientType}}s:</h3>
      <ul>
        <li v-for="ingredient in filteredIngredients" v-bind:key="ingredient.ingredientId"><input type="checkbox" v-bind:value="ingredient" :checked="ingredient" v-model="selectedCheeses"/>
          {{ ingredient.ingredientName }}
        </li>
      </ul>
        <!-- <h4>Cheese: </h4>
        <label>
            <p>Mozzarella</p>
            <input type="checkbox" name="cheese" value="Mozzarella">
            <img src="../../images/Mozzarella.jpg" />
        </label>
        <label>
            <p>RicottaCheese</p>
            <input type="checkbox" name="cheese" value="RicottaCheese">
            <img src="../../images/RicottaCheese.jpg" />
        </label> -->
        <!-- <ul>
            <li v-for="()">
                {{  }}
            </li>
        </ul> -->
    </div>
</template>

<script>
export default{
      data(){
        return{
          selectedCheeses: []
        }
      },
      computed: {
          filteredIngredients() {
              return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Cheese'});
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