using AlbumAlertClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumAlertClient
{
    public class AlbumAlertApp
    {
        private AlbumConsoleService albumConsole = new AlbumConsoleService();
        public void run()
        {

            Console.WriteLine("Welcome to Album Alert!");
            albumConsole.PrintMainMenu();

        }
    }
}
