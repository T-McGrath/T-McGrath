using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumAlertClient.Services
{
    public class AlbumConsoleService
    {

        public void PrintMainMenu()
        {
          
            Console.WriteLine("Please choose the number of your desired menu option.");
            Console.WriteLine("[1] Login (you already have account");
            Console.WriteLine("[2] Register (you do NOT have an account yet");
        }


    }
}
