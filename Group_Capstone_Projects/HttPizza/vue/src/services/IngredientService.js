import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

  export default{

    getAllIngredients(){
        return http.get(`/ingredient`);
    },
    getIngredientById(id){
        return http.get(`/ingredient/${id}`);
    },
    getIngredientsByRecipeId(id){
        return http.get(`/ingredient/recipe/${id}`);
    },
    updateIngredient(id, ingredient){
        return http.put(`/ingredient/${id}`, ingredient);
    },
    createIngredient(ingredient){
        return http.post(`/ingredient`, ingredient);
    }
  }