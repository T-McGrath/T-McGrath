<template>
  <div class="main">
    <div class="gallery">
      <img src="../../images/Crust.jpg" />
      <h3>{{filteredIngredients[0].ingredientType}}s:</h3>
      <ul>
        <li v-for="ingredient in filteredIngredients" v-bind:key="ingredient.ingredientId"><input type="checkbox" v-bind:value="ingredient" :checked="ingredient" v-model="selectedCrusts" />
          {{ ingredient.ingredientName }}
        </li>
      </ul>
        <!-- <h4>Crusts: </h4>
        <label>
            <p>ChicagoDeepDish</p>
            <input type="checkbox" name="crust" value="ChicagoDeepDish">
            <img src="../../images/ChicagoDeepDish.jpg" />
        </label>
        <label>
            <p>ThickCrust</p>
            <input type="checkbox" name="crust" value="ThickCrust">
            <img src="../../images/ThickCrust.jpg" />
        </label>
        <label>
            <p>ThinCrust</p>
            <input type="checkbox" name="crust" value="ThinCrust">
            <img src="../../images/ThinCrust.jpg" />
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
  data(){
    return{
      selectedCrusts: []
    }
  },
      computed: {
          filteredIngredients() {
              return this.allIngredients.filter(ingredient => {return ingredient.ingredientType === 'Crust'});
          },
          saveSelected() {
              return this.$store.commit('ADD_ING', this.selectedCrusts);
          }
      },
    props:{
    allIngredients: {
      type: Array,
      required: true
    },
    selected: {
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