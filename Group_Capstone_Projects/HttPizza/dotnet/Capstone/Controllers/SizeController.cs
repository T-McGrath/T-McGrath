using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeDao sizeDao;

        public SizeController(ISizeDao sizeDao)
        {
            this.sizeDao = sizeDao;
        }

        [HttpGet()]
        public IList<Size> GetAllSizes()
        {
            return sizeDao.GetAllSizes();
        }

        [HttpGet("{sizeId}")]
        public ActionResult<Size> GetSizeById(int sizeId)
        {
            Size size = sizeDao.GetSizeById(sizeId);
            if (size != null)
            {
                return size;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{sizeId}")]
        public ActionResult<Size> UpdateSizeAvailability(int sizeId, Size size)
        {
            Size updatedSize = sizeDao.UpdateSizeAvailability(sizeId, size);
            if (size == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(updatedSize);
            }
        }

        [HttpPost()]
        public ActionResult<Size> CreateSize(Size size)
        {
            Size newSize = sizeDao.CreateSize(size);
            return Created($"/sizes/{newSize.SizeId}", newSize);
        }
    }
}
