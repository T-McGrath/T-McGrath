using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("transfer")]
    [ApiController]
    [Authorize]
    public class TransferController : ControllerBase
    {
        private ITransferDao transferDao;
        // Might need more instance variables.
        
        public TransferController(ITransferDao theTransferDao) // Might need more parameters.
        {
            transferDao = theTransferDao;
        }

        [HttpGet("{transferId}")] // Get transfer by TRANSFER ID
        public ActionResult<Transfer> GetTransferByTransferId(int transferId)
        {
            Transfer transfer = transferDao.GetTransferById(transferId);
            if (transfer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(transfer);
            }
        }

        [HttpGet("user/{id}")]
        public ActionResult<List<Transfer>> GetTransfersByUserId(int id, int statusId = 0)
        {
            List<Transfer> transferList;
            if (statusId == 0)
            {
                transferList = transferDao.GetTransfersByUserId(id);
            }
            else
            {
                transferList = transferDao.GetTransfersByStatusAndUserId(id, statusId);
            }
            
            if (transferList.Count == 0)
            {
                return NoContent(); // Does it make more sense for this to be NoContent()?
            }
            else
            {
                return Ok(transferList);
            }
        }
        
        [HttpPost()]
        public ActionResult<Transfer> CreateTransfer(Transfer transfer)
        {
            Transfer newTransfer = transferDao.CreateTransfer(transfer);
            return Created($"/transfers/{newTransfer.TransferId}", newTransfer);
        }

        [HttpPut()]
        public ActionResult<Transfer> UpdateTransfer(Transfer transfer)
        {
            Transfer updatedTransfer = transferDao.UpdateTransferById(transfer);
            if (updatedTransfer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(transfer);
            }
        }
    }
}
