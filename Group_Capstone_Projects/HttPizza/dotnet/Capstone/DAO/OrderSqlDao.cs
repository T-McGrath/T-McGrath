using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Exceptions;

namespace Capstone.DAO
{
    public class OrderSqlDao : IOrderDao
    {
        private readonly string connectionString;
        public OrderSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public IList<Order> GetAllOrders()
        {
            IList<Order> orders = new List<Order>();
            string sql = "SELECT * FROM orders;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = MapRowToOrder(reader);
                        orders.Add(order);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return orders;
        }
        public IList<Order> GetCurrentOrderByCustomerId(int customerId)
        {
            IList<Order> orders = new List<Order>();
            string sql = "SELECT * FROM orders WHERE customer_id = @customer_id AND order_status = 'Pending';";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = MapRowToOrder(reader);
                        orders.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return orders;
        }
        public Order GetOrderByOrderId(int orderId)
        {
            Order order = null;
            string sql = "SELECT * FROM orders WHERE order_id = @order_id";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        order = MapRowToOrder(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return order;
        }
        public IList<Order> GetOrdersByCustomerId(int customerId)
        {
            IList<Order> orders = new List<Order>();
            string sql = "SELECT * FROM orders where customer_id = @customer_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = MapRowToOrder(reader);
                        orders.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return orders;
        }
        public IList<Order> GetAllPendingOrders()
        {
            IList<Order> orders = new List<Order>();
            string sql = "SELECT * FROM orders WHERE order_status = 'Pending';";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = MapRowToOrder(reader);
                        orders.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return orders;
        }
        public Order CreateOrder(Order order)
        {
            Order newOrder = null;
            string sql = "INSERT INTO orders (customer_id, order_date_time, order_status, is_delivery, total_price) " +
                            "OUTPUT INSERTED.order_id " +
                            "VALUES (@customer_id, @order_date_time, @order_status, @is_delivery, @total_price);";
            try
            {
                int newOrderId;
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", order.CustomerId);
                    cmd.Parameters.AddWithValue("@order_date_time", order.OrderDateTime);
                    cmd.Parameters.AddWithValue("@order_status", order.OrderStatus);
                    cmd.Parameters.AddWithValue("@is_delivery", order.IsDelivery);
                    cmd.Parameters.AddWithValue("@total_price", order.TotalPrice);
                    newOrderId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newOrder = GetOrderByOrderId(newOrderId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return newOrder;
        }
        public Order UpdateOrderStatus(int orderId, Order order)
        {
            Order updatedOrder = null;
            string sql = "UPDATE orders SET customer_id = @customer_id, order_date_time = @order_date_time, order_status = @order_status, is_delivery = @is_delivery, total_price = @total_price WHERE order_id = @order_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", order.CustomerId);
                    cmd.Parameters.AddWithValue("@order_date_time", order.OrderDateTime);
                    cmd.Parameters.AddWithValue("@order_status", order.OrderStatus);
                    cmd.Parameters.AddWithValue("@is_delivery", order.IsDelivery);
                    cmd.Parameters.AddWithValue("@total_price", order.TotalPrice);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    cmd.ExecuteNonQuery();
                }
                updatedOrder = GetOrderByOrderId(orderId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return updatedOrder;
        }
        public IList<OrderRecipeSize> GetORS(int orderId)
        {
            IList<OrderRecipeSize> orderRecipeSizes = new List<OrderRecipeSize>();
            string sql = "SELECT * FROM order_recipe WHERE order_id = @order_id;";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        OrderRecipeSize orderRecipeSize = new OrderRecipeSize();
                        orderRecipeSize.OrderId = Convert.ToInt32(reader["order_id"]);
                        orderRecipeSize.RecipeId = Convert.ToInt32(reader["recipe_id"]);
                        orderRecipeSize.SizeId = Convert.ToInt32(reader["size_id"]);
                        orderRecipeSizes.Add(orderRecipeSize);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            return orderRecipeSizes;
        }
        public void LinkOrderAndRecipeAndSize(int orderId, int recipeId, int sizeId)
        {
            //OrderRecipeSize orderRecipeSize = null;
            string sql = "INSERT INTO order_recipe (order_id, recipe_id, size_id) VALUES (@order_id, @recipe_id, @size_id);";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    cmd.Parameters.AddWithValue("recipe_id", recipeId);
                    cmd.Parameters.AddWithValue("@size_id", sizeId);
                    cmd.ExecuteNonQuery();
                }
                //orderRecipeSize = GetORS(order.OrderId, recipe.RecipeId, size.SizeId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL Exception occured!", ex);
            }
            //return orderRecipeSize;
        }
        public Order MapRowToOrder(SqlDataReader reader)
        {
            Order order = new Order();
            order.OrderId = Convert.ToInt32(reader["order_id"]);
            order.CustomerId = Convert.ToInt32(reader["customer_id"]);
            order.OrderDateTime = Convert.ToDateTime(reader["order_date_time"]);
            order.OrderStatus = Convert.ToString(reader["order_status"]);
            order.IsDelivery = Convert.ToBoolean(reader["is_delivery"]);
            order.TotalPrice = Convert.ToDecimal(reader["total_price"]);
            return order;
        }
    }
}
