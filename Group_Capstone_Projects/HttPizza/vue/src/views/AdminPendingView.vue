<template>
    <div class="page-name" style="margin-left:15%">
        <div>
    <!-- <h2>Pending Orders</h2> -->
    <h2>{{ pendingMode? "Pending Orders" : "All Orders" }}</h2>
    <button v-show="!pendingMode" @click="getPendingOrders" class="newForm">View Only Pending Orders</button>
    <button v-show="pendingMode" @click="getAllOrders" class="newForm">View All Orders</button>
    <table>
      <thead>
        <tr>
          <th></th>
          <th>Order ID</th>
          <th>Customer ID</th>
          <th>Date and Time</th>
          <th>Price</th>
          <th>Delivery?</th>
          <th>Status</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(order) in pendingOrders" :key="order.orderId">
          <td>
            <input type="checkbox" v-model="selectedOrders" :value="order" :checked="order"/>
          </td>
          <td>{{ order.orderId }}</td>
          <td>{{ order.customerId }}</td>
          <td>{{ order.orderDateTime }}</td>
          <td>{{ order.totalPrice }}</td>
          <td>{{ order.isDelivery }}</td>
          <td>
            <select v-model="order.orderStatus" >
              <option value="Pending">Pending</option>
              <option value="Cancel">Cancel</option>
              <option value="Complete">Complete</option>
              <option value="Ready">Ready</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
    <button @click="submitOrders" class="newForm">Update Selected Orders</button>
    <p v-show="textVisible">Orders Updated!</p>
  </div>
    </div>
</template>


<script>
import OrderService from "../services/OrderService"
import { ref } from 'vue'

export default {
  data() {
    return {
      textVisible: ref(false),
      pendingMode: false,
      pendingOrders: [
        {
          orderId: 1,
          customerId: 'ABC123',
          orderDateTime: '2023-12-09 12:00 PM',
          orderStatus: 'Pending',
          isDelivery: 'Delivery',
          totalPrice: 25.99
        },
      ],
      selectedOrders: []
    };
  },
  methods: {
    hitButton(){
      this.textVisible = true;
      setTimeout(() => {
        this.textVisible = false, 2000
      });
    },
    getAllOrders(){
      OrderService.getAllOrders()
        .then(response =>{
          this.pendingOrders = response.data;
          this.pendingMode = false;
        })
    },
    getPendingOrders(){
      OrderService.getPendingOrders()
        .then(response =>{
          this.pendingOrders = response.data;
          this.pendingMode = true;
        })
    },
    submitOrders() {
      this.selectedOrders.forEach(order => {
        OrderService.updateOrder(order.orderId, order)
          .then(response => {
            console.log(response.data);
            this.hitButton();
            this.$router.go(0);
          })
      })
    }
  },
  created(){
    this.getAllOrders();
  }
};
</script>


<style>

</style>