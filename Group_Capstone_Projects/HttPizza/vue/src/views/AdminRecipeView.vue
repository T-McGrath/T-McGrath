<template>
    <div class="page-name" style="margin-left:15%">
    <div>
        <h1>Recipe Pizza</h1>
        <admin-specialties-comp v-bind:recipes="recipes"/>
        <!-- <Specialties v-bind:recipes="recipes"/> -->
    </div>
</div>
</template>


<script>
// import Specialties from '../components/SpecialtiesComp.vue'
import RecipeService from '../services/RecipeService'
import RIService from '../services/RIService';
import IngredientService from '../services/IngredientService'
import AdminSpecialtiesComp from '../components/AdminSpecialtiesComp.vue';

export default {
    components: {
        // Specialties
        AdminSpecialtiesComp
    },
    data(){
        return{
            recipes: []
        }
    },
    methods: {
        // getPizzas(){

        // },
        getRecipes(){
            RecipeService.getAllRecipes()
                .then(response =>
                this.recipes = response.data
        )},
        getIngredients(recipe){
            IngredientService.getIngredientsByRecipeId(recipe.recipeId)
                .then(response =>
                recipe.ings =  response.data)
        }
    },
    created(){
        RecipeService.getAllRecipes().then((response) => {
            this.recipes = response.data;
            this.recipes.forEach((recipe) =>{
                this.getIngredients(recipe)
        })


    })
    }
    
};
</script>


<style>

</style>