import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

  export default{

    getAllRecipes(){
        return http.get(`/recipe`);
    },
    getRecipeById(id){
        return http.get(`/recipe/${id}`);
    },
    updateRecipe(id, recipe){
        return http.put(`/recipe/${id}`, recipe);
    },
    createRecipe(recipe){
        return http.post(`/recipe`, recipe);
    }
  }