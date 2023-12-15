using ChooseYourOwnAdventure.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure.Rooms
{
    public class GreenRoom
    {
        private static readonly String INTRO = "Welcome to the green room! There is a box sitting on a table. Do you open it?";

        private static readonly string OPTION_1 = "Yes, open the box";
        private static readonly string OPTION_2 = "Leave room";
        private static readonly string[] OPTIONS = {OPTION_1, OPTION_2
    };

        public void OnEnterRoom(Player player)
        {

            while (true)
            {

                Console.WriteLine(INTRO);

                String selectedOption = MenuDisplay.Prompt(OPTIONS);
                if (selectedOption.Equals(OPTION_1))
                {
                    OnOpenBox(player);
                }
                else if (selectedOption.Equals(OPTION_2))
                {
                    Console.WriteLine("You exit the room");
                    break;
                }
            }
        }
        private void OnOpenBox(Player player)
        {
            Console.WriteLine("Congratulations! You found a red key!");
            player.AddItem(GameConstants.RED_KEY);
        }
    }
}

