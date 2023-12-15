<template>
  
  <div class="main">
    <form action="https://localhost:44315/customer" method="POST" v-on:submit.prevent="createNewCustomer">
      <label for="customerName">Name: </label>
      <input id="customerName" v-model="newCustomer.customerName" name="customerName" type="text"/>
      <label for="address">Address: </label>
      <input id="address" v-model="newCustomer.address" name="address" type="text"/>
      <label for="phoneNum">Phone Number: </label>
      <input id="phoneNum" v-model="newCustomer.phoneNum" name="phoneNum" type="text"/>
      <label for="paymentInfo">Credit Card Number: </label>
      <input id="paymentInfo" v-model="newCustomer.paymentInfo" name="paymentInfo" type="text"/>
      <input class="newForm" name="submitButton" type="submit"/>
    </form>
  </div>
</template>

<script>
import customerService from "../services/CustomerService.js"

export default{
  data() {
    return{
      newCustomerId: 1,
      newCustomer: 
      {
        // customerId: null,
        userId: null,
        customerName: "",
        address: "",
        phoneNum: "",
        paymentInfo: ""
      }
    }
  },
  methods: {
    updateNewCustomerId() {
      return this.newCustomerId++;
    },
    createNewCustomer() {
      //this.newCustomer.customerId = this.updateNewCustomerId();
      this.newCustomer.userId = this.$store.state.user.userId;
      customerService.createCustomer(this.newCustomer);
      this.$router.push({name: "home"});
    }
  } 
};
</script>

<style scoped>

</style>