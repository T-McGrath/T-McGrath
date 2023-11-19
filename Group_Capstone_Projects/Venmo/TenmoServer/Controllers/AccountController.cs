using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("account")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private IAccountDao accountDao;

        public AccountController(IAccountDao theAccountDao)
        {
            accountDao = theAccountDao;
        }

        [HttpGet("user/{id}")]
        public ActionResult<Account> GetAccountByUserId(int id)
        {
            Account account = accountDao.GetAccountByUserId(id);

            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
