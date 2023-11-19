using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using TenmoClient.Models;

namespace TenmoClient.Services
{
    public class TenmoApiService : AuthenticatedApiService
    {
        public readonly string ApiUrl;
        

        public TenmoApiService(string apiUrl) : base(apiUrl) { }

        // Add methods to call api here...

        public List<ApiUser> GetUsers()
        {
            RestRequest request = new RestRequest("user");
            IRestResponse<List<ApiUser>> response = client.Get<List<ApiUser>>(request);
            CheckForError(response);
            return response.Data;
        }
        public ApiUser GetUserById(int id) 
        {
            RestRequest request = new RestRequest($"user/{id}");
            IRestResponse<ApiUser> response = client.Get<ApiUser>(request);
            CheckForError(response);
            return response.Data;
        }
        public ApiUser GetUserByAccountId(int id)
        {
            RestRequest request = new RestRequest($"user/account/{id}");
            IRestResponse<ApiUser> response = client.Get<ApiUser>(request);
            CheckForError(response);
            return response.Data;
        }
        public List<Transfer> GetTransfersByUserId(int userId)
        {
            RestRequest request = new RestRequest($"transfer/user/{userId}");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);
            CheckForError(response);
            return response.Data;
        }
        public List<Transfer> GetTransfersByUserIdAndPending(int userId)
        {
            RestRequest request = new RestRequest($"transfer/user/{userId}?statusId=1");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);
            if (response.Data == null)
            {
                return null;
            }
            CheckForError(response);
            return response.Data;
        }
        public Transfer GetTransferByTransferId(int transferId)
        {
            RestRequest request = new RestRequest($"transfer/{transferId}");
            IRestResponse<Transfer> response = client.Get<Transfer>(request);
            CheckForError(response);
            return response.Data;
        }
        public List<Transfer> GetListOfTransfers()
        {
            List<Transfer> transfers = GetTransfersByUserId(UserId);
            return transfers;
        }
        public List<Transfer> GetListOfPendingTransfers()
        {
            List<Transfer> transfers = GetTransfersByUserIdAndPending(UserId);
            return transfers;
        }
        public Account GetAccountByUserId(int userId)
        {
            RestRequest request = new RestRequest($"account/user/{userId}");
            IRestResponse<Account> response = client.Get<Account>(request);
            CheckForError(response);
            return response.Data;
        }
        public decimal GetAccountBalance() 
        { 
            Account account = GetAccountByUserId(UserId);
            return account.Balance;
        }
        public Transfer CreateTransfer(Transfer transfer)
        {
            RestRequest request = new RestRequest("transfer");
            request.AddJsonBody(transfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);

            CheckForError(response);
            return response.Data;
        }
        public Transfer UpdateTransferStatus(Transfer transfer)
        {
            RestRequest request = new RestRequest("transfer");
            request.AddJsonBody(transfer);
            IRestResponse<Transfer> response = client.Put<Transfer>(request);
            CheckForError(response);
            return response.Data;
        }

    }
}
