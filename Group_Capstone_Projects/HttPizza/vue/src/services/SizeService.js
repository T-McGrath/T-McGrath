import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

  export default{

    getAllSizes(){
        return http.get(`/size`);
    },
    getSizeById(id){
        return http.get(`/size/${id}`);
    },
    updateSize(id, size){
        return http.put(`/size/${id}`, size);
    },
    createSize(size){
        return http.post(`/size`, size);
    }
  }