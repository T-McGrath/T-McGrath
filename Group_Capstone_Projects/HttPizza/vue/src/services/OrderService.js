import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

  export default{

    getAllOrders(){
        return http.get(`/order`);
    },
    getCurrentOrderByCustId(id){
        return http.get(`/order/customerOrder/${id}`);
    },
    getOrderByOrderId(id){
        return http.get(`/order/${id}`);
    },
    getOrdersByCustId(id){
        return http.get(`/order/customer/${id}`);
    },
    getPendingOrders(){
        return http.get(`/order/pending`);
    },
    createOrder(order){
        return http.post(`/order`, order);
    },
    updateOrder(id, order){
        return http.put(`/order/${id}`, order);
    }
  }