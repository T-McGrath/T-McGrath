using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDao
    {
        Transfer CreateTransfer(Transfer transfer);

        List<Transfer> GetTransfersByUserId(int userId);

        Transfer GetTransferById(int transferId);

        List<Transfer> GetTransfersByStatusAndUserId(int userId, int statusId);

        Transfer UpdateTransferById(Transfer transfer);
    }
}
