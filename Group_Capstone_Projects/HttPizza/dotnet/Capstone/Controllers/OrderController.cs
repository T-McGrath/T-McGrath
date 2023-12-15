using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDao orderDao;

        public OrderController(IOrderDao orderDao)
        {
            this.orderDao = orderDao;
        }
       
        [HttpGet()]
        public IList<Order> GetAllOrders()
        {
            return orderDao.GetAllOrders();
        }

        [HttpGet("customerOrder/{customerId}")]
        public ActionResult<IList<Order>> GetCurrentOrderByCustomerId(int customerId)
        {
            IList<Order> orders = orderDao.GetCurrentOrderByCustomerId(customerId);

            if (orders.Count != 0)
            {
                return Ok(orders);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrderByOrderId(int orderId)
        {
            Order order = orderDao.GetOrderByOrderId(orderId);

            if (order != null)
            {
                return order;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<IList<Order>> GetOrdersByCustomerId(int customerId)
        {
            IList<Order> orders = orderDao.GetOrdersByCustomerId(customerId);

            if (orders.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(orders);
            }
        }

        [HttpGet("pending")]
        public ActionResult<List<Order>> GetAllPendingOrders()
        {
            IList<Order> orders = orderDao.GetAllPendingOrders();

            if (orders.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(orders);
            }
        }

        //[HttpGet("orderInfo/{orderId}")]
        //public ActionResult<IList<OrderRecipeSize>> GetAllOrderInfoByOrderId(int orderId)
        //{
        //    IList<OrderRecipeSize> orderInfoList = orderDao.GetORS(orderId);
        //    if(orderInfoList.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return Ok(orderInfoList);
        //    }
        //}

        [HttpPost()]
        public ActionResult<Order> CreateOrder(Order order)
        {
            Order newOrder = orderDao.CreateOrder(order);
            return Created($"/orders/{newOrder.OrderId}", newOrder);
        }

        //[HttpPost()]
        //public ActionResult<OrderRecipeSize> LinkRecipeOrderSize(int orderId, int recipeId, int sizeId)
        //{
        //    string success = "Check error code";
        //    orderDao.LinkOrderAndRecipeAndSize(orderId, recipeId, sizeId);
        //    return Created($"/orders/hedgehog", success);
        //}
        [HttpPut("{orderId}")]
        public ActionResult<Order> UpdateOrderStatus(int orderId, Order order)
        {
            Order updatedOrder = orderDao.UpdateOrderStatus(orderId, order);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(updatedOrder);
            }
        }
    }
}
