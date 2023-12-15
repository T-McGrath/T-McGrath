using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ORSController : ControllerBase
    {
        private readonly IOrderDao orderDao;

        public ORSController(IOrderDao orderDao)
        {
            this.orderDao = orderDao;
        }
       
        [HttpGet("orderInfo/{orderId}")]
        public ActionResult<IList<OrderRecipeSize>> GetAllOrderInfoByOrderId(int orderId)
        {
            IList<OrderRecipeSize> orderInfoList = orderDao.GetORS(orderId);
            if (orderInfoList.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(orderInfoList);
            }
        }

        [HttpPost()]
        public ActionResult<OrderRecipeSize> LinkRecipeOrderSize(OrderRecipeSize orderRecipeSize)
        {
            string success = "Check error code";
            orderDao.LinkOrderAndRecipeAndSize(orderRecipeSize.OrderId, orderRecipeSize.RecipeId, orderRecipeSize.SizeId);
            return Created($"/orders/hedgehog", orderRecipeSize);
        }

    }
}
