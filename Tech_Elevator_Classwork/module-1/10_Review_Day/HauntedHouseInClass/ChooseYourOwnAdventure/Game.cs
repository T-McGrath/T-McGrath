using ChooseYourOwnAdventure.Menu;
using ChooseYourOwnAdventure.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure
{
    public class Game
    {
        private static string INTRO = "You are in the lobby of a haunted mansion!";
        private static readonly string OPTION_RED = "Go to red room";
        private static readonly string OPTION_BLUE = "Go to blue room";
        private static readonly string OPTION_GREEN = "Go to green room";
        private static readonly string OPTION_EXIT = "Exit";

        private GreenRoom greenRoom = new GreenRoom();

        public void BeginGame()
        {
            Player player = new Player();
            Console.WriteLine(INTRO);
            while (true)
            {
                
                string selectedOption = MenuDisplay.Prompt(new string[] {OPTION_BLUE, OPTION_GREEN, OPTION_RED, OPTION_EXIT});
                if (selectedOption == OPTION_EXIT)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (selectedOption == (OPTION_GREEN)) {
                    greenRoom.OnEnterRoom(player);
                }
                
            }
        }
    }
}
