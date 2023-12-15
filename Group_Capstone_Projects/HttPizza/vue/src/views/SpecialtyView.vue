<template>
<div style="margin-left:15%">
    <div class="page-name">
        <h1>Specialty Pizza</h1>
    </div>
    <Specialties v-bind:recipes="recipes"/>
</div>
</template>


<script>
import Specialties from '../components/SpecialtiesComp.vue'
import RecipeService from '../services/RecipeService'
import RIService from '../services/RIService';
import IngredientService from '../services/IngredientService'

export default {
    components: {
        Specialties
    },
    data(){
        return{
            recipes: [],
        }
    },
    methods: {
        getRecipes(){
            RecipeService.getAllRecipes()
                .then(response =>
                this.recipes = response.data
        )},
        getIngredients(recipe){
            IngredientService.getIngredientsByRecipeId(recipe.recipeId)
                .then(response =>
                recipe.ings =  response.data)
        },
    },
    created() {
        RecipeService.getAllRecipes().then((response) => {
            this.recipes = response.data;
            this.recipes.forEach((recipe) =>{
                this.getIngredients(recipe)
            });
        });
        this.$store.commit('CLEAR_RECIPE');
    }
};
</script>


<style>

</style>