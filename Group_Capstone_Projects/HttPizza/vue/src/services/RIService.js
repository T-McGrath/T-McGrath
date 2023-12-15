import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

  export default{
    
    getIngredientsByRecipeId(id){
        return http.get(`/RI/${id}`);
    },
    linkRecipeIngredient(recipeIngredient){
        return http.post(`/RI`, recipeIngredient);
    }
  }