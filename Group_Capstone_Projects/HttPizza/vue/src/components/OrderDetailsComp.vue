<template>
    <div>
      <h2>Pending Orders</h2>
      <ul>
        <li v-for="order in filteredOrders" :key="order.id">
          {{ order.type === 'pickup' ? 'Pickup' : 'Delivery' }} Order #{{ order.id }} - Pizza: {{ order.pizza }}
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default{
      data() {
          return {
              orders: []
          }
      },
      computed: {
          filteredOrders() {
              return this.orders.filter(order => order.status === 'pending');
          },
      },
  };
  </script>

<style scoped>

</style>