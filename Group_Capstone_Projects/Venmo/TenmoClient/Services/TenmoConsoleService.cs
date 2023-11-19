using System;
using System.Collections.Generic;
using System.Net.Sockets;
using TenmoClient.Models;

namespace TenmoClient.Services
{
    public class TenmoConsoleService : ConsoleService
    {
        //public readonly TenmoApiService tenmoApiService;

        public TenmoConsoleService()
        {

        }

        //public TenmoConsoleService(string apiUrl)
        //{
        //    tenmoApiService = new TenmoApiService(apiUrl);
        //}

        /************************************************************
            Print methods
        ************************************************************/
        public void PrintLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome to TEnmo!");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Register");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }

        public void PrintMainMenu(string username)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Hello, {username}!");
            Console.WriteLine("1: View your current balance");
            Console.WriteLine("2: View your past transfers");
            Console.WriteLine("3: View your pending requests");
            Console.WriteLine("4: Send TE bucks");
            Console.WriteLine("5: Request TE bucks");
            Console.WriteLine("6: Log out");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }
        public LoginUser PromptForLogin()
        {
            string username = PromptForString("User name");
            if (String.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            string password = PromptForHiddenString("Password");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        // Add application-specific UI methods here...
        public Transfer PromptForTransfer(bool isRequest, int id, List<ApiUser> userList, Account account, TenmoApiService tenmo)
        {
            //TenmoApiService tenmoApiService = new TenmoApiService(Program);
            
            ListUsers(userList);
            if (isRequest)
            {
                int userIdFrom = PromptForInteger("ID of the user you are requesting from");
                if (userIdFrom == id)
                {
                    PrintError("Cannot transfer to the same account: Returning to Menu...");
                    Pause();
                    return null;
                }
                bool doesNotExist = true;
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userIdFrom == userList[i].UserId)
                    {
                        doesNotExist = false;
                    }
                }
                if (doesNotExist)
                {
                    PrintError("This user does not exist: Returning to Menu...");
                    Pause();
                    return null;
                }
                decimal amountToTransfer = PromptForDecimal("Enter amount to request");
                if (amountToTransfer <= 0)
                {
                    PrintError("Cannot transfer a value less than or equal to 0: Returning to Menu...");
                    Pause();
                    return null;
                }
                //tenmoApiService.ApiUrl
                Transfer transfer = new Transfer
                {
                    AccountFrom = tenmo.GetAccountByUserId(userIdFrom).AccountId,
                    Amount = amountToTransfer,
                    AccountTo = tenmo.GetAccountByUserId(id).AccountId,
                    TransferTypeId = 1,
                    TransferStatusId = 1
                };
                return transfer;

            }
            else
            {
                int userIdTo = PromptForInteger("ID of the user you are sending to");
                if (userIdTo == id)
                {
                    PrintError("Cannot transfer to the same account: Returning to Menu...");
                    Pause();
                    return null;
                }
                bool doesNotExist = true;
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userIdTo == userList[i].UserId)
                    {
                        doesNotExist = false;
                    }
                }
                if (doesNotExist)
                {
                    PrintError("This user does not exist: Returning to Menu...");
                    Pause();
                    return null;
                }
                decimal amountToTransfer = PromptForDecimal("Enter amount to send");
                if (amountToTransfer <= 0)
                {
                    PrintError("Cannot transfer a value less than or equal to 0: Returning to Menu...");
                    Pause();
                    return null;
                }
                
                if (amountToTransfer > account.Balance)
                {
                    PrintError("Cannot send a value more than you're current balance: Returning to Menu...");
                    Pause();
                    return null;
                }
                Transfer transfer = new Transfer
                {
                    AccountFrom = tenmo.GetAccountByUserId(id).AccountId,
                    Amount = amountToTransfer,
                    AccountTo = tenmo.GetAccountByUserId(userIdTo).AccountId,
                    TransferTypeId = 2,
                    TransferStatusId = 2
                };
                return transfer;
            }
        }

        public void PromptForViewTransfer(List<Transfer> transferList, TenmoApiService tenmoApiService, int id)
        {
            ListTransfers(transferList, tenmoApiService, id);
            int transferId = PromptForInteger("Enter transfer ID to view details (0 to cancel)");
            bool doesNotExist = true;
            for (int i = 0; i < transferList.Count; i++)
            {
                if (transferId == transferList[i].TransferId)
                {
                    doesNotExist = false;
                }
            }
            if (doesNotExist)
            {
                PrintError("This user does not exist: Returning to Menu...");
            }
            else
            {
                ViewTransferDetails(tenmoApiService.GetTransferByTransferId(transferId), tenmoApiService);
            }
        }
        public void PromptForViewPendingTransfer(List<Transfer> transferList, TenmoApiService tenmoApiService, int id)
        {
            if (transferList == null)
            {
                Console.WriteLine("You have no pending transfers: Returning to menu...");
            }
            else
                {
                ListPendingTransfers(transferList, tenmoApiService, id);
                int transferId = PromptForInteger("Enter transfer ID to approve/reject (0 to cancel)");
                bool doesNotExist = true;
                for (int i = 0; i < transferList.Count; i++)
                {
                    if (transferId == transferList[i].TransferId)
                    {
                        doesNotExist = false;
                    }
                }
                if (doesNotExist)
                {
                    PrintError("This user does not exist: Returning to Menu...");
                }
                else
                {
                    ViewApproveOrDeny(tenmoApiService.GetTransferByTransferId(transferId), tenmoApiService);
                }
            }
        }

        public void ViewTransferDetails(Transfer transfer, TenmoApiService tenmoApiService)
        {
            string transferTypeDesc = "Send";
            string transferStatusDesc = "Rejected";
            if (transfer.TransferTypeId == 1)
            {
                transferTypeDesc = "Request";
            }
            if (transfer.TransferStatusId == 1) 
            {
                transferStatusDesc = "Pending";
            }
            else if (transfer.TransferStatusId == 2)
            {
                transferStatusDesc = "Accepted";
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Transfer Details");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"ID: {transfer.TransferId}");
            Console.WriteLine($"From: {tenmoApiService.GetUserByAccountId(transfer.AccountFrom).Username}");
            Console.WriteLine($"To: {tenmoApiService.GetUserByAccountId(transfer.AccountTo).Username}");
            Console.WriteLine($"Type: {transferTypeDesc}");
            Console.WriteLine($"Status: {transferStatusDesc}");
            Console.WriteLine($"Amount: {transfer.Amount}");
        }
        public void ViewApproveOrDeny(Transfer transfer, TenmoApiService tenmoApiService)
        {
            Console.WriteLine("1: Approve");
            Console.WriteLine("2: Reject");
            Console.WriteLine("0: Back to menu");
            Console.WriteLine("--------");
            int choice = PromptForInteger("Please choose an option");
            if (choice != 1 && choice != 2 && choice != 0)
            {
                PrintError("This is not a valid choice: Returning to menu...");
            }
            
            if (choice == 0)
            {
                Console.WriteLine("Returning to menu...");
            }
            else if (choice == 1)
            {
                if (tenmoApiService.GetAccountBalance() < transfer.Amount)
                {
                    PrintError("Not enough money in balance to approve. Returning to menu...");
                }
                else
                {
                    Transfer updatedTransfer = new Transfer
                    {
                        TransferId = transfer.TransferId,
                        AccountFrom = transfer.AccountFrom,
                        Amount = transfer.Amount,
                        AccountTo = transfer.AccountTo,
                        TransferTypeId = transfer.TransferTypeId,
                        TransferStatusId = 2
                    };
                    tenmoApiService.UpdateTransferStatus(updatedTransfer);
                    PrintSuccess("Transfer Approved!");
                }
            }
            else if(choice == 2)
            {
                Transfer updatedTransfer = new Transfer
                {
                    TransferId = transfer.TransferId,
                    AccountFrom = transfer.AccountFrom,
                    Amount = transfer.Amount,
                    AccountTo = transfer.AccountTo,
                    TransferTypeId = transfer.TransferTypeId,
                    TransferStatusId = 3
                };
                tenmoApiService.UpdateTransferStatus(updatedTransfer);
                PrintError("Transfer Rejected!");

            }

        }

        private void ListUsers(List<ApiUser> userList)
        {
            Console.WriteLine("|-------- Users --------|");
            Console.WriteLine("|   Id | Username       |");
            Console.WriteLine("|------+----------------|");
            foreach (ApiUser element in userList)
            {
                Console.WriteLine($"   {element.UserId}  | {element.Username}     ");
            }
            Console.WriteLine("|-----------------------|");
        }

        private void ListTransfers(List<Transfer> transferList, TenmoApiService tenmoApiService, int id)
        {
            string otherUserName = "";
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Transfers");
            Console.WriteLine("ID       From/To            Amount ");
            Console.WriteLine("-----------------------------------");
            foreach(Transfer transfer in transferList)
            {
                string transferTypeDesc = "";
                if (transfer.AccountTo == tenmoApiService.GetAccountByUserId(id).AccountId) //&& (transfer.TransferTypeId == 2  || transfer.TransferTypeId == 1 && transfer.AccountTo == id)
                {
                    transferTypeDesc = "From: ";
                    otherUserName = tenmoApiService.GetUserByAccountId(transfer.AccountFrom).Username;
                }
                else
                {
                    transferTypeDesc = "To:   ";
                    otherUserName = tenmoApiService.GetUserByAccountId(transfer.AccountTo).Username;
                }
                Console.WriteLine($"{transfer.TransferId}     {transferTypeDesc}{otherUserName}       ${transfer.Amount}");
            }
            Console.WriteLine("--------");
        }
        private void ListPendingTransfers(List<Transfer> transferList, TenmoApiService tenmoApiService, int id)
        {
            string otherUserName = "";
            Console.WriteLine("------------------------------");
            Console.WriteLine("Pending Transfers");
            Console.WriteLine("ID       To            Amount ");
            Console.WriteLine("------------------------------");
            foreach(Transfer transfer in transferList)
            {
                
                otherUserName = tenmoApiService.GetUserByAccountId(transfer.AccountTo).Username;
                Console.WriteLine($"{transfer.TransferId}     {otherUserName}       ${transfer.Amount}");
            }
            Console.WriteLine("--------");
        }

        public string MakePrettyString(string str, bool shouldAddPipe, int totalLength = 37)
        {
            string result = str;
            for (int i = 0; i < totalLength - str.Length - 1; i++)
            {
                result += " ";
            }
            if (shouldAddPipe)
            {
                result += "|";
            }
            else
            {
                result += " ";
            }
            return result;
        }
    }
}
