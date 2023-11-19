using System;
using System.Collections.Generic;
using TenmoClient.Models;
using TenmoClient.Services;

namespace TenmoClient
{
    public class TenmoApp
    {

        //private static string urlAgain;
        private readonly TenmoConsoleService console = new TenmoConsoleService();
        private readonly TenmoApiService tenmoApiService;
        //public static ApiUser outsideUser = new ApiUser();

        public TenmoApp(string apiUrl)
        {
            tenmoApiService = new TenmoApiService(apiUrl);
            //urlAgain = apiUrl;
        }

        public void Run()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                // The menu changes depending on whether the user is logged in or not
                if (tenmoApiService.IsLoggedIn)
                {
                    keepGoing = RunAuthenticated();
                }
                else // User is not yet logged in
                {
                    keepGoing = RunUnauthenticated();
                }
            }
        }

        private bool RunUnauthenticated()
        {
            console.PrintLoginMenu();
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 2, 1);
            while (true)
            {
                if (menuSelection == 0)
                {
                    return false;   // Exit the main menu loop
                }

                if (menuSelection == 1)
                {
                    // Log in
                    Login();
                    return true;    // Keep the main menu loop going
                }

                if (menuSelection == 2)
                {
                    // Register a new user
                    Register();
                    return true;    // Keep the main menu loop going
                }
                console.PrintError("Invalid selection. Please choose an option.");
                console.Pause();
            }
        }

        private bool RunAuthenticated()
        {
            console.PrintMainMenu(tenmoApiService.Username);
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 6);
            if (menuSelection == 0)
            {
                // Exit the loop
                return false;
            }

            if (menuSelection == 1)
            {
                // View your current balance
                ViewBalance();
            }

            if (menuSelection == 2)
            {
                // View your past transfers
                ViewAllTransfers();
            }

            if (menuSelection == 3)
            {
                // View your pending requests
                ViewPendingTransfers();
            }

            if (menuSelection == 4)
            {
                // Send TE bucks
                CreateTransfer(false, tenmoApiService.GetUsers());
            }

            if (menuSelection == 5)
            {
                // Request TE bucks
                CreateTransfer(true, tenmoApiService.GetUsers());

            }

            if (menuSelection == 6)
            {
                // Log out
                tenmoApiService.Logout();
                console.PrintSuccess("You are now logged out");
            }

            return true;    // Keep the main menu loop going
        }

        private void Login()
        {
            LoginUser loginUser = console.PromptForLogin();
            if (loginUser == null)
            {
                return;
            }

            try
            {
                ApiUser user = tenmoApiService.Login(loginUser);
                if (user == null)
                {
                    console.PrintError("Login failed.");
                }
                else
                {
                    //outsideUser = user;
                    console.PrintSuccess("You are now logged in");
                }
            }
            catch (Exception)
            {
                console.PrintError("Login failed.");
            }
            console.Pause();
        }

        private void Register()
        {
            LoginUser registerUser = console.PromptForLogin();
            if (registerUser == null)
            {
                return;
            }
            try
            {
                bool isRegistered = tenmoApiService.Register(registerUser);
                if (isRegistered)
                {
                    console.PrintSuccess("Registration was successful. Please log in.");
                }
                else
                {
                    console.PrintError("Registration was unsuccessful.");
                }
            }
            catch (Exception)
            {
                console.PrintError("Registration was unsuccessful.");
            }
            console.Pause();
        }
        private void ViewBalance()
        {
            decimal balance = tenmoApiService.GetAccountBalance();
            console.PrintSuccess($"Your current account balance is: ${balance}");
            console.Pause();
        }
        private void CreateTransfer(bool isRequest, List<ApiUser> userList)
        {
            Transfer transferToAdd = console.PromptForTransfer(isRequest, tenmoApiService.UserId, userList, tenmoApiService.GetAccountByUserId(tenmoApiService.UserId), tenmoApiService);
            if (transferToAdd == null)
            {
                return;
            }

            try
            {
                
                //(Possibly need second transfer model as a confirmation from the API) Transfer user = tenmoApiService.CreateTransferRequest(transfer);
                Transfer addedTransfer = tenmoApiService.CreateTransfer(transferToAdd);
                if (addedTransfer == null)
                {
                    console.PrintError("Transfer Failed");
                }
                else
                {
                    console.PrintSuccess("Transfer was successful");
                }
            }
            catch (Exception)
            {
                console.PrintError("Unexpected Error Occured");
            }
            console.Pause();
        }
        private void ViewAllTransfers()
        {
            List<Transfer> transfers = tenmoApiService.GetListOfTransfers();
            console.PromptForViewTransfer(transfers, tenmoApiService, tenmoApiService.UserId);
            console.Pause();
        }
        private void ViewPendingTransfers()
        {
            List<Transfer> transfers = tenmoApiService.GetListOfPendingTransfers();
            console.PromptForViewPendingTransfer(transfers, tenmoApiService, tenmoApiService.UserId);
            console.Pause();
                
        }
    }
    
}
