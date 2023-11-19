using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDao userDao;

        public UserController(IUserDao theUserDao)
        {
            userDao = theUserDao;
        }

        [HttpGet()]
        public IList<User> GetAllUsers()
        {
            return userDao.GetUsers();
        }
        [HttpGet("{id}")]
        public User GetUserByUserId(int id)
        {
            return userDao.GetUserById(id);
        }

        [HttpGet("account/{id}")]
        public ActionResult<User> GetUserByAccountId(int id)
        {
            User user = userDao.GetUserByAccountId(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
