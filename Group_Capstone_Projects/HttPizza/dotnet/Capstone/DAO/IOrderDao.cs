using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IOrderDao
    {
        IList<Order> GetAllOrders();
        IList<Order> GetCurrentOrderByCustomerId(int customerId);
        Order GetOrderByOrderId(int orderId);
        IList<Order> GetOrdersByCustomerId(int customerId);
        IList<Order> GetAllPendingOrders();
        Order CreateOrder(Order order);
        Order UpdateOrderStatus(int orderId, Order order);
        IList<OrderRecipeSize> GetORS(int orderId);
        void LinkOrderAndRecipeAndSize(int orderId, int recipeId, int sizeId);
    }
}
