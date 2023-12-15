import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

  export default{

    getAllCustomers(){
        return http.get(`/customer`);
    },
    getCustomerByCustomerId(id){
        return http.get(`/customer/${id}`);
    },
    getCustomerByUserId(id){
        return http.get(`/customer/user/${id}`);
    },
    updateCustomer(id, customer){
        return http.put(`/customer/${id}`, customer);
    },
    createCustomer(customer){
        return http.post(`/customer`, customer);
    }
  };