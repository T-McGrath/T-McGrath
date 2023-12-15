import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

  export default{

    getAllOrderInfoById(id){
        return http.get(`/ORS/orderInfo/${id}`);
    },
    linkRecipeOrderSize(orderRecipeSize){
        return http.post(`/ORS`, orderRecipeSize);
    }
  }